using Microsoft.EntityFrameworkCore;
using ProductManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDBEntity.Repository
{
   public class ProductRepository : IProductRepository
    {
        public ProductDBContext _productDbContext;
        public ProductRepository(ProductDBContext productDbContext)
        {
            _productDbContext = productDbContext;
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
                _productDbContext.Products.Add(product);
                var product1 = await _productDbContext.SaveChangesAsync();
                if (product1 > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
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
                Products product = _productDbContext.Products.Find(productId);
                _productDbContext.Products.Remove(product);
                var product1 = await _productDbContext.SaveChangesAsync();
                if (product1 > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// To retrieve products by using userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Products>> GetProducts(int userId)
        {
            try
            {
                return await _productDbContext.Products.Where(e => e.UserId == userId).ToListAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<Products> GetProductById(int ProductId)
        {
            try
            {
                return await _productDbContext.Products.FindAsync(ProductId);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// To update an existing product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> UpdateProduct(Products product)
        {
            try
            {
                _productDbContext.Products.Update(product);
                var product1 = await _productDbContext.SaveChangesAsync();
                if (product1 > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// To retrieve all products
        /// </summary>
        /// <returns></returns>
        
        public async Task<List<Products>> GetAllProducts()
        {
            try
            {
               
                return await _productDbContext.Products.ToListAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}


