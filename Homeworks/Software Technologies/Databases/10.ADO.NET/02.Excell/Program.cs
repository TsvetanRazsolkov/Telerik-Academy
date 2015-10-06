namespace _02.Excell
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class Program
    {
        public static void Main()
        {
            string conectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\Students.xlsx;Extended Properties='Excel 12.0 xml;HDR=Yes';";
            var con = new OleDbConnection(conectionString);

            con.Open();

            using (con)
            {
                var excelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                Console.WriteLine("TASK 6: Reading data from Excell file:");
                ReadFromExcellFile(con, sheetName);

                Console.WriteLine();
                Console.WriteLine("TASK 7: Appending data to excell file:");
                AppendToExcellFile(con, sheetName, "Me", -25.0);
            }
        }

        private static void ReadFromExcellFile(OleDbConnection con, string sheetName)
        {
            var excellCommand = new OleDbCommand(@"SELECT * FROM [" + sheetName + "]", con);

            using (var reader = excellCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];

                    Console.WriteLine(name + " - " + score);
                }
            }
        }

        private static void AppendToExcellFile(OleDbConnection con, string sheetName, string name, double score)
        {
            var excellCommand = new OleDbCommand("INSERT INTO [" + sheetName + @"] 
                                                 VALUES(@name, @score)", con);

            excellCommand.Parameters.AddWithValue("@name", name);
            excellCommand.Parameters.AddWithValue("@score", score);

            try
            {
                excellCommand.ExecuteNonQuery();

                Console.WriteLine("Row inserted successfully.");
            }
            catch (OleDbException exception)
            {
                Console.WriteLine("SQL Error occured: " + exception);
            }
        }        
    }
}
