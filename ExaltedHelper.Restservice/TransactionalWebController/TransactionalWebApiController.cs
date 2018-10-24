using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using ExaltedHelper.Common.Logging;
using ExaltedHelper.Repositories.Contracts;
using NLog;

namespace ExaltedHelper.Restservice.TransactionalWebController
{
    public class TransactionalWebApiController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Logger _log = CommonLogger.Log;

        public TransactionalWebApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<HttpResponseMessage> ExecuteAsync(
            HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {

            var profiler = new Stopwatch();

            profiler.Start();

            _log.Trace("WebApi-Request for Uri: {0}", controllerContext.Request.RequestUri);

            var executeResult = base.ExecuteAsync(controllerContext, cancellationToken).ContinueWith(
                t =>
                {
                    if (t.Result.IsSuccessStatusCode)
                    {
                        try
                        {
                            _unitOfWork.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            t.Result.StatusCode = HttpStatusCode.InternalServerError;
                            _log.Error(e);
                        }
                        
                    }
                    else
                    {
                        if (t.Result.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            _log.Warn("Unsuccessful WebApi-Response Code: {0}", t.Result.StatusCode);

                        }
                        else
                        {
                            _log.Error("Unsuccessful WebApi-Response Code: {0}", t.Result.StatusCode);
                        }

                        try
                        {
                            _unitOfWork.Rollback();
                        }
                        catch
                        {
                            // ignore rollback-errors to be able to return the errors causing the rollback
                        }
                    }

                    return t.Result;
                },
                cancellationToken);

            _log.Info("Controller:{0},ActionName:{1},Elapsed Time: {2}", controllerContext.ControllerDescriptor.ControllerName, controllerContext.Request.GetActionDescriptor().ActionName, profiler.Elapsed);

            return executeResult;
        }
    }
}