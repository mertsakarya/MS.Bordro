using System.Collections.Generic;
using MS.Bordro.Domain.Entities;

namespace MS.Bordro.Interfaces.Services
{
    public interface ICompanyService
    {
        IList<Company> GetAll(out int total);
        void Add(Company company);
        Company GetById(long id);
        void Update(Company company);
        void Delete(Company company);
    }
}
