namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Web.Models;

    public class TestsController : BaseController
    {
        private const string CourseNotFoundMessage = "There is no such course";
        private const string TestNotFoundMessage = "No such test - invalid id.";

        public TestsController()
            : base()
        {
        }

        public TestsController(IStudentSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.Data.Tests.All().Select(TestModel.FromDataToTestModel));
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var test = this.Data.Tests.SearchFor(t => t.Id == id)
                                            .Select(TestModel.FromDataToTestModel);

            if (test == null)
            {
                return BadRequest(TestNotFoundMessage);
            }

            return Ok(test);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]TestModel testModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var course = this.Data.Courses.All().FirstOrDefault(c => c.Name == testModel.Course);

            if (course == null)
            {
                return BadRequest(CourseNotFoundMessage);
            }

            var test = TestModel.FromTestModelToData(testModel, course);

            this.Data.Tests.Add(test);
            this.Data.SaveChanges();

            return Created(this.Url.ToString(), testModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] TestModel testModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var test = this.Data.Tests.All()
                                            .FirstOrDefault(t => t.Id == id);

            if (test == null)
            {
                return BadRequest(TestNotFoundMessage);
            }

            var course = this.Data.Courses.All().FirstOrDefault(c => c.Name == testModel.Course);

            if (course == null)
            {
                return BadRequest(CourseNotFoundMessage);
            }

            test.Course = course;

            this.Data.Tests.Update(test);
            this.Data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var test = this.Data.Tests.All().FirstOrDefault(t => t.Id == id);

            if (test == null)
            {
                return BadRequest(TestNotFoundMessage);
            }

            this.Data.Tests.Delete(test);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}
