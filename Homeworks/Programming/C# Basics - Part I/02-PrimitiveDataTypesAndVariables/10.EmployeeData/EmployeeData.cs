using System;

class EmployeeData
{
    static void Main()
    {
        /* A marketing company wants to keep record of its employees. Each record would have the following characteristics:
        First name
        Last name
        Age (0...100)
        Gender (m or f)
        Personal ID number (e.g. 8306112507)
        Unique employee number (27560000…27569999)
        Declare the variables needed to keep the information for a single employee using appropriate primitive data types. Use descriptive names. Print the data at the console. */

        string firstName = "Ivan";
        string lastName = "Ivanov";
        byte age = 30;
        char gender = 'M';
        long IDnumber = 1010101010L;
        int uniqueNumber = 27562100;

        Console.WriteLine("{0} {1}\n{2} years old, {3}\nID number: {4}\nUnique employee number: {5}", firstName, lastName, age, gender, IDnumber, uniqueNumber);
    }
}
