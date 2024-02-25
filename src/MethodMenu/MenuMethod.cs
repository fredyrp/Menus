namespace MethodMenu;
public class MenuMethod
{
    private Dictionary<string, string> _dictionary = new Dictionary<string, string>();

    public MenuMethod()
    {
        _dictionary.Add("1", "Option 1");
        _dictionary.Add("2", "Option 2");
        _dictionary.Add("3", "Option 3");
        _dictionary.Add("4", "Option 4");
        _dictionary.Add("x", "To exit");
    }

    public void RunMenu()
    {
        char key;
        do
        {
            HeaderMenu();
            ShowOptions();
            key = SelectedOption();
            HandleOptions(key);
            FooterMenu();
        } while (key != 'x');
    }

    private void HeaderMenu()
    {
        Console.Clear();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("--      Welcome to the Method Menu      --");
        Console.WriteLine("------------------------------------------");
    }

    private void ShowOptions()
    {
        Console.WriteLine("  Select an option:");
        foreach (var item in _dictionary)
        {
            Console.WriteLine($"\t{item.Key}. {item.Value}");
        }
    }

    private char SelectedOption()
    {
        Console.Write("  Option: ");
        return Console.ReadKey().KeyChar;
    }

    private void HandleOptions(char key)
    {
        Console.Clear();

        string message;
        if (_dictionary.TryGetValue(key.ToString(), out string? option))
        {
            message = $"You selected option {key}: {option}.";
        }
        else if (key == 'x')
        {
            message = "You selected to exit.";
        }
        else
        {
            message = "Invalid option.";
        }

        Console.WriteLine(message);
    }

    private void FooterMenu()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
