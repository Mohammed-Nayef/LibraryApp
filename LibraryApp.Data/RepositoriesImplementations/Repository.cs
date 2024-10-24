using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.RepositoriesImplementations
{
    public class Repository<T> where T : class
    {
        protected DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A List<typeparamref name="T"/> where instance of <typeparamref name="T"/> includeing AppUser if T is IUserDerivedEntity (Employee ,Customer or Driver).
        /// Otherwise returns List<typeparamref name="T"/>  </returns>
        public virtual IEnumerable<T> GetAll()
        {
            if (typeof(T).GetInterfaces().Contains(typeof(ISoftDeletable)))
            {
                return _dbContext.Set<T>()
                .OfType<ISoftDeletable>()
                    .Where(e => e.IsDeleted == false)
                    .ToList().Cast<T>();
            }
            if (typeof(T).GetInterfaces().Contains(typeof(IUserDerivedEntity)))
            {
                return _dbContext.Set<T>()
                    .OfType<IUserDerivedEntity>()
                    .Include(e => e.AppUser)
                    .Where(e => e.AppUser.IsDeleted == false)
                    .ToList().Cast<T>();
            }
            return _dbContext.Set<T>().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An instance of T with AppUser Included if T is IUserDerivedEntity (Employee ,Customer or Driver)</returns>
        /// <returns>An instance of T otherwise</returns>
        public virtual T? GetById(int id)
        {
            if (typeof(T).GetInterfaces().Contains(typeof(ISoftDeletable)))
            {
                return _dbContext.Set<T>()
                     .OfType<ISoftDeletable>()
                .Where(e => e.Id == id && !e.IsDeleted)
                .Cast<T>()
                     .FirstOrDefault();
            }
            if (typeof(T).GetInterfaces().Contains(typeof(IUserDerivedEntity)))
            {
                return _dbContext.Set<T>()
                    .OfType<IUserDerivedEntity>()
                    .Include(e => e.AppUser)
                    .Where(e => e.Id == id && !e.AppUser.IsDeleted)
                    .Cast<T>()
                    .FirstOrDefault();

            }

            return _dbContext.Set<T>().Find(id);
        }
        public virtual void Delete(T entity)
        {
            // if the entity is soft deletable 
            if (entity is ISoftDeletable)
            {
                var softDeletable = (ISoftDeletable)entity;
                softDeletable.IsDeleted = true;
                return;
            }

            // if the entity is related to user (customer,driver,employee)
            if (entity is IUserDerivedEntity)
            {

                var userDerivedEntity = (IUserDerivedEntity)entity;
                if (userDerivedEntity.AppUser is null)
                {
                    throw new ArgumentNullException($"The Entity you tryed to delete has a property of {typeof(AppUser)} with value of null");
                }

                userDerivedEntity.AppUser.IsDeleted = true;
                return;
            }
            // if the entity is neither softDeletable or user derived entity
            _dbContext.Set<T>().Remove(entity);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }
    }
}
