using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPIMovie.Core.Models;
using WebAPIMovie.Core.Repositories;
using WebAPIMovie.Data.Contexts;

namespace WebAPIMovie.Data.Repository.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    private readonly WebAPIMovieDbContext _context;
    private readonly DbSet<T> _dbSet;
    private IDbContextTransaction? _transaction;

    public GenericRepository(WebAPIMovieDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
    {
        if (includes == null) throw new ArgumentNullException(nameof(includes));
        IQueryable<T> query = _dbSet;
        query = includes.Aggregate(query, (current, include) => current.Include(include));
        var entity = await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        return entity ?? throw new KeyNotFoundException($"No entity found with ID {id}.");
    }

    public async Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;
        if (includes != null)
        {
            foreach (var include in includes)
                query = query.Include(include);
        }
        if (filter != null)
            query = query.Where(filter);
        if (orderBy != null)
            query = orderBy(query);
        return await query.ToListAsync();
    }

    public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        IQueryable<T> query = _dbSet.Where(predicate);
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        return await query.ToListAsync();
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        IQueryable<T> query = _dbSet;
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        var entity = await query.FirstOrDefaultAsync(predicate);
        return entity ?? throw new KeyNotFoundException("Entity with the specified criteria not found.");
    }

    public async Task<T> AddAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _dbSet.Update(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _dbSet.Remove(entity);
    }

    public async Task<List<T>> GetPaginatedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includes)
    {
        if (pageNumber <= 0 || pageSize <= 0) throw new ArgumentException("Page number and size must be greater than zero.");
        IQueryable<T> query = _dbSet;
        if (includes != null)
        {
            foreach (var include in includes)
                query = query.Include(include);
        }
        if (filter != null)
            query = query.Where(filter);
        if (orderBy != null)
            query = orderBy(query);
        return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        if (_transaction != null)
        {
            throw new InvalidOperationException("A transaction is already in progress.");
        }

        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("No transaction to commit.");
        }

        try
        {
            await _transaction.CommitAsync();
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("No transaction to roll back.");
        }

        try
        {
            await _transaction.RollbackAsync();
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

}
