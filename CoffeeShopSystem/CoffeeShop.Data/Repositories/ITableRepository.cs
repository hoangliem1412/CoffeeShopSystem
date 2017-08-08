using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Data.Repositories
{
    public interface ITableRepository : IRepository<Table>
    {
        IEnumerable<Table> GetAllPagingByGroup(int group, int pageIndex, int pageSize, out int totalRow);
    }
}
