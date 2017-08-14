using System;
using System.Collections.Generic;
using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Model.ModelEntity;
using System.Linq;
using CoffeeShop.Model;
using System.Data.SqlClient;

namespace CoffeeShop.Service
{
    public class MaterialLogService : Service<MaterialLog>, IMaterialLogService
    {
        public MaterialLogService(IRepository<MaterialLog> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public IEnumerable<MaterialLog> GetAvailable()
        {
            return base.GetMulti(x => x.IsDelete == false).ToList();
        }

        public IEnumerable<MaterialLog> GetByStatus(IEnumerable<MaterialLog> list, int status)
        {
            // status = 0: active
            // status = 1: deleted

            IEnumerable<MaterialLog> result = new List<MaterialLog>();

            if (status == -1)
            {
                result = GetMulti(x => x.IsDelete == false).ToList();
            }
            else
            {
                if (status == 0)
                {
                    result = list.Where(x => x.IsDelete == false).ToList();

                    if (result.Count() == 0)
                    {
                        result = GetMulti(x => x.IsDelete == false).ToList();
                    }
                }
                else if (status == 1)
                {
                    result = list.Where(x => x.IsDelete == true).ToList();

                    if (result.Count() == 0)
                    {
                        result = GetMulti(x => x.IsDelete == true).ToList();
                    }
                }
            }

            return result;
        }

        public IEnumerable<MaterialLog> GetDeleted()
        {
            return base.GetMulti(x => x.IsDelete == true).ToList();
        }

        public dynamic Flat(MaterialLog buf)
        {
            if (buf != null)
            {
                var result = new { buf.CreatedDate, buf.Description, buf.EmployeeID, buf.ID, buf.Inventory, buf.IsDelete, MateName = buf.Material.Name, buf.MaterialID, buf.Type, buf.UnitPrice, EmpName = buf.User.Name };
                return result;
            }

            return null;
        }

        public dynamic Paging(IEnumerable<MaterialLog> list, int rowPerPage, int currentPage)
        {
            if (list.Count() > 0)
            {
                var result = list.Skip((currentPage - 1) * rowPerPage)
                .Take(rowPerPage)
                .Select(x => new { x.ID, x.Inventory, x.IsDelete, MateName = x.Material.Name, x.MaterialID, x.Type, x.UnitPrice, CreatedDate = x.CreatedDate.GetValueOrDefault(DateTime.Now), x.Description, x.EmployeeID, EmpName = x.User.Name })
                .ToList();

                return result;
            }

            return null;
        }

        public new bool Delete(int id)
        {
            var item = base.GetSingleById(id);
            var result = true;

            try
            {
                if (item != null)
                {
                    item.IsDelete = true;
                    base.Update(item);
                    Save();
                }
            }
            catch (SqlException ex)
            {
                result = false;
            }

            return result;
        }

        public new MaterialLog Add(MaterialLog item)
        {
            var newItem = base.Add(item);

            try
            {
                Save();
            }
            catch (SqlException ex)
            {
                newItem = null;
            }
            
            return item;
        }

        public new bool Update(MaterialLog item)
        {
            base.Update(item);
            var result = true;

            try
            {
                Save();
            }
            catch (SqlException ex)
            {
                result = false;
            }

            return result;
        }

        public IEnumerable<MaterialLog> SearchByName(string keyword)
        {
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                return GetMulti(x => x.Material.Name.Contains(keyword)).ToList();
            }

            return new List<MaterialLog>();
        }

        public dynamic Flat(IEnumerable<MaterialLog> buf)
        {
            if (buf.Count() > 0)
            {
                var result = buf
                    .Select(x => new { x.ID, x.Inventory, x.IsDelete, MateName = x.Material.Name, x.MaterialID, x.Type, x.UnitPrice, CreatedDate = x.CreatedDate.GetValueOrDefault(DateTime.Now), x.Description, x.EmployeeID, EmpName = x.User.Name })
                    .ToList();
                return result;
            }

            return new List<MaterialLog>();
        }

        public IEnumerable<MaterialLog> Search(MaterialLogSearchViewModel model)
        {
            IEnumerable<MaterialLog> result = GetAll();

            if (model.ID != 0)
            {
                result = result.Where(x => x.ID == model.ID).ToList();
            }

            if (model.FromDate != DateTime.MinValue)
            {
                result = result.Where(x => x.CreatedDate.GetValueOrDefault(DateTime.Now) >= model.FromDate).ToList();
            }

            if (model.ToDate != DateTime.MinValue)
            {
                result = result.Where(x => x.CreatedDate.GetValueOrDefault(DateTime.Now) <= model.ToDate).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.Description))
            {
                result = result.Where(x => x.Description.Contains(model.Description)).ToList();
            }

            if (model.Inventory != 0)
            {
                result = result.Where(x => x.Inventory.GetValueOrDefault(0) == model.Inventory).ToList();
            }

            if (model.UnitPrice != 0)
            {
                result = result.Where(x => x.UnitPrice.GetValueOrDefault(0) == model.UnitPrice).ToList();
            }

            if (model.Type != -1)
            {
                result = result.Where(x => x.Type.GetValueOrDefault(false) == Convert.ToBoolean(model.Type)).ToList();
            }

            if (model.IsDelete != -1)
            {
                result = result.Where(x => x.IsDelete.GetValueOrDefault(false) == Convert.ToBoolean(model.IsDelete)).ToList();
            }

            return result;
        }
    }
}
