﻿namespace ArmyOfCreatures.Extended
{
    using System;
    using System.Globalization;

    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Extended.Creatures;

    public class CreaturesFactoryExtension : CreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            switch (name)
            {
                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "Goblin":
                    return new Goblin();
                case "Griffin":
                    return new Griffin();
                case "WolfRaider":
                    return new WolfRaider();
                case "CyclopsKing":
                    return new CyclopsKing();
                default:
                    return base.CreateCreature(name);
            }
        }
    }
}

