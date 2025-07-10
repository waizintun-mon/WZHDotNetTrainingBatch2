using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHDotNetTrainingBatch2.MiniPos.DataBase.AppDbContextModels;

namespace WZHDotNetTrainingBatch2.MiniPos.Domain.Features
{
    public class SaleService
    {
        public TblProduct FindProductId(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            return item;
        }
        public int Sale(List<TblSaleDetail> products)
        {
            AppDbContext db = new AppDbContext();
            #region Generate SaleSummary Id and Create Sale Summary
            TblSaleSummary sale = new TblSaleSummary();
            sale.SaleDate = DateTime.Now;
            sale.Total = products.Sum(x => (x.Price * x.Quantity));
            sale.VoucherNo = Guid.NewGuid().ToString();
            sale.DeleteFlag = false;

            db.Add(sale);
            db.SaveChanges();// we get sale id
            #endregion 

            #region Modify Sale Detail and Create SaleDetail 
            foreach (var product in products)
            {
                product.SaleId = sale.SaleId;
            }

            db.TblSaleDetails.AddRange(products);
            var result = db.SaveChanges();
            return result;
            #endregion
        }
        public List <TblSaleSummary> GetSale()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.TblSaleSummaries.
               Where(x =>x.DeleteFlag==false). ToList();
            return lst;
        }
        public TblSaleSummary GetSaleId(int id)
        {

            AppDbContext db = new AppDbContext();
            var item = db.TblSaleSummaries.FirstOrDefault(x => x.SaleId == id);
            return item;
        }

        public List<TblSaleDetail> GetSaleDetail()
        {

            AppDbContext db = new AppDbContext();
            var lst = db.TblSaleDetails.ToList();
            return lst;
        }

    }
}

