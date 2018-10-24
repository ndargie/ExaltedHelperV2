using System.Collections.Generic;
using System.Net;
using ExaltedHelper.Common.Constants;
using ExaltedHelper.Common.Dto;
using Kendo.Mvc.UI;

namespace ExaltedHelper.Managers.Time.Interface
{
    public interface IDurationManager
    {
        IList<DropdownDto> GetDurationsForDropdown();
        HttpStatusCode SaveDuration(string name, string description);
        HttpStatusCode DeleteDuration(int id);
        HttpStatusCode DisableDuration(int id);
        DataSourceResult GetDurations(DataSourceRequest request);
        DurationDto GetDuration(int id);
    }
}