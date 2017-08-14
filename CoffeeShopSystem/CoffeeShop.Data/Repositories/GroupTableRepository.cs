﻿using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoffeeShop.Data.Repositories
{
    public class GroupTableRepository : RepositoryBase<GroupTable>, IGroupTableRepository
    {
        public GroupTableRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}