using System.Collections.Generic;
using System.Linq;
using ExaltedHelper.Common.Dto;
using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Managers.Time.Interface;
using Kendo.Mvc.Extensions;

namespace ExaltedHelper.Managers.Time
{
    public class DurationManager : IDurationManager
    {
        private readonly IRepository<Duration, int> _durationRepository;

        public DurationManager(IRepository<Duration, int> durationRepository)
        {
            _durationRepository = durationRepository;
        }
        public IList<DropdownDto> GetDurations()
        {
            return _durationRepository.GetAll().Select(x => new DropdownDto() {Id = x.Id, Name = x.Name}).ToList();
        }
    }
}