using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; } // Her ürünün 1 kategorisi olmalı
        public virtual Category Category { get; set; } // Her ürünün 1 kategorisi olmalı
        public List<Order> Orders { get; set; } //Bir ürün birden fazla sipariş içerisinde olaiblir


    }
}
