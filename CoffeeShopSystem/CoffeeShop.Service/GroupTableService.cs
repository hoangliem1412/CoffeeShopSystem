using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Service
{
    

    public class GroupTableService : Service<GroupTable>, IGroupTableService
    {
        public GroupTableService(IRepository<GroupTable> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
        }

        public IEnumerable<GroupTable> GetByShop(int id)
        {
            return base.GetMulti(gt => gt.ShopID == id); //select duoc group table tuong ung.
        }
        
        public IEnumerable<dynamic> SearchCondition(string option)
        {
            var key = option.ToLower();
            IEnumerable<GroupTable> result;
            if (key == "delete")
            {
                result = base.GetMulti(t => t.IsDelete == true && t.ShopID == 1);
            }
            else if (key == "manage")
            {
                result = base.GetMulti(t => t.IsDelete != true && t.ShopID == 1);
            }
            else
            {
                result = GetByShop(1);
            }
            return result.Select(gt => new { ID = gt.ID, Name = gt.Name, Surcharge = gt.Surcharge, TableCount = gt.Tables.Count, Description = gt.Description }); ;

        }

        public bool Recover(int id)
        {
            var toRecover = base.GetSingleById(id);
            if (toRecover == null)
            {
                return false;
            }
            else
            {
                toRecover.IsDelete = false;
                Update(toRecover);
                Save();
                return true;
            }
        }
    }
}