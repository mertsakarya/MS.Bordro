using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Web.Models;

namespace MS.Bordro.Web.Controllers
{
    public class CompanyLocationController : GridDetailController<CompanyLocation, CompanyLocationModel>
    {
        private readonly ICompanyLocationService _service;

        public CompanyLocationController(IResourceService resourceService, IUserService userService, ICompanyLocationService service)
            : base(resourceService, userService, service)
        {
            _service = service;
        }
    }
}
