using System.Net.Http;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace ExaltedHelper.Common.Helpers
{
    public static class DataSourceRequestHelper
    {
        public static DataSourceRequest ConvertToDataSourceRequest(this HttpRequestMessage requestMessage)
        {
            return JsonConvert.DeserializeObject<DataSourceRequest>(
                requestMessage.RequestUri.ParseQueryString().GetValues(0)?[0], new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                });
        }
    }
}