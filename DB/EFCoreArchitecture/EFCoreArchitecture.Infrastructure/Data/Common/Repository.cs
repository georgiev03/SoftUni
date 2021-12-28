using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCoreArchitecture.Infrastructure.Data.Common
{
    /// <summary>
    /// Implementation of repository access methods
    /// for Relational Database Engine
    /// </summary>
    /// <typeparam name="T">Type of data table which
    /// current repository is attached</typeparam>
    public abstract class Repository : IRepository
    {
        /// <summary>
        /// Entity framework DB context holding connection information and properties
        /// and tracking entity states
        /// </summary>
        protected DbContext Context { get; set; }

        /// <summary>
        /// Representation of table in database
        /// </summary>
        protected DbSet<T> DbSet<T>() where T : class
        {
            return this.Context.Set<T>();
        }

        /// <summary>
        /// Disposing the context when it is not needed
        /// Don't have to call this method explicitely
        /// Leave it to the IoC container
        /// </summary>
        public void Dispose()
        {
            this.Context.Dispose();
        }

        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class
        {
            return DbSet<T>().Where(search).AsQueryable();
        }

        /// <summary>
        /// The result won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        public IQueryable<T> AllReadonly<T>() where T : class
        {
            return DbSet<T>()
                .AsQueryable()
                .AsNoTracking();
        }

        public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class
        {
            return DbSet<T>()
                .Where(search)
                .AsQueryable()
                .AsNoTracking();
        }

        /// <summary>
        /// Gets specific record from database by primary key
        /// </summary>
        /// <param name="id">record identificator</param>
        /// <returns>Single record</returns>
        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<T> GetByIdsAsync<T>(object[] id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        /// <summary>
        /// Adds entity to the database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns></returns>
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        /// <summary>
        /// Adds collection of entities to the database
        /// </summary>
        /// <param name="entities">Enumerable list of entities</param>
        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }

        /// <summary>
        /// Updates a record in database
        /// </summary>
        /// <param name="entity">Entity for record to be updated</param>
        public void Update<T>(T entity) where T : class
        {
            this.DbSet<T>().Update(entity);
        }

        /// <summary>
        /// Updates set of records in the database
        /// </summary>
        /// <param name="entities">Enumerable collection of entities to be updated</param>
        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            this.DbSet<T>().UpdateRange(entities);
        }

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <param name="id">Identificator of record to be deleted</param>
        public async Task DeleteAsync<T>(object id) where T : class
        {
            T entity = await GetByIdAsync<T>(id);

            Delete<T>(entity);
        }

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <param name="entity">Entity representing record to be deleted</param>
        public void Delete<T>(T entity) where T : class
        {
            EntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                DbSet<T>().Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        public void DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Detaches given entity from the context
        /// </summary>
        /// <param name="entity">Entity to be detached</param>
        public void Detach<T>(T entity) where T : class
        {
            EntityEntry entry = Context.Entry(entity);

            entry.State = EntityState.Deleted;
        }

        /// <summary>
        /// Saves all made changes in transaction
        /// </summary>
        /// <returns>Error code</returns>
        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.Context.SaveChangesAsync();
        }

    }
}
