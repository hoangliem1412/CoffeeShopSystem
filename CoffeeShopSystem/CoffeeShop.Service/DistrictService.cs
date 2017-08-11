using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Service
{
    
    public class DistrictService : Service<District>, IDistrictService
    {
        private IDistrictRepository _iDistrictRepository;
        private IUnitOfWork _unitOfWork;

        public DistrictService(IRepository<District> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
        }

        public IEnumerable<District> GetDistrictByCityID(int id)
        {
            return _iDistrictRepository.GetAll().Where(d => d.CityID == id && d.IsDelete == false);
        }

        public IEnumerable<District> GetAllIsDelete()
        {
            return _iDistrictRepository.GetAll().Where(c => c.IsDelete == false).OrderBy(c => c.Name);
        }

        public IEnumerable<District> GetAll(string keyword)
        {
            return _iDistrictRepository.GetMulti(x => x.Name.Contains(keyword));
        }

        public void Restore(int id)
        {
            var district = _iDistrictRepository.GetSingleById(id);
            district.IsDelete = false;
            _iDistrictRepository.Update(district);
        }

        public IEnumerable<District> GetByCityID(int cityID)
        {
            return _iDistrictRepository.GetByCityID(x => x.CityID == cityID);
        }
    }
}
