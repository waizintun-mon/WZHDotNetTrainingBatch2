using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHDotNetTrainingBatch2.MiniPos.DataBase.App2DbContextModels;

namespace WZHDotNetTrainingBatch2.MiniPos.ConsoleApp
{
    public class SaleService
    {
        public void Read()
        {
            App2DbContext db = new App2DbContext();
            var lst = db.TblSaleSummaries.ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.SaleId);
                Console.WriteLine(item.SaleDate);
                Console.WriteLine(item.VoucherNo);
                Console.WriteLine(item.Total);
            }
        }
        public void Edit()
        {
            Console.Write("Enter id..");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            App2DbContext db = new App2DbContext();
            var item = db.TblSaleSummaries.FirstOrDefault(x => x.SaleId == id);
            if (item is null) return;
            Console.WriteLine(item.SaleDate);
            Console.WriteLine(item.VoucherNo);
            Console.WriteLine(item.Total);


        }
        public void Create()
        {
            Console.Write("Enter SaleDate eg.2025-06-12 YY//MM//DD...");
            string date = Console.ReadLine()!;
            Console.Write("Enter VoucherNo..");
            string voucher = Console.ReadLine()!;
            Console.Write("Total amount");
            decimal total = decimal.Parse(Console.ReadLine()!);

            TblSaleSummary sale = new TblSaleSummary();
            sale.SaleDate = DateTime.Parse(date);

            sale.VoucherNo = voucher;
            sale.Total = total;

            App2DbContext db = new App2DbContext();
            db.TblSaleSummaries.Add(sale);
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
            EnumSale menu = (EnumSale)no;
            switch (menu)
            {

                case EnumSale.SaleRecord:
                    Console.WriteLine("This is Sale Record");
                    Read();
                    break;
                case EnumSale.EditSale:
                    Console.WriteLine("This is Edit Sale");
                    Edit();
                    break;
                case EnumSale.NewSale:
                    Console.WriteLine("This is create new Sale");
                    Create();
                    break;
                case EnumSale.Exit:

                    goto End;
                case EnumSale.None:
                default:
                    break;
            }
        End: Console.WriteLine("Exiting from Sale menu");
        }
        public enum EnumSale
        {
            None,
            SaleRecord,
            EditSale,
            NewSale,
            Exit
        }
    }
}

