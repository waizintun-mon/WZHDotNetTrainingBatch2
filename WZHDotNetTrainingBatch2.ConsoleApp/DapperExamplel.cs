using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace WZHDotNetTrainingBatch2.ConsoleApp
{
    public class DapperExample
    {
        //Read
        //Edit     one group

        // Create
        //Update
        //
        //  DataSource = ".",
        // InitialCatalog = "DotNetTrainingBatch2",
        //  UserID = "sa",
        //  Password = "sasa@123",
        // TrustServerCertificate = true

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".", //servername
            InitialCatalog = "DotNetTrainingBatch2",// Database Name
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                //  var lst = db.Query<BlogDto>("select * from tbl_blog ").ToList();// query and execute can't usewithout dapper BlogDto we want to avoid Dynamic
                //we can store anything in dynamic / over var ctrl .
                List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog ").ToList();

                foreach (var item in lst)
                {
                    Console.WriteLine("blogid =>" + item.BlogId);
                    Console.WriteLine("blogtitle =>" + item.BlogTitle);
                    Console.WriteLine("blogauthor =>" + item.BlogAuthor);
                    Console.WriteLine("blogcontent =>" + item.BlogContent);
                }
            }
        }

        public void Edit()
        {
             First:
            //object a = new {BlogId = 1, Blog title = "mgmg"}
            Console.Write("Enter Id:");// valid id 
            //  int id = Convert.ToInt32(Console.ReadLine());
            string input = Console.ReadLine()!;
          bool isInt =  int.TryParse(input, out int id);
           // if (isInt == false)
           if(!isInt )
            {
                Console.WriteLine("Invalid Id, please enter valid Id");
                //  return;
                goto First;// to ask valid id again
            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("select * from Tbl_Blog where BlogId = @BlogId", new BlogDto { BlogId = id });
                if (item == null)
                {
                    Console.WriteLine("Blog not found with Id" + id);
                    return;
                }
                Console.WriteLine("blogid =>" + item.BlogId);
                Console.WriteLine("blogtitle =>" + item.BlogTitle);
                Console.WriteLine("blogauthor =>" + item.BlogAuthor);
                Console.WriteLine("blogcontent =>" + item.BlogContent);

            }
        }
        

        public void Create()
        {
            Console.WriteLine("Title :");
            string title = Console.ReadLine()!;
            Console.WriteLine("Author :");
            string author = Console.ReadLine()!;
            Console.WriteLine("Content :");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content  

            };
            string query = @"
                INSERT INTO [dbo].[Tbl_Blog]
                           ([BlogTitle]
                           ,[BlogAuthor]
                           ,[BlogContent])
                     VALUES
                           (@BlogTitle
                           ,@BlogAuthor
                           ,@BlogContent)";
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
              int result =  db.Execute(query, blog);
                Console.WriteLine(result >0? "saving successed" : "failed  ");
            }
        }
        public void Update()
        {
        FirstPage:
            Console.WriteLine("Enter Id :");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("please enter a valid Id");
                goto FirstPage;
            }

            Console.WriteLine(" Update Title :");
            string title = Console.ReadLine()!;
            Console.WriteLine(" Update Author :");
            string author = Console.ReadLine()!;
            Console.WriteLine(" Update Content :");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogId = id,
                BlogTitle= title,
                BlogAuthor= author, 
                BlogContent= content    
            };
            string query = @"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor 
                              ,[BlogContent] = @BlogContent
                         WHERE BlogId = @BlogId
                        ";
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString)) 
            {
                db.Open();
              int result =  db.Execute(query, blog);
                Console.WriteLine(result>0 ? "updating success": "updating failed" );
            }
        }

        public void Delete()
        {
        FirstPage:
            Console.WriteLine("Enter Id");
            string input = Console.ReadLine()!;
           bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine(  "invalid id please enter a valid id");
                goto FirstPage;
            }
            using(IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            { 
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("select * from Tbl_Blog where BlogId = @BlogId", new BlogDto { BlogId = id });
                if (item == null)
                {
                    Console.WriteLine("could not found id" + id);
                    return;
                }
                string query = ("delete from tbl_blog where BlogId = @BlogId");
               var result = db.Execute(query, new BlogDto { BlogId = id });
                Console.WriteLine( result>0? "Delete Successful":"Delete Failed" );

            }
        }
    }
}
