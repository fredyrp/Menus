namespace SingleMenu
{
    public class MenuSingle
    {
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
                Console.WriteLine("\t1. Option 1");
                Console.WriteLine("\t2. Option 2");
                Console.WriteLine("\t3. Option 3");
                Console.WriteLine("\t4. Option 4");
                Console.WriteLine("\tx. To exit");
                Console.Write("  Option: ");
                key = Console.ReadKey().KeyChar;

                Console.Clear();

                string message = $"You selected option {key}.";
                if (key == 'x')
                {
                    message = "You selected to exit.";
                }
                else if (key < '1' || key > '4')
                {
                    message = "Invalid option.";
                }

                Console.WriteLine(message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (key != 'x');
        }
    }
}