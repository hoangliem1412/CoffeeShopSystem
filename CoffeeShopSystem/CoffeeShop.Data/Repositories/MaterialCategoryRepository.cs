using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Repositories
{

    public class MaterialCategoryRepository : RepositoryBase<MaterialCategory>, IMaterialCategoryRepository
    {
        public MaterialCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
