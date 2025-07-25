﻿using System;
using System.Collections.Generic;

namespace WZHDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public bool DeleteFlag { get; set; }
}
