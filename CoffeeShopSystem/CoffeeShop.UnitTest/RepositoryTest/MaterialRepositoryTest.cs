using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class MaterialRepositoryTest
    {
        IDbFactory dbFactory;
        IMaterialRepository objRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize() //test phuong thuc khoi tao. de khoi tao cac khoi tuong test
        {
            dbFactory = new DbFactory();
            objRepository = new MaterialRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void GroupTable_Repository_GetAll()
        {
            var list = objRepository.GetAll(new string[] { "MaterialCategory"}).ToList();
            Assert.AreEqual(7, list.Count);
        }
    }
}
