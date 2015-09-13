namespace _02.Builder
{
    using Builders;
    using Directors;

    public class Example
    {
        public static void Main()
        {
            var constructor = new WorkerConstructor();

            var academyStudent = constructor.Construct(new ProgrammerBuilder());
            System.Console.WriteLine(academyStudent);

            var ohBoli = constructor.Construct(new DoctorBuilder());
            System.Console.WriteLine(ohBoli);
        }
    }
}
