
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

    public class HomeworksController : BaseController
    {
        public HomeworksController()
            : base()
        {
        }

        public HomeworksController(IStudentSystemData data)
            : base(data)
        {
        }

        // Only reading service for this model. No time :)
        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.Data.Homeworks.All().Select(HomeworkModel.FromDataToHomeworkModel));
        }
    }
}
