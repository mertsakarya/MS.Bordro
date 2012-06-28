using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using MS.Bordro.Interfaces.Services;

namespace MS.Bordro.Web.Controllers
{
    public class UtilitiesController : BordroController
    {
        private readonly ISamplesService _samplesService;
        private readonly IUtilityService _utilityService;

        public UtilitiesController(IResourceService resourceService, ISamplesService samplesService, IUserService userService, IUtilityService utilityService
            )
            : base(resourceService, userService)
        {
            _samplesService = samplesService;
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

        [HttpGet]
        public void GenerateCompanies(string key)
        {
            int extra;
            var count = GetValues(key, out extra);
            if (count <= 0) return;
            _samplesService.GenerateCompanies(count, extra);
            Response.Write(String.Format("({0}) items are created with extra {1}!", count, extra));
        }

        private int GetValues(string key, out int extra)
        {
            Response.ContentType = "text/plain";
            int count;
            if (!int.TryParse(key, out count)) Response.Write("Wrong count!");
            var str = (Request.QueryString["extra"]);
            if (!int.TryParse(str, out extra)) extra = 0;
            return count;
        }
    }
}
