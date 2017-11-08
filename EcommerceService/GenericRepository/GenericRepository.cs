using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KebapBob.GenericRepository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        #region Private member variables...
        internal KebapBobEntities Context;
        internal DbSet<TEntity> DbSet;
        #endregion

        #region Public Constructor...
        /// &lt;summary>
        /// Public Constructor,initializes privately declared local variables.
        /// &lt;/summary>
        /// &lt;param name="context">&lt;/param>
        public GenericRepository(KebapBobEntities context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }
        #endregion

        #region Public member methods...

        /// &lt;summary>
        /// generic Get method for Entities
        /// &lt;/summary>
        /// &lt;returns>&lt;/returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }

        /// &lt;summary>
        /// Generic get method on the basis of id for Entities.
        /// &lt;/summary>
        /// &lt;param name="id">&lt;/param>
        /// &lt;returns>&lt;/returns>
        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        /// &lt;summary>
        /// generic Insert method for the entities
        /// &lt;/summary>
        /// &lt;param name="entity">&lt;/param>
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// &lt;summary>
        /// Generic Delete method for the entities
        /// &lt;/summary>
        /// &lt;param name="id">&lt;/param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// &lt;summary>
        /// Generic Delete method for the entities
        /// &lt;/summary>
        /// &lt;param name="entityToDelete">&lt;/param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        /// &lt;summary>
        /// Generic update method for the entities
        /// &lt;/summary>
        /// &lt;param name="entityToUpdate">&lt;/param>
        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// &lt;summary>
        /// generic method to get many record on the basis of a condition.
        /// &lt;/summary>
        /// &lt;param name="where">&lt;/param>
        /// &lt;returns>&lt;/returns>
        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).ToList();
        }

        /// &lt;summary>
        /// generic method to get many record on the basis of a condition but query able.
        /// &lt;/summary>
        /// &lt;param name="where">&lt;/param>
        /// &lt;returns>&lt;/returns>
        public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).AsQueryable();
        }

        /// &lt;summary>
        /// generic get method , fetches data for the entities on the basis of condition.
        /// &lt;/summary>
        /// &lt;param name="where">&lt;/param>
        /// &lt;returns>&lt;/returns>
        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return DbSet.Where(where).FirstOrDefault<TEntity>();
        }

        /// &lt;summary>
        /// generic delete method , deletes data for the entities on the basis of condition.
        /// &lt;/summary>
        /// &lt;param name="where">&lt;/param>
        /// &lt;returns>&lt;/returns>
        public void Delete(Func<TEntity, Boolean> where)
        {
            IQueryable<TEntity> objects = DbSet.Where<TEntity>(where).AsQueryable();
            foreach (TEntity obj in objects)
                DbSet.Remove(obj);
        }

        /// &lt;summary>
        /// generic method to fetch all the records from db
        /// &lt;/summary>
        /// &lt;returns>&lt;/returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        /// &lt;summary>
        /// Inclue multiple
        /// &lt;/summary>
        /// &lt;param name="predicate">&lt;/param>
        /// &lt;param name="include">&lt;/param>
        /// &lt;returns>&lt;/returns>
        public IQueryable<TEntity> GetWithInclude(
            System.Linq.Expressions.Expression<Func<TEntity,
                    bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this.DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        /// &lt;summary>
        /// Generic method to check if entity exists
        /// &lt;/summary>
        /// &lt;param name="primaryKey">&lt;/param>
        /// &lt;returns>&lt;/returns>
        public bool Exists(object primaryKey)
        {
            return DbSet.Find(primaryKey) != null;
        }

        /// &lt;summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// &lt;/summary>
        /// &lt;param name="predicate">Criteria to match on&lt;/param>
        /// &lt;returns>A single record that matches the specified criteria&lt;/returns>
        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return DbSet.Single<TEntity>(predicate);
        }

        /// &lt;summary>
        /// The first record matching the specified criteria
        /// &lt;/summary>
        /// &lt;param name="predicate">Criteria to match on&lt;/param>
        /// &lt;returns>A single record containing the first record matching the specified criteria&lt;/returns>
        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return DbSet.First<TEntity>(predicate);
        }


        #endregion
    }
}
