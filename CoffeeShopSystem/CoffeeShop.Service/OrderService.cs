using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository tableRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = tableRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Cập nhật hóa đơn
        /// </summary>
        /// <param name="order"></param>
        public void Update(Order order)
        {
            var orderUpdate = _orderRepository.GetSingleById(order.ID);
            orderUpdate.TableID = order.TableID;
            orderUpdate.Status = order.Status;
            decimal total = 0;
            foreach (var p in orderUpdate.OrderProducts.Where(p => p.isDelete == false).ToList())
            {
                total = total + (decimal)p.Money;
            }
            orderUpdate.TotalMoney = total;
            _orderRepository.Update(orderUpdate);
        }
        /// <summary>
        /// Xóa hóa đơn, cập nhật isDelete=true
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var orderUpdate = _orderRepository.GetSingleById(id);
            orderUpdate.isDelete = true;
            _orderRepository.Delete(id);
        }


        /// <summary>
        /// Lấy tất cả hóa đơn
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll().ToList();
        }


        /// <summary>
        /// Lấy hóa đơn theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetByID(int id)
        {
            return _orderRepository.GetSingleById(id);
        }

        /// <summary>
        /// Save database
        /// </summary>
        public void Save()
        {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Tìm kiếm theo IDOrder, TableName , CustomerName
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="lst"></param>
        /// <returns>dynamic</returns>
        public dynamic SearchByIDandTable(string keyword,List<Order> lst)
        {
            var list = lst.ToList().Where(o => o.ID.ToString().ToLower().Contains(keyword.ToLower()) || o.Table.Name.ToString().ToLower().Contains(keyword.ToLower()) || o.User.Name.ToLower().Contains(keyword.ToLower())).Select(o => new { id = o.ID, tableName = o.Table.Name, userName = o.User.Name, promoName = o.Promotion.Name, setDate = o.SetDate, totalMoney = o.TotalMoney, status = o.Status, tableID = o.TableID }).ToList();
            return list;
        }

		
		        /// <summary>
        ///Filter by Date and TableID
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="TableID"></param>
        /// <returns>dynamic</returns>
        public dynamic SearchAdvanced(string customerName,string fromDate, string toDate, int TableID, ref List<Order> lst)
        {
            var list = lst.Where(o=>(customerName=="" ? true : o.User.Name.ToLower().Contains(customerName.ToLower())) && (fromDate==""? true : o.SetDate.Value>=DateTime.Parse(fromDate)) && (toDate == "" ? true : o.SetDate.Value <= DateTime.Parse(toDate)) && (TableID == 0 ? true : o.TableID ==TableID))
                          .Select(o => new { id = o.ID, tableName = o.Table.Name, userName = o.User.Name, promoName = o.Promotion.Name, setDate = o.SetDate, totalMoney = o.TotalMoney, status = o.Status, tableID = o.TableID })
                          .ToList();
            return list ;
        }
		
        /// <summary>
        /// Lọc theo tình trạng hóa đơn
        /// </summary>
        /// <param name="status"></param>
        /// <param name="lst"></param>
        /// <returns>dynamic</returns>
        public dynamic GetByStatus(string status, ref List<Order> lst)
        {
            var list2 = _orderRepository.GetAll().ToList(); 
            var list = _orderRepository.GetAll().ToList().Select(o => new { id = o.ID, tableName = o.Table.Name, userName = o.User.Name, promoName = o.Promotion.Name, setDate = o.SetDate, totalMoney = o.TotalMoney, status = o.Status, tableID = o.TableID }).ToList();
            if (status == "1") 
            {
                lst = list2;
                return list;
             
            }
            else if (status == "2") 
            {
                lst = list2.Where(o => o.Status == false).ToList();
                return list.Where(o => o.status == false);
                
            }
            else 
            {
                lst = list2.Where(o => o.Status == true).ToList();
                return list.Where(o => o.status == true);            
            }
        }
    }
}
