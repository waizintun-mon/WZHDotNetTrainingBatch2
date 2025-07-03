using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WZHDotNetTrainingBatch2.ConsoleApp
{
    public class AdoDotNetExample
    {
        //ctrl RR
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID ="sa",
            Password = "sa@@123",
            TrustServerCertificate = true,
        };

           public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = "select * from Tbl_Blog where DeleteFlag =0";
             SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt); //execute to store the data need to build first dt
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine("Blog id=>" + row["BlogId"]);
                Console.WriteLine("Blog title =>" + row["BlogTitle"]);
                Console.WriteLine("Blog author =>" + row["BlogAuthor"]);
                Console.WriteLine("Blog content =>" + row["BlogContext"]);
            }                         
        }

        public void Edit()
        {
        FirstPage:
            Console.Write("Enter Id");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("Please enter valid Id");
                goto FirstPage;
            }
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = $"select * from Tbl_Blog where BlogId = @BlogId where DeleteFlag =0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Blogid", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt); //execute to store the data need to build first dt
            connection.Close();

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("no data found");
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine("Blog id=>" + row["BlogId"]);
                Console.WriteLine("Blog title =>" + row["BlogTitle"]);
                Console.WriteLine("Blog author =>" + row["BlogAuthor"]);
                Console.WriteLine("Blog content =>" + row["BlogContext"]);
            }
        }
        public void Create()
        {
       
            Console.Write( "Enter Blog Title :");
            string title = Console.ReadLine()!;

            Console.Write("Enter Blog Author :" );
            string author = Console.ReadLine()!;

            Console.Write("Enter Blog content :");
            string content = Console.ReadLine()!;

            // multiple lines support "@" dynamic  '$"
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContext]
           ,[DeleteFlag])
     VALUES
           (@Title
           ,@Author
           ,@Content
          ,0)";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);
          //  cmd.Parameters.AddWithValue("@DeleteFlag", false);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine( result> 0 ? "create success" : "failed");
        }
        public void Update()
        {
        FirstPage:
            Console.Write("Enter Id");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("Please enter valid Id");
                goto FirstPage;
            }

            Console.Write("Update Blog Title :");
            string title = Console.ReadLine()!;

            Console.Write("Update Blog Author :");
            string author = Console.ReadLine()!;

            Console.Write("Update Blog content :");
            string content = Console.ReadLine()!;

            string query = $@"UPDATE [dbo].[Tbl_Blog]
                   SET [BlogTitle] = @Title
                      ,[BlogAuthor] = @Author
                      ,[BlogContext] =@Content
                      ,[DeleteFlag] = 0
                 WHERE BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);
            //  cmd.Parameters.AddWithValue("@DeleteFlag", false);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result > 0 ? "Update success" : "failed");
        }
        public void Delete()
        {
        FirstPage:
            Console.Write("Enter Id");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt)
            {
                Console.WriteLine("Please enter valid Id");
                goto FirstPage;
            }
            string query = $@"
                        update Tbl_Blog
                        set DeleteFlag = 1
                        where BlogId = @BlogId ";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result > 0 ? "Delete success" : "failed");
        }
    }
    }

