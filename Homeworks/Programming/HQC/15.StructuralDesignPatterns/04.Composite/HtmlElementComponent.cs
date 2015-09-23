namespace _04.Composite
{
    public abstract class HtmlElementComponent
    {
        public HtmlElementComponent(string type, string textContent)
        {
            this.Type = type;
            this.TextContent = textContent;
            this.Indentation = 0;
        }

        public HtmlElementComponent Parent { get; set; }

        public string Type { get; set; }

        public int Indentation { get; set; }

        public string TextContent { get; set; }

        public abstract void Render();
    }
}
