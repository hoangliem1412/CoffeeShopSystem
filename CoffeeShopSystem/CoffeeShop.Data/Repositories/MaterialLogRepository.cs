using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Data.Repositories
{
    public class MaterialLogRepository : RepositoryBase<MaterialLog>, IMaterialLogRepository
    {
        public MaterialLogRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
