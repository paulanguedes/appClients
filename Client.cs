namespace Cadastro;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly Birth { get; set; }
    public DateTime RegisteredIn { get; set; }
    public decimal Discount { get; set; }
}