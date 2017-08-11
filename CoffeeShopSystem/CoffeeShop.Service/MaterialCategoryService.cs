using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public class MaterialCategoryService : IMaterialCategoryService
    {
        private IMaterialCategoryRepository materialCategoryRepository;
        private IUnitOfWork unitOfWork;

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