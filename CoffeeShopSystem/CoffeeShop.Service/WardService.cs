using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
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

        public int Insert(Ward ward)
        {
            var list = base.GetAll();
            bool check = false;
            foreach (var item in list)
            {
                if (ward.Name == item.Name && ward.DistrictID == item.DistrictID)
                {
                    check = true;
                }
            }
            if (!check)
            {
                base.Add(ward);
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public int Edit(Ward ward)
        {
            base.Update(ward);
            var list = base.GetAll();
            int count = 0;
            foreach (var item in list)
            {
                if (ward.Name == item.Name && ward.DistrictID == item.DistrictID)
                {
                    count++;
                }
            }
            if (count >= 2)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public void Delete1(int id)
        {
            var ward = base.GetSingleById(id);
            ward.IsDelete = true;
            base.Update(ward);
        }

        public void Restore(int id)
        {
            var ward = base.GetSingleById(id);
            ward.IsDelete = false;
            base.Update(ward);
        }
    }
}
