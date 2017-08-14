using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Service
{


    public class ProductCategoryService : Service<ProductCategory>, IProductCategoryService
    {
        private IProductCategoryRepository _cateRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IRepository<ProductCategory> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
        }
    }
}
