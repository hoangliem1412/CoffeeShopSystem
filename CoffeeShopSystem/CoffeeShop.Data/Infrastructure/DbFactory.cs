using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory //kế thừa 1 inteface và 1 class.
    {
        CoffeeShopDbContext dbContext;
        public CoffeeShopDbContext Init()
        {
            return dbContext ?? (dbContext = new CoffeeShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
