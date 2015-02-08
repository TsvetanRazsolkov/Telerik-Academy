using System;

class StringsAndObjects
{
    static void Main()
    {
        //Declare two string variables and assign them with Hello and World. Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval between).Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).

        string hello = "Hello";
        string world = "World!";
        object dataContainer = hello + ' ' + world;
        string greeting = (string)dataContainer;
        Console.WriteLine("{0}\n{1}\n{2}\n{3}", hello, world, dataContainer, greeting);
    }
}
