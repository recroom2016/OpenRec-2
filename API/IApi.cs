namespace OpenRec_2.API;

using Microsoft.AspNetCore.Http;

public interface IApi
{
    public string Response(HttpContext context);
    public string GetUrl();
    
    public string GetMethod();
}