using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using System.Linq;

namespace CoffeeShop.Service.Tests
{
    [TestClass()]
    public class MaterialLogServiceTests
    {
        private IMaterialLogService sv;
        private List<MaterialLog> list;

        [TestInitialize]
        public void Initialize()
        {
            var fac = new DbFactory();
            sv = new MaterialLogService(new MaterialLogRepository(fac), new UnitOfWork(fac));
        }

        [TestMethod]
        public void GetAllTest()
        {
            var result = sv.GetAll();
            Assert.AreEqual(3, result.Count());
        }
    }
}