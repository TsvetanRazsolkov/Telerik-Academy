namespace _06.Command
{
    using System.Collections.Generic;

    /// <summary>
    /// The Invoker class
    /// </summary>
    public class Player
    {
        private readonly IList<ICommand> commands = new List<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            this.commands.Add(command);
            command.Execute();
        }

        public void Undo()
        {
            if (this.commands.Count > 1)
            {
                this.commands[this.commands.Count - 2].Execute();
            }
            else
            {
                System.Console.WriteLine("No previous commands to undo.");
            }
        }
    }
}
