namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string regNum)
        {
            this.Name = name;
            this.RegistrationNumber = regNum;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("Invalid name - name should be 5 or more symbols.");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set
            {
                ValidateRegNumber(value);
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(this.furnitures); }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("Furniture can not be null.");
            }
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (!this.Furnitures.Contains(furniture))
            {
                return;
            }
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            var result = this.Furnitures.Where(f => f.Model.ToLower() == model.ToLower())
                                        .FirstOrDefault();
            return result;
        }

        public string Catalog()
        {
            string output;

            output = string.Format("{0} - {1} - {2} {3}",
            this.Name,
            this.RegistrationNumber,
            this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
            this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            if (this.Furnitures.Count == 0)
            {
                return output;
            }

            else
            {
                var orderedCatalog = this.Furnitures.OrderBy(f => f.Price) 
                                                    .ThenBy(f => f.Model);
                foreach (var item in orderedCatalog)
                {
                    output += "\r\n" + item.ToString();
                }

                return output;
            }

        }

        private void ValidateRegNumber(string regNum)
        {
            if (regNum.Length != 10)
            {
                throw new ArgumentException("Registration number should be 10 digits.");
            }
            else
            {
                foreach (var symbol in regNum)
                {
                    if (!char.IsDigit(symbol))
                    {
                        throw new ArgumentException("Registration number should be 10 digits.");
                    }
                }
            }
        }
    }
}
