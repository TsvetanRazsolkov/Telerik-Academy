namespace _08.Visitor
{
    using DocumentStrucuture;

    public interface IVisitor
    {
        void Visit(PlainText docPart);

        void Visit(BoldText docPart);

        void Visit(Hyperlink docPart);
    }
}
