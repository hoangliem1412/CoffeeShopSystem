using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using CoffeeShop.Data.Infrastructure;

namespace CoffeeShop.Service
{


    public class ShopService : IShopService
    {

        private IShopRepository shopRepository;
        private IUnitOfWork unitOfWork;
        


        public ShopService(IShopRepository shopRepository, IUnitOfWork unitOfWork)
        {
            // TODO: Complete member initialization
            this.shopRepository = shopRepository;
            this.unitOfWork = unitOfWork;
        }


        public bool ValidShopModel(Shop s)
        {   
            bool notValid = s.ID == null || s.Name == null || s.DetailAddress == null || s.WardID == null;
            if (notValid)
            {
                return false;
            }
            return true;
        }

        public bool CreateNew(Shop s)
        {   
            if (!ValidShopModel(s))
            {
                return false;
            }


            if (s.IsDelete == null)
            {
                s.IsDelete = false;
            }

            try
            {
                shopRepository.Add(s);
                this.unitOfWork.Commit();
            }

            catch 
            { 
                return false; 
            }

            return true;
           


        }

        public  IEnumerable<Shop> GetAll()
        {
            return shopRepository.GetAll();
        }

        public IEnumerable<Shop> GetAllNonDelete()
        {
            return shopRepository.GetMulti( s=> s.IsDelete == false,null);
        }


        public IEnumerable<Shop> GetAllDeleted()
        {
            return shopRepository.GetMulti(s => s.IsDelete == true, null);
        }

        public bool Update(Shop s)
        {
            if (!ValidShopModel(s))
            {
                return false;
            }

            try
            {
                Shop originShop = shopRepository.GetsingleByCondition(shop => shop.ID == s.ID, null);
                originShop.Name = s.Name;
                originShop.Description = s.Description;
                if (s.IsDelete == null)
                {
                    originShop.IsDelete = false;
                }

                else
                {
                    originShop.IsDelete = true;
                }
                originShop.DetailAddress = s.DetailAddress;
                originShop.WardID = s.WardID;
                shopRepository.Update(originShop);
                this.unitOfWork.Commit();
            }
            catch 
            { 
                return false; 
            }

            return true;
        }

        public bool SoftDelete(Shop s)
        {
            if (!ValidShopModel(s))
            {
                return false;
            }

            s.IsDelete = true;
            try
            {
                shopRepository.Update(s);
                this.unitOfWork.Commit();
            }

            catch 
            {
                return false;
            }


            return true;
        }



        public Shop GetShopByID(int id)
        {  
             
            return shopRepository.GetSingleById(id);
        }

        public IEnumerable<Shop> SearchByNameOrDescription(string Filter, int curPage = 1,int pageSize =5, string sort="ID", string type="asc", string option ="Managing")
        {
            int total;
            if (Filter == "")
            {
                if (option == "Managing")
                {
                    return shopRepository.GetMultiPagingForShop(s => s.IsDelete == false, out total, curPage, pageSize, sort, type);
                }

                // option = deleted 
                return shopRepository.GetMultiPagingForShop(s => s.IsDelete == true, out total, curPage, pageSize, sort, type);
            }

            // có input Filter
            else
            {
                if (option == "Managing")
                {
                    return shopRepository.GetMultiPagingForShop(u => (u.Name.Contains(Filter) || u.Description.Contains(Filter)) && u.IsDelete == false, out total, curPage, pageSize, sort, type);
                }

                //option = deleted
                return shopRepository.GetMultiPagingForShop(u => (u.Name.Contains(Filter) || u.Description.Contains(Filter)) && u.IsDelete == true, out total, curPage, pageSize, sort, type);
                
            }
        }


        public string ChangeSortType(string type, bool condition)
        {

            if (!condition) return "asc";



            if (type == "asc") type = "desc";
            else type = "asc";
            return type;


        }


        public IEnumerable<Shop> GetAllNonDeleteWithPaginationAndSort(string sort,string type,out int total , int curpage, int pageSize)
        {

            IEnumerable<Shop> listShop;

            listShop = shopRepository.GetMultiPagingForShop(s => s.IsDelete == false,out total,curpage , pageSize , sort, type);
            return listShop.ToList();
        }



        public IEnumerable<Shop> GetAllDeletedWithPaginationAndSort(string sort, string type, out int total, int curpage, int pageSize)
        {

            IEnumerable<Shop> listShop;

            listShop = shopRepository.GetMultiPagingForShop(s => s.IsDelete == true, out total, curpage, pageSize, sort, type);
            return listShop.ToList();
        }
    }
}