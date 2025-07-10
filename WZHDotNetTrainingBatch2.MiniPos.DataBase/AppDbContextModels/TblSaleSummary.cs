﻿using System;
using System.Collections.Generic;

namespace WZHDotNetTrainingBatch2.MiniPos.DataBase.AppDbContextModels;

public partial class TblSaleSummary
{
    public int SaleId { get; set; }

    public string VoucherNo { get; set; } = null!;

    public DateTime SaleDate { get; set; }

    public decimal Total { get; set; }

    public bool DeleteFlag { get; set; }
}
