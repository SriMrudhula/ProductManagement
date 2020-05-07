using NUnit.Framework;
using ProductManagementDBEntity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using TST_UserManagement;
using TST_UserManagement.Data;
using UserManagement.Helper;
using UserManagement.Repository;
using Moq;
using System.Threading.Tasks;
using ProductManagementDBEntity.Models;

namespace ProductTest.Helper
{
    public class UserManagementHelperTests
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



    }
}
