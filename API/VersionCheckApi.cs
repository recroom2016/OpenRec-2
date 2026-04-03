namespace OpenRec_2.API;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public class VersionCheckApi : IApi
{
    public string Response(HttpContext context)
    {
        string version = context.Request.Headers["X-Rec-Room-Version"].ToString();
        string supportedVersion = "20170626_EA";

        var response = new VersionCheckResponse
        {
            ValidVersion = (version == supportedVersion)
        };

        return JsonConvert.SerializeObject(response);
    }

    public string GetUrl()
    {
        return "/api/versioncheck/v1";
    }

    public string GetMethod()
    {
        return HttpMethods.Get;
    }

    public class VersionCheckResponse
    {
        public bool ValidVersion { get; set; }
    }
}