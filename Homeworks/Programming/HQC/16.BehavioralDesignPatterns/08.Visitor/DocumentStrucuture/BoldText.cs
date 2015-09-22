namespace _08.Visitor.DocumentStrucuture
{
    public class BoldText : DocumentPart
    {
        public BoldText(string text) : base(text)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
