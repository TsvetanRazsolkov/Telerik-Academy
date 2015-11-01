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

    public class CoursesController : BaseController
    {
        private const string CourseNotFoundMessage = "No such course - invalid id.";

        public CoursesController()
            : base()
        {
        }

        public CoursesController(IStudentSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.Data.Courses.All().Select(CourseModel.FromDataToCourseModel));
        }

        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            var course = this.Data.Courses.SearchFor(c => c.Id.ToString() == id)
                                            .Select(CourseModel.FromDataToCourseModel);

            if (course == null)
            {
                return BadRequest(CourseNotFoundMessage);
            }

            return Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]CourseModel courseModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var course = CourseModel.FromCourseModelToData(courseModel);

            this.Data.Courses.Add(course);
            this.Data.SaveChanges();

            return Created(this.Url.ToString(), courseModel);
        }

        [HttpPut]
        public IHttpActionResult Update(string id, [FromBody] CourseModel courseModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var course = this.Data.Courses.All()
                                            .FirstOrDefault(c => c.Id.ToString() == id);

            if (course == null)
            {
                return BadRequest(CourseNotFoundMessage);
            }

            // Same for the other properties in the model - it's a bit late and the idea is clear so... :)
            course.Description = string.IsNullOrEmpty(courseModel.Description) ? course.Description : courseModel.Description;

            this.Data.Courses.Update(course);
            this.Data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var course = this.Data.Courses.All().FirstOrDefault(c => c.Id.ToString() == id);

            if (course == null)
            {
                return BadRequest(CourseNotFoundMessage);
            }

            this.Data.Courses.Delete(course);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}

