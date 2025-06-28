using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHMiniPos.App2DbContextModels;

namespace WZHDotNetTrainingBatch2.MiniPos
{
    public class ProductServie
    {
        public void Read()
        {
            App2DbContext db = new App2DbContext();
            var lst = db.TblProducts.Where(x => x.DeleteFlag == false).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.Price);
            }

        }
        public void Edit()
        {
            Console.Write("Enter Id...");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            App2DbContext db = new App2DbContext();
            var item = db.TblProducts.
                 Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.ProductId == id);
            if (item is null) return;
            Console.WriteLine(item.ProductName);
            Console.WriteLine(item.Price);

        }
        public void Create()
        {
            Console.Write("Enter Product Name...");
            string name = Console.ReadLine()!;
            Console.Write("Enter Price..");
            decimal price = decimal.Parse(Console.ReadLine()!);


            TblProduct product = new TblProduct();
            product.ProductName = name;
            product.Price = price;

            App2DbContext db = new App2DbContext();
            db.TblProducts.Add(product);
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "insert successful" : "insert failed");
        }
        public void Update()
        {
            Console.Write("Enter Id...");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            Console.Write("Update Product Name..");
            string name = Console.ReadLine()!;
            Console.Write("Update Price..");
            decimal price = decimal.Parse(Console.ReadLine()!);


            bool isExit = FindId(id);
            if (!isExit) return;

            App2DbContext db = new App2DbContext();
            var item = db.TblProducts.Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.ProductId == id);
            item.ProductName = name;
            item.Price = price;
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "update successful" : "update failed");
        }
        public void Delete()
        {
            Console.Write("Enter Id...");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            bool isExit = FindId(id);
            if (!isExit) return;
            App2DbContext db = new App2DbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            item.DeleteFlag = true;
            var result = db.SaveChanges();
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
                    Console.WriteLine( "This Menu is NewProduct");
                    Create();
                    break;
                case EnumProductMenu.ProductList:
                    Console.WriteLine("This Menu is ProductList");
                    Read();
                    break;
                case EnumProductMenu.EditProduct:
                    Console.WriteLine("This Menu is EditProduct");
                    Edit();
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
            Console.WriteLine( "------------------------------");
            goto Menu;

        End:
            Console.WriteLine( "Exiting from app");
        }

        
    }
    public enum EnumProductMenu
    {
        None,
        NewProduct ,
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