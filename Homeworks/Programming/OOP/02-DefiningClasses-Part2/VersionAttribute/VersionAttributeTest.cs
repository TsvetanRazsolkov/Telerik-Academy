namespace VersionAttribute
{
    using System;
    using System.Reflection;

    [Version("Version 2.11")]
    class VersionAttributeTest
    {
        static void Main()
        {
            Type type = typeof(VersionAttributeTest);
            
            var attributes = type.GetCustomAttributes<VersionAttribute>(false);
            foreach (var item in attributes)
            {
                Console.WriteLine("{0} - {1}", item.Version, type.Name);
            }
        }
    }
}
