using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DBRepostitory.Models;

namespace DBRepostitory.Utility
{
    public class BasicRepository<T> where T : class
    {
        private NorthwindEntities db  = new NorthwindEntities();

        //public BasicRepository(NorthwindEntities inDb)
        //{
        //    db = inDb;
        //}


        /// <summary>
        /// 新增一筆資料。
        /// </summary>
        /// <param name="entity">要新增到的Entity</param>
        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
        }

        /// <summary>
        /// 取得第一筆符合條件的內容。如果符合條件有多筆，也只取得第一筆。
        /// </summary>
        /// <param name="predicate">要取得的Where條件。</param>
        /// <returns>取得第一筆符合條件的內容。</returns>
        public T Select(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// 取得Entity全部筆數的IQueryable。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        public IQueryable<T> Selects()
        {
            return db.Set<T>().AsQueryable();
        }

        /// <summary>
        /// 更新一筆Entity內容。
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        public void Update(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 更新一筆資料的內容。
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        public void Update(T entity, Expression<Func<T, object>>[] updateProperties)
        {
            db.Configuration.ValidateOnSaveEnabled = false;

            db.Entry<T>(entity).State = EntityState.Unchanged;
            if(updateProperties != null)
            {
                foreach(var item in updateProperties)
                {
                    db.Entry<T>(entity).Property(item).IsModified = true;
                }
            }

            //if (entity != null)
            //{
            //    db.Entry(entity).State = EntityState.Modified;
            //}
        }

        /// <summary>
        /// 刪除一筆資料內容。
        /// </summary>
        /// <param name="entity">要被刪除的Entity。</param>
        public void Delete(T entity)
        {
            if (entity != null)
            {
                db.Entry(entity).State = EntityState.Deleted;
            }
        }

        /// <summary>
        /// 儲存異動。
        /// </summary>
        public void SaveChanges()
        {
            db.SaveChanges();

            if(db.Configuration.ValidateOnSaveEnabled == false)
            {
                db.Configuration.ValidateOnSaveEnabled = true;
            }
        }
    }
}
