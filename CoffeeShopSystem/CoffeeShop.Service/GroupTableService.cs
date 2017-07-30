using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.Models;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public interface IGroupTableService
    {
        GroupTable Add(GroupTable group);

        void Update(GroupTable group);

        GroupTable Delete(int id);

        IEnumerable<GroupTable> GetAll();

        GroupTable GetByID(int id);
    }

    public class GroupTableService : IGroupTableService
    {
        private IGroupTableRepository _groupTableRepository;
        private IUnitOfWork _unitOfWork;

        public GroupTableService(IGroupTableRepository groupTableRepository, IUnitOfWork unitOfWork)
        {
            this._groupTableRepository = groupTableRepository;
            this._unitOfWork = unitOfWork;
        }

        public GroupTable Add(GroupTable group)
        {
            return _groupTableRepository.Add(group);
        }

        public GroupTable Delete(int id)
        {
            return _groupTableRepository.Delete(id);
        }

        public IEnumerable<GroupTable> GetAll()
        {
            return _groupTableRepository.GetAll();
        }

        public GroupTable GetByID(int id)
        {
            return _groupTableRepository.GetSingleById(id);
        }

        public void Update(GroupTable group)
        {
            _groupTableRepository.Update(group);
        }
    }
}