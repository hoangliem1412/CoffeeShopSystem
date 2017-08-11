using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Service
{
    public class PromotionService : IPromotionService
    {
        IPromotionRepository _PromotionRepository;
        IUnitOfWork _unitOfWork;
        public PromotionService(IPromotionRepository PromotionRepository, IUnitOfWork unitOfWork)
        {
            this._PromotionRepository = PromotionRepository;
            this._unitOfWork = unitOfWork;
        }


        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Promotion> GetAll()
        {
            return _PromotionRepository.GetAll(); //select duoc group Promotion tuong ung.
        }


        /// <summary>
        /// Get List Active
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Promotion> GetActive()
        {
            return _PromotionRepository.GetMany(x => x.IsDelete != true);
        }


        /// <summary>
        /// Get List Delete
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Promotion> GetDelete()
        {
            return _PromotionRepository.GetMany(x => x.IsDelete == true);
        }



        /// <summary>
        /// Get Promotion by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Promotion GetByID(int id)
        {
            // Để truyền ra Ajax => Show data to update
            var promotion = _PromotionRepository.GetSingleById(id);
            Promotion p = new Promotion();
            p.ID = promotion.ID;
            p.Name = promotion.Name;
            p.ShopID = promotion.ShopID;
            p.StartDate = promotion.StartDate;
            p.EndDate = promotion.EndDate;
            p.BasePurchase = promotion.BasePurchase;
            p.Discount = promotion.Discount;
            p.Description = promotion.Description;
            return p;
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IEnumerable<Promotion> Search(string keyword)
        {
            if (keyword == "")
            {
                return GetActive();
            }
            else
            {
                return _PromotionRepository.GetMany(x => x.Name.ToLower().Contains(keyword) || x.Description.ToLower().Contains(keyword) && x.IsDelete != true);
            }
        }


        /// <summary>
        /// Add Promotion
        /// </summary>
        /// <param name="Promotion"></param>
        public void Add(Promotion Promotion)
        {
            _PromotionRepository.Add(Promotion);
            Save();
        }



        /// <summary>
        /// Update Promotion
        /// </summary>
        /// <param name="Promotion"></param>
        public void Update(Promotion Promotion)
        {
            _PromotionRepository.Update(Promotion);
            Save();
        }



        /// <summary>
        /// Delete Promotion
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            // Load to Update IsDelete = true
            var p = _PromotionRepository.GetSingleById(id);

            // Nếu pro đã có trong hóa đơn => k xóa
            if (p.Orders.Any(o => o.PromotionID == id))
            {
                return false;
            }
            else
            {
                p.IsDelete = true;
                _PromotionRepository.Update(p);
                Save();
                return true;
                
            }

        }


        public int GetTotalPage(int totalitem, int recordsPerPage)
        {
            int nPages = totalitem / recordsPerPage;
            int m = totalitem % recordsPerPage;

            if (m > 0)
            {
                nPages++;
            }
            else
            {

            }
            return nPages;
        }


        /// <summary>
        /// Phân trang
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Promotion> Paging(IEnumerable<Promotion> List, int recordsPerPage, int page)
        {
            return _PromotionRepository.Paging(List, recordsPerPage, page);
        }


        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            _unitOfWork.Commit();
        }


        //public Promotion GetByID(int id)
        //{
        //    return _PromotionRepository.GetSingleById(id);
        //}


        //public IEnumerable<Promotion> GetAllPaging(int page, int size, out int totalRow)
        //{
        //    return _PromotionRepository.GetMultiPaging(x => (!x.IsDelete ?? true), out totalRow, page, size);
        //}

        //public IEnumerable<Promotion> GetAllPagingByGroup(int groupPromotion, int pageIndex, int pageSize, out int totalRow)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Promotion> GetAllPagingByGroup(int groupPromotion, int pageIndex, int pageSize, out int totalRow)
        //{
        //    //return _PromotionRepository.GetMultiPaging(x => (!x.IsDelete ?? true) && x.GroupPromotionID == groupPromotion, out totalRow, pageIndex, pageSize, new string[] { "GroupPromotion" });
        //}


    }
}
