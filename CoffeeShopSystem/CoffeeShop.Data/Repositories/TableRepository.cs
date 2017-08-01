using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Data.Repositories
{
    public class TableRepository : RepositoryBase<Table>, ITableRepository
    {
        public TableRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Table> GetAllPagingByGroup(int groupTable, int pageIndex, int pageSize, out int totalRow)
        {
            //var query = from t in DbContext.Tables
            //            join gt in DbContext.GroupTables
            //            on t.GroupTableID equals gt.ID
            //            where gt.ID == groupTable && (t.IsDelete ?? false)
            //            select t;
            var query = DbContext.Tables.AsEnumerable().Where(x => x.GroupTableID == groupTable && (!x.IsDelete ?? true));
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}