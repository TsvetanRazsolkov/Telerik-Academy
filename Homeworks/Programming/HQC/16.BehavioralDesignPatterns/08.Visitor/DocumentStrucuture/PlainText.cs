namespace _08.Visitor.DocumentStrucuture
{
    public class PlainText : DocumentPart
    {
        public PlainText(string text) : base(text)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
