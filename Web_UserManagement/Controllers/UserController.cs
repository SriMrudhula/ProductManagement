using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_UI.Models;
using Newtonsoft.Json;

namespace MVC_UI.Controllers
{
    public class UserController : Controller
    {
        public static string url = "https://localhost:50951/api/v1/";
        // GET: User
        public async Task<IActionResult> Index()
        {
            List<UserDetails> userList = new List<UserDetails>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50951/api/v1/ViewAllUsers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   // userList = JsonConvert.DeserializeObject<List<UserDetails>>(apiResponse);
                }
            }
            return View(userList);
        }
        // GET: User/Create
        public async Task<IActionResult> UserRegister()
        {
            return View();
        }
        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRegister(UserDetails userDetails)
        {
            UserDetails userDetails1 = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userDetails), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:50951/api/v1/UserRegister/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //userDetails1 = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return RedirectToAction("Index");
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
            return View(userDetails);
        }
        public async Task<IActionResult> UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserDetails userDetails)
        {
            UserDetails userDetails1 = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userDetails), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:50951/api/v1/UserLogin/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        return RedirectToAction("GetUser");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials");
                        return RedirectToAction("UserLogin");
                    }
                    //userDetails1 = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }

            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateUser(string userid)
        {
            UserDetails user = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50951/api/v1/EditProfile/" + userid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserDetails userdetails)
        {
            UserDetails user = new UserDetails();
            int userid = user.UserId;
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(user.UserId.ToString()), "Empid");
                content.Add(new StringContent(user.UserName), "UserName");
                content.Add(new StringContent(user.FirstName), "FirstName");
                content.Add(new StringContent(user.LastName), "LastName");
                content.Add(new StringContent(user.EmailAddr), "Email Id");
                content.Add(new StringContent(user.PhoneNumber), "Phone Number");
                content.Add(new StringContent(user.CreateDate.ToString()), "Create Date");
                content.Add(new StringContent(user.UpdatedDate.ToString()), "Updated Date");

                using (var response = await httpClient.PutAsync("http://localhost:50951/api/v1/EditProfile/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    user = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}