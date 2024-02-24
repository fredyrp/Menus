using System;
using SingleMenu;

namespace MainMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            char key = ' ';
            while (key != 'x')
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("--       Welcome to the Main Menu       --");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Select an menu:");
                Console.WriteLine("\t1. Single Menu");
                Console.WriteLine("\t2. Single Array Menu");
                Console.WriteLine("\t3. Single Functions Menu");
                Console.WriteLine("\tx. To exit");
                Console.Write("Option: ");
                key = Console.ReadKey().KeyChar;

                Console.Clear();
                switch (key)
                {
                    case '1':
                        new MenuSingle().RunMenu();
                        break;
                    case '2':
                        //SingleArrayMenu.MainMenu();
                        break;
                    case '3':
                        //SingleFunctionsMenu.MainMenu();
                        break;
                    case 'x':
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
