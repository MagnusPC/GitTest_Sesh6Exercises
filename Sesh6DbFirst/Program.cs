// See https://aka.ms/new-console-template for more information
using Sesh6DbFirst.CtrlLayer;
using Sesh6DbFirst.DbLayer;
using Sesh6DbFirst.ModelLayer;
using System.Data;

Console.WriteLine("Hello, World!");
Console.WriteLine("totally a feature");

string connectionString = "data Source=.; Database=SalesDatabase; integrated security=true";

DbAccess dba1 = new();

List<ConnectionState> connectionStates = dba1.TryConnection(connectionString);

foreach(ConnectionState state in connectionStates)
{
    Console.WriteLine("Connectionstate was: " + state);
}


ProductCtrl pc = new();

Console.WriteLine("Call GetProductById(int id)");

Product prod1 = pc.GetProductById(2);
Console.WriteLine(prod1.TempName);

Product prod2 = pc.GetProductById(4);
Console.WriteLine(prod2.TempName);

Console.WriteLine(Environment.NewLine + "Call GetAllProducts()");

List<Product> foundProducts = pc.GetAllProducts();
if (foundProducts != null)
{
    foreach (Product prod in foundProducts)
    {
        Console.WriteLine(prod.TempName);
    }
}