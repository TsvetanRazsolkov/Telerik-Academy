namespace StudentSystem.Data
{
    using System.Data.Entity;

    using Models;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext() :base("StudentSystemDb")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<Material> Materials { get; set; }
    }
}
