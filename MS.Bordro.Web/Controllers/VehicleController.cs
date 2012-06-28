using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Web.Models;

namespace MS.Bordro.Web.Controllers
{
    public class VehicleController : GridController<Vehicle, VehicleModel>
    {
        private readonly IVehicleService _service;

        public VehicleController(IResourceService resourceService, IUserService userService, IVehicleService service) : base(resourceService, userService, service) {
            _service = service;
        }
    }
}
