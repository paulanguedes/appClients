using Repository;

namespace AppClients;

class Program
{
    private static ClientRepository _clientRepository = new ClientRepository();
    static void Main(string[] args)
    {
        while(true)
        {
            Menu();
            Console.ReadKey();
        }
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("CLIENT REGISTER OPTIONS");
        Console.WriteLine("==========================");
        Console.WriteLine("1 - Client Register");
        Console.WriteLine("2 - Show clients");
        Console.WriteLine("3 - Update client");
        Console.WriteLine("4 - Delete client");
        Console.WriteLine("5 - Exit");
        Console.WriteLine("==========================");

        ChooseOption();
    }

    static void ChooseOption()
    {
        Console.WriteLine("Type an option and press Enter: ");
        var option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
            {
                _clientRepository.ClientRegister();
                Menu();
                break;
            }
            case 2:
            {
                _clientRepository.ShowClients();
                Menu();
                break;
            }
            case 3:
            {
                _clientRepository.UpdateClient();
                Menu();
                break;
            }
            case 4:
            {
                _clientRepository.DeleteClient();
                Menu();
                break;
            }
            case 5:
            {
                Environment.Exit(0);
                break;
            }
            default:
            {
                Console.Clear();
                Console.WriteLine("Invalid option!");
                Console.WriteLine("Press Enter to go back to the Menu");
                break;
            }
        }
    }
}
