using System.Collections.Generic;
using System.Net;
using ExaltedHelper.Common.Dto;

namespace ExaltedHelper.Managers.User.Interface
{
    public interface IFunctionalityManager
    {
        IEnumerable<DropdownDto> GetFunctionalitiesForDropDown();
        HttpStatusCode SaveFunctionality(string name, string description);
        HttpStatusCode DeleteFunctionality(int id);
        HttpStatusCode DisableFunctionality(int id);

    }
}