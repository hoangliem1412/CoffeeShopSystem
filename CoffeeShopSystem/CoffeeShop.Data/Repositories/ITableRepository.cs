using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Repositories
{
    public interface ITableRepository : IRepository<Table>
    {
        IEnumerable<Table> GetAllPagingByGroup(int group, int pageIndex, int pageSize, out int totalRow);
    }
}
