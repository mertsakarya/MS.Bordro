using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Web.Models;

namespace MS.Bordro.Web.Controllers
{
    public class WorkRequestController : GridController<WorkRequest, WorkRequestModel>
    {
        private readonly IWorkRequestService _workRequestService;

        public WorkRequestController(IResourceService resourceService, IUserService userService, IWorkRequestService workRequestService) : base(resourceService, userService, workRequestService) {
            _workRequestService = workRequestService;
        }
    }
}
