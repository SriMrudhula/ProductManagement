using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_ProductManagement.Models;
using Newtonsoft.Json;
using System.Text;

namespace Web_ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        public static string url = "http://localhost:50898/api/v1/";
        // GET: User
        public async Task<IActionResult> Index()
        {
            List<Products> productList = new List<Products>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50898/api/v1/GetAllProducts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
                }
            }
            return View(productList);
        }
        // GET: User/Create
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }
        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Products productDetails)
        {
            Products productDetails1 = new Products();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(productDetails), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:50898/api/v1/AddProduct/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productDetails1 = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public ViewResult GetProducts() => View();

        [HttpGet]
        public async Task<IActionResult> GetProducts(int id)
        {
            Products productDetails= new Products();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50898/api/v1/GetProducts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   productDetails = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            return View(productDetails);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int productid)
        {
            Products productDetails = new Products();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50898/api/v1/GetUser/" + productid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productDetails = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            return View(productDetails);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Products productdetails)
        {
            Products products = new Products();
            int productid = products.ProductId;
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(products.ProductId.ToString()), "productid");
                content.Add(new StringContent(products.ProductName), "ProductName");
                content.Add(new StringContent(products.ProductDesc), "ProductDesc");
                content.Add(new StringContent(products.ProductPrice.ToString()), "ProductPrice");
                content.Add(new StringContent(products.ProducedDate.ToString()), "ProducedDate");
                content.Add(new StringContent(products.ProductExpireDate.ToString()), "ProductExpireDate");
                content.Add(new StringContent(products.CreateDate.ToString()), "CreateDate");
                content.Add(new StringContent(products.UpdatedDate.ToString()), "UpdatedDate");
                content.Add(new StringContent(products.UserId.ToString()), "UserId");
            

                using (var response = await httpClient.PutAsync("http://localhost:50898/api/v1/UpdateProduct/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    products = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public ViewResult DeleteProduct() => View();

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int productid)
        {
            Products products = new Products();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50898/api/v1/DeleteProduct/" + productid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            return View(products);
        }

    }
}