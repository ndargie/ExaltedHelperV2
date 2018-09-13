using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExaltedHelper.Common.Dto;
using ExaltedHelper.Managers.Time.Interface;

namespace ExaltedHelper.Restservice.Controllers
{
    public class DurationController : ApiController
    {

        private readonly IDurationManager _durationManager;

        public DurationController(IDurationManager durationManager)
        {
            _durationManager = durationManager;
        }

        [HttpGet]
        public IEnumerable<DropdownDto> GetDurationsForDropDown()
        {
            return _durationManager.GetDurations();
        }
    }
}
