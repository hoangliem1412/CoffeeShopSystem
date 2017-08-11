using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace CoffeeShop.Service
{

    public class WardService : Service<Ward>, IWardService
    {
        public WardService(IRepository<Ward> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
        }

        public IEnumerable<Ward> GetAllActive()
        {
            return base.GetAll().Where(x => x.IsDelete == false).ToList();
        }

        public IEnumerable<Ward> GetByDistrictID(int districtID)
        {
            return base.GetAll().Where(x => x.DistrictID == districtID).ToList();
        }
    }
}
