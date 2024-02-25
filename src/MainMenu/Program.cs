using System;
using SingleMenu;
using DictionaryMenu;

namespace MainMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            char key = ' ';
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("--       Welcome to the Main Menu       --");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Select an menu:");
                Console.WriteLine("\t1. Simple menu");
                Console.WriteLine("\t2. Menu using a dictionary.");
                Console.WriteLine("\t3. Menu split into methods.");
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
                        new MenuDictionary().RunMenu();
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
            } while (key != 'x');
        }
    }
}
