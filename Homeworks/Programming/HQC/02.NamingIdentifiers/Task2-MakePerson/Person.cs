namespace Task2_MakePerson
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string name, Gender gender, int age) : this()
        {
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public override string ToString()
        {
            string result = this.Name + ", " + this.Age + " years old, " + this.Gender;
            return result;
        }
    }
}
