namespace _6.CreateNorthwindTwin
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Text;

    using NorthwindContext;

    public class Program
    {
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                string generatedScript = ((IObjectContextAdapter)db).ObjectContext.CreateDatabaseScript();

                var dbScript = new StringBuilder();
                dbScript.Append("USE NorthwindTwin ");
                dbScript.Append(generatedScript);

                db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "CREATE DATABASE NorthwindTwin");
                db.Database.ExecuteSqlCommand(dbScript.ToString());
            }
        }
    }
}
