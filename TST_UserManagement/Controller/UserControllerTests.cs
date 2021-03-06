﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProductManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TST_UserManagement.Data;
using UserManagement;
using UserManagement.Helper;
namespace TST_UserManagement.Controller
{
    class UserControllerTests
    {
        private UserController mockUserController;
        private Mock<IUserManagementHelper> mockUserManagementHelper;
        private UserDatas mockUserData;
        [SetUp]
        public void Setup()
        {
            mockUserManagementHelper = new Mock<IUserManagementHelper>();
            mockUserData = new UserDatas();
            mockUserController = new UserController(mockUserManagementHelper.Object);
        }
        /// <summary>
        /// To get all user details
        /// </summary>
        /// <returns></returns>
        [Test]

        public async Task GetAll_Valid_Returns()
        {
            mockUserManagementHelper.Setup(d => d.GetAll()).ReturnsAsync(mockUserData.userDetails);
            var result = (await mockUserController.ViewAllUsers()) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.Not.Null);
        }
        /// <summary>
        /// To get details of a particular user by using userId
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetUser_Valid_Returns()
        {
            mockUserManagementHelper.Setup(d => d.ViewProfile(It.IsAny<int>())).ReturnsAsync(new UserDetails());
            var result = await mockUserController.GetUser(10) as OkObjectResult;
            Assert.That(result, Is.Not.Null);

        }
        /// <summary>
        /// For a new user to register
        /// </summary>
        /// <returns></returns>
        [Test]
        [Ignore("")]
        public async Task UserRegister_valid_Returns()
        {
            mockUserManagementHelper.Setup(d => d.UserRegister(It.IsAny<UserDetails>())).ReturnsAsync(default(bool));
            var result = await mockUserController.UserRegister(new UserDetails()
            {
                UserId = 67,
                UserName = "Abc",
                EmailAddr = "Abc@gmail.com",
                UserPassword = "4545",
                UserAddress = "Ap",
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PhoneNumber = "9874563210",
                FirstName = "Abc",
                LastName = "Xyz"
            }) as OkObjectResult;
            Assert.That(result, Is.EqualTo(true));
        }
        /// <summary>
        /// To update details of an existing user
        /// </summary>
        /// <returns></returns>
        [Test]
        [Ignore("")]
        public async Task UpdateUser_valid_Returns()
        {
            mockUserManagementHelper.Setup(d => d.UpdateProfile(It.IsAny<UserDetails>())).ReturnsAsync(true);
            var result = await mockUserController.EditProfile(new UserDetails()
            {

                UserId = 10,
                UserName = "Abc1",
                EmailAddr = "Abc1@gmail.com",
                UserPassword = "4545",
                UserAddress = "Ap",
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PhoneNumber = "9874563210",
                FirstName = "Abc1",
                LastName = "Xyz"
            }) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ToString(), Is.EqualTo(true));
        }

    }
}
