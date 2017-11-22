using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WiseBook.DAL.ORM.Context;
using WiseBook.DAL.ORM.Entity;

namespace WiseBook.BLL.Repository.Base
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private WiseBookContext context;
        protected DbSet<T> dbset;

        public BaseRepository()
        {
            context = new WiseBookContext();
            dbset = context.Set<T>();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
        //category list
        public List<T> SelectByCondition(Expression<Func<T, bool>> predicate)
        {
            return dbset
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .Where(predicate).ToList();
        }

        #region Insert
        public virtual int Insert(T entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.InsertDate = DateTime.Now;
                dbset.Add(entity);
                return Save();
            }
            catch
            {
                return 0;
            }
        }

        public virtual int InsertMany(ICollection<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.InsertDate = DateTime.Now;
                    dbset.Add(entity);
                }

                return Save();
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region Update
        public virtual int Update(T updatedEntity)
        {
            if (updatedEntity.Id == 0) return 0;

            try
            {
                T oldEntity = dbset.Find(updatedEntity.Id);

                if (oldEntity == null) return 0;

                updatedEntity.UpdateDate = DateTime.Now;
                updatedEntity.InsertDate = oldEntity.InsertDate;
                updatedEntity.IsActive = oldEntity.IsActive;
                updatedEntity.IsDeleted = oldEntity.IsDeleted;

                context.Entry(oldEntity).CurrentValues.SetValues(updatedEntity);

                return Save();
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region Delete
        public virtual int Delete(int? Id)
        {
            T entity = dbset.Find(Id);
            entity.DeleteDate = DateTime.Now;
            entity.IsDeleted = true;
            entity.IsActive = false;

            return Save();
        }

        public virtual int SuperDelete(int? Id)
        {
            T entity = dbset.Find(Id);
            dbset.Remove(entity);

            return Save();
        }

        public virtual int Revert(int? Id)
        {
            var model = dbset.Find(Id);
            model.IsActive = true;
            model.IsDeleted = false;

            return Save();
        }
        #endregion

        public List<T> SelectAll()
        {
            return dbset.ToList();
        }

        public List<T> SelectByStateForAll(bool? deleteState = false)
        {
            return dbset.Where(x => x.IsDeleted == deleteState).ToList();
        }

        public List<T> SelectByState(bool activeState, bool? deleteState = false)
        {
            return dbset.Where(x => x.IsActive == activeState && x.IsDeleted == deleteState).ToList();
        }

        public List<T> SelectByCondition(Expression<Func<T, bool>> predicate, bool? activeState = true, bool? deleteState = false)
        {
            if (activeState == true && deleteState == false)
                return SelectByCondition(predicate);

            return dbset
                .Where(x => x.IsActive == activeState && x.IsDeleted == deleteState)
                .Where(predicate).ToList();
        }

        public List<T> SelectAsTransferable(int Id)
        {
            return dbset.Where(x => x.Id == Id).ToList();
        }

        public T SelectFirst(Expression<Func<T, bool>> predicate)
        {
            return dbset.FirstOrDefault(predicate);
        }
    }
}

