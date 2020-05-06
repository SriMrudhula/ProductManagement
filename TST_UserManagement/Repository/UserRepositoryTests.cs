using NUnit.Framework;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST_UserManagement.Data;
using UserManagement.Repository;

namespace TST_UserManagement.Repository
{
    [TestFixture]
    class UserRepositoryTests
    {
        private IUserRepository userRepository;
        private ProductDBContext mockProductManagementContext;
        private UserDatas mockUserDatas;
        [SetUp]
        public void Setup()
        {
            mockProductManagementContext = new Sqlite().CreateSqliteConnection();
            userRepository = new UserRepository(mockProductManagementContext);
            mockUserDatas = new UserDatas();
        }
        [Test]
        public async Task GetAllUsers_Valid_Returns()
        {
            mockProductManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockProductManagementContext.SaveChangesAsync();
            var getAllUser = await userRepository.GetAll();
            Assert.That(getAllUser, Is.Not.Null);
            Assert.That(getAllUser.Count, Is.EqualTo(2));

        }


        [Test]
        public async Task RegisterUser_Valid_Returns(UserDetails user)
        {
            mockProductManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockProductManagementContext.SaveChangesAsync();
            var register = await userRepository.UserRegister(new UserDetails()
            {
                UserId = 14,
                UserName = "jyo2",
                EmailAddr = "jyo@gmail.com",
                UserPassword = "abc2",
                UserAddress = "Chennai",
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PhoneNumber = "9866451327",
                FirstName = "Jyo1",
                LastName = "Jyo1",
            });
        }

    }
}

