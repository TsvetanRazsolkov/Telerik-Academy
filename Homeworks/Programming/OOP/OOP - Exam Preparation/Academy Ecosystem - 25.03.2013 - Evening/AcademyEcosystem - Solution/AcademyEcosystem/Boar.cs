using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private const int BoarSize = 4;
        private const int BoarBiteSise = 2;

        private int biteSize;// All herbivors have it, so it will be better to add int BiteSize{ get; } in IHerbivor;

        public Boar(string name, Point position)
        : base(name, position, BoarSize)
        {
            this.biteSize = BoarBiteSise;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null)
            {
                if (animal.Size <= this.Size)
				{
					return animal.GetMeatFromKillQuantity();
				}
            }
            

            return 0;
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size += 1;
                return plant.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }
    }
}
