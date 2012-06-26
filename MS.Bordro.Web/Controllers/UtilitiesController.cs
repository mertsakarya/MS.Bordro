using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using MS.Bordro.Interfaces.Services;

namespace MS.Bordro.Web.Controllers
{
    public class UtilitiesController : BordroController
    {
        private readonly IUtilityService _utilityService;

        public UtilitiesController(IResourceService resourceService, IUserService userService, IUtilityService utilityService
            )
            : base(resourceService, userService)
        {
            _utilityService = utilityService;
        }

        [HttpGet]
        public ActionResult Index() { return View(); }

        [HttpGet]
        public void InitConfiguration()
        {
            Response.ContentType = "text/plain";
            var configurationDataFilename = Server.MapPath(ConfigurationManager.AppSettings["ConfigurationDataFilename"]);
            var result = _utilityService.ResetDatabaseResources(configurationDataFilename).Aggregate("", (current, line) => current + (line + "\r\n"));
            if (String.IsNullOrWhiteSpace(result)) result = "DONE!";
            Response.Write(result);
        }

        public void ClearDatabase()
        {
            _utilityService.ClearDatabase();
            Response.Write("Done!");
        }
    }
}
