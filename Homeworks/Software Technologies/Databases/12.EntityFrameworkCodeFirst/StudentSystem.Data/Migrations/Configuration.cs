namespace StudentSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true; // so that we can change the model at this stage;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            context.Students.AddOrUpdate(
                s => s.Number,
                new Student
            {
                Name = "Seeded pesho",
                Number = 654321,
                Gender = GenderType.NotSpecified
            },
            new Student
            {
                Name = "Seeded Mariika",
                Number = 111111,
                Gender = GenderType.Female
            });
        }
    }
}
