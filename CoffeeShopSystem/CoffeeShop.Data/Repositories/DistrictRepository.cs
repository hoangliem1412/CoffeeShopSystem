using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Data.Repositories
{
    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        public DistrictRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<District> GetByCityID(Expression<Func<District, bool>> expression)
        {
            return GetMany(expression);
        }
    }
}