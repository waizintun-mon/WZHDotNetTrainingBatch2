using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZHDotNetTrainingBatch2.ConsoleApp
{
    public class BlogDto
    {
        public int BlogId { get; set; } 
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContext { get; set; }
        bool DeleteFlag { get; set; }   
    }
}
