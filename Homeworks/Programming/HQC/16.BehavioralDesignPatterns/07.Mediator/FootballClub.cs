namespace _07.Mediator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Abstract Coleague class
    /// </summary>
    public abstract class FootballClub
    {
        public FootballClub(string name, ICollection<Player> players)
        {
            this.Name = name;
            this.Players = players;

            foreach (var player in this.Players)
            {
                player.Club = this;
            }
        }

        public string Name { get; set; }

        public ICollection<Player> Players { get; protected set; }

        public TransferMediator Mediator { get; set; }

        public void SendRequirementsToMediator(int age, int speed, int technique)
        {
            this.Mediator.SearchForPlayer(
                this,
                p => p.Age == age && p.Speed >= speed && p.Technique >= technique);
        }

        public void ReceiveMessage(string name, string message)
        {
            Console.WriteLine("{0} {1}.", name, message);
        }

        public void ProcessOffer(FootballClub buyingClub, Player player)
        {
            // some logic for accepting, denying or something else
            this.AcceptOffer(buyingClub, player);
        }

        private void AcceptOffer(FootballClub buyingClub, Player playerToBeSold)
        {
            // some logic in the mediator for transfer
            string message = string.Format("sells {0} to {1} for {2:c}.", playerToBeSold.Name, buyingClub.Name, playerToBeSold.Price);
            this.Mediator.SendMessage(this.Name, buyingClub, message);
        }
    }
}
