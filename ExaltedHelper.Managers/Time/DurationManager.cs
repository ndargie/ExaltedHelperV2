using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ExaltedHelper.Common.Constants;
using ExaltedHelper.Common.Dto;
using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Managers.Time.Interface;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using NLog;

namespace ExaltedHelper.Managers.Time
{
    public class DurationManager : IDurationManager
    {
        private readonly IRepository<Duration, int> _durationRepository;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public DurationManager(IRepository<Duration, int> durationRepository)
        {
            _durationRepository = durationRepository;
        }
        public IList<DropdownDto> GetDurationsForDropdown()
        {
            List<DropdownDto> dropDowns = new List<DropdownDto>();
            try
            {
                _log.Trace($"");
                dropDowns = _durationRepository.GetAll().Where(x => x.Status != StatusOptions.Deleted)
                    .Select(x => new DropdownDto() { Id = x.Id, Name = x.Name }).ToList();
            }
            catch (Exception e)
            {
                _log.Error(e);
            }

            return dropDowns;
        }

        public HttpStatusCode SaveDuration(string name, string description)
        {
            HttpStatusCode code;
            try
            {
                var duration = _durationRepository.GetAll().SingleOrDefault(x => x.Name == name) ?? new Duration() { DateCreated = DateTime.Now, Name = name};
                duration.Description = description;
                duration.DateModified = DateTime.Now;
                duration.SetEnabled();
                _durationRepository.Save(duration);
                code = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                code = HttpStatusCode.InternalServerError;
                _log.Error(ex);
            }

            return code;
        }

        public HttpStatusCode DeleteDuration(int id)
        {
            HttpStatusCode code;
            try
            {
                var duration = _durationRepository.GetAll().SingleOrDefault(x => x.Id == id);
                if (duration != null)
                {
                    duration.SetDeleted();
                    duration.DateModified = DateTime.Now;
                    _durationRepository.Save(duration);
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

        public HttpStatusCode DisableDuration(int id)
        {
            HttpStatusCode code;
            try
            {
                var duration = _durationRepository.GetAll().SingleOrDefault(x => x.Id == id);
                if (duration != null)
                {
                    duration.SetDisabled();
                    duration.DateModified = DateTime.Now;
                    _durationRepository.Save(duration);
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

        public DataSourceResult GetDurations(DataSourceRequest request)
        {
            DataSourceResult result = new List<DurationDto>().AsQueryable().ToDataSourceResult(request);
            try
            {
                result = _durationRepository.GetAll()
                    .Select(x => new DurationDto() {Description = x.Description, Id = x.Id, Name = x.Name})
                    .ToDataSourceResult(request);
            }
            catch (Exception e)
            {
               _log.Error(e);
            }

            return result;
        }

        public DurationDto GetDuration(int id)
        {
            DurationDto durationDto = new DurationDto();
            try
            {
                var duration = _durationRepository.GetAll().SingleOrDefault(x => x.Id == id);
                if (duration != null)
                {
                    durationDto = new DurationDto()
                    {
                        Name = duration.Name,
                        Id = duration.Id,
                        Description = duration.Description
                    };
                }
            }
            catch (Exception e)
            {
               _log.Error(e);
            }

            return durationDto;
        }
    }
}