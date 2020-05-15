using ProductManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TST_ProductManagement.Data
{
    class ProductDatas
    {
        public List<Products> products { get; private set; }
        public List<UserDetails> userDetails { get; private set; }
        public ProductDatas()
        {
            userDetails = new List<UserDetails>(){new  UserDetails() { UserId = 10,UserName = "hello", EmailAddr = "hello@gmail.com",UserPassword ="hello",
            UserAddress="tnl",CreateDate=DateTime.Now,UpdatedDate=DateTime.Now,PhoneNumber="6583920836",FirstName ="hello",LastName="hello"
           }};

            products = new List<Products>(){new  Products() { ProductId=3,ProductName="Bangles",ProductDesc="Good",ProductPrice=1000,
                ProducedDate=DateTime.Now,ProductExpireDate=DateTime.Now,CreateDate=DateTime.Now,UpdatedDate=DateTime.Now,UserId=10
           },

           new Products()
            {
                ProductId=4,
               ProductName="Bangles",
               ProductDesc="Good",
               ProductPrice=1000,
                ProducedDate=DateTime.Now,
               ProductExpireDate=DateTime.Now,
               CreateDate=DateTime.Now,
               UpdatedDate=DateTime.Now,
               UserId=10

           }};

        }

    }
}
