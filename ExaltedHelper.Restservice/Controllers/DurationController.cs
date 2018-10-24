using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExaltedHelper.Common.Dto;
using ExaltedHelper.Common.Helpers;
using ExaltedHelper.Common.Logging;
using ExaltedHelper.Managers.Time.Interface;
using ExaltedHelper.Repositories.Contracts;
using ExaltedHelper.Restservice.TransactionalWebController;
using Kendo.Mvc.UI;
using NLog;

namespace ExaltedHelper.Restservice.Controllers
{
    [Authorize]
    public class DurationController : TransactionalWebApiController
    {
        private readonly IDurationManager _durationManager;
        private readonly Logger _log = CommonLogger.Log;

        public DurationController(IDurationManager durationManager, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _durationManager = durationManager;
        }

        [HttpGet]
        public IEnumerable<DropdownDto> GetDurationsForDropDown()
        {
            return _durationManager.GetDurationsForDropdown();
        }

        [HttpPut]
        public HttpStatusCode SaveDuration(string name, string description)
        {
            return _durationManager.SaveDuration(name, description);
        }

        [HttpDelete]
        public HttpStatusCode DeleteDuration(int id)
        {
            return _durationManager.DeleteDuration(id);
        }

        [HttpPut]
        public HttpStatusCode DisableDuration(int id)
        {
            return _durationManager.DisableDuration(id);
        }

        [HttpGet]
        public DataSourceResult GetDurations(HttpRequestMessage requestMessage)
        {
            var request = requestMessage.ConvertToDataSourceRequest();
            return _durationManager.GetDurations(request);
        }

        [HttpGet]
        public DurationDto GetDuration(int id)
        {
            return _durationManager.GetDuration(id);
        }
    }
}
