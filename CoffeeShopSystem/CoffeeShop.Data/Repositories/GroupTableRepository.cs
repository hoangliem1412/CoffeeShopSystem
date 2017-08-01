using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Data.Repositories
{
    public class GroupTableRepository : RepositoryBase<GroupTable>, IGroupTableRepository
    {
        public GroupTableRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}