using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Service
{
    public interface IGroupTableService : IService<GroupTable>
    {
        bool Recover(int id);
        IEnumerable<GroupTable> GetAll();
        IEnumerable<GroupTable> GetByShop(int id);

        GroupTable GetByID(int id);

        IEnumerable<dynamic> SearchCondition(string option);
    }
}
