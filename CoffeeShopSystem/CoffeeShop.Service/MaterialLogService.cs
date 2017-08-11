using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Service
{
    public class MaterialLogService : Service<MaterialLog>, IMaterialLogService
    {
        public MaterialLogService(IRepository<MaterialLog> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
