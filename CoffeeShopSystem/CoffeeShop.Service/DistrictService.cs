using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CoffeeShop.Service
{
    
    public class DistrictService : Service<District>, IDistrictService
    {

        public DistrictService(IRepository<District> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
        }

        public int Insert(District district)
        {
            var list = base.GetAll();
            bool check = false;
            foreach (var item in list)
            {
                if (district.Name == item.Name && district.CityID == item.CityID)
                {
                    check = true;
                }
            }
            if (!check)
            {
                base.Add(district);
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public int Edit(District district)
        {
            base.Update(district);
            var list = base.GetAll();
            int count = 0;
            foreach (var item in list)
            {
                if (district.Name == item.Name && district.CityID == item.CityID)
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

        public IEnumerable<District> GetDistrictByCityID(int id)
        {

            return base.GetAll().Where(d => d.CityID == id && d.IsDelete == false);
        }

        public IEnumerable<District> GetAllIsDelete()
        {

            return base.GetAll().Where(c => c.IsDelete == false).OrderBy(c => c.Name);
        }

        public IEnumerable<District> GetAll(string keyword)
        {

            return base.GetMulti(x => x.Name.Contains(keyword));
        }

        public void Delete1(int id)
        {
            var district = base.GetSingleById(id);
            district.IsDelete = true;
            base.Update(district);
        }

        public void Restore(int id)
        {

            var district = base.GetSingleById(id);
            district.IsDelete = false;

            base.Update(district);
        }

        public IEnumerable<District> GetByCityID(int cityID)
        {
             return base.GetAll().Where(x => x.CityID == cityID && x.IsDelete == false);
        }
		
    }
}
