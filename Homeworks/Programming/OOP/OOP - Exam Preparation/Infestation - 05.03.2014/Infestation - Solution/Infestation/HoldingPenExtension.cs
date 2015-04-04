using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HoldingPenExtension : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            string supplementTargetID = commandWords[2];
            string supplementType = commandWords[1];
            Unit targetUnit = this.GetUnit(supplementTargetID);
            switch (supplementType)
            {
                case "AggressionCatalyst":
                    targetUnit.AddSupplement(new AggressionCatalyst());
                    break;
                case "HealthCatalyst":
                    targetUnit.AddSupplement(new HealthCatalyst());
                    break;
                case "PowerCatalyst":
                    targetUnit.AddSupplement(new PowerCatalyst());
                    break;
                case "Weapon":
                    targetUnit.AddSupplement(new Weapon());
                    break;
                default:
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}
