using System.Collections.Generic;
using ExaltedHelper.Common.Dto;
using Kendo.Mvc.UI;

namespace ExaltedHelper.Managers.Time.Interface
{
    public interface IDurationManager
    {
        IList<DropdownDto> GetDurations();
    }
}