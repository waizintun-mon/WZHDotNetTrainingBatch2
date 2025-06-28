using System;
using System.Collections.Generic;

namespace WZHMiniPos.App2DbContextModels;

public partial class TblSaleSummary
{
    public int SaleId { get; set; }

    public string VoucherNo { get; set; } = null!;

    public DateTime SaleDate { get; set; }

    public decimal Total { get; set; }
}
