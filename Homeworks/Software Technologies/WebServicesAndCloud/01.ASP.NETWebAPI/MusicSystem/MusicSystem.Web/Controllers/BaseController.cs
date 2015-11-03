namespace MusicSystem.Web.Controllers
{
    using System.Web.Http;

    using Data;

    public class BaseController : ApiController
    {
        private IMusicSystemData data;

        public BaseController()
            : this(new MusicSystemData())
        {
        }

        public BaseController(IMusicSystemData data)
        {
            this.data = data;
        }

        protected IMusicSystemData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}