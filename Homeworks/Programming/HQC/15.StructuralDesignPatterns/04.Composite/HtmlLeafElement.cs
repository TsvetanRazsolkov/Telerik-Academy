namespace _04.Composite
{
    public class HtmlLeafElement : HtmlElementComponent
    {
        public HtmlLeafElement(string type, string textContent) : base(type, textContent)
        {
        }

        public override void Render()
        {
            if (this.Parent != null)
            {
                this.Indentation = this.Parent.Indentation + 4;
            }

            System.Console.WriteLine("{0}<{1}>{2}</{1}>", new string(' ', this.Indentation), this.Type, this.TextContent);
        }

    }
}
