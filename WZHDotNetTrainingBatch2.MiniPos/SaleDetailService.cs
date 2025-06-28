using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHMiniPos.App2DbContextModels;

namespace WZHDotNetTrainingBatch2.MiniPos
{
    public class SaleDetailService
    {
        public void Read()
        {
            App2DbContext db = new App2DbContext();
            var lst = db.TblSaleDetails.ToList();
            foreach (var item in lst)
            {
                Console.WriteLine( item.SaleDetailId);
                Console.WriteLine(item.SaleId);
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.Price);
                Console.WriteLine( item.Quantity);

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
            Console.WriteLine( item.SaleId);
            Console.WriteLine( item.ProductId);
            Console.WriteLine(item.Price);
            Console.WriteLine( item.Quantity);
        }
        public void Create()
        {

        }
    }
}
