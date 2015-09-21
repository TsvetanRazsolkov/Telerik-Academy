namespace _06.Command
{
    using System;

    /// <summary>
    /// The Client class
    /// </summary>
    public class Example
    {
        public static void Main()
        {
            Figure figure = new Figure(0, 0);
            Console.WriteLine("Figure corrdinates: {0}, {1}", figure.XCoordinate, figure.YCoordinate);

            Player player = new Player();

            player.ExecuteCommand(new MoveCommand(figure, 5, 5));
            Console.WriteLine("Figure corrdinates: {0}, {1}", figure.XCoordinate, figure.YCoordinate);

            player.ExecuteCommand(new MoveCommand(figure, 15, 25));
            Console.WriteLine("Figure corrdinates: {0}, {1}", figure.XCoordinate, figure.YCoordinate);

            player.Undo();
            Console.WriteLine("Figure corrdinates: {0}, {1}", figure.XCoordinate, figure.YCoordinate);
        }
    }
}
