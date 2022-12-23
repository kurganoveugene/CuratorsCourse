using System.Collections.Generic;
using SmartVkApi.Configurations;

namespace SmartVkApi.Utils
{
    public class RequestUtils
    {
        public string CreateRequest(string method, Dictionary<string, string> paramsDict) 
            => GetApiUrl(method, paramsDict, Configuration.Token, Configuration.ApiVersion);

        private string GetApiUrl(string methodName, Dictionary<string, string> paramsDict, string token, string version) 
            => Configuration.ApiUrl + GetMethodPath(methodName) + GetParamsPath(paramsDict) + GetTokenPath(token) + GetVersionPath(version); 

        private string GetMethodPath(string methodName) => "method/" + methodName + "?";

        private string GetParamPath(string paramName, string paramValue) => paramName + "=" + paramValue + "&";

        private string GetTokenPath(string token) => "access_token=" + token + "&";

        private string GetVersionPath(string version) => "v=" + version;

        private string GetParamsPath(Dictionary<string, string> paramsDict)
        {
            var paramsPath = string.Empty;
            foreach (KeyValuePair<string, string> paramName in paramsDict)
            {
                paramsPath += GetParamPath(paramName.Key, paramName.Value);
            }
            return paramsPath;
        }
    }
}
