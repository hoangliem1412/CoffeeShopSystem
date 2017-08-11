using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Service
{
    public interface IDistrictService : IService<District>
    {
        IEnumerable<District> GetAll();

        IEnumerable<District> GetDistrictByCityID(int id);

        IEnumerable<District> GetAllIsDelete();

        IEnumerable<District> GetAll(string keyword);

        void Restore(int id);

        District GetByID(int id);

        IEnumerable<District> GetByCityID(int cityID);
    }

}
