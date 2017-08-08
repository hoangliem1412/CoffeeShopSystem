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
            _tableRepository.Update(table);
        }
        public void Delete(int id)
        {
            _tableRepository.Delete(id);
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

            return _tableRepository.GetListOrderProductByOrderID(id).ToList();
            //var list =_tableRepository.GetListOrderProductByOrderID(id);
            //var result = new List<OrderProduct>();
            //foreach(var item in list)
            //{
            //    var od = new OrderProduct();
            //    od.ID = item.ID;
            //    od.Money = item.Money;
            //    od.OrderID = item.OrderID;
            //    od.Quantity = item.Quantity;
            //    od.Price = item.Price;
            //    result.Add(od);
            //}
            //return result;
        }
    }
}
