using Moq;
using NUnit.Framework;
using ProductManagement.Helper;
using ProductManagementDBEntity.Models;
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
        /// <summary>
        /// To get all products
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// To test for exception while getting products
        /// </summary>
        /// <returns></returns>

        [Test]
        public async Task GetAll_InValid_ReturnsNull()
        {
            mockProductRepository.Setup(d => d.GetAllProducts()).ReturnsAsync((List<Products>)(null));
            var result = await productManagementHelper.GetAllProducts();
            Assert.That(result, Is.Null);
        }
        //[Test]
        //public async Task GetProducts_Valid_Returns()
        //{
        //    mockProductRepository.Setup(d => d.GetProducts(It.IsAny<int>())).ReturnsAsync(new Products());
        //    var result = await productManagementHelper.GetProducts(10);
        //    Assert.That(result, Is.Not.Null);
        //    /*            Assert.That(result.UserId, Is.EqualTo(10));*/
        //}

        //    [Test]
        //public async Task GetUser_InValid_ReturnsNull()
        //{
        //    mockProductRepository.Setup(d => d.GetProducts(It.IsAny<int>())).ReturnsAsync((Products)(null));
        //    var result = await productManagementHelper.GetProducts(1);
        //    Assert.That(result, Is.Null);
        //}
        /// <summary>
        /// To add new product
        /// </summary>

        /// <returns></returns>
        [Test]
        public async Task AddProduct_valid_Returns()
        {
            mockProductRepository.Setup(d => d.AddProduct(It.IsAny<Products>())).ReturnsAsync(true);
            var result = await productManagementHelper.AddProduct(new Products()
            {
                ProductId = 3,
                ProductName = "Bangles",
                ProductDesc = "Good",
                ProductPrice = 1000,
                ProducedDate = DateTime.Now,
                ProductExpireDate = DateTime.Now,
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 1
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }
        /// <summary>
        /// To update an existing product
        /// </summary>

        /// <returns></returns>
        [Test]
        public async Task UpdateProduct_valid_Returns()
        {
            mockProductRepository.Setup(d => d.UpdateProduct(It.IsAny<Products>())).ReturnsAsync(true);
            var result = await productManagementHelper.UpdateProduct(new Products()
            {
                ProductId = 3,
                ProductName = "Bangles",
                ProductDesc = "Good",
                ProductPrice = 1000,
                ProducedDate = DateTime.Now,
                ProductExpireDate = DateTime.Now,
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 1
            });

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }

    }
}
