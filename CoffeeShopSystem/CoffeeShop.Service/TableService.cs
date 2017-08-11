using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Service
{
    
    public class TableService : Service<Table>, ITableService
    {
        ITableRepository _tableRepository;
        IUnitOfWork _unitOfWork;
        public TableService(IRepository<Table> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
        }
        
        /// <summary>
        /// Lấy danh sách table thuộc 1 shop cụ thể
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>List<Table></returns>
        public IEnumerable<Table> GetByShop(int id)
        {
            //gọi repository
            return _tableRepository.GetByShop(id); //select duoc table tuong ung.
        }

        public IEnumerable<Table> GetAllPaging(int page, int size, out int totalRow)
        {
            return _tableRepository.GetMultiPaging(x => (!x.IsDelete ?? true), out totalRow, page, size);
        }

        public IEnumerable<Table> GetAllPagingByGroup(int groupTable, int pageIndex, int pageSize, out int totalRow)
        {
            return _tableRepository.GetMultiPaging(x => (!x.IsDelete ?? true) && x.GroupTableID == groupTable, out totalRow, pageIndex, pageSize, new string[] { "GroupTable" });
        }

        /// <summary>
        /// Search cơ bản
        /// </summary>
        /// <param name="text">string</param>
        /// <returns>List<Table></returns>
        public IEnumerable<dynamic> SearchBase(string text)
        {
            var key = text.ToLower();
            //Gọi SearchBase có điều kiện
            return _tableRepository.SearchBase(t => t.Name.ToLower().Contains(key) || t.GroupTable.Name.ToLower().Contains(key)).Select(t => new { ID = t.ID, Name = t.Name, GroupTableName = t.GroupTable.Name, GroupTableID = t.GroupTableID, OrderCount = t.Orders.Count, Des = t.Description }); ;

        }

        /// <summary>
        /// Search theo option, tất cả - đã xóa - chưa xóa
        /// </summary>
        /// <param name="option">string</param>
        /// <returns>List<ID, Name, GroupTableName, GroupTableID, OrderCount, Des></returns>
        public IEnumerable<dynamic> SearchCondition(string option)
        {
            var key = option.ToLower();
            IEnumerable<Table> result;
            //Kiểm tra điều kiện
            if (key == "delete")
            {
                result = _tableRepository.GetMulti(t => t.IsDelete == true && t.GroupTable.ShopID == 1);
            }
            else if(key == "manage")
            {
                result = _tableRepository.GetMulti(t => t.IsDelete != true && t.GroupTable.ShopID == 1);
            }
            else
            {
                result = _tableRepository.GetByShop(1);
            }
            return result.Select(t => new { ID = t.ID, Name = t.Name, GroupTableName = t.GroupTable.Name, GroupTableID = t.GroupTableID, OrderCount = t.Orders.Count, Des = t.Description }); ;

        }

        /// <summary>
        /// Phục hồi table đã xóa
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool Recover(int id)
        {
            //Lấy thông tin table
            var toRecover = _tableRepository.GetSingleById(id);
            if (toRecover == null)
            {
                //không tồn tại
                return false;
            }
            else
            {
                //cập nhật cột IsDelete
                toRecover.IsDelete = false;
                Update(toRecover);
                //save
                this._unitOfWork.Commit();
                return true;
            }
        }
    }
}
