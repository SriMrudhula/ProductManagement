using NUnit.Framework;
using ProductManagementDBEntity.Models;
using SHR_Model;
using System;
using System.Threading.Tasks;
using UserManagement.Repository;

namespace NUnitUserTest
{
    [TestFixture]
    public class Tests
    {
        UserRepository _userRepository;
        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository(new ProductDBContext());
        }

        [Test]
        [Description("TestUserLogin")]
        public async Task TestUserLogin()
        {
            var result = await _userRepository.UserLogin(new UserLogin()
            {
                UserName = "jagadu",
                UserPassword = "jagadu45"
            });
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("TestUserRegister")]
        public async Task TestUserRegister()
        {
            await _userRepository.UserRegister(new UserDetails()
            {
                FirstName = "Devika",
                LastName = "G",
                UserName = "Devika",
                UserPassword = "devika",
                EmailAddr = "devika@gmail.com",
                PhoneNumber = "9987566767",
                CreateDate = DateTime.Now,
                UserAddress = "Ponnur"

            });
        }
        [Test]
        [Description("View Profile")]
        public async Task TestViewProfile()
        {
            var result = await _userRepository.ViewProfile(1);
            Assert.NotNull(result);
        }
        [Test]
        [Description("Update User")]
        public async Task UpdateUser()
        {
            UserDetails user = await _userRepository.ViewProfile(1);
            user.PhoneNumber = "7778655213";
            await _userRepository.UpdateProfile(user);
            UserDetails user1 = await _userRepository.ViewProfile(1);
            Assert.AreSame(user, user1);

        }
    }
}