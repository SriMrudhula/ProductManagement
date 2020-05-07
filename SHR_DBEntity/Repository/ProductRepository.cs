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

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Products product = await _productDbContext.Products.FindAsync(productId);
                _productDbContext.Products.Remove(product);
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


