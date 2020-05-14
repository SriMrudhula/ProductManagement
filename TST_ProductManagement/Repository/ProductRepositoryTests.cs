
using NUnit.Framework;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST_ProductManagement.Data;
using TST_UserManagement.Data;

namespace TST_ProductManagement.Repository
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private IProductRepository productRepository;
        private ProductDBContext mockProductManagementContext;
        private ProductDatas mockProductDatas;
        private UserDatas mockUserDatas;
        [SetUp]
        public void Setup()
        {
            mockProductManagementContext = new Sqlite().CreateSqliteConnection();
            productRepository = new ProductRepository(mockProductManagementContext);
            mockProductDatas = new ProductDatas();
            mockUserDatas = new UserDatas();
        }
        /// <summary>
        /// To get all products
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAll_Valid_Returns()
        {
            mockProductManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockProductManagementContext.SaveChangesAsync();
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
            mockProductManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockProductManagementContext.SaveChangesAsync();
            mockProductManagementContext.Products.AddRange(mockProductDatas.products);
            await mockProductManagementContext.SaveChangesAsync();
            var getProducts = await productRepository.GetProducts(3);
            Assert.That(getProducts, Is.Not.Null);
        }
        /// <summary>
        /// To add a new product
        /// </summary>

        /// <returns></returns>
        [Test]
        public async Task AddProduct_Valid_Returns()
        {
            mockProductManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockProductManagementContext.SaveChangesAsync();
            mockProductManagementContext.Products.AddRange(mockProductDatas.products);
            await mockProductManagementContext.SaveChangesAsync();
            var getProductById = await productRepository.AddProduct(
                new Products()
                {
                    ProductId = 5,
                    ProductName = "Bangles1",
                    ProductDesc = "Good",
                    ProductPrice = 1000,
                    ProducedDate = DateTime.Now,
                    ProductExpireDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UserId = 10
                });
            Assert.That(getProductById, Is.Not.Null);
            Assert.That(getProductById, Is.EqualTo(true));
        }
        //[Test]
        //public async Task DeleteProduct_Valid_Return()
        //{
        //    mockProductRepository.Setup(d => d.GetAllProducts()).ReturnsAsync(mockProductData.products);
        //    var result = await productManagementHelper.DeleteProduct(1);
        //    Assert.That(result, Is.Null);


        //}
    }
}
