using CoffeeShop.Model;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public interface IMaterialLogService : IService<MaterialLog>
    {
        IEnumerable<MaterialLog> GetAvailable();
        IEnumerable<MaterialLog> GetDeleted();
        IEnumerable<MaterialLog> GetByStatus(IEnumerable<MaterialLog> list, int status);
        dynamic Paging(IEnumerable<MaterialLog> list, int rowPerPage, int currentPage);
        dynamic Flat(MaterialLog buf);
        dynamic Flat(IEnumerable<MaterialLog> buf);
        new void Delete(int id);
        IEnumerable<MaterialLog> SearchByName(string keyword);
        IEnumerable<MaterialLog> Search(MaterialLogSearchViewModel model);
    }
}
