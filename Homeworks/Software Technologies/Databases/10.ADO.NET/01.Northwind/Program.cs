namespace _01.Northwind
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            // The connection string is in the app.config file, if changes to it are necessary to connect.
            string connectionString = GetConnectionStringByName("NorthwindConnectionString");

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            using (con)
            {
                ExecuteTaskOne(con);
                ExecuteTaskTwo(con);
                ExecuteTaskThree(con);
                ExecuteTaskFour(con, "A% massive% tru%ck.", false);
                ExecuteTaskFive(con, "..//..//Images//{0}.jpg");
                ExecuteTaskEight(con);
            }
        }

        /// <summary>
        /// Write a program that retrieves from the Northwind sample database in MS SQL Server
        /// the number of rows in the Categories table.
        /// </summary>
        /// <param name="con">Database connection</param>
        private static void ExecuteTaskOne(SqlConnection con)
        {
            var sqlCommand = new SqlCommand("SELECT COUNT(*) FROM Categories", con);
            int rows = (int)sqlCommand.ExecuteScalar();
            Console.WriteLine("TASK 1: Rows in Categories table = " + rows);
            Console.WriteLine();
        }

        /// <summary>
        /// Write a program that retrieves the name and description of all categories in the Northwind DB.
        /// </summary>
        /// <param name="con">DB connection</param>
        private static void ExecuteTaskTwo(SqlConnection con)
        {
            var sqlCommand = new SqlCommand("SELECT CategoryName, Description FROM Categories", con);
            using (var reader = sqlCommand.ExecuteReader())
            {
                Console.WriteLine("TASK 2: Names and descriptions of Categories:");

                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string categoryDescription = (string)reader["Description"];

                    Console.WriteLine("--{0} -> {1}--", categoryName, categoryDescription);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Write a program that retrieves from the Northwind database all product categories and the names of the products in each category.
        /// Can you do this with a single SQL query (with table join)?
        /// </summary>
        /// <param name="con">DB connection</param>
        private static void ExecuteTaskThree(SqlConnection con)
        {
            var sqlCommand = new SqlCommand(@"SELECT c.CategoryName, p.ProductName
                                              FROM Products p
                                              JOIN Categories c
                                              ON p.CategoryID = c.CategoryID
                                              GROUP BY c.CategoryName, p.ProductName", con);

            using (var reader = sqlCommand.ExecuteReader())
            {
                Console.WriteLine("TASK 3: List of categories and the products in them:");
                while (reader.Read())
                {
                    string category = (string)reader["CategoryName"];
                    string product = (string)reader["ProductName"];

                    Console.WriteLine("--{0} -> {1}--", category, product);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Write a method that adds a new product in the products table in the Northwind database.
        /// Use a parameterized SQL command.
        /// </summary>
        /// <param name="con">DB connection</param>
        /// <param name="productName">Name of product to add</param>
        /// <param name="discontinued">Discontinued or not - boolean value.</param>
        private static void ExecuteTaskFour(
                                            SqlConnection con, string productName, bool discontinued, int? supplierId = null,
                                            int? categoryId = null, string quantityPerUnit = null, decimal? unitPrice = null,
                                            int? unitsInStock = null, int? unitsOnOrder = null, int? reorderLevel = null)
        {
            Console.WriteLine("TASK 4: Adding product {0}.", productName);

            var sqlCommand = new SqlCommand(@"INSERT INTO Products
                                              VALUES(@productName, @supplierId, @categoryId,
                                                    @quantityPerUnit, @unitPrice, @unitsInStock,
                                                    @unitsOnOrder, @reorderLevel, @discontinued)", con);

            sqlCommand.Parameters.AddWithValue("@productName", productName);
            sqlCommand.Parameters.AddWithValue("@discontinued", discontinued);

            var supplierIdParam = new SqlParameter("@supplierId", supplierId);
            if (supplierId == null)
            {
                supplierIdParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(supplierIdParam);

            var categoryIdParam = new SqlParameter("@categoryId", categoryId);
            if (categoryId == null)
            {
                categoryIdParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(categoryIdParam);

            var quantityPerUnitParam = new SqlParameter("@quantityPerUnit", quantityPerUnit);
            if (quantityPerUnit == null)
            {
                quantityPerUnitParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(quantityPerUnitParam);

            var unitPriceParam = new SqlParameter("@unitPrice", unitPrice);
            if (unitPrice == null)
            {
                unitPriceParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(unitPriceParam);

            var unitsInStockParam = new SqlParameter("@unitsInStock", unitsInStock);
            if (unitsInStock == null)
            {
                unitsInStockParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(unitsInStockParam);

            var unitsOnOrderParam = new SqlParameter("@unitsOnOrder", unitsOnOrder);
            if (unitsOnOrder == null)
            {
                unitsOnOrderParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(unitsOnOrderParam);

            var reorderLevelParam = new SqlParameter("@reorderLevel", reorderLevel);
            if (reorderLevel == null)
            {
                reorderLevelParam.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(reorderLevelParam);

            sqlCommand.ExecuteNonQuery();

            Console.WriteLine("Product {0} was added.", productName);
            Console.WriteLine();
        }
        
        /// <summary>
        /// Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
        /// </summary>
        /// <param name="con">DB connection</param>
        private static void ExecuteTaskFive(SqlConnection con, string filePathFormat)
        {
            var sqlCommand = new SqlCommand("SELECT CategoryID, Picture FROM Categories", con);

            Console.WriteLine("TASK 5: Saving pictures from DB to a folder Images in the project directory.");
            using (var reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    byte[] imageByteArray = (byte[])reader["Picture"];

                    // Northwind is initially designed as Access database(MDB) and the images in it
                    // have a 78-byte OLE header, after which the actual image data begins. The SQL version uses
                    // the same images, so to get valid image data we start the stream at index 78.
                    // It should usually be 0 for a SQL database.
                    using (MemoryStream stream = new MemoryStream(imageByteArray, 78, imageByteArray.Length - 78))
                    {
                        using (Image img = Image.FromStream(stream))
                        {
                            img.Save(string.Format(filePathFormat, (int)reader["CategoryID"]));
                        }
                    }
                }
            }

            Console.WriteLine("Images saved.");
            Console.WriteLine();
        }

        /// <summary>
        /// Write a program that reads a string from the console and finds all products that contain this string.
        /// Ensure you handle correctly characters like ', %, ", \ and _.
        /// </summary>
        /// <param name="con">DB connection</param>
        private static void ExecuteTaskEight(SqlConnection con)
        {
            Console.WriteLine("TASK 8: Enter search string for product: ");
            string searchPattern = Console.ReadLine();

            var sqlCommand = new SqlCommand(@"SELECT ProductName
                                              FROM Products
                                              WHERE CHARINDEX(@searchPattern, ProductName) > 0", con);
            
            sqlCommand.Parameters.AddWithValue("@searchPattern", searchPattern);

            Console.WriteLine("Products containg the pattern \"{0}\"", searchPattern);

            using (var reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine((string)reader["ProductName"]);
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Returns the connection string with the specified name from the app.config file.
        /// </summary>
        /// <param name="name">Name of the searched connection string.</param>
        /// <returns>string: the desired connection string</returns>
        private static string GetConnectionStringByName(string name)
        {
            string result = null;

            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
                result = settings.ConnectionString;

            return result;
        }
    }
}
