namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private List<Class> classes;

        public School(params Class[] classes)
        {
            this.classes = new List<Class>(classes);
        }

        public List<Class> Classes
        {
            get { return new List<Class>(this.classes); }
        }

        public void AddClass(Class classToAdd)
        {
            this.classes.Add(classToAdd);
        }

        public void RemoveClass(Class classToRemove)
        {
            this.classes.Remove(classToRemove);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.Classes);
        }
    }
}
