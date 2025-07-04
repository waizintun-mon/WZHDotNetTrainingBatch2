using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WZHDotNetTrainingBatch2.ConsoleApp
{
    internal class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sa@@123",
            TrustServerCertificate = true,
        };
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                List<BlogDto> lst = db.Query<BlogDto>("select * from Tbl_Blog").ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine("Blog id =>" + item.BlogId);
                    Console.WriteLine("Blog title=>" + item.BlogTitle);
                    Console.WriteLine("Blog author =>" + item.BlogAuthor);
                    Console.WriteLine("Blog content =>" + item.BlogContext);
                }
            }
        }
        public void Edit()
        {
        FirstPage:
            Console.Write("Enter Id :");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("please enter valid id");
                goto FirstPage;
            }
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("select * from Tbl_Blog where BlogId = @BlogId", new BlogDto { BlogId = id });
                if (item == null)
                {
                    Console.WriteLine("id not found");
                    return;
                }
                Console.WriteLine("Blog id =>" + item.BlogId);
                Console.WriteLine("Blog title=>" + item.BlogTitle);
                Console.WriteLine("Blog author =>" + item.BlogAuthor);
                Console.WriteLine("Blog content =>" + item.BlogContext);

            }
        }
        public void Create()
        {
            Console.Write("Enter Blog Title :");
            string title = Console.ReadLine()!;

            Console.Write("Enter Blog Author :");
            string author = Console.ReadLine()!;

            Console.Write("Enter Blog content :");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContext = content
            };
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContext]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContext
           ,0)";
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                int result = db.Execute(query, blog);
                Console.WriteLine(result > 0 ? "saving success" : "Failed");
            }
        }
        public void Update()
        {

        FirstPage:
            Console.Write("Enter Id :");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("please enter valid id");
                goto FirstPage;
            }
            Console.Write("Update Blog Title :");
            string title = Console.ReadLine()!;

            Console.Write("Update Blog Author :");
            string author = Console.ReadLine()!;

            Console.Write("Update Blog content :");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogId = id,
                BlogAuthor = author,
                BlogTitle = title,
                BlogContext = content
            };
            string query = @"
                            UPDATE [dbo].[Tbl_Blog]
                               SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContext] = @BlogContext
                                  ,[DeleteFlag] = 0
                             WHERE BlogId = @BlogId";
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                int result = db.Execute(query, blog);
                Console.WriteLine(result > 0 ? "updating success" : "Failed");
            }
        }
        public void Delete()
        {
        FirstPage:
            Console.Write("Enter Id :");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("please enter valid id");
                goto FirstPage;
            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("select * from Tbl_Blog where BlogId = @BlogId", new BlogDto { BlogId = id });
                if (item == null)
                {
                    Console.WriteLine("id not found");
                    return;
                }
                string query = @"
                        update Tbl_Blog
                        set DeleteFlag = 1
                        where BlogId = @BlogId ";
                int result = db.Execute(query, new BlogDto { BlogId = id });
                Console.WriteLine( result > 0 ? "Deleting success" : "Failed");
            }
        }
    }
}
