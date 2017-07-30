﻿using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.Models;

namespace CoffeeShop.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
    }
}