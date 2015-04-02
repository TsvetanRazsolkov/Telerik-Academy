namespace FurnitureManufacturer.Engine.Factories
{
    using FurnitureManufacturer.Engine;
    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class CompanyFactory : ICompanyFactory
    {
        public ICompany CreateCompany(string name, string registrationNumber)
        {
            // TODO: Implement this method
            return new Company(name, registrationNumber);
        }
    }
}
