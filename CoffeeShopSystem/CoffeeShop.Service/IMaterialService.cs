using CoffeeShop.Model.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoffeeShop.Service
{
    public interface IMaterialService
    {
        Material Add(Material mate);

        void Update(Material mate);

        void Delete(int id);

        Material GetSingleByID(int id);

        IEnumerable<Material> GetMulti(Expression<Func<Material, bool>> predicate);

        IEnumerable<Material> GetSearch(string keyword);

        IEnumerable<Material> GetSearchPaging(string keyword, int index, int size, out int total);

        IEnumerable<Material> GetSearchStatusPaging(string keyword, int status, int index, int size, out int total);

        void Save();
    }
}