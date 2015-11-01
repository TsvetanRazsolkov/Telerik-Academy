namespace _06.Command
{
    /// <summary>
    /// The Receiver class
    /// </summary>
    public class Figure : IMovable
    {
        public Figure(int x, int y)
        {
            this.XCoordinate = x;
            this.YCoordinate = y;
        }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public void Move(int newX, int newY)
        {
            this.XCoordinate = newX;
            this.YCoordinate = newY;
        }
    }
}
