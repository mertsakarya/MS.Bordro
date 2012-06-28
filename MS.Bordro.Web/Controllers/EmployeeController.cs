using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Web.Models;

namespace MS.Bordro.Web.Controllers
{
    public class EmployeeController : GridController<Employee, EmployeeModel>
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IResourceService resourceService, IUserService userService, IEmployeeService service) : base(resourceService, userService, service) {
            _service = service;
        }
    }
}
