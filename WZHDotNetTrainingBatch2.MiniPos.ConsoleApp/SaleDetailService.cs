using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHDotNetTrainingBatch2.MiniPos.DataBase.App2DbContextModels;

namespace WZHDotNetTrainingBatch2.MiniPos.ConsoleApp
{
    public class SaleDetailService
    {
        public void Read()
        {
            App2DbContext db = new App2DbContext();
            var lst = db.TblSaleDetails.ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.SaleDetailId);
                Console.WriteLine(item.SaleId);
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Quantity);

            }
        }
        public void Edit()
        {
            Console.Write("Enter id..");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            App2DbContext db = new App2DbContext();
            var item = db.TblSaleDetails.FirstOrDefault(x => x.SaleId == id);
            if (item is null) return;
            Console.WriteLine("Sale Id => " + item.SaleId);
            Console.WriteLine(item.ProductId);
            Console.WriteLine(item.Price);
            Console.WriteLine(item.Quantity);
        }
        public void Create()
        {
            Console.Write("Enter SaleId.");
            int saleid = int.Parse(Console.ReadLine()!);

            Console.Write("Enter ProductId..");
            int productId = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Price..");
            decimal price = decimal.Parse(Console.ReadLine()!);
            Console.Write("Enter Quantity..");
            int quantity = int.Parse(Console.ReadLine()!);

            TblSaleDetail saleDetail = new TblSaleDetail();
            saleDetail.SaleId = saleid;
            saleDetail.ProductId = productId;
            saleDetail.Price = price;
            saleDetail.Quantity = quantity;

            App2DbContext db = new App2DbContext();
            db.TblSaleDetails.Add(saleDetail);
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "insert successful" : "insert failed");

        }
        public void Execute()
        {
            Console.WriteLine("Sale Menu");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. SaleRecord ");
            Console.WriteLine("2. Edit Sale");
            Console.WriteLine("3. New Sale");
            Console.WriteLine("4. Exit");

        Menu:
            Console.Write("Choose menu..");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int no);
            if (!isInt)
            {
                Console.WriteLine("Invalid Product Menu,please choose from 1 to 4");
                goto Menu;
            }
            EnumSaleDetail menu = (EnumSaleDetail)no;
            switch (menu)
            {

                case EnumSaleDetail.SaleRecord:
                    Console.WriteLine("This is Sale Record");
                    Read();
                    break;
                case EnumSaleDetail.EditSale:
                    Console.WriteLine("This is Edit Sale");
                    Edit();
                    break;
                case EnumSaleDetail.NewSale:
                    Console.WriteLine("This is create new Sale");
                    Create();
                    break;
                case EnumSaleDetail.Exit:
                    goto End;
                case EnumSaleDetail.None:
                default:
                    break;
            }
        End:
            Console.WriteLine("Exiting from menu");
        }

    }
    public enum EnumSaleDetail
    {
        None,
        SaleRecord,
        EditSale,
        NewSale,
        Exit
    }
}

