using System;

class PrintCompanyInformation
{
    static void Main()
    {
        // A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. Write a program that reads the information about a company and its manager and prints it back on the console.

        Console.Write("Enter company's name and press ENTER: ");
        string companyName = Console.ReadLine();
        Console.Write("Enter company's address and press ENTER: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Enter company's phone number and press ENTER: ");
        string companyPhone = Console.ReadLine();
        Console.Write("Enter company's fax number and press ENTER: ");
        string companyFax = Console.ReadLine();
        Console.Write("Enter company's web site and press ENTER: ");
        string companyWebSite = Console.ReadLine();
        Console.Write("Enter company's manager first name and press ENTER: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Enter company's manager last name and press ENTER: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Enter company's manager age and press ENTER: ");
        string managerAge = Console.ReadLine();
        Console.Write("Enter company's manager phone number and press ENTER: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("     Company Information:");
        Console.WriteLine(companyName);
        Console.WriteLine("Address: {0}", companyAddress);
        Console.WriteLine("Tel. {0}", companyPhone);
        Console.WriteLine("Fax: {0}", companyFax);
        Console.WriteLine("Web site: {0}", companyWebSite);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", managerFirstName, managerLastName, managerAge, managerPhone);
    }
}