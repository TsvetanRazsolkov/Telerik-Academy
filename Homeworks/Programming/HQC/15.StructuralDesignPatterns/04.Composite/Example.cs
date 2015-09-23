namespace _04.Composite
{
    public class Example
    {
        public static void Main()
        {
            var body = new HtmlCompositeElement("body", string.Empty);
            var peshoDiv = new HtmlCompositeElement("div", "Pesho's div");
            var goshoDiv = new HtmlCompositeElement("div", "Gosho's div");

            var goshoSpan = new HtmlLeafElement("span", "Gosho's span");
            var stamatSpan = new HtmlLeafElement("span", "Stamat's span");

            peshoDiv.AppendChild(goshoSpan);
            goshoDiv.AppendChild(stamatSpan);

            body.AppendChild(peshoDiv);
            body.AppendChild(goshoDiv);

            body.Render();
        }
    }
}
