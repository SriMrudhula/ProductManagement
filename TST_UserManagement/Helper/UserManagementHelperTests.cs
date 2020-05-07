using Moq;
using NUnit.Framework;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST_UserManagement.Data;
using UserManagement.Helper;

namespace TST_UserManagement.Helper
{
    class UserManagementHelperTests
    {
        private UserManagementHelper userManagementHelper;
        private Mock<IUserRepository> mockUserRepository;
        private UserDatas mockUserData;
        [SetUp]
        public void Setup()
        {
            mockUserRepository = new Mock<IUserRepository>();
            mockUserData = new UserDatas();
            userManagementHelper = new UserManagementHelper(mockUserRepository.Object);
        }
        [Test]
        public async Task GetAll_Valid_Returns()
        {
            mockUserRepository.Setup(d => d.GetAll()).ReturnsAsync(mockUserData.userDetails);
            var result = await userManagementHelper.GetAll();
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.Count, Is.EqualTo(2));
        }
        [Test]
        public async Task GetAll_InValid_ReturnsNull()
        {
            mockUserRepository.Setup(d => d.GetAll()).ReturnsAsync((List<UserDetails>)(null));
            var result = await userManagementHelper.GetAll();
            Assert.That(result, Is.Null);
        }
        [Test]
        public async Task GetUser_Valid_Returns()
        {
            mockUserRepository.Setup(d => d.ViewProfile(It.IsAny<int>())).ReturnsAsync(new UserDetails());
            var result = await userManagementHelper.ViewProfile(10);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.UserId, Is.EqualTo(10));
        }
        [
            Test]
        public async Task GetUser_InValid_ReturnsNull()
        {
            mockUserRepository.Setup(d => d.ViewProfile(It.IsAny<int>())).ReturnsAsync((UserDetails)(null));
            var result = await userManagementHelper.ViewProfile(1);
            Assert.That(result, Is.Null);
        }
        [Test]
        public async Task InsertUser_Valid_Returns()
        {
            mockUserRepository.Setup(d => d.UserRegister(It.IsAny<UserDetails>())).ReturnsAsync(new Boolean());
            var result = await userManagementHelper.UserRegister(new UserDetails()
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
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public async Task UpdateUser_Valid_Returns()
        {
            mockUserRepository.Setup(d => d.UpdateProfile(It.IsAny<UserDetails>())).ReturnsAsync(new Boolean());
            var result = await userManagementHelper.UpdateProfile(new UserDetails()
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
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }

    }
}
