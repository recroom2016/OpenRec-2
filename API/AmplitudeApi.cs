namespace OpenRec_2.API;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public class AmplitudeApi : IApi
{
    public string Response(HttpContext context)
    {
        var response = new AmplitudeResponse
        {
            AmplitudeKey = "NoKeyProvided"
        };
        
        return JsonConvert.SerializeObject(response);
    }

    public string GetUrl()
    {
        return "/api/config/v1/amplitude";
    }

    public string GetMethod()
    {
        return HttpMethods.Get;
    }

    private class AmplitudeResponse
    {
        public string AmplitudeKey { get; set; }
    }
}