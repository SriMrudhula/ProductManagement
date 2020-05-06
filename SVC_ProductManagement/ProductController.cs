using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement
{
    [Route("api/v1")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GetProducts/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetProducts(int userId)
        {
            try
            {
                return Ok(await _productRepository.GetProducts(userId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
       

        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(Products products)
        {
            try
            {
                await _productRepository.AddProduct(products);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        

        [Route("UpdateProduct")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Products products)
        {
            try
            {
                await _productRepository.UpdateProduct(products);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        [Route("DeleteProduct/{productId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                await _productRepository.DeleteProduct(productId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}