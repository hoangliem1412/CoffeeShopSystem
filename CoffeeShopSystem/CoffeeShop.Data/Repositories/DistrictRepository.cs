﻿using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;

namespace CoffeeShop.Data.Repositories
{
    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        public DistrictRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}