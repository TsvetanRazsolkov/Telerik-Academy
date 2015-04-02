namespace FurnitureManufacturer.Engine.Factories
{
    using System;

    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            ValidateMaterialInput(materialType);
            var material = GetMaterialType(materialType.ToLower());
            return new Table(model, material.ToString(), price, height, length, width);
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            ValidateMaterialInput(materialType);
            var material = GetMaterialType(materialType.ToLower());
            return new Chair(model, material.ToString(), price, height, numberOfLegs);
        }

        public IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            ValidateMaterialInput(materialType);
            var material = GetMaterialType(materialType.ToLower());
            return new AdjustableChair(model, material.ToString(), price, height, numberOfLegs);
        }

        public IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            ValidateMaterialInput(materialType);
            var material = GetMaterialType(materialType.ToLower());
            return new ConvertibleChair(model, material.ToString(), price, height, numberOfLegs);
        }

        private MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden;
                case Leather:
                    return MaterialType.Leather;
                case Plastic:
                    return MaterialType.Plastic;
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }

        private void ValidateMaterialInput(string material)
        {
            if (string.IsNullOrEmpty(material))
            {
                throw new ArgumentException("Material can not be empty string or null.");
            }
        }
    }
}
