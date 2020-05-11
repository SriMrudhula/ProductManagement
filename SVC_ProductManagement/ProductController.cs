using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Helper;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement
{
    [Route("api/v1")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductManagementHelper _iProductManagementHelper;
        public ProductController(IProductManagementHelper iproductManagementHelper)
        {
            _iProductManagementHelper = iproductManagementHelper;
        }
        /// <summary>
        /// To retrieve products by using userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GetProducts/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetProducts(int userId)
        {
            try
            {
                return Ok(await _iProductManagementHelper.GetProducts(userId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// To add a new Product
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>

        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(Products products)
        {
            try
            {
                await _iProductManagementHelper.AddProduct(products);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }


        /// <summary>
        /// To update an existing product
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>


        [Route("UpdateProduct")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Products products)
        {
            try
            {
                await _iProductManagementHelper.UpdateProduct(products);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetProductById/{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                return Ok(await _iProductManagementHelper.GetProductById(productId));
            }
            catch(Exception ex)
            {
                return Ok(ex.InnerException.Message);
            }
        }
        /// <summary>
        /// To delete a product by using productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        [Route("DeleteProduct/{productId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                await _iProductManagementHelper.DeleteProduct(productId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// To retrieve all existing products
        /// </summary>
        /// <param name="All Products"></param>
        /// <returns></returns>
        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                List<Products> userDetails = await _iProductManagementHelper.GetAllProducts();
                return Ok(userDetails);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}