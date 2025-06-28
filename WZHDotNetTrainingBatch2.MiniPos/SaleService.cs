using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHMiniPos.App2DbContextModels;

namespace WZHDotNetTrainingBatch2.MiniPos
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
                Console.WriteLine( item.Total);
            }
        }
        public void Edit()
        {
            Console.Write("Enter id..");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            App2DbContext db= new App2DbContext();
           var item = db.TblSaleSummaries.FirstOrDefault(x=> x.SaleId == id);
            if (item is null) return;
            Console.WriteLine(item.SaleDate);
            Console.WriteLine(item.VoucherNo);
            Console.WriteLine(item.Total);


        }
        public void Create()
        {
            Console.Write("Enter SaleDate eg. YY//MM//DD...");
            string date = Console.ReadLine()!;
            Console.Write("Enter VoucherNo..");
            string voucher = Console.ReadLine()!;
            Console.Write("Total amount");
            decimal total = decimal.Parse(Console.ReadLine()!);

            TblSaleSummary sale= new TblSaleSummary();
            sale.SaleDate = DateTime.Parse(date);

            sale.VoucherNo = voucher;
            sale.Total = total;

            App2DbContext db = new App2DbContext();
            db.TblSaleSummaries.Add(sale);
           var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "insert successful" : "insert failed");


        }
    }
}
