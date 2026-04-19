using System;
using SingleMenu;
using DictionaryMenu;
using MethodMenu;

namespace MainMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataFolder = Path.Combine(AppContext.BaseDirectory, "MenuData");
            string singleOptionsPath = Path.Combine(dataFolder, "single-options.txt");
            string dictionaryOptionsPath = Path.Combine(dataFolder, "dictionary-options.txt");
            string methodOptionsPath = Path.Combine(dataFolder, "method-options.txt");
            string defaultXmlPath = Path.Combine(dataFolder, "menu-options.xml");
            string defaultJsonPath = Path.Combine(dataFolder, "menu-options.json");

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
                Console.WriteLine("\t4. Upload XML menu.");
                Console.WriteLine("\t5. Upload JSON menu.");
                Console.WriteLine("\tx. To exit");
                Console.Write("Option: ");
                key = Console.ReadKey().KeyChar;

                Console.Clear();

                try
                {
                    switch (key)
                    {
                        case '1':
                        {
                            var options = MenuFileLoader.LoadFromSeparatedFile(singleOptionsPath, ':');
                            new MenuSingle(options).RunMenu();
                            break;
                        }
                        case '2':
                        {
                            var options = MenuFileLoader.LoadFromSeparatedFile(dictionaryOptionsPath, '=');
                            new MenuDictionary(options).RunMenu();
                            break;
                        }
                        case '3':
                        {
                            var options = MenuFileLoader.LoadFromSeparatedFile(methodOptionsPath, ',');
                            new MenuMethod(options).RunMenu();
                            break;
                        }
                        case '4':
                        {
                            string xmlPath = PromptPath("Enter the XML file path.", defaultXmlPath);
                            var options = MenuFileLoader.LoadFromXml(xmlPath);
                            new MenuDictionary(options).RunMenu();
                            break;
                        }
                        case '5':
                        {
                            string jsonPath = PromptPath("Enter the JSON file path.", defaultJsonPath);
                            var options = MenuFileLoader.LoadFromJson(jsonPath);
                            new MenuDictionary(options).RunMenu();
                            break;
                        }
                        case 'x':
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not load menu options: {ex.Message}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            } while (key != 'x');
        }

        private static string PromptPath(string message, string defaultPath)
        {
            Console.WriteLine(message);
            Console.Write($"Path (Enter = {defaultPath}): ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                return defaultPath;
            }

            return input.Trim().Trim('"');
        }
    }
}
