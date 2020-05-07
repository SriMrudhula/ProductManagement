using NUnit.Framework;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST_UserManagement;
using TST_UserManagement.Data;
using UserManagement.Repository;

namespace ProductTest.Repository
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private IUserRepository userRepository;
        private ProductDBContext mockCouponManagementContext;
        private UserDatas mockUserDatas;
        [SetUp]
        public void Setup()
        {
            mockCouponManagementContext = new Sqlite().CreateSqliteConnection();
            userRepository = new UserRepository(mockCouponManagementContext);
            mockUserDatas = new UserDatas();
        }
        [Test]
        public async Task GetAll_Valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getAllUser = await userRepository.GetAll();
            Assert.That(getAllUser, Is.Not.Null);
            Assert.That(getAllUser.Count, Is.EqualTo(2));

        }
        [Test]
        public async Task GetUser_Valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getUserById = await userRepository.ViewProfile(10);
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById.UserId, Is.EqualTo(10));
        }
        [Test]
        public async Task InsertUser_valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getUserById = await userRepository.UserRegister(
                new UserDetails()
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
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById, Is.EqualTo(true));
        }
        [Test]
        public async Task UpdateUser_valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getUserById = await userRepository.UpdateProfile(
                new UserDetails()
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
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById, Is.EqualTo(true));
        }

    }
}
