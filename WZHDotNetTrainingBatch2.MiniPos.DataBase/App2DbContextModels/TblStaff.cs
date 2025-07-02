using System;
using System.Collections.Generic;

namespace WZHDotNetTrainingBatch2.MiniPos.DataBase.App2DbContextModels;

public partial class TblStaff
{
    public int StaffId { get; set; }

    public int StaffCode { get; set; }

    public string Name { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Email { get; set; } = null!;
}
