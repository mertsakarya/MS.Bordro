using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Domain.Entities.BaseEntities;
using MS.Bordro.Infrastructure.Cache;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Interfaces.Services;

namespace MS.Bordro.Services
{
    public abstract class BaseGridRepositoryService<T> : IGridService<T> where T: BaseModel
    {
        private readonly IRepository<T> _repository;
        private readonly IBordroGlobalCacheContext _bordroGlobalCache;

        public BaseGridRepositoryService(IRepository<T> repository, IBordroGlobalCacheContext globalCacheContext)
        {
            _repository = repository;
            _bordroGlobalCache = globalCacheContext;
        }

        public IList<T> GetAll(out int total, int page, int pageSize) { return _repository.GetAll(out total, page, pageSize); }
        public void Add(T entity) { _repository.Add(entity); _repository.Save(); }
        T IGridService<T>.GetById(long id) { return _repository.GetById(id); }
        public void Update(T entity) { _repository.FullUpdate(entity); _repository.Save(); }
        public void Delete(T entity) { _repository.SoftDelete(entity); _repository.Save(); }
    }

    public abstract class BaseDetailGridRepositoryService<T> : BaseGridRepositoryService<T>, IDetailGridService<T> where T : BaseModel
    {
        private readonly IDetailRepository<T> _repository;
        protected BaseDetailGridRepositoryService(IDetailRepository<T> repository, IBordroGlobalCacheContext globalCacheContext) : base(repository, globalCacheContext) { _repository = repository; }
        public IList<T> GetAllByKey<TKey>(long id, out int total, int page, int pageSize, Expression<Func<T, TKey>> orderByClause, bool ascending) { return _repository.GetAllByKey<TKey>(id, out total, page, pageSize, orderByClause, ascending); }
    }

}
