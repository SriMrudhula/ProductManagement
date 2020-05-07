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

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                bool product = await _iProductRepository.DeleteProduct(productId);
                return product;
            }
            catch
            {
                throw;
            }
        }

    }
}
