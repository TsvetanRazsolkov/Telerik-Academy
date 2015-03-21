namespace AnimalHierarchy
{
    public class Tomcat : Cat
    {
        private const Gender gender = Gender.Male;

        public Tomcat(string name, int age) : base(name, age, gender)
        {
        }

        public override string MakeSound()
        {
            return "Mrrr";
        }
    }
}
