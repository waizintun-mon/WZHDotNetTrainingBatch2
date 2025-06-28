// See https://aka.ms/new-console-template for more information
using WZHDotNetTrainingBatch2.MiniPos;
using WZHMiniPos.App2DbContextModels;

Console.WriteLine("Welcome to MiniPos!");
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
switch (menu )
{
    case EnumMenu.Product:
        ProductServie productServie = new ProductServie();
        productServie.Execute();
        goto Menu;
    case EnumMenu.Sale:
        break;
    case EnumMenu.SaleDetail:
        break;
    case EnumMenu.Exit:
        goto End;
    case EnumMenu.None:
    default:
        break;
}
End:
Console.WriteLine("Exiting from app");
//ProductServie efCoreMiniPos = new ProductServie();
//efCoreMiniPos.Read();
//efCoreMiniPos.Edit();
//efCoreMiniPos.Create();
//efCoreMiniPos.Update();
//efCoreMiniPos.Delete();
//SaleService miniPosSale = new SaleService();
//miniPosSale.Read();
//miniPosSale.Create();

//Console.ReadKey();
