namespace OpenRec_2.API;

using Microsoft.AspNetCore.Http;

public class DefaultApi : IApi
{
    public string Response(HttpContext context)
    {
        return "Hello! This is a OpenRec-2!";
    }

    public string GetUrl()
    {
        return "/";
    }

    public string GetMethod()
    {
        return HttpMethods.Get;
    }
}