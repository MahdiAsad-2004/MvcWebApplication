using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrganicShop.DAL.Context;
using OrganicShop.Domain;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Repositories.Base
{
    public abstract class CrudRepository<TEntity, TKey> :
        IReadRepository<TEntity, TKey>
        , IWriteRepository<TEntity, TKey>
        , IDeleteRepository<TEntity, TKey>
        where TEntity : EntityId<TKey>, IAggregateRoot
        where TKey : struct
    {

        protected OrganicShopDbContext _context { get; init; }
        protected DbSet<TEntity> _dbSet { init; get; }
        public CrudRepository(OrganicShopDbContext organicShopDbContext)
        {
            _context = organicShopDbContext;
            _dbSet = _context.Set<TEntity>();
        }


        public async Task<TKey> Add(TEntity entity, long id, string? operationDescription = null)
        {
            entity.BaseEntity = new BaseEntity(true);
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = typeof(TEntity).Name,
                Type = Domain.Enums.OperationType.Create,
                UserId = id,
                Description = operationDescription != null ? operationDescription : $"Creating {typeof(TEntity).Name}",
            };
            await _dbSet.AddAsync(entity);
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Add(List<TEntity> entities, long id, string? operationDescription = null)
        {
            foreach (var entity in entities)
            {
                entity.BaseEntity = new BaseEntity(true);
            }
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = typeof(TEntity).Name,
                Type = Domain.Enums.OperationType.Create,
                UserId = id,
                Description = operationDescription != null ? operationDescription : $"Creating {typeof(TEntity).Name}s",
            };
            await _dbSet.AddRangeAsync(entities);
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity, long id, string? operationDescription = null)
        {
            entity.BaseEntity.LastModified = DateTime.Now;
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = typeof(TEntity).Name,
                Type = Domain.Enums.OperationType.Update,
                UserId = id,
                Description = operationDescription != null ? operationDescription : $"Editing {typeof(TEntity).Name}",
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task Update(List<TEntity> entities, long id, string? operationDescription = null)
        {
            foreach (var entity in entities)
            {
                entity.BaseEntity.LastModified = DateTime.Now;
            }
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = typeof(TEntity).Name,
                Type = Domain.Enums.OperationType.Update,
                UserId = id,
                Description = operationDescription != null ? operationDescription : $"Editing {typeof(TEntity).Name}s",
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNoTrack(TEntity entity, long id, string? operationDescription = null)
        {
            entity.BaseEntity.LastModified = DateTime.Now;
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = typeof(TEntity).Name,
                Type = Domain.Enums.OperationType.Update,
                UserId = id,
                Description = operationDescription != null ? operationDescription : $"Editing {typeof(TEntity).Name}",
            };
            _dbSet.Update(entity);
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }


        public async Task SoftDelete(TEntity entity, long id, string? operationDescription = null)
        {
            _context.Entry(entity).Entity.BaseEntity.DeleteDate = DateTime.Now;
            _context.Entry(entity).Entity.BaseEntity.IsDelete = true;
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = typeof(TEntity).Name,
                Type = Domain.Enums.OperationType.SoftDelete,
                UserId = id,
                Description = operationDescription != null ? operationDescription : $"Soft Delete {typeof(TEntity).Name}",
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDelete(TKey key, long id, string? operationDescription = null)
        {
            TEntity entity = await GetAsTracking(key);
            _context.Entry(entity).Entity.BaseEntity.DeleteDate = DateTime.Now;
            _context.Entry(entity).Entity.BaseEntity.IsDelete = true;
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = typeof(TEntity).Name,
                Type = Domain.Enums.OperationType.SoftDelete,
                UserId = id,
                Description = operationDescription != null ? operationDescription : $"Soft Delete {typeof(TEntity).Name}",
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity?> GetAsNoTracking(TKey id)
            => await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id.Equals(id));


        public virtual async Task<TEntity?> GetAsTracking(TKey id)
            => await _context
            .Set<TEntity>()
            .AsTracking()
            .FirstOrDefaultAsync(a => a.Id.Equals(id));


        public virtual IQueryable<TEntity> GetQueryable()
            => _dbSet
            .AsNoTracking()
            .AsQueryable();


        public virtual IQueryable<TEntity> GetQueryableTracking()
          => _dbSet
            .AsTracking()
            .AsQueryable();


        public async Task Delete(TEntity entity, long id, string? operationDescription = null)
        {
            _dbSet.Remove(entity);
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = typeof(TEntity).Name,
                Type = Domain.Enums.OperationType.Delete,
                UserId = id,
                Description = operationDescription != null ? operationDescription : $"Deleting {typeof(TEntity).Name}",
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TKey key, long id, string? operationDescription = null)
        {
            TEntity entity = await GetAsNoTracking(key);
            _dbSet.Remove(entity);
            var operation = new Domain.Entities.Operation
            {
                Date = DateTime.Now,
                EntityNewData = null,
                EntityOldData = null,
                EntityTitle = typeof(TEntity).Name,
                Type = Domain.Enums.OperationType.Delete,
                UserId = id,
                Description = operationDescription != null ? operationDescription : $"Deleting {typeof(TEntity).Name}",
            };
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        => _context.Dispose();

        public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();

        public async Task SaveChanges()
        => await _context.SaveChangesAsync();
    }
}
