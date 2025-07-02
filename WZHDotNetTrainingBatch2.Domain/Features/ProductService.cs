using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHDotNetTrainingBatch2.MiniPos.DataBase.App2DbContextModels;

namespace WZHDotNetTrainingBatch2.MiniPos.Domain.Features
{
    public class ProductService
    {
        public List<TblProduct> GetProduct()
        {

            App2DbContext db = new App2DbContext();
            var lst = db.TblProducts.Where(x => x.DeleteFlag == false).ToList();
            return lst;
        }
        public TblProduct FindProductId(int id)
        {
            App2DbContext db = new App2DbContext();
            var item = db.TblProducts.
                 Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.ProductId == id);
            return item;
        }
        public int CreateNewProduct(string name, decimal price)
        {
            TblProduct product = new TblProduct();
            product.ProductName = name;
            product.Price = price;

            App2DbContext db = new App2DbContext();
            db.TblProducts.Add(product);
            var result = db.SaveChanges();
            return result;
        }
        public int UpdateProduct(int id, string name, decimal price)
        {
            App2DbContext db = new App2DbContext();
            var item = db.TblProducts.Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.ProductId == id);
            item.ProductName = name;
            item.Price = price;
            var result = db.SaveChanges();
            return result;
        }
        public int DeleteProduct(int id)
        {
            App2DbContext db = new App2DbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            item.DeleteFlag = true;
            var result = db.SaveChanges();
            return result;
        }
    }
}
