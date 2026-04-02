using OpenRec_2.API;

namespace OpenRec_2;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public static class Server
{
    private static Dictionary<string, IApi> ApiDictionaryGet = new()
    {
        { "",  },
        { "Key2", }
    };
    
    public static async Task StartAsync(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        //builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Warning);

        var app = builder.Build();

        app.Run(async context =>
        {
            var path = context.Request.Path;
            var method = context.Request.Method;
            
            if (method == HttpMethods.Get && path == "/")
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Server is actively listening!");
            }
            else if (method == HttpMethods.Get && path == "/data")
            {
                await Task.Delay(50);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"status\": \"success\", \"message\": \"Async response\"}");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("404 - Endpoint Not Found");
            }
        });

        // Start the server and block the thread here so it keeps running
        await app.RunAsync();
    }
}