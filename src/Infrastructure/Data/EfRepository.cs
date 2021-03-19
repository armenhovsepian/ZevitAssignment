﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly ContactContext _dbContext;
        private bool _disposed = false;
        public EfRepository(ContactContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken ct)
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken ct)
        {
            var specificationResult = ApplySpecification(spec, ct);
            return await specificationResult.ToListAsync();
        }

        public async Task<T> AddAsync(T entity, CancellationToken ct)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            //await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken ct)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
            //await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity, CancellationToken ct)
        {
            _dbContext.Set<T>().Remove(entity);
            await Task.CompletedTask;
            //await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec, CancellationToken ct)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }
    }
}
