using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using System.Linq.Expressions;

namespace CoffeeShop.Service
{
    public class MaterialService : IMaterialService
    {
        IMaterialRepository materialRepository;
        //IMaterialLogRepository materialLogRepository;
        IUnitOfWork unitOfWork;
        public MaterialService(IMaterialRepository repoMate, IUnitOfWork unit)
        {
            this.materialRepository = repoMate;
            //materialLogRepository = repoMateLog;
            this.unitOfWork = unit;
        }
        public Material Add(Material material)
        {
            var rs = materialRepository.Add(material);
            //MaterialLog mateLog = new MaterialLog()
            //{
            //    MaterialID = rs.ID,
            //    Inventory = rs.Inventory,
            //    UnitPrice = rs.UnitPrice,
            //    CreatedDate = DateTime.Now,
            //    IsDelete = false,
            //    Type = false,
            //    //EmployeeID
            //};
            //materialLogRepository.Add(mateLog);
            return rs;
        }

        public void Delete(int id)
        {
            var mate = GetSingleByID(id);
            mate.IsDelete = !mate.IsDelete;
            materialRepository.Update(mate);
            //MaterialLog mateLog = new MaterialLog()
            //{
            //    MaterialID = mate.ID,
            //    Inventory = mate.Inventory,
            //    UnitPrice = mate.UnitPrice,
            //    CreatedDate = DateTime.Now,
            //    IsDelete = false,
            //    Type = true,
            //    //EmployeeID
            //};
            //materialLogRepository.Add(mateLog);
        }

        public Material GetSingleByID(int id)
        {
            return materialRepository.GetSingleById(id);
        }

        public void Update(Material mate)
        {
            materialRepository.Update(mate);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<Material> GetSearch(string keyword)
        {
            return materialRepository.GetMulti(x => x.Name.Contains(keyword) && (!x.IsDelete ?? true));
        }

        public IEnumerable<Material> GetSearchPaging(string keyword, int index, int size, out int total)
        {
            return materialRepository.GetMultiPaging(x => x.Name.Contains(keyword), out total, index, size);
        }

        public IEnumerable<Material> GetMulti(Expression<Func<Material, bool>> predicate)
        {
            return materialRepository.GetMulti(predicate);
        }

        public IEnumerable<Material> GetSearchStatusPaging(string keyword, int status, int index, int size, out int total)
        {

            Expression<Func<Material, bool>> func;
            switch (status)
            {
                case 2:
                    func = x => x.IsDelete == false && (x.Name.Contains(keyword) || x.Description.Contains(keyword) || x.CreatedDate.ToString().Contains(keyword) || x.UnitPrice.ToString().Contains(keyword));
                    break;
                case 3:
                    func = x => x.IsDelete == true && (x.Name.Contains(keyword) || x.Description.Contains(keyword) || x.CreatedDate.ToString().Contains(keyword) || x.UnitPrice.ToString().Contains(keyword));
                    break;
                default:
                    func = x => (x.Name.Contains(keyword) || x.Description.Contains(keyword) || x.CreatedDate.ToString().Contains(keyword) || x.UnitPrice.ToString().Contains(keyword));
                    break;
            }
            var query = materialRepository.GetMulti(func);
            total = query.Count();
            query = query.OrderByDescending(x => x.CreatedDate)
              .Skip((index - 1) * size)
              .Take(size).AsEnumerable();

            return query;
        }
    }
}
