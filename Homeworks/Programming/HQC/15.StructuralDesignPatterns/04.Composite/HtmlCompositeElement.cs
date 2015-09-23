namespace _04.Composite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HtmlCompositeElement : HtmlElementComponent
    {
        public HtmlCompositeElement(string type, string textContent) : base(type, textContent)
        {
            this.Children = new List<HtmlElementComponent>();
        }

        public ICollection<HtmlElementComponent> Children { get; private set; }

        public void AppendChild(HtmlElementComponent child)
        {
            // Check for null or whatever
            child.Parent = this;
            this.Children.Add(child);
        }

        public override void Render()
        {
            if (this.Parent != null)
            {
                this.Indentation = this.Parent.Indentation + 4;
            }

            string indentation = new string(' ', this.Indentation);

            Console.WriteLine(indentation + "<" + this.Type + ">" + this.TextContent);

            foreach (var child in this.Children)
            {
                child.Render();
            }

            Console.WriteLine(indentation + "</" + this.Type + ">");
        }
    }
}
