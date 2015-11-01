namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Data;
    using StudentSystem.Web.Models;

    public class StudentsController : BaseController
    {
        private const string StudentNotFoundMessage = "No such student - invalid id.";

        public StudentsController()
            : base()
        {
        }

        public StudentsController(IStudentSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.Data.Students.All().Select(StudentModel.FromDataToStudentModel));
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var student = this.Data.Students.SearchFor(s => s.StudentIdentification == id)
                                            .Select(StudentModel.FromDataToStudentModel);

            if (student == null)
            {
                return BadRequest(StudentNotFoundMessage);
            }

            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]StudentModel studentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var student = StudentModel.FromStudentModelToData(studentModel);

            this.Data.Students.Add(student);
            studentModel.StudentIdentification = student.StudentIdentification;
            this.Data.SaveChanges();

            return Created(this.Url.ToString(), studentModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] StudentModel studentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var student = this.Data.Students.All()
                                            .FirstOrDefault(s => s.StudentIdentification == id);

            if (student == null)
            {
                return BadRequest(StudentNotFoundMessage);
            }

            // Same for the other properties in the model - it's a bit late and the idea is clear so... :)
            student.AdditionalInformation.Address = string.IsNullOrEmpty(studentModel.Address) ? student.AdditionalInformation.Address : studentModel.Address;

            this.Data.Students.Update(student);
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

            var student = this.Data.Students.All().FirstOrDefault(s => s.StudentIdentification == id);

            if (student == null)
            {
                return BadRequest(StudentNotFoundMessage);
            }

            this.Data.Students.Delete(student);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}
