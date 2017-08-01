using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Service
{
    public interface ITableService
    {
        void Add(Table table);
        void Update(Table table);
        void Delete(int id);
        IEnumerable<Table> GetAll();
        IEnumerable<Table> GetAllPaging(int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Table> GetAllPagingByGroup(int groupTable, int pageIndex, int pageSize, out int totalRow);
        Table GetByID(int id);
        void Save();
    }
    public class TableService : ITableService
    {
        ITableRepository _tableRepository;
        IUnitOfWork _unitOfWork;
        public TableService(ITableRepository tableRepository, IUnitOfWork unitOfWork)
        {
            this._tableRepository = tableRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Table table)
        {
            _tableRepository.Add(table);
        }

        public void Delete(int id)
        {
            _tableRepository.Delete(id);
        }

        public IEnumerable<Table> GetAll()
        {
            return _tableRepository.GetAll(new string[] { "GroupTable" }); //select duoc group table tuong ung.
        }

        public IEnumerable<Table> GetAllPaging(int page, int size, out int totalRow)
        {
            return _tableRepository.GetMultiPaging(x => (!x.IsDelete ?? true), out totalRow, page, size);
        }

        public IEnumerable<Table> GetAllPagingByGroup(int groupTable, int pageIndex, int pageSize, out int totalRow)
        {
            return _tableRepository.GetMultiPaging(x => (!x.IsDelete ?? true) && x.GroupTableID == groupTable, out totalRow, pageIndex, pageSize, new string[] { "GroupTable" });
        }

        public Table GetByID(int id)
        {
            return _tableRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Table table)
        {
            _tableRepository.Update(table);
        }
    }
}
