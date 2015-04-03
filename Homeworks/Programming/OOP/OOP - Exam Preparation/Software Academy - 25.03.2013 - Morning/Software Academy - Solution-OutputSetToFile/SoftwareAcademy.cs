using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.IO;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public abstract class Course : ICourse
    {
        private string name;
        private ICollection<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
        }

        public string  Name
        {
            get { return this.name; }
            set
            {
                ValidateStringInput(value);
                this.name = value;
            }
        }

        public ITeacher Teacher { get; set; }

        public ICollection<string> Topics
        {
            get { return new List<string>(this.topics); }
        }

        public void AddTopic(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentException("Topic can not be empty string or null.");
            }
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0}: Name={1}; ", this.GetType().Name, this.Name);
            if (this.Teacher != null)
            {
                output.AppendFormat("Teacher={0}; ", this.Teacher.Name);
            }
            if (this.Topics.Count != 0)
            {
                output.AppendFormat("Topics=[{0}]; ", string.Join(", ", this.Topics));
            }

            return output.ToString();
        }

        public void ValidateStringInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("String input can not be null or empty string.");
            }
        }
    }

    public class LocalCourse : Course, ICourse, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                ValidateStringInput(value);
                this.lab = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Lab={0}", this.Lab);
        }
    }

    public class OffsiteCourse : Course, ICourse, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                ValidateStringInput(value);
                this.town = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Town={0}", this.Town);
        }
    }
    
    public class Teacher : ITeacher
    {
        private string name;
        private ICollection<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Teacher name can not be null or empty string.");
                }
                this.name = value;
            }
        }

        public ICollection<ICourse> Courses
        {
            get { return new List<ICourse>(this.courses); }
        }

        public void AddCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Can not add to a teacher course that is NULL.");
            }
            this.courses.Add(course);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("Teacher: Name={0}; ", this.Name);
            if (this.Courses.Count != 0)
            {
                var coursesNames = this.Courses.Select(c => c.Name);
                output.AppendFormat("Courses=[{0}]", string.Join(", ", coursesNames));
            }

            string result = output.ToString().TrimEnd(';', ' ');

            return result;
        }
    }    

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            FileStream fs = new FileStream("..\\..\\Test.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            Console.SetOut(sw);
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
            sw.Close();
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
