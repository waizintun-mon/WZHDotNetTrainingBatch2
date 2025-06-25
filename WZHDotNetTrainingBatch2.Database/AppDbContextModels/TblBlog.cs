using System;
using System.Collections.Generic;

namespace WZHDotNetTrainingBatch2.Database.AppDbContextModels;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContext { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}
