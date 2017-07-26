using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Repositories
{
    public class TableRepository : RepositoryBase<Table>
    {
        public TableRepository(IDbFactory dbFactory) : base (dbFactory)
        {

        }
    }
}
