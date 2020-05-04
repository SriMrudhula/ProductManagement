using System;
using System.Collections.Generic;

namespace ProductManagementDBEntity.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime ProducedDate { get; set; }
        public DateTime? ProductExpireDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserId { get; set; }

        public virtual UserDetails User { get; set; }
    }
}
