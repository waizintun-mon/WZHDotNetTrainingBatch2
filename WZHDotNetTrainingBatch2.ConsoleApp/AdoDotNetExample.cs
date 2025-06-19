using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZHDotNetTrainingBatch2.ConsoleApp
{
    public class AdoDotNetExample
    {// we can use any methods this one  such CRUD

        // press ctrl r,r to rename
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void Read()
        {
            // SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            // sqlConnectionStringBuilder.DataSource = "DESKTOP-NFOPO25";
            //sqlConnectionStringBuilder.DataSource = "(local";
            //sqlConnectionStringBuilder.DataSource = "Desktop name";
            //sqlConnectionStringBuilder.InitialCatalog = "DotNetTrainingBatch2";
            //sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = "sasa@123";
            //sqlConnectionStringBuilder.TrustServerCertificate = true;




            //can write two ways but inside doubleqoute we can write anything  it is not best practice
            //SqlConnection connection = new SqlConnection("Data Source =.; Initial Catalog = DotNetTrainingBatch2; User ID = sa; Password = sasa@123");
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("connection is opening....");
            connection.Open();
            Console.WriteLine("connection opened!");

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Console.WriteLine("connection is closing...");
            connection.Close(); // can cause connection time out that's why we need to close
            Console.WriteLine("connection is closed!....");

            //DataSet one or more tables can store
            //DataTable 
            //Data Row
            //Data Column

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine("blogid =>"+ row["BlogId"]);// we don't use index can cause place error
                Console.WriteLine("blogtitle =>" + row["BlogTitle"]);
                Console.WriteLine("blogauthor =>" + row["BlogAuthor"]);
                Console.WriteLine("blogcontent =>" + row["BlogContent"]);
            }
        }

        public void Edit()
        {
            Console.Write("Enter id:");
            string blogId = Console.ReadLine()!;
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
           // string query = $"select * from Tbl_Blog where BlogId = {blogId} ";//or 1=1"; can cause sql injection avoid this way
            string query = $"select * from Tbl_Blog where BlogId = @BlogId"; //variable @
            SqlCommand cmd = new SqlCommand(query,connection);
           //cmd.Parameters.AddWithValue("@BlogId", blogId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)// double tap
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine("blogid =>" + row["BlogId"]);// we don't use index can cause place error
                Console.WriteLine("blogtitle =>" + row["BlogTitle"]);
                Console.WriteLine("blogauthor =>" + row["BlogAuthor"]);
                Console.WriteLine("blogcontent =>" + row["BlogContent"]);
            }   


        }

        public void Create()
        {
            Console.Write("Enter Title:");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author:");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content:");
            string content = Console.ReadLine()!;

            //       string query = $@"INSERT INTO [dbo].[Tbl_Blog]
            //      ([BlogTitle]
            //      ,[BlogAuthor]
            //      ,[BlogContent])
            //VALUES
            //      ('{title}'
            //      ,'{author}'
            //      ,'{content}')"; can cause sql conjection 

            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@Title
           ,@Author
           ,@Content)";// this is secure ways


            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title",title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);// the best way to write with parameters

            int result = cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result > 0 ? "insert successed" : "insert failed");
        
        
        }
    }
}
