using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHDotNetTrainingBatch2.MiniPos.DataBase.App2DbContextModels;

namespace WZHDotNetTrainingBatch2.MiniPos.ConsoleApp
{
    public class SaleFeatureService
    {
        public void Execute()
        {
            App2DbContext db = new App2DbContext();
            List<TblSaleDetail> products = new List<TblSaleDetail>();
        FirstPage:
            Console.Write("Please Enter Product Id-");// should product code
            int id = Convert.ToInt32(Console.ReadLine());
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            if (item is null) return;
            Console.WriteLine($"Product name - {item.ProductName}");
            Console.WriteLine($"Price -{item.Price}");

            Console.Write("Please Enter Product Quantity -");
            int quantity = Convert.ToInt32(Console.ReadLine());

            //to store the  customer product in saledetail
            products.Add(new TblSaleDetail
            {
                ProductId = item.ProductId,
                Price= item.Price,
                Quantity = quantity,
                DeleteFlag = false,


            });

            //ask condition
            Console.WriteLine("Do you want to add more? Y or N");
            string result = Console.ReadLine()!;
            if (result == "Y")
            {
                goto FirstPage;
            }    
            TblSaleSummary sale = new TblSaleSummary();
            sale.SaleDate = DateTime.Now;
            sale.Total = products.Sum(x => (x.Price * x.Quantity));
            sale.VoucherNo = Guid.NewGuid().ToString(); 
            sale.DeleteFlag = false;

            db.Add(sale);
            db.SaveChanges();// we get sale id

            foreach ( var product in products)
            {
                product.SaleId = sale.SaleId;
            }
            db.TblSaleDetails.AddRange(products);
            db.SaveChanges();
        }

    }
}
