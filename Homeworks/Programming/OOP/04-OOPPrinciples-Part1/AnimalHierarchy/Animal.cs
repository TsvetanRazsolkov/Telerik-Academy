namespace AnimalHierarchy
{
    using System;
    using System.Linq;

    public abstract class Animal : ISound
    {

        private int age;
        private string name;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public int Age
        {
            get { return this.age; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be positive.");
                }
                this.age = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or empty string.");
                }
                this.name = value;
            }
        }

        public Gender Gender
        {
            get { return this.gender; }
            protected set
            {
                this.gender = value;
            }
        }

        public abstract string MakeSound();

        public override string ToString()
        {
            return string.Format("{0} is a {1}-year old {2} {3}\n{0} says {4}!",
                                 this.Name, this.Age, this.Gender, this.GetType().Name, this.MakeSound());
        }

        public static double CalculateAverageAge(Type typeOfAnimal, params Animal[] animals)
        {
            double averageAge = 0;
            if (typeOfAnimal == typeof(Cat))
            {
                averageAge = animals.Where(an => an is Cat)
                                    .Average(an => an.Age);
            }
            else
            {
                averageAge = animals.Where(an => an.GetType() == typeOfAnimal)
                                    .Average(an => an.Age);
            }          

            return averageAge;
        }
    }
}
