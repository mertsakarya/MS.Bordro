using System;
using System.Collections.Generic;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Enumerations;
using MS.Bordro.Infrastructure.Cache;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Interfaces.Services;

namespace MS.Bordro.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepositoryDB _repository;
        private readonly IBordroGlobalCacheContext _bordroGlobalCache;

        public CompanyService(ICompanyRepositoryDB repository, IBordroGlobalCacheContext globalCacheContext)
        {
            _repository = repository;
            _bordroGlobalCache = globalCacheContext;
        }

        public IList<Company> GetAll(out int total)
        {
           return _repository.GetAll(out total);
        }
    }
}
