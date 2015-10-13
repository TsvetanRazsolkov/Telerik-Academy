namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new MoqCarsRepository())
            ////: this(new JustMockCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        // Index() tests:
        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        // Adding car tests:
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullCarShouldThrowArgumentNullException()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarWithEmptyMakeShouldThrowArgumentNullException()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarWithEmptyModelShouldThrowArgumentNullException()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        // Details() tests:
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GettingDetailsViewWithInvalidIdShouldThrowArgumentNullException()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(-1));
        }

        [TestMethod]
        public void GettingDetailsViewWithValidIdShouldReturnCorrectView()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(1));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        // Searching tests:
        [TestMethod]
        public void GettingSearchViewShouldReturnCorrectView()
        {
            var model = (List<Car>)this.GetModel(() => this.controller.Search("BMW"));

            Assert.AreEqual("BMW", model[0].Make);
            Assert.AreEqual("BMW", model[1].Make);
        }

        // Sorting tests:
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingByIncorrectParameterShouldThrowArgumentException()
        {
            var modelList = (List<Car>)this.GetModel(() => this.controller.Sort("some invalid parameter"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingByNullParameterShouldThrowArgumentException()
        {
            var modelList = (List<Car>)this.GetModel(() => this.controller.Sort(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingByEmptyParameterShouldThrowArgumentException()
        {
            var modelList = (List<Car>)this.GetModel(() => this.controller.Sort(string.Empty));
        }

        [TestMethod]
        public void SortingByMakeShouldReturnCorrectView()
        {
            var modelList = (List<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(4, modelList.Count);
        }

        [TestMethod]
        public void SortingByYearShouldReturnCorrectView()
        {
            var modelList = (List<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(4, modelList.Count);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
