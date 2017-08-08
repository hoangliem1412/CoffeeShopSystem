using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
        public IEnumerable<Order> GetAllPagingByGroup(int id, int pageIndex, int pageSize, out int totalRow)
        {
            var query = DbContext.Orders.AsEnumerable().Where(x => x.ID == id);
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }

    }
}
