﻿using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Repositories;
using MS.Bordro.Repositories.DB.Base;

namespace MS.Bordro.Repositories.DB
{
    public class UserRepositoryDB : BaseGuidRepositoryDB<User>, IUserRepositoryDB
    {
        public UserRepositoryDB(IBordroDbContext dbContext) : base(dbContext) { }
    }
}
