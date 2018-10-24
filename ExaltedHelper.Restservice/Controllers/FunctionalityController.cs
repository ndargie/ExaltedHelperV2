using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using ExaltedHelper.Common.Dto;
using ExaltedHelper.Managers.User.Interface;
using ExaltedHelper.Repositories.Contracts;
using ExaltedHelper.Restservice.TransactionalWebController;
using Kendo.Mvc.UI;

namespace ExaltedHelper.Restservice.Controllers
{
    [Authorize]
    public class FunctionalityController : TransactionalWebApiController
    {
        private readonly IFunctionalityManager _functionalityManager;

        public FunctionalityController(IUnitOfWork unitOfWork, IFunctionalityManager functionalityManager) : base(unitOfWork)
        {
            _functionalityManager = functionalityManager;
        }

        [HttpGet]
        public IEnumerable<DropdownDto> GetFunctionalitiesForDropDown()
        {
            return _functionalityManager.GetFunctionalitiesForDropDown();
        }

        [HttpPut]
        public HttpStatusCode SaveFunctionality(string name, string description)
        {
            return _functionalityManager.SaveFunctionality(name, description);
        }

        [HttpPut]
        public HttpStatusCode DeleteFunctionality(int id)
        {
            return _functionalityManager.DeleteFunctionality(id);
        }

        [HttpPut]
        public HttpStatusCode DisableFunctionality(int id)
        {
            return _functionalityManager.DisableFunctionality(id);
        }



    }
}
