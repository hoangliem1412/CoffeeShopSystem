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
        ICityRepository _cityRepository;
        IUnitOfWork _unitOfWork;

        public CityService(IRepository<City> cityRepository, IUnitOfWork unitOfwork) : base(cityRepository, unitOfwork)
        {
        }

        public IEnumerable<City> GetAllIsDelete()
        {
            return _cityRepository.GetAll().Where(c => c.IsDelete == false).OrderBy(c => c.Name);
        }

        public IEnumerable<City> GetAll(string keyword)
        {
            return _cityRepository.GetMulti(x => x.Name.Contains(keyword));
        }

        public void Restore(int id)
        {
            var city = _cityRepository.GetSingleById(id);
            city.IsDelete = false;
            _cityRepository.Update(city);
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
