using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class InteractionManagerExtension : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }
            return item;            
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {                
                case "gather":
                    HandleGatherInteraction(commandWords[2], actor);
                    break;
                case "craft":
                    HandleCraftCommand(actor, commandWords[2], commandWords[3]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }            
        }

        private void HandleCraftCommand(Person actor, string itemType, string itemName)
        {
            Item craftedItem = null;
            if (itemType == "armor" && this.ActorHasItem(actor, ItemType.Iron))
            {
                craftedItem = new Armor(itemName);
                this.AddToPerson(actor, craftedItem);
            }
            else if (itemType == "weapon" 
                  && this.ActorHasItem(actor, ItemType.Iron)
                  && this.ActorHasItem(actor, ItemType.Wood))
            {
                craftedItem = new Weapon(itemName);
                this.AddToPerson(actor, craftedItem);
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;
        }

        private void HandleGatherInteraction(string itemName, Person actor)
        {
            Item itemToGather = null;
            if (actor.Location is IGatheringLocation)
            {
                var gatheringLocation = actor.Location as IGatheringLocation;
                if (this.ActorHasItem(actor, gatheringLocation.RequiredItem))
                {
                    itemToGather = gatheringLocation.ProduceItem(itemName);
                    this.AddToPerson(actor, itemToGather);
                }
            }
        }
      
        private bool ActorHasItem(Person actor, ItemType type)
        {
            List<Item> inventory = actor.ListInventory();
            foreach (var item in inventory)
            {
                if (item.ItemType == type)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
