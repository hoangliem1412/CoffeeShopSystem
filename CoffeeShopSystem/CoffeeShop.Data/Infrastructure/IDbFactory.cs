using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        CoffeeShopDbContext Init(); // 1 phương thức đễ khởi tạo dbcontext
    }
}
