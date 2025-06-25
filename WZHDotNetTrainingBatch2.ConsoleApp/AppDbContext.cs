using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZHDotNetTrainingBatch2.ConsoleApp
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder() 
                { 
                DataSource=".",//server name, local
                InitialCatalog="DotNetTrainingBatch2",
                UserID ="sa",
                Password = "sa@@123",
                TrustServerCertificate=true,
                };
                optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
            }
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
    //Model First <=> Database Column Mapping
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        [Column("BlogId")]
        public int BlogId { get; set; }
        public string BlogTitle{ get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContext { get; set; }
        public bool DeleteFlag {  get; set; }
    }
}
