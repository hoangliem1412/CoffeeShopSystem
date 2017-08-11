using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Service
{
    public interface ITableService : IService<Table>
    {
        bool Recover(int id);
        IEnumerable<Table> GetAll();
        IEnumerable<Table> GetByShop(int id);
        IEnumerable<Table> GetAllPaging(int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Table> GetAllPagingByGroup(int groupTable, int pageIndex, int pageSize, out int totalRow);
        Table GetByID(int id);
        IEnumerable<dynamic> SearchBase(string text);
        IEnumerable<dynamic> SearchCondition(string option);
    }
}
