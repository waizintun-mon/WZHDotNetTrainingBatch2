using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZHDotNetTrainingBatch2.ConsoleApp
{
    public class EfCoreExample
    {
        public void Read()

        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs.
                Where (x=>x.DeleteFlag==false).ToList();// should do filter first then List
            foreach (var item in lst)
            { 
                Console.WriteLine("Blog Id =>"+ item.BlogId );
                Console.WriteLine("Blogtitle =>" + item.BlogTitle);
                Console.WriteLine("Blogauthor =>" + item.BlogAuthor);
                Console.WriteLine("Blogcontext => " + item.BlogContext);
            }
        }
        public void Edit()
        {
            Console.Write("Enter Id.." );
           string input = Console.ReadLine()!;
           bool isInt = int.TryParse(input, out int id);
            if (!isInt) return;

            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                   . Where(x => x.DeleteFlag == false).
                   FirstOrDefault(x => x.BlogId ==id);
            if (item is null) return;
            Console.WriteLine(  item.BlogId); 
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContext);

        }
        public void Update()
        {
            Console.Write("Enter Id .." );
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt) return;

            Console.Write("update title" );
            string title = Console.ReadLine()!;
            Console.Write( "update author");
            string author = Console.ReadLine()!;
            Console.Write("update context");
            string context = Console.ReadLine()!;

            bool isExit = FindId(id);
            if (!isExit) return;
            //update process
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.
                    Where(x => x.DeleteFlag == false).
                    FirstOrDefault(x => x.BlogId==id);
           // item = Console.ReadLine("")
           item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContext = context;
           var result = db.SaveChanges();
            Console.WriteLine(result>0 ? "update succrssful": "update failed");
        }
        public void Delete()
        {
            Console.Write("Enter Id ..");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            if (!isInt) return;

            bool isExit = FindId(id);
            if (!isExit) return;
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.FirstOrDefault(y => y.BlogId==id);
            // db.Blogs.Remove(item!);
            item.DeleteFlag = true;
            var result = db.SaveChanges();
            Console.WriteLine( result > 0 ? "delete successful": "delete failed");
        }

        private bool FindId(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.Where(x => x.DeleteFlag == false).FirstOrDefault(x => x.BlogId == id);
            return item != null;

        }

    }
}
