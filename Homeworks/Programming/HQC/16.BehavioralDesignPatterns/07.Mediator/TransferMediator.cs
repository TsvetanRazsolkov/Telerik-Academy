namespace _07.Mediator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The Mediator class
    /// </summary>
    public class TransferMediator
    {
        public TransferMediator()
        {
            this.Players = new List<Player>();
        }

        public ICollection<Player> Players { get; private set; }

        public void MakeContractWithClub(FootballClub club)
        {
            club.Mediator = this;

            foreach (var player in club.Players)
            {
                this.Players.Add(player);
            }
        }

        public void SearchForPlayer(FootballClub club, Func<Player, bool> predicate)
        {
            var searchedPlayer = this.Players.Where(predicate)
                                     .OrderBy(p => p.Price)
                                     .FirstOrDefault();

            if (searchedPlayer != null)
            {
                this.SendOffer(club, searchedPlayer.Club, searchedPlayer);
            }
            else
            {
                this.SendMessage("Transfer mediator", club, "could not find player with the desired qualities.");
            }
        }

        public void SendMessage(string from, FootballClub recipient, string message)
        {
            recipient.ReceiveMessage(from, message);
        }

        public void SendOffer(FootballClub buyerClub, FootballClub sellerClub, Player playerToBeTraded)
        {
            sellerClub.ProcessOffer(buyerClub, playerToBeTraded);
        }
    }
}
