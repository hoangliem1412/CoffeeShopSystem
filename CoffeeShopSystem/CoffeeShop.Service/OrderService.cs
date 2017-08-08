using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Service
{
    public class OrderService:IOrderService
    {
        IOrderRepository _tableRepository;
        IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository tableRepository, IUnitOfWork unitOfWork)
        {
            this._tableRepository = tableRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Order order)
        {
            _tableRepository.Add(order);
        }
        public void Update(Order table)
        {
            _tableRepository.Update(table);
        }
        public void Delete(int id)
        {
            _tableRepository.Delete(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _tableRepository.GetAll(); 
        }

        public Order GetByID(int id)
        {
            return _tableRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

       
    }
}
