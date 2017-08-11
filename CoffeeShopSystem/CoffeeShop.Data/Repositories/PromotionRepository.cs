using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoffeeShop.Data.Repositories
{
    public class PromotionRepository : RepositoryBase<Promotion>, IPromotionRepository
    {
        public PromotionRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<Promotion> Paging(IEnumerable<Promotion> List, int recordsPerPage, int page)
        {
            var list = List
                .OrderBy(p => p.ID)
                .Skip((page - 1) * recordsPerPage)
                .Take(recordsPerPage)
                .ToList();
            return list;
        }

    }
}