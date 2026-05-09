using Figgle.Fonts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.CompilerServices;

namespace OpenRec2
{
    public class Program
    {

        public static WebApplication app { get; set; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();



            LoadRootMenu();

        }

        private static void LoadRootMenu()
        {
            Console.Beep(800, 100);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(FiggleFonts.Standard.Render("OpenRec 2"));
            Console.WriteLine("--------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine(
                " Info: This server is powered by .NET 8!"+
                "\n Feel Free to fork this project and add anything you'd like!"+
                "\n Made by RecRoom2016 & NoMason!"
                );
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(
                " 1 - Start Server\n 2 - Settings\n 3 - Quit"
                );

            Console.WriteLine("\n Enter Selection: ");
            var selection = Console.ReadLine();


            if (int.TryParse(selection.ToString(), out int result) && result is 1)
            {
                Console.Beep(800, 100);
                Console.Clear();
                app.Run();
            }

            if (int.TryParse(selection.ToString(), out int result2) && result2 is 2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Settings Not Implemented Yet!");
                Console.ResetColor();
                LoadRootMenu();
                return;
            }
        }
    }
}
