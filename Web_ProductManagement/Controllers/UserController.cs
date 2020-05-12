using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_UserManagement.Models;
using Newtonsoft.Json;
using System.Web;
using System.ComponentModel;
using Microsoft.VisualBasic.CompilerServices;

namespace Web_ProductManagement.Controllers
{
    public class UserController : Controller
    { 
        public static string url = "https://localhost:50951/api/v1/";
        
        // GET: User
        public async Task<IActionResult> Index()
        {
            List<UserDetails> usersList = new List<UserDetails>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50951/api/v1/ViewAllUsers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    usersList = JsonConvert.DeserializeObject<List<UserDetails>>(apiResponse);
                }
            }
            return View(usersList);
        }
        // GET: User/Create
        public async Task<IActionResult> UserRegister()
        {
            return View();
        }
        // POST: User/Create
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserDetails user)
        {
            UserDetails userDetails1 = new UserDetails();
            user.CreateDate = DateTime.Now;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:50951/api/v1/UserRegister/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("UserLogin");
        }
        [HttpGet]
        public async Task<IActionResult> UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLogin userLogin)
        {
            string apiResponse;
            int userId;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userLogin), System.Text.Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:50951/api/v1/UserLogin/", content))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            if (apiResponse.Equals("Invalid User"))
            {
                ViewBag.Message = String.Format("Invaild User");
                return View();
            }
            else
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:50951/api/v1/GetIdByName/" + userLogin.UserName))
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                        userId = JsonConvert.DeserializeObject<Int32>(apiResponse);
                    }
                    TempData["UserId"] = userId;
                    int User =Convert.ToInt32(TempData["id"]);
                    return RedirectToAction("GetProducts", "Product", new { id = userId });
                }
            }
        }
        public ViewResult GetUser() => View();
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            UserDetails userDetails = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50951/api/v1/GetUser/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userDetails = JsonConvert.DeserializeObject<UserDetails>(apiResponse);

                }
            }
            TempData["UserId"] = id;
            return View(userDetails);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            UserDetails userDetails = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50951/api/v1/GetUser/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userDetails = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            TempData["UserId"] = id;
            return View(userDetails);
        }

       [HttpPost]
        public async Task<IActionResult> EditUser(UserDetails user)
        {
            UserDetails userDetails = new UserDetails();
            user.UpdatedDate = DateTime.Now;
            string apiResponse;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:50951/api/v1/EditProfile/", content))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetProducts", "Product", new { id = user.UserId });
        }
    }
}