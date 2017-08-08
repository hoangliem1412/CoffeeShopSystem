using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Data.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        IEnumerable<Order> GetAllPagingByGroup(int group, int pageIndex, int pageSize, out int totalRow);
    }
}
