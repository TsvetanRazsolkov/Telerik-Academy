namespace _06.Command
{
    /// <summary>
    /// The Concrete command class
    /// </summary>
    public class MoveCommand : ICommand
    {
        private readonly IMovable figure;
        private int xCoord;
        private int yCoord;

        public MoveCommand(IMovable figure, int x, int y)
        {
            this.figure = figure;
            this.xCoord = x;
            this.yCoord = y;
        }

        public void Execute()
        {
            this.figure.Move(this.xCoord, this.yCoord);
        }
    }
}
