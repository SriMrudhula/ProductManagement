using ProductManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TST_ProductManagement.Data
{
    class ProductDatas
    {
        public List<Products> products { get; private set; }
        public ProductDatas()
        {
            products = new List<Products>(){new  Products() { ProductId=3,ProductName="Bangles",ProductDesc="Good",ProductPrice=1000,
                ProducedDate=DateTime.Now,ProductExpireDate=DateTime.Now,CreateDate=DateTime.Now,UpdatedDate=DateTime.Now,UserId=1
           },

           new Products()
            {
                ProductId=3,
               ProductName="Bangles",
               ProductDesc="Good",
               ProductPrice=1000,
                ProducedDate=DateTime.Now,
               ProductExpireDate=DateTime.Now,
               CreateDate=DateTime.Now,
               UpdatedDate=DateTime.Now,
               UserId=1

           }};

        }

    }
}
