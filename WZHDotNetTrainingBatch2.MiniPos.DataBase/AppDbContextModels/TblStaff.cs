using System;
using System.Collections.Generic;

namespace WZHDotNetTrainingBatch2.MiniPos.DataBase.AppDbContextModels;

public partial class TblStaff
{
    public int StaffId { get; set; }

    public string StaffCode { get; set; } = null!;

    public string StaffName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int MobileNo { get; set; }

    public bool DeleteFlag { get; set; }
}
