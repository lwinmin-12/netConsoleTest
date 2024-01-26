using System;
using System.Data;
using System.Data.SqlClient;

namespace netConsoleTest.AdoDotNetExample
{
	public class AdoDotNetExample
	{
		public void Run ()
		{
            // Read();
            // Edit(1);
            // Create("gg" ,"bb" , "cc");
            // Update(100 ,"cc" ,"dd" , "gg");
            Drop(100);

		}

		private static void Read ()
		{
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "netConsole",
                UserID = "sa",
                Password = "Asdffdsa4580"
            };

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Opened");

            string query = "SELECT [Blog_Id],[Blog_Title],[Blog_Author],[Blog_Content] FROM Blog";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

            DataTable dt = new DataTable();


            sqlDataAdapter.Fill(dt);

  
            connection.Close();
            Console.WriteLine("Connection Closed");

        }
        private static void Edit (int id)
		{
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "netConsole",
                UserID = "sa",
                Password = "Asdffdsa4580"
            };

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Opened");

            string query = "SELECT [Blog_Id],[Blog_Title],[Blog_Author],[Blog_Content] FROM Blog WHERE Blog_Id=@Blog_Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Blog_Id" , id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

            DataTable dt = new DataTable();


            sqlDataAdapter.Fill(dt);

  
            connection.Close();
            Console.WriteLine("Connection Closed");

            if(dt.Rows.Count == 0){
                Console.WriteLine("No data not found."); 
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"Blog Id: {row["Blog_Id"]}");
                Console.WriteLine($"Blog Title: {row["Blog_Title"]}");
                Console.WriteLine($"Blog Author: {row["Blog_Author"]}");
                Console.WriteLine($"Blog Content: {row["Blog_Content"]}");
                Console.WriteLine();
            }

        }

        private static void Create (string title , string author , string content) {
             SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "netConsole",
                UserID = "sa",
                Password = "Asdffdsa4580"
            };

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Opened");

            string query = "INSERT INTO Blog ([Blog_Id],[Blog_Title],[Blog_Author],[Blog_Content]) VALUES (@Blog_Id,@Blog_Title,@Blog_Author,@Blog_Author)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Blog_Id" , 100 );
            command.Parameters.AddWithValue("Blog_Title" , title );
            command.Parameters.AddWithValue("Blog_Author" , author );
            command.Parameters.AddWithValue("Blog_Content" , content );
            int result = command.ExecuteNonQuery();

  
            connection.Close();

            string message =  result > 0 ? "saving successful" : "saving faild";

            Console.WriteLine(message);
        }
    
        private static void Update (int id ,string title , string author , string content) {
             SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "netConsole",
                UserID = "sa",
                Password = "Asdffdsa4580"
            };

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Opened");

            string query = "UPDATE Blog SET [Blog_Title]=@Blog_Title,[Blog_Author]=@Blog_Author,[Blog_Content]=@Blog_Content WHERE Blog_Id = @Blog_Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Blog_Id" , id );
            command.Parameters.AddWithValue("Blog_Title" , title );
            command.Parameters.AddWithValue("Blog_Author" , author );
            command.Parameters.AddWithValue("Blog_Content" , content );
            int result = command.ExecuteNonQuery();

  
            connection.Close();

            string message =  result > 0 ? "update successful" : "update faild";

            System.Console.WriteLine(message);
        }

        private static void Drop (int id ) {
             SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "netConsole",
                UserID = "sa",
                Password = "Asdffdsa4580"
            };

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Opened");

            string query = "DELETE FROM Blog WHERE Blog_Id = @Blog_Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Blog_Id" , id );
            int result = command.ExecuteNonQuery();

  
            connection.Close();

            string message =  result > 0 ? "delete successful" : "delete faild";

            Console.WriteLine(message);
        }
    
    
    }
}

