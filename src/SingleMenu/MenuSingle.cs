namespace SingleMenu
{
    public class MenuSingle
    {
        private readonly Dictionary<string, string> _options;

        public MenuSingle()
            : this(null)
        {
        }

        public MenuSingle(Dictionary<string, string>? options)
        {
            _options = BuildDefaultOptions();

            if (options is null)
            {
                return;
            }

            _options.Clear();
            foreach (var option in options)
            {
                _options[option.Key] = option.Value;
            }

            if (!_options.ContainsKey("x"))
            {
                _options["x"] = "To exit";
            }
        }

        public void RunMenu()
        {
            char key = ' ';
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("--  Welcome to the Single Console Menu  --");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("  Select an option:");

                foreach (var option in _options)
                {
                    Console.WriteLine($"\t{option.Key}. {option.Value}");
                }

                Console.Write("  Option: ");
                key = Console.ReadKey().KeyChar;

                Console.Clear();

                string message = $"You selected option {key}.";
                if (key == 'x')
                {
                    message = "You selected to exit.";
                }
                else if (!_options.ContainsKey(key.ToString()))
                {
                    message = "Invalid option.";
                }
                else
                {
                    message = $"You selected option {key}: {_options[key.ToString()]}.";
                }

                Console.WriteLine(message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (key != 'x');
        }

        private static Dictionary<string, string> BuildDefaultOptions()
        {
            return new Dictionary<string, string>
            {
                ["1"] = "Option 1",
                ["2"] = "Option 2",
                ["3"] = "Option 3",
                ["4"] = "Option 4",
                ["x"] = "To exit"
            };
        }
    }
}