using System.Data;
using System.Data.SqlClient;
using netConsoleTest.AdoDotNetExample;
Console.WriteLine("Hello, World!");
// SqlConnectionStringBuilder sqlConnectionStringBuilder =  new SqlConnectionStringBuilder();
// sqlConnectionStringBuilder.DataSource = ".";
// sqlConnectionStringBuilder.InitialCatalog =  "netConsole";
// sqlConnectionStringBuilder.UserID = "sa";
// sqlConnectionStringBuilder.Password ="Asdffdsa4580";

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

adoDotNetExample.Run();

// Console.WriteLine()