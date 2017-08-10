using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Data.Infrastructure;

namespace CoffeeShop.Service
{
    public class MaterialCategoryService : IMaterialCategoryService
    {
        IMaterialCategoryRepository materialCategoryRepository;
        IUnitOfWork unitOfWork;

        public MaterialCategoryService(IMaterialCategoryRepository mateCateRepository, IUnitOfWork unit)
        {
            this.materialCategoryRepository = mateCateRepository;
            this.unitOfWork = unit;
        }
        public IEnumerable<MaterialCategory> GetAll()
        {
            return materialCategoryRepository.GetAll();
        }
    }
}
