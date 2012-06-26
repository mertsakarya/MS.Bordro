using System.Collections.Generic;
using MS.Bordro.Domain.Entities;

namespace MS.Bordro.Interfaces.Services
{
    public interface ICompanyService
    {
        IList<Company> GetAll(out int total);
    }
}
