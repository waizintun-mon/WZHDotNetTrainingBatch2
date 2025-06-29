using System;
using System.Collections.Generic;

namespace WZHDotNetTrainingBatch2.MiniPos.DataBase.App2DbContextModels;

public partial class TblSaleDetail
{
    public int SaleDetailId { get; set; }

    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool DeleteFlag { get; set; }
}
