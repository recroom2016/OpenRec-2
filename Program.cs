using System;
using System.Threading.Tasks;
using Figgle.Fonts;

int selectedIndex = 0;
bool apiSelected = false;
bool wsSelected = false;

while (true)
{
    Console.Clear();
    
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine(FiggleFonts.Standard.Render("OpenRec-2"));
    Console.WriteLine("--------------------------------------------------");
    Console.ResetColor();
    Console.WriteLine(" Info: This server is powered by .NET 10 Kestrel.");
    Console.WriteLine(" Feel free to fork this project and add anything you want.");
    Console.WriteLine(" Made by RecRoom2016!");
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine(" Use [UP/DOWN] to navigate, [ENTER] to toggle.");
    Console.WriteLine(" Press [ENTER] on 'Run Selected Servers' to start.");
    Console.WriteLine(" Press [ESC] to exit.\n");
    
    for (int i = 0; i < 3; i++)
    {
        if (i == selectedIndex)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.ResetColor();
        }

        if (i == 0)
        {
            string check = apiSelected ? "X" : " ";
            Console.WriteLine($"[{check}] Start APIServer");
        }
        else if (i == 1)
        {
            string check = wsSelected ? "X" : " ";
            Console.WriteLine($"[{check}] Start WebsocketServer");
        }
        else if (i == 2)
        {
            Console.WriteLine("Run Selected Servers");
        }
    }

    Console.ResetColor();

    var key = Console.ReadKey(intercept: true).Key;

    if (key == ConsoleKey.UpArrow)
    {
        selectedIndex--;
        if (selectedIndex < 0) selectedIndex = 2;
    }
    else if (key == ConsoleKey.DownArrow)
    {
        selectedIndex++;
        if (selectedIndex > 2) selectedIndex = 0;
    }
    else if (key == ConsoleKey.Enter)
    {
        if (selectedIndex == 0) apiSelected = !apiSelected;
        else if (selectedIndex == 1) wsSelected = !wsSelected;
        else if (selectedIndex == 2) break;
    }
    
    else if (key == ConsoleKey.Escape)
    {
        Console.WriteLine("\n[System] Shutting down...");
        return;
    }
}

Console.WriteLine("\n[System] Booting up selected servers...");

var serverTasks = new System.Collections.Generic.List<Task>();

if (apiSelected)
{
    serverTasks.Add(OpenRec_2.Server.StartAsync(args));
}

if (wsSelected)
{
}

if (serverTasks.Count > 0)
{
    await Task.WhenAll(serverTasks);
}
else
{
    Console.WriteLine("[System] No servers were selected. Exiting.");
}