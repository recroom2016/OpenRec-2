

using System;
using System.Threading.Tasks;
using Figgle;
using Figgle.Fonts;

// 1. Draw the UI
Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.ResetColor();
Console.WriteLine("--------------------------------------------------");
Console.WriteLine(FiggleFonts.Standard.Render("OpenRec-2"));
Console.WriteLine("--------------------------------------------------");
Console.WriteLine(" Info: This server is powered by .NET 10 Kestrel.");
Console.WriteLine(" Mode: Bare-Metal Terminal Middleware");
Console.WriteLine(" Port: 5000 (HTTP) / 5001 (HTTPS) default");
Console.WriteLine("--------------------------------------------------");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(" Press [ENTER] to start the server...");
Console.ResetColor();
Console.WriteLine(" Press [ESC] to exit.");

// 2. Wait for user input
while (true)
{
    var key = Console.ReadKey(intercept: true).Key;
    if (key == ConsoleKey.Enter)
    {
        Console.WriteLine("\n[System] Booting up Kestrel...");

        await OpenRec_2.Server.StartAsync(args);
        break;
    }
    else if (key == ConsoleKey.Escape)
    {
        Console.WriteLine("\n[System] Shutting down...");
        return;
    }
}