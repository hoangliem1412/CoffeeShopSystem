using System.Collections.Generic;
using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Data.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        IEnumerable<Order> GetAllPagingByGroup(int group, int pageIndex, int pageSize, out int totalRow);

        /// <summary>
        /// Tìm kiếm theo ID hoặc Tên bàn  hoặc tên khách hàng
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns> IEnumerable<Order></returns>
        IEnumerable<Order> SearchByIDandTable(string keyword);
    }
}
