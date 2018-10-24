using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ExaltedHelper.Common.Constants;
using ExaltedHelper.Common.Dto;
using ExaltedHelper.Common.Logging;
using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Enterties;
using ExaltedHelper.Managers.User.Interface;
using NLog;

namespace ExaltedHelper.Managers.User
{
    public class FunctionalityManager : IFunctionalityManager
    {
        private readonly IRepository<Functionality, int> _functionalityRepository;
        private readonly Logger _log = CommonLogger.Log;

        public FunctionalityManager(IRepository<Functionality, int> functionalityRepository)
        {
            _functionalityRepository = functionalityRepository;
        }
        public IEnumerable<DropdownDto> GetFunctionalitiesForDropDown()
        {
            List<DropdownDto> dropDowns = new List<DropdownDto>();
            try
            {
                dropDowns = _functionalityRepository.GetAll().Where(x => x.Status != StatusOptions.Deleted)
                    .Select(x => new DropdownDto() { Id = x.Id, Name = x.Name }).ToList();
            }
            catch (Exception e)
            {
                _log.Error(e);
            }

            return dropDowns;
        }

        public HttpStatusCode SaveFunctionality(string name, string description)
        {
            HttpStatusCode code;
            try
            {
                var duration = _functionalityRepository.GetAll().SingleOrDefault(x => x.Name == name) ?? new Functionality() { DateCreated = DateTime.Now, Name = name };
                duration.Description = description;
                duration.DateModified = DateTime.Now;
                duration.SetEnabled();
                _functionalityRepository.Save(duration);
                code = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                code = HttpStatusCode.InternalServerError;
            }

            return code;

        }

        public HttpStatusCode DeleteFunctionality(int id)
        {
            HttpStatusCode code;
            try
            {
                var duration = _functionalityRepository.GetAll().SingleOrDefault(x => x.Id == id);
                if (duration != null)
                {
                    duration.SetDeleted();
                    duration.DateModified = DateTime.Now;
                    _functionalityRepository.Save(duration);
                    code = HttpStatusCode.OK;
                }
                else
                {
                    code = HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                code = HttpStatusCode.InternalServerError;
            }

            return code;
        }

        public HttpStatusCode DisableFunctionality(int id)
        {
            HttpStatusCode code;
            try
            {
                var duration = _functionalityRepository.GetAll().SingleOrDefault(x => x.Id == id);
                if (duration != null)
                {
                    duration.SetDisabled();
                    duration.DateModified = DateTime.Now;
                    _functionalityRepository.Save(duration);
                    code = HttpStatusCode.OK;
                }
                else
                {
                    code = HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                code = HttpStatusCode.InternalServerError;
            }

            return code;
        }
    }
}