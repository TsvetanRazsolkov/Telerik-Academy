namespace _08.Visitor.DocumentStrucuture
{
    using System.Collections.Generic;

    public class Document
    {
        private ICollection<DocumentPart> parts;

        public Document(ICollection<DocumentPart> parts)
        {
            this.parts = new List<DocumentPart>(parts);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var part in this.parts)
            {
                part.Accept(visitor);
            }
        }
    }
}
