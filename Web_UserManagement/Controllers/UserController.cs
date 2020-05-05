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
        public static string url = "https://localhost:53109/api/v1/";

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
        [HttpGet]
        public async Task<IActionResult> UserRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserDetails user)
        {
            UserDetails userDetails1 = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:50951/api/v1/ViewAllUsers", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //userDetails1 = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public ViewResult ViewDetails() => View();
        [HttpGet]
        public async Task<IActionResult> ViewDetails(int id)
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
            return View(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserDetails user)
        {
            UserDetails userDetails = new UserDetails();

            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                int id = user.UserId;
                content.Add(new StringContent(user.UserId.ToString()), "Empid");
                content.Add(new StringContent(user.UserName), "UserName");
                content.Add(new StringContent(user.FirstName), "FirstName");
                content.Add(new StringContent(user.LastName), "LastName");
                content.Add(new StringContent(user.EmailAddr), "Email Id");
                content.Add(new StringContent(user.PhoneNumber), "Phone Number");
                content.Add(new StringContent(user.CreateDate.ToString()), "Create Date");
                content.Add(new StringContent(user.UpdatedDate.ToString()), "Updated Date");
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:50951/api/v1/EditProfile/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    userDetails = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return RedirectToAction("index");
        }


    }
}