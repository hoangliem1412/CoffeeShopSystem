using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    
    public class ProductService : Service<Product>, IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;
        public ProductService(IRepository<Product> productService, IUnitOfWork unitOfWork) : base(productService, unitOfWork)
        {
            
        }
        
        public IEnumerable<Product> GetAllPaging(int page, int size, out int totalRow)
        {
            return _productRepository.GetMultiPaging(x => (!x.IsDelete ?? true), out totalRow, page, size);
        }
        
    }
}
