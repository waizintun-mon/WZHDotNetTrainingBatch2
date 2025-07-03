using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHDotNetTrainingBatch2.MiniPos.DataBase.App2DbContextModels;
using WZHDotNetTrainingBatch2.MiniPos.Domain.Features;

namespace WZHDotNetTrainingBatch2.MiniPos.ConsoleApp
{
    public class ProductUI
    {
        public void Read()
        {
            ProductService productiveService = new ProductService();
            var lst = productiveService.GetProduct();
            foreach (var item in lst)
            {
                Console.WriteLine("Product id =>" + item.ProductId);
                Console.WriteLine("Product name =>" + item.ProductName);
                Console.WriteLine("Price =>" + item.Price);
            }

        }
        public void Edit()
        {
            Console.Write("Enter Id...");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            ProductService productService = new ProductService();
            var item = productService.FindProductId(id);
            if (item is null) return;

            Console.WriteLine("Product id =>" + item.ProductName);
            Console.WriteLine("Price =>" + item.Price);

        }
        public void Create()
        {
            Console.Write("Enter Product Name...");
            string name = Console.ReadLine()!;
        PriceInput:
            Console.Write("Enter Price..");
            var input = Console.ReadLine()!;
            bool isDecimal = decimal.TryParse(input, out decimal price);
            if(!isDecimal) 
            {
                goto PriceInput;
            }
            ProductService productService = new ProductService();
            int result = productService.CreateNewProduct(name, price);
            
            Console.WriteLine(result > 0 ? "insert successful" : "insert failed");
        }
        public void Update()
        {
        ProductIdInput:
            Console.Write("Enter Id...");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                goto ProductIdInput;
            }
            ProductService productService= new ProductService();
           var item = productService.FindProductId(id);
            if(item is null)
            {
                Console.WriteLine("No data found");
                goto ProductIdInput;
            }
            Console.WriteLine("Product id =>" + item.ProductName);
            Console.WriteLine("Price =>" + item.Price);

            Console.Write("Update Product Name..");
            string name = Console.ReadLine()!;

        PriceInput:
            Console.Write("Enter Price..");
           string priceInput = Console.ReadLine()!;
            bool isDecimal = decimal.TryParse(priceInput, out decimal price);
            if (!isDecimal)
            {
                goto PriceInput;
            }

           var result = productService.UpdateProduct(id, name, price);
            Console.WriteLine(result > 0 ? "update successful" : "update failed");
        }
        public void Delete()
        {
            Console.Write("Enter Id...");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            
            ProductService productService = new ProductService();
            productService.FindProductId(id);
                
         var result = productService.DeleteProduct(id);
            Console.WriteLine(result > 0 ? "delete successful" : "delete failed");
        }
        private bool FindId(int id)
        {
            App2DbContext db = new App2DbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            return item != null;
        }
        public void Execute()
        {
            Console.WriteLine("Product Menu");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. New Product");
            Console.WriteLine("2. Product List");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");
            Console.WriteLine("---------------------------");

        Menu:
            Console.Write("Choose menu..");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int no);
            if (!isInt)
            {
                Console.WriteLine("Invalid Product Menu,please choose from 1 to 5");
                goto Menu;
            }
            EnumProductMenu menu = (EnumProductMenu)no;
            switch (menu)
            {

                case EnumProductMenu.NewProduct:
                    Console.WriteLine("This Menu is NewProduct");
                    Create();
                    break;
                case EnumProductMenu.ProductList:
                    Console.WriteLine("This Menu is ProductList");
                    Read();
                    break;
                case EnumProductMenu.EditProduct:
                    Console.WriteLine("This Menu is EditProduct");
                    Edit();
                    Update();
                    break;
                case EnumProductMenu.DeleteProduct:
                    Console.WriteLine("This Menu is DeleteProduct");
                    Delete();
                    break;
                case EnumProductMenu.Exit:
                    goto End;

                case EnumProductMenu.None:
                default:
                    Console.WriteLine("Invalid Product Menu,please choose from 1 to 4");
                    goto Menu;
            }
            Console.WriteLine("------------------------------");
            goto Menu;

        End:
            Console.WriteLine("Exiting from product menu");
        }


    }
    public enum EnumProductMenu
    {
        None,
        NewProduct,
        ProductList,
        EditProduct,
        DeleteProduct,
        Exit,
    }
    public enum EnumMenu
    {
        None,
        Product,
        Sale,
        SaleDetail,
        Exit
    }
}

