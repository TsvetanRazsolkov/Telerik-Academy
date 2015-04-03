using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace HTMLRenderer
{
	public interface IElement
	{
		string Name { get; }
		string TextContent { get; set; }
		IEnumerable<IElement> ChildElements { get; }
		void AddElement(IElement element);
		void Render(StringBuilder output);
		string ToString();
	}

	public interface ITable : IElement
	{
		int Rows { get; }
		int Cols { get; }
		IElement this[int row, int col] { get; set; }
	}

    public interface IElementFactory
    {
		IElement CreateElement(string name);
		IElement CreateElement(string name, string content);
		ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
		public IElement CreateElement(string name)
		{
            return new HTMLElement(name);
		}

		public IElement CreateElement(string name, string content)
		{
            return new HTMLElement(name, content);
		}

		public ITable CreateTable(int rows, int cols)
		{
            return new HTMLTable(rows, cols);
		}
	}

    public class HTMLElement : IElement
    {
        private string name;
        private string textContent;
        private IList<IElement> childElements;

        public HTMLElement(string name, string content)
        {
            this.Name = name;
            this.TextContent = content;
            this.childElements = new List<IElement>();
        }

        public HTMLElement(string name) : this(name, null)
        {
        }

        public HTMLElement() : this(null, null)
        {            
        }

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public string TextContent
        {
            get { return this.textContent; }
            set { this.textContent = value; }
        }

        public IEnumerable<IElement> ChildElements
        {
            get { return new List<IElement>(this.childElements); }
        }

        public void AddElement(IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Can not add null elements.");
            }
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.AppendFormat("<{0}>", this.Name);
            }
            if (this.TextContent != null)
            {
                string contentToAppend = this.TextContent.Replace("&", "&amp;");
                contentToAppend = contentToAppend.Replace(">", "&gt;");
                contentToAppend = contentToAppend.Replace("<", "&lt;");
                output.Append(contentToAppend);
            }
            foreach (var item in this.ChildElements)
            {
                output.Append(item.ToString());
            }
            if (this.Name != null)
            {
                output.AppendFormat("</{0}>", this.Name);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            Render(output);
            return output.ToString();
        }

    }

    public class HTMLTable : HTMLElement, ITable
    {
        private const string tableName = "table";

        private int rows;
        private int cols;
        private IElement[,] table;

        public HTMLTable(int rows, int cols) : base(tableName, null)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.table = new IElement[this.Rows, this.Cols];
        }

        public int Rows
        {
            get { return this.rows; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Table can not have less than 1 row.");
                }
                this.rows = value;
            }
        }

        public int Cols
        {
            get { return this.cols; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Table can not have less than 1 column.");
                }
                this.cols = value;
            }
        }

        public IElement[,] Table
        {
            get { return this.table; }            
        }

        public IElement this[int row, int col]
        {
            get
            {
                CheckIndices(row, col);
                return this.Table[row, col];
            }
            set
            {
                CheckIndices(row, col);
                if (value == null)
                {
                    throw new ArgumentNullException("Can not null elements to HTMLTable.");
                }
                this.table[row, col] = value;
            }
        }

        public override void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>", this.Name);
            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < this.Cols; col++)
                {
                    if (this.Table[row, col] != null)
                    {
                        output.Append("<td>");
                        output.Append(this.Table[row, col].ToString());
                        output.Append("</td>");
                    }
                }
                output.Append("</tr>");
            }
            output.AppendFormat("</{0}>", this.Name);
        }

        private void CheckIndices(int row, int col)
        {
            if (row >= this.Rows || row < 0)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the table.");
            }
            if (col >= this.Cols || col < 0)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the table.");
            }
        }
    }

    public class HTMLRendererCommandExecutor
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
                  using HTMLRenderer;

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
