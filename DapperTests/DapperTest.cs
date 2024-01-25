using System.Data;
using System.Data.SqlClient;
using Dapper;
using netConsoleTest.Models;

namespace netConsoleTest.DapperTests
{
    public class DapperTest
    {

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "netConsole",
            UserID = "sa",
            Password = "Asdffdsa4580"
        };
        public void Run (){ 
            // Read();
            // Edit(1);
            // Create("gg" , "gg" , "gg");
            // Update(100 , "bb" , "cc" , "ee");
            Drop(100);

        }
        private void Read () {
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            string query = "SELECT [Blog_Id],[Blog_Title],[Blog_Author],[Blog_Content] FROM Blog";
            List<BlogDataModel> lst = db.Query<BlogDataModel>(query).ToList();

            foreach(BlogDataModel ea in lst) {
                Console.WriteLine(ea.Blog_Id);
                Console.WriteLine(ea.Blog_Title);
                Console.WriteLine(ea.Blog_Author);
                Console.WriteLine(ea.Blog_Content);

            }

        }
        private void Edit (int id ) {
            string query = "SELECT [Blog_Id],[Blog_Title],[Blog_Author],[Blog_Content] FROM Blog WHERE Blog_Id=@Blog_Id";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            BlogDataModel? item = db.Query<BlogDataModel>(query , new BlogDataModel {Blog_Id = id}).FirstOrDefault();
            if(item is null) {
                Console.WriteLine("No data found");
                return;
            }

            Console.WriteLine(item.Blog_Id);
            Console.WriteLine(item.Blog_Title);
            Console.WriteLine(item.Blog_Author);
            Console.WriteLine(item.Blog_Content);
        }

        private void Create (string title , string author , string content) {
            string query = "INSERT INTO Blog ([Blog_Id],[Blog_Title],[Blog_Author],[Blog_Content]) VALUES (@Blog_Id,@Blog_Title,@Blog_Author,@Blog_Author)";
            BlogDataModel blog = new BlogDataModel{
                Blog_Id = 100,
                Blog_Title = title,
                Blog_Author = author,
                Blog_Content = content
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query ,  blog);

            string message =  result > 0 ? "saving successful" : "saving faild";
            Console.WriteLine(message);
        }

        private void Update (int id ,string title , string author , string content) {
            string query = "UPDATE Blog SET [Blog_Title]=@Blog_Title,[Blog_Author]=@Blog_Author,[Blog_Content]=@Blog_Content WHERE Blog_Id = @Blog_Id";
             BlogDataModel blog = new BlogDataModel{
                Blog_Id = id,
                Blog_Title = title,
                Blog_Author = author,
                Blog_Content = content
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query , blog);

            string message =  result > 0 ? "Update successful" : "Update faild";
            Console.WriteLine(message);
        }

        private void Drop (int id ) {
            // string query = "UPDATE Bxlog SET [Blog_Title]=@Blog_Title,[Blog_Author]=@Blog_Author,[Blog_Content]=@Blog_Content WHERE Blog_Id = @Blog_Id";
            string query = "DELETE FROM Blog WHERE Blog_Id = @Blog_Id";
             BlogDataModel blog = new BlogDataModel{
                Blog_Id = id,
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query , blog);

            string message =  result > 0 ? "delete successful" : "delete faild";
            Console.WriteLine(message);
        }
    }
} 