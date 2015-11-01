namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Data;
    using Models;

    public class BaseController : ApiController
    {
        private IStudentSystemData data;

        public BaseController() : this(new StudentsSystemData())
        {
        }

        public BaseController(IStudentSystemData data)
        {
            this.data = data;
        }

        protected IStudentSystemData Data
        {
            get { return this.data; }
        }
    }
}
