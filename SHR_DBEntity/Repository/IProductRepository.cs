using ProductManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDBEntity.Repository
{
    public interface IProductRepository
    {
        Task<bool> AddProduct(Products product);
        Task<List<Products>> GetProducts(int userId);
        Task<bool> UpdateProduct(Products product);
        Task<bool> DeleteProduct(int productId);
    }
}
