using OpenRec_2.API;

namespace OpenRec_2;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public static class Server
{
    private static readonly List<IApi> ApiList =
    [
        new DefaultApi(),
        new TestApi(),
        new CharadesWordsApi(),
        new AmplitudeApi(),
        new ConfigV2Api(),
        new VersionCheckApi()
    ];
    
    public static async Task StartAsync(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        //builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Warning);

        var app = builder.Build();

        app.Run(async context =>
        {
            var path = context.Request.Path;
            var method = context.Request.Method;
            bool apiFufilled = false;
            
            foreach (IApi api in ApiList)
            {
                if (path == api.GetUrl() && method == api.GetMethod())
                {
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(api.Response(context));
                    apiFufilled = true;
                    break;
                }
            }
            
            if (!apiFufilled)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("404 - Endpoint Not Found");
            }
        });

        // asgfhosa ckjabvuciba bnc vbakuyfcp/al vchjnavboaiv ashgbc ajiakjb cyab gffff
        await app.RunAsync();
    }
}