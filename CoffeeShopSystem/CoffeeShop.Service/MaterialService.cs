using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Data.Infrastructure;

namespace CoffeeShop.Service
{
    public class MaterialService : Service<Material>, IMaterialService
    {
        public MaterialService(IRepository<Material> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
