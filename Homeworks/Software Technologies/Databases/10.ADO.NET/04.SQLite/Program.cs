namespace _04.SQLite
{
    using System;
    using System.Data.SQLite;

    public class Program
    {
        public static void Main()
        {
            string connectionString = @"Data Source=../../library.sqlite;Version=3;";

            var con = new SQLiteConnection(connectionString);
            con.Open();

            using (con)
            {
                AddBook(con, "New book", "John Hohn", DateTime.Now, 123456789);
                AddBook(con, "Another book", "Pesho", DateTime.Now, 987654321);

                FindBook(con, "New book");

                ListAllBooks(con);
            }
        }

        private static void ListAllBooks(SQLiteConnection con)
        {
            var sqlCommandString = @"SELECT Title, Author, PublishDate, ISBN FROM Books";
            var sqlCommand = new SQLiteCommand(sqlCommandString, con);

            try
            {
                using (var reader = sqlCommand.ExecuteReader())
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

        private static void FindBook(SQLiteConnection con, string title)
        {
            var sqlCommandString = @"SELECT Title, Author, PublishDate, ISBN FROM Books WHERE Title = @title";
            var sqlCommand = new SQLiteCommand(sqlCommandString, con);

            sqlCommand.Parameters.AddWithValue("@title", title);

            try
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    Console.WriteLine("Found books:");
                    while (reader.Read())
                    {
                        Console.WriteLine("Title {0}; Author{1}; PublishDate{2}; ISBN{3}",
                            reader["Title"], reader["Author"], reader["PublishDate"], reader["ISBN"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching for book " + ex);
            }
        }

        private static void AddBook(SQLiteConnection con, string title, string author, DateTime publishDate, int isbn)
        {
            var sqlCommandString = @"INSERT INTO Books (Title, Author, PublishDate, ISBN) VALUES (@title, @author, @publishDate, @isbn)";
            var sqlCommand = new SQLiteCommand(sqlCommandString, con);

            sqlCommand.Parameters.AddWithValue("@title", title);
            sqlCommand.Parameters.AddWithValue("@author", author);
            sqlCommand.Parameters.AddWithValue("@publishDate", publishDate);
            sqlCommand.Parameters.AddWithValue("@isbn", isbn);

            try
            {
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("{0} by {1} added.", title, author);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while inserting new book : " + ex);
            }
        }
    }
}

