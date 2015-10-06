namespace _03.MySQL
{
    using System;
    using MySql.Data.MySqlClient;

    public class Program
    {
        public static void Main()
        {
            string yourPassword = string.Empty; // Enter your password if necessary;

            // Execute the script library.sql to create the database if you allready don't have it.
            string connectionString = "Server=localhost;Database=library;Uid=root;Pwd=" + yourPassword;

            var con = new MySqlConnection(connectionString);
            con.Open();

            using (con)
            {
                AddBook(con, "New book", "John Hohn", DateTime.Now, 123456789);
                AddBook(con, "Another book", "Pesho", DateTime.Now, 987654321);
                
                ListAllBooks(con);

                FindBook(con, "New book");
            }
        }

        private static void ListAllBooks(MySqlConnection con)
        {
            var mySqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN FROM Books", con);

            try
            {
                using (var reader = mySqlCommand.ExecuteReader())
                {
                    Console.WriteLine("All books:");
                    while (reader.Read())
                    {
                        Console.WriteLine("Title - {0}; Author - {1}; PublishDate - {2}; ISBN - {3}",
                            reader["Title"], reader["Author"], reader["PublishDate"], reader["ISBN"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while listing all books " + ex);
            }
        }

        private static void FindBook(MySqlConnection con, string title)
        {
            var sqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN FROM Books WHERE Title = @title", con);
            sqlCommand.Parameters.AddWithValue("@title", title);

            try
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    Console.WriteLine("Found books:");
                    while (reader.Read())
                    {
                        Console.WriteLine("Title- {0}; Author- {1}; PublishDate- {2}; ISBN- {3}",
                            reader["Title"], reader["Author"], reader["PublishDate"], reader["ISBN"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching for book " + ex);
            }
        }

        private static void AddBook(MySqlConnection con, string title, string author, DateTime publishDate, int isbn)
        {
            var mySqlCommand = new MySqlCommand("INSERT INTO Books (Title, Author, PublishDate, ISBN) VALUES (@title, @author, @publishDate, @isbn)", con);

            mySqlCommand.Parameters.AddWithValue("@title", title);
            mySqlCommand.Parameters.AddWithValue("@author", author);
            mySqlCommand.Parameters.AddWithValue("@publishDate", publishDate);
            mySqlCommand.Parameters.AddWithValue("@isbn", isbn);

            try
            {
                mySqlCommand.ExecuteNonQuery();
                Console.WriteLine("Book {0} by {1} added.", title, author);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error while inserting new book : " + exception);
            }            
        }
    }
}
