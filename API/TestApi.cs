namespace OpenRec_2.API;

using Microsoft.AspNetCore.Http;

public class TestApi : IApi
{
    public string Response(HttpContext context)
    {
        string name = context.Request.Query["name"];

        if (string.IsNullOrEmpty(name))
        {
            return "Please provide a 'name' parameter in the URL query.";
        }

        return $"Hello there, {name}!";
    }

    public string GetUrl()
    {
        return "/test";
    }
    
    public string GetMethod()
    {
        return HttpMethods.Get;
    }
}