
using NUnit.Framework;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST_ProductManagement.Data;

namespace TST_ProductManagement.Repository
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private IProductRepository productRepository;
        private ProductDBContext mockProductManagementContext;
        private ProductDatas mockProductDatas;
        [SetUp]
        public void Setup()
        {
            mockProductManagementContext = new Sqlite().CreateSqliteConnection();
            productRepository = new ProductRepository(mockProductManagementContext);
            mockProductDatas = new ProductDatas();
        }
        /// <summary>
        /// To get all products
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAll_Valid_Returns()
        {
            mockProductManagementContext.Products.AddRange(mockProductDatas.products);
            await mockProductManagementContext.SaveChangesAsync();
            var getAllProducts = await productRepository.GetAllProducts();
            Assert.That(getAllProducts, Is.Not.Null);
            Assert.That(getAllProducts.Count, Is.EqualTo(2));

        }
        /// <summary>
        /// To test for an exception while getting products
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetProducts_Valid_Returns()
        {
            mockProductManagementContext.Products.AddRange(mockProductDatas.products);
            await mockProductManagementContext.SaveChangesAsync();
            var getProductsById = await productRepository.GetProducts(8);
            Assert.That(getProductsById, Is.Not.Null);
            Assert.That(getProductsById.Count, Is.EqualTo(10));
        }
        /// <summary>
        /// To add a new product
        /// </summary>

        /// <returns></returns>
        [Test]
        public async Task AddProduct_Valid_Returns()
        {
            mockProductManagementContext.Products.AddRange(mockProductDatas.products);
            await mockProductManagementContext.SaveChangesAsync();
            var getProductById = await productRepository.AddProduct(
                new Products()
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
            Assert.That(getProductById, Is.Not.Null);
            Assert.That(getProductById, Is.EqualTo(true));
        }

    }
}
