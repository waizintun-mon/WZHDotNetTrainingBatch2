using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHDotNetTrainingBatch2.MiniPos.DataBase.App2DbContextModels;
using WZHDotNetTrainingBatch2.MiniPos.Domain.Features;

namespace WZHDotNetTrainingBatch2.MiniPos.ConsoleApp
{
    public class SaleUI
    {
        public void CreateSaleUI()
        {
            SaleService saleService = new SaleService();

            List<TblSaleDetail> products = new List<TblSaleDetail>();
        #region Collecting Products
        FirstPage:
            Console.Write("Please Enter Product Id-");// should product code
            int id = Convert.ToInt32(Console.ReadLine());
            //var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            var item = saleService.FindProductId(id);
            if (item is null) return;
            Console.WriteLine($"Product name - {item.ProductName}");
            Console.WriteLine($"Price -{item.Price}");

            Console.Write("Please Enter Product Quantity -");
            int quantity = Convert.ToInt32(Console.ReadLine());

            //to store the  customer product in saledetail
            products.Add(new TblSaleDetail
            {
                ProductId = item.ProductId,
                Price = item.Price,
                Quantity = quantity,
                DeleteFlag = false,


            });
            //the same way above
            //var collect = new TblSaleDetail
            //{
            //    ProductId = item.ProductId,
            //    Price = item.Price,
            //    Quantity = quantity,
            //    DeleteFlag = false,
            //};
            //    products.Add(collect); 
            #endregion

            #region Add more Products or Continue
            //ask condition
            Console.WriteLine("Do you want to add more? Y or N");
            string confirm = Console.ReadLine()!;
            if (confirm == "Y")
            {
                goto FirstPage;
            }
            #endregion

            #region Sale Process 
        int result = saleService.Sale(products);
            #endregion
            Console.WriteLine( result>0? "Sale Process is successful": "Failed");

        }
        public void Read()
        {
            SaleService saleService = new SaleService();
          var lst =  saleService.GetSale();
            foreach (var item in lst)
            {
                Console.WriteLine("Sale id =>" +item.SaleId);
                Console.WriteLine("Sale Date =>"+item.SaleDate);
                Console.WriteLine("Voucher no =>" +item.VoucherNo);
                Console.WriteLine("Total amount =>" +item.Total);
            }
        }
        public void Edit()
        {
        FirstPage:
            Console.Write("Enter id..");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine( "Could not found Id");
                goto FirstPage;
            }
            SaleService saleService = new SaleService();
            var item = saleService.GetSaleId(id);
          
            if (item is null) return;
            Console.WriteLine("Sale Date =>"+item.SaleDate);
            Console.WriteLine("Sale Voucher No =>"+item.VoucherNo);
            Console.WriteLine("Total Amount =>"+item.Total);


        }
        public void ReadSaleDetail()
        {
            SaleService saleService = new SaleService();
           var lst = saleService.GetSaleDetail();
            foreach (var item in lst)
            {
                Console.WriteLine("SaleDetail Id =>" +item.SaleDetailId);
                Console.WriteLine("Sale Id =>"+ item.SaleId);
                Console.WriteLine( "Product Id =>" +item.ProductId);
                Console.WriteLine ("Price" +item.Price);
                Console.WriteLine( "Quantity" +item.Quantity);

            }
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
                Console.WriteLine("Invalid Sale Menu,please choose from 1 to 4");
                goto Menu;
            }
            EnumSale menu = (EnumSale)no;
            switch (menu)
            {

                case EnumSale.SaleRecord:
                    Console.WriteLine("This is Sale Record");
                    Read();
                    ReadSaleDetail();
                    break;
                case EnumSale.EditSale:
                    Console.WriteLine("This is Edit Sale");
                    Edit();
                    break;
                case EnumSale.NewSale:
                    Console.WriteLine("This is create new Sale");
                    CreateSaleUI();
                    break;
                case EnumSale.Exit:

                    goto End;
                case EnumSale.None:
                default:
                    Console.WriteLine("Invalid Sale Menu,please choose from 1 to 4");
                    goto Menu;
                    
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


    

