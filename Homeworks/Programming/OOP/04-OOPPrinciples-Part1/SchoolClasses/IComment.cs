namespace SchoolClasses
{
    public interface IComment
    {
        string Comment { get; }
        void AddComment(string comment);
        void DeleteComment();
    }
}
