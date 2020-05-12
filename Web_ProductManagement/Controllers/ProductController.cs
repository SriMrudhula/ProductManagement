using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_UserManagement.Models;
using Newtonsoft.Json;
using System.Text;
using System.Web;
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
            productDetails.CreateDate = DateTime.Now;
            productDetails.UserId= Convert.ToInt32(TempData["UserId"]);
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(productDetails), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:50898/api/v1/AddProduct/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetProducts", new { id=TempData["UserId"]});
        }
        public ViewResult GetProducts() => View();

        [HttpGet]
        public async Task<IActionResult> GetProducts(int id)
        {
            List<Products> productList = new List<Products>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50898/api/v1/GetProducts/"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
                }
            }
            TempData["UserId"] = id; 
            return View(productList);
        }
        public ViewResult GetProductById() => View();
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            Products productList = new Products();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50898/api/v1/GetProductById/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            TempData["UserId"] = id;
            return View(productList);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            Products productDetails = new Products();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50898/api/v1/GetProductById/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productDetails = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            TempData["UserId"] = id;
            return View(productDetails);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Products product)
        {
            product.UpdatedDate = DateTime.Now;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), System.Text.Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:50898/api/v1/UpdateProduct/", content))
                {
                   string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetProducts", new { id =product.UserId});
     }

        public async Task<IActionResult> DeleteProduct(int? id)
        {
            Products productDetails = new Products();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50898/api/v1/GetProductById/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productDetails = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            TempData["UserId"] = productDetails.UserId;
            return View(productDetails);
        }
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:50898/api/v1/DeleteProduct/"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetProducts","Product", new { id =TempData["UserId"] });
        }
    }
}