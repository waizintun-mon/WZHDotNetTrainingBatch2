
using WZHDotNetTrainingBatch2.MiniPos.DataBase;

using WZHDotNetTrainingBatch2.MiniPos.ConsoleApp;

Console.WriteLine("Welcome to Mini Pos");

Menu:

Console.WriteLine(" Menu");
Console.WriteLine("---------------------------");
Console.WriteLine("1. Product");
Console.WriteLine("2. Sale");
Console.WriteLine("3. SaleDetail");
Console.WriteLine("4. Exit");
Console.WriteLine("---------------------------");

Console.Write("Choose menu..");
string input = Console.ReadLine()!;
bool isInt = int.TryParse(input, out int no);
if (!isInt)
{
    Console.WriteLine("Invalid Product Menu,please choose from 1 to 4");
    goto Menu;
}
EnumMenu menu = (EnumMenu)no;
switch (menu)
{
    case EnumMenu.Product:
        ProductService productServie = new ProductService();
        productServie.Execute();
        goto Menu;
    case EnumMenu.Sale:
        SaleService saleService = new SaleService();
        saleService.Execute();
        goto Menu;
    case EnumMenu.SaleDetail:
        SaleDetailService saleDetailService = new SaleDetailService();
        saleDetailService.Execute();
        goto Menu;
    case EnumMenu.Exit:
        goto End;
    case EnumMenu.None:
    default:
        break;
}
End:
Console.WriteLine("Exiting from app");
