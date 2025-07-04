// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using WZHDotNetTrainingBatch2.ConsoleApp;
using WZHDotNetTrainingBatch2.Database;
using AMM = WZHDotNetTrainingBatch2.Database.AppDbContextModels.AppDbContext;

Console.WriteLine("Hello, World!");
//EfCoreExample efCoreExample = new EfCoreExample();
//efCoreExample.Read();
//efCoreExample.Edit();
//efCoreExample.Update();
//efCoreExample.Delete(); 

// AMM db= new AMM();
//var lst = db.TblBlogs.ToList();
//foreach (var item in lst)
//{
//    Console.WriteLine("Blog Id =>" + item.BlogId);
//    Console.WriteLine("Blogtitle =>" + item.BlogTitle);
//    Console.WriteLine("Blogauthor =>" + item.BlogAuthor);
//    Console.WriteLine("Blogcontext => " + item.BlogContext);
//}
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit();
//adoDotNetExample.Create();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();
DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit();
//dapperExample.Create();
//dapperExample.Update();
dapperExample.Delete();

Console.ReadLine();