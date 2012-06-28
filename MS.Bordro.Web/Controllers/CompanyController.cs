using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Web.Models;

namespace MS.Bordro.Web.Controllers
{
    public class CompanyController : GridController<Company, CompanyModel>
    {
        private readonly ICompanyService _companyService;

        public CompanyController(IResourceService resourceService, IUserService userService, ICompanyService companyService) : base(resourceService, userService, companyService) {
            _companyService = companyService;
        }
    }
}
