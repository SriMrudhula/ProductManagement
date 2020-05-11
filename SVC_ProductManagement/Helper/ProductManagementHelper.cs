using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Helper
{

    public interface IProductManagementHelper
    {
        Task<List<Products>> GetAllProducts();
        public Task<Products> GetProductById(int ProductId);
        Task<bool> AddProduct(Products product);
        Task<List<Products>> GetProducts(int userId);
        Task<bool> UpdateProduct(Products product);
        Task<bool> DeleteProduct(int productId);
    }
    public class ProductManagementHelper : IProductManagementHelper
    {
        private readonly IProductRepository _iProductRepository;

        public ProductManagementHelper(IProductRepository iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }

        /// <summary>
        /// To get all existing products
        /// </summary>

        /// <returns></returns>
        public async Task<List<Products>> GetAllProducts()
        {
            try
            {
                return await _iProductRepository.GetAllProducts();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// To add a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>

        public async Task<bool> AddProduct(Products product)
        {
            try
            {
                bool products = await _iProductRepository.AddProduct(product);
                return products;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// To retrieve products by using UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Products>> GetProducts(int userId)
        {
            try
            {
                List<Products> products = await _iProductRepository.GetProducts(userId);
                if (products != null)
                {
                    return products;
                }
                else
                    return null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To Update an existing product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> UpdateProduct(Products product)
        {
            try
            {
                bool products = await _iProductRepository.UpdateProduct(product);
                return products;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Products> GetProductById(int ProductId)
        {
            try
            {
                return await _iProductRepository.GetProductById(ProductId);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// To delete a product by using productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {

                bool product1 = await _iProductRepository.DeleteProduct(productId);
                return product1;
            }
            catch
            {
                throw;
            }
        }

    }
}
