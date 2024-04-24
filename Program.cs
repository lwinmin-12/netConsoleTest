using System.Data;
using System.Data.SqlClient;
using netConsoleTest.AdoDotNetExample;
using netConsoleTest.DapperTests;
using netConsoleTest.EFCoreExamples;
using netConsoleTest.HttpClientExamples;
using netConsoleTest.RestClientExamples;
using RestSharp;
Console.WriteLine("Hello, World!");
// SqlConnectionStringBuilder sqlConnectionStringBuilder =  new SqlConnectionStringBuilder();
// sqlConnectionStringBuilder.DataSource = ".";
// sqlConnectionStringBuilder.InitialCatalog =  "netConsole";
// sqlConnectionStringBuilder.UserID = "sa";
// sqlConnectionStringBuilder.Password ="Asdffdsa4580";

// AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

// adoDotNetExample.Run();

// DapperTest dapperTest = new DapperTest();
// dapperTest.Run();


// EFCoreTest eFCoreTest = new EFCoreTest();
// eFCoreTest.Read();

// eFCoreTest.Edit(20);

// eFCoreTest.Create(20, "gg", "gg", "gg");

// Console.WriteLine()

// HttpClientExample httpClientExample = new HttpClientExample();

// await httpClientExample.Run();

RestClientExample restClientExample= new RestClientExample();

await restClientExample.Run();