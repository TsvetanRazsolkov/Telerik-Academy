namespace _08.Visitor
{
    using System;

    using DocumentStrucuture;

    public class HtmlVisitor : IVisitor
    {
        public string Output { get; private set; }

        public void Visit(PlainText docPart)
        {
            this.Output += (docPart.Text + Environment.NewLine);
        }

        public void Visit(BoldText docPart)
        {
            this.Output += ("<b>" + docPart.Text + "</b>" + Environment.NewLine);
        }

        public void Visit(Hyperlink docPart)
        {
            this.Output += ("<a href=\"" + docPart.Url + "\">" + docPart.Text + "</a>" + Environment.NewLine);
        }
    }
}
