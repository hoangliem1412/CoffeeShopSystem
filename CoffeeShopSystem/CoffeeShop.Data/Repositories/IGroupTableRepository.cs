using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoffeeShop.Data.Repositories
{
    public interface IGroupTableRepository : IRepository<GroupTable>
    {
        IEnumerable<GroupTable> SearchBase(Expression<Func<GroupTable, bool>> condition);
        IEnumerable<GroupTable> GetByShop(int id);
    }
}
