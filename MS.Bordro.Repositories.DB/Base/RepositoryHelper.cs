﻿using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MS.Bordro.Domain.Entities.BaseEntities;

namespace MS.Bordro.Repositories.DB.Base
{
    public static class RepositoryHelper
    {
        public static TEntity Add<TEntity>(DbContext context, TEntity entity) where TEntity : BaseModel
        {
            return ExecuteAdd(context, entity);
        }

        private static TEntity ExecuteAdd<TEntity>(DbContext context, TEntity entity) where TEntity : BaseModel
        {
            entity.PrepareForAdd();
            context.Set<TEntity>().Add(entity);
            return entity;
        }

        public static TEntity AddWithGuid<TEntity>(DbContext context, TEntity entity) where TEntity : BaseGuidModel
        {
            entity = AddWithGuid(context, entity, (entity.Guid == Guid.Empty) ? Guid.NewGuid(): entity.Guid);
            return entity;
        }

        public static TEntity AddWithGuid<TEntity>(DbContext context, TEntity entity, Guid guid) where TEntity : BaseGuidModel
        {
            entity.Guid = guid;
            return ExecuteAdd(context, entity);
        }

        public static TEntity Update<TEntity>(DbContext context, TEntity entity, params Expression<Func<TEntity, object>>[] expressionParams) where TEntity : BaseModel
        {
            entity.PrepareForUpdate();
            var expressions = expressionParams.ToList();
            expressions.Add(p => p.ModifiedDate);
            AttachAndSetAsModified(context, entity, expressions.ToArray());
            return entity;
        }

        public static TEntity Delete<TEntity>(DbContext context, TEntity entity) where TEntity : BaseModel
        {
            if (context.Entry(entity).State == EntityState.Detached) {
                context.Set<TEntity>().Attach(entity);
            }
            return context.Set<TEntity>().Remove(entity);
        }

        public static IQueryable<T> Query<T>(IQueryable<T> dbSet, Expression<Func<T, bool>> filter, bool includeDeleted = false,  params Expression<Func<T, object>>[] includeExpressionParams) where T : BaseModel
        {
            if (includeExpressionParams != null)
                dbSet = includeExpressionParams.Aggregate(dbSet, (current, expression) => current.Include(expression));
            if(!includeDeleted) 
                dbSet = dbSet.Where(p => !p.Deleted);
            if (filter != null)
                dbSet = dbSet.Where(filter);
            return dbSet;
        }

        private static void AttachAndSetAsModified<TEntity>(DbContext context, TEntity entity, params Expression<Func<TEntity, object>>[] expressionParams) where TEntity : class
        {
            if (context.Entry(entity).State == EntityState.Detached)
                context.Set<TEntity>().Attach(entity);
            SetAsModified(context, entity, expressionParams);
        }

        private static void SetAsModified<TEntity>(DbContext context, TEntity entity, params Expression<Func<TEntity, object>>[] expressionParams) where TEntity : class
        {
            expressionParams.ToList().ForEach(expression => context.Entry(entity).Property(expression).IsModified = true);
        }

        public static TEntity SoftDelete<TEntity>(DbContext context, TEntity entity) where TEntity : BaseModel
        {
            context.Entry(entity).State = EntityState.Modified;
            entity.PrepareForSoftDelete();
            var expressions = new Expression<Func<TEntity, object>>[]
                            {
                                p => p.ModifiedDate,
                                p => p.Deleted,
                                p => p.DeletionDate
                            };
            AttachAndSetAsModified(context, entity, expressions);
            return entity;
        }
    }
}
