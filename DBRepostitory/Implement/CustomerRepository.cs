using DBRepostitory.Models;
using DBRepostitory.Utility;

namespace DBRepostitory.Implement
{
    //repository without interface
    public class CustomerRepository<T> :BasicRepository<T> where T : Customers
    {
        
    }
}
