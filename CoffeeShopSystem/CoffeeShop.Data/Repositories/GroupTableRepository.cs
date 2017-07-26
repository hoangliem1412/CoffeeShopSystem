using CoffeeShop.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Repositories
{
    public interface IGroupTableRepository
    {
        //dinh nghia nhung phuong thuc khong co trong repository
    }
    public class GroupTableRepository : RepositoryBase<GroupTableRepository>
    {
        public GroupTableRepository(IDbFactory dbFactory) 
            : base(dbFactory)
        {

        }
    }
}
