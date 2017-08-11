using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;

namespace CoffeeShop.Service
{
    public interface IPromotionService
    {
        void Add(Promotion promotion);
        void Update(Promotion promotion);
        bool Delete(int id);
        void Save();


        // Get All
        IEnumerable<Promotion> GetAll();

        // Get List Active
        IEnumerable<Promotion> GetActive();

        // Get List Delete
        IEnumerable<Promotion> GetDelete();

        // Get By ID
        Promotion GetByID(int id);

        //Search
        IEnumerable<Promotion> Search(string input);

        // Get GetTotalPage
        int GetTotalPage(int totalitem, int recordsPerPage);

        // Phân trang
        IEnumerable<Promotion> Paging(IEnumerable<Promotion> list, int recordsPerPage, int page);
    }
}
