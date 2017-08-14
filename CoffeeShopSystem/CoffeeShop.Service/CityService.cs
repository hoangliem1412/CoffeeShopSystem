using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CoffeeShop.Service
{
    public class CityService :Service<City>, ICityService
    {
        //ICityRepository _cityRepository;
        //IUnitOfWork _unitOfWork;

        public CityService(IRepository<City> cityRepository, IUnitOfWork unitOfwork) : base(cityRepository, unitOfwork)
        {
        }

        public int Insert(City city)
        {
            var list = base.GetAll();
            bool check = false;
            foreach (var item in list)
            {
                if (city.Name == item.Name)
                {
                    check = true;
                }
            }
            if (!check)
            {
                var rs = base.Add(city);
                base.Save();
                return rs.ID;
            }
            else
            {
                return -1;
            }
        }

        public int Edit(City city)
        {
            base.Update(city);
            var list = base.GetAll();
            int count = 0;
            foreach (var item in list)
            {
                if (city.Name == item.Name)
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

        public IEnumerable<City> GetAllIsDelete()
        {
            return base.GetAll().Where(c => c.IsDelete == false).OrderBy(c => c.Name);
        }

        public IEnumerable<City> GetAll(string keyword)
        {
            return base.GetMulti(x => x.Name.Contains(keyword));
        }

        public void Delete1(int id)
        {
            var city = base.GetSingleById(id);
            city.IsDelete = true;
            base.Update(city);
        }

        public void Restore(int id)
        {
            var city = base.GetSingleById(id);
            city.IsDelete = false;
            base.Update(city);
        }

        public void CreateNew(City c)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(City c)
        {
            throw new NotImplementedException();
        }

        public City GetCityByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> SearchByNameOrDescription(string Filter)
        {
            throw new NotImplementedException();
        }
    }
}
