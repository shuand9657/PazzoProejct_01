using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DBRepostitory.Models;
using DBRepostitory.ViewModel;

namespace BussinessLogic.Interface
{
    public interface ICustomersService
    {
        // 新增 客戶資料
        bool Create(CustomerViewModel entity);
        // 修改 客戶資料
        bool Update(CustomerViewModel entity);
        // 刪除 客戶資料
        bool Delete(CustomerViewModel entity);
        // 查詢 客戶資料全部
        Customers Select(Expression<Func<Customers, bool>> predicate);
        // 查詢 客戶資料 by ID
        IQueryable<Customers> Selects();
    }
}
