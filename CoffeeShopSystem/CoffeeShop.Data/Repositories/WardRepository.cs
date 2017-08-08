using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Data.Repositories
{
    public class WardRepository : RepositoryBase<Ward>, IWardRepository
    {
        public WardRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
