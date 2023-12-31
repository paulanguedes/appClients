using System.ComponentModel.DataAnnotations.Schema;
using Cadastro;

namespace Repository;

public class ClientRepository
{
    public List<Client> clients = new List<Client>();

    public void SaveClientsData()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(clients);
        File.WriteAllText("clients.txt", json);
    }

    public void ReadClientsData()
    {
        if (File.Exists("clients.txt"))
        {
            var data = File.ReadAllText("clients.txt");
            var listClients = System.Text.Json.JsonSerializer.Deserialize<List<Client>>(data);
            clients.AddRange(listClients);
        }
    }

    public void PrintClient(Client client)
    {
        Console.WriteLine("Id           : " + client.Id);
        Console.WriteLine("Name         : " + client.Name);
        Console.WriteLine("Discount     : " + client.Discount);
        Console.WriteLine("Birth        : " + client.Birth);
        Console.WriteLine("Registered in: " + client.RegisteredIn);
    }

    public void ShowClients()
    {
        Console.Clear();
        foreach (var client in clients)
        {
            PrintClient(client);
            Console.WriteLine("-------------------------------------");
        }

        Console.WriteLine("-------------------------------------");
        Console.WriteLine("*** Press any key to go back to the Menu ***");
        Console.ReadKey();
    }

    public void ClientRegister()
    {
        Console.Clear();

        Console.Write("Name: ");
        var name = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Birth (dd/mm/yyyy): ");
        var birth = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Discount (only numbers): ");
        var discount = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        var client = new Client
        {
            Id = clients.Count + 1,
            Name = name,
            Birth = birth,
            Discount = discount,
            RegisteredIn = DateTime.Now
        };

        clients.Add(client);

        Console.WriteLine("Client registered! =D ");
        Console.WriteLine("-------------------------------------");
        PrintClient(client);

        Console.WriteLine("-------------------------------------");
        Console.WriteLine("*** Press any key to go back to the Menu ***");
        Console.ReadKey();
    }

    public void UpdateClient()
    {
        Console.Clear();
        Console.Write("Insert client's id: ");
        var id = int.Parse(Console.ReadLine());

        var client = clients.FirstOrDefault(
            p => p.Id == id
        );

        if (client == null)
        {
            Console.WriteLine("Client not found =/ ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("*** Press any key to go back to the Menu ***");
            Console.ReadKey();
            return;
        }

        PrintClient(client);

        Console.Write("Name: ");
        var name = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Birth: ");
        var birth = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Discount: ");
        var discount = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        client.Name = name;
        client.Birth = birth;
        client.Discount = discount;
        
        Console.WriteLine("Client updated! =) ");
        Console.WriteLine("-------------------------------------");
        PrintClient(client);

        Console.WriteLine("-------------------------------------");
        Console.WriteLine("*** Press any key to go back to the Menu ***");
        Console.ReadKey();
    }

    public void DeleteClient()
    {
        Console.Clear();
        Console.Write("Insert client's id: ");
        var id = int.Parse(Console.ReadLine());

        var client = clients.FirstOrDefault(
            p => p.Id == id
        );

        if (client == null)
        {
            Console.WriteLine("Client not found =/ ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("*** Press any key to go back to the Menu ***");
            Console.ReadKey();
            return;
        }

        PrintClient(client);

        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Are you sure you want to delete this client? ");
        Console.WriteLine("Please insert Y for yes ou N for no");
        var answer = Console.ReadLine().ToLower();
        Console.WriteLine("-------------------------------------");

        if (answer == "y") {
            clients.Remove(client);
            Console.WriteLine("Client deleted! =( ");
        } else if (answer == "n") {
            Console.WriteLine("Ok! Please type any key to exit. ");
        } else {
            Console.WriteLine("Invalid option!");
        }
        
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("*** Press any key to go back to the Menu ***");
        Console.ReadKey();
    }

}