namespace PersonClass
{
    using System;

    public class PersonClassTest
    {
        public static void Main()
        {
            Person pesho = new Person("Pesho");
            Console.WriteLine(pesho);

            Person petkan = new Person("Petkan", 20);
            Console.WriteLine(petkan);
        }
    }
}
