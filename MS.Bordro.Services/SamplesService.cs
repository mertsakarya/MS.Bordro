using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Services.Helpers;

namespace MS.Bordro.Services
{
    public class SamplesService : ISamplesService
    {
        private readonly ICompanyService _companyService;
        private readonly IResourceService _resourceService;

        public SamplesService(ICompanyService companyService, IResourceService resourceService)
        {
            _companyService = companyService;
            _resourceService = resourceService;
        }

        public void GenerateCompanies(int count, int extra = 0)
        {
            for(var i = 0; i < count; i++) {
                var company = new Company {Name = RandomHelper.RandomString(20, false)};
                _companyService.Add(company);
            }
        }
    }

}
