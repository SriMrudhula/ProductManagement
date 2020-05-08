using Moq;
using NUnit.Framework;
using ProductManagement.Helper;
using ProductManagementDBEntity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST_ProductManagement.Data;

namespace TST_ProductManagement.Helper
{
    public class ProductManagementHelperTests
    {
        private ProductManagementHelper productManagementHelper;
        private Mock<IProductRepository> mockProductRepository;
        private ProductDatas mockProductData;
        [SetUp]
        public void Setup()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockProductData = new ProductDatas();
            productManagementHelper = new ProductManagementHelper(mockProductRepository.Object);
        }
        [Test]
        public async Task GetAll_Valid_Returns()
        {
            mockProductRepository.Setup(d => d.GetAllProducts()).ReturnsAsync(mockProductData.products);
            var result = await productManagementHelper.GetAllProducts();
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.Count, Is.EqualTo(2));
        }
        
       
    }
}
