using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _tableRepository;
        IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository tableRepository, IUnitOfWork unitOfWork)
        {
            this._tableRepository = tableRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Cập nhật hóa đơn
        /// </summary>
        /// <param name="order"></param>
        public void Update(Order order)
        {
            var orderUpdate = _tableRepository.GetSingleById(order.ID);
            orderUpdate.TableID = order.TableID;
            orderUpdate.Status = order.Status;
            decimal total = 0;
            foreach (var p in orderUpdate.OrderProducts.Where(p => p.isDelete == false).ToList())
            {
                total = total + (decimal)p.Money;
            }
            orderUpdate.TotalMoney = total;
            _tableRepository.Update(orderUpdate);
        }
        /// <summary>
        /// Xóa hóa đơn, cập nhật isDelete=true
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var orderUpdate = _tableRepository.GetSingleById(id);
            orderUpdate.isDelete = true;
            _tableRepository.Delete(id);
        }


        /// <summary>
        /// Lấy tất cả hóa đơn
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> GetAll()
        {
            return _tableRepository.GetAll().ToList();
        }


        /// <summary>
        /// Lấy hóa đơn theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetByID(int id)
        {
            return _tableRepository.GetSingleById(id);
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
        /// Lọc theo tình trạng hóa đơn
        /// </summary>
        /// <param name="status"></param>
        /// <param name="lst"></param>
        /// <returns>dynamic</returns>
        public dynamic GetByStatus(string status, ref List<Order> lst)
        {
            var list2 = _tableRepository.GetAll().ToList(); //gán giá trị vào biến toàn cục listOrder ở OrderController
            var list = _tableRepository.GetAll().ToList().Select(o => new { id = o.ID, tableName = o.Table.Name, userName = o.User.Name, promoName = o.Promotion.Name, setDate = o.SetDate, totalMoney = o.TotalMoney, status = o.Status, tableID = o.TableID }).ToList();
            if (status == "1") //lấy tất cả
            {
                lst = list2;
                return list;
             
            }
            else if (status == "2") //lấy hóa đơn chưa thanh toán
            {
                lst = list2.Where(o => o.Status == false).ToList();
                return list.Where(o => o.status == false);
                
            }
            else //lấy hóa đơn đã thanh toán
            {
                lst = list2.Where(o => o.Status == true).ToList();
                return list.Where(o => o.status == true);            
            }
        }
    }
}
