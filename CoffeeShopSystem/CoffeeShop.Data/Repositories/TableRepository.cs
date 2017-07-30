using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Data.Repositories
{
    public class TableRepository : RepositoryBase<Table>, ITableRepository
    {
        //public TableRepository(IDbFactory dbFactory) : base(dbFactory)
        //{
        //}

        public IEnumerable<Table> GetAllPagingByGroup(int groupTable, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from t in DbContext.Tables
                        join gt in DbContext.GroupTables
                        on t.GroupTableId equals gt.ID
                        where gt.ID == groupTable && !t.IsDelete
                        select t;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}