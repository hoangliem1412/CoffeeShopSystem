using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Service
{
    public class OrderProductService : IOrderProductService
    {
        IOrderProductRepository _tableRepository;
        IUnitOfWork _unitOfWork;
        public OrderProductService(IOrderProductRepository tableRepository, IUnitOfWork unitOfWork)
        {
            this._tableRepository = tableRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(OrderProduct order)
        {
            _tableRepository.Add(order);
        }
        public void Update(OrderProduct table)
        {
           var op= _tableRepository.GetSingleById(table.ID);
            op.Quantity = table.Quantity;
            op.Money = op.Quantity * op.Price;
            _tableRepository.Update(op);
        }
        public void Delete(int id)
        {
            var orderUpdate = _tableRepository.GetSingleById(id);
            orderUpdate.isDelete = true;
            _tableRepository.Update(orderUpdate);
        }

        public IEnumerable<OrderProduct> GetAll()
        {
            return _tableRepository.GetAll();
        }

        public OrderProduct GetByID(int id)
        {
            return _tableRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public List<OrderProduct> GetListOrderProductByOrderID(int id)
        {
            return _tableRepository.GetListOrderProductByOrderID(id).Where(od=>od.isDelete==false).ToList();
        }
    }
}
