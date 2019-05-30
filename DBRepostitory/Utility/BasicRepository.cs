using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DBRepostitory.Models;

namespace DBRepostitory.Utility
{
    public class BasicRepository<T> where T : class
    {
        private NorthwindEntities db = new NorthwindEntities();

        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
        }

        /// <summary>
        /// select one by condition
        /// </summary>
        /// <param name="predicate">condition</param>
        /// <returns>return 1 items</returns>
        public T Select(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate).FirstOrDefault();
        }
        /// <summary>
        /// Select All
        /// </summary>
        /// <returns>table as queryable</returns>
        public IQueryable<T> Selects()
        {
            return db.Set<T>().AsQueryable();
        }
    }
}
