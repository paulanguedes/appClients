namespace AppClients;

class Program
{
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


    }
}
