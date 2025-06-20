
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using WZHDotNetTrainingBatch2.ConsoleApp;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();

DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit();
//dapperExample.Create();
//dapperExample.Update();
dapperExample.Delete();


Console.ReadKey();

//ADO.NET
//Dapper
//EF Core
