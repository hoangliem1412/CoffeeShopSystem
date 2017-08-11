using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Data.Repositories
{
    public interface IPromotionRepository : IRepository<Promotion>
    {
        IEnumerable<Promotion> Paging(IEnumerable<Promotion> List, int recordsPerPage, int page);
    }
}