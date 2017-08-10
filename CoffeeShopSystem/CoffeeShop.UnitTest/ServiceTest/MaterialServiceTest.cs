using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.UnitTest.ServiceTest
{
    [TestClass]
    public class MaterialServiceTest
    {
        private IMaterialService materialService;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IMaterialRepository> materialRepository;
        private Mock<IMaterialLogRepository> materialLogRepository;
        private List<Material> listMaterial;
        //private DbFactory dbFactory;
        [TestInitialize]
        public void Initialize()
        {
            //dbFactory = new DbFactory();
            materialLogRepository = new Mock<IMaterialLogRepository>();
            materialRepository = new Mock<IMaterialRepository>();
            unitOfWork = new Mock<IUnitOfWork>();
            materialService = new MaterialService(materialRepository.Object, materialLogRepository.Object, unitOfWork.Object);
            listMaterial = new List<Material>()
            {
                new Material() {ID = 1, Name= "Test 1", CategoryID = 1, IsDelete = false },
                new Material() {ID = 2, Name= "Test 2", CategoryID = 2, IsDelete = false },
                new Material() {ID = 3, Name= "Test 3", CategoryID = 1, IsDelete = true },
                new Material() {ID = 4, Name= "Test 4", CategoryID = 2, IsDelete = false }
            };
        }

        [TestMethod]
        public void Material_Serivice_Add()
        {
            Material mate = new Material()
            {
                Name = "test-name",
                CategoryID = 1,
                UnitPrice = 10000,
                Inventory = 30,
                Description = "test-description",
                CreatedDate = DateTime.Now,
                IsDelete = false
            };
            materialRepository.Setup(m => m.Add(mate)).Returns((Material g) =>
            {
                g.ID = 1;
                return g;
            });
            var rs = materialService.Add(mate);
            Assert.IsNotNull(rs);
            Assert.AreEqual(1, rs.ID);
        }
    }
}
