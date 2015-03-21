namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : Person
    {
        private List<Discipline> disciplines;

        public Teacher( string name, params Discipline[] disciplines) : base(name)
        {
            this.disciplines = new List<Discipline>(disciplines);
        }

        public List<Discipline> Disciplines
        {
            get { return new List<Discipline>(this.disciplines); }
        }        

        public void AddDiscipline(Discipline discipline)
        {
            if (discipline == null)
            {
                throw new NullReferenceException();
            }
            this.disciplines.Add(discipline);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Name: " + this.Name);
            result.AppendLine("Comment: " + this.Comment);
            result.AppendLine("Disciplines: ");
            result.AppendLine(string.Join(Environment.NewLine, this.Disciplines));

            return result.ToString();
        }
    }
}
