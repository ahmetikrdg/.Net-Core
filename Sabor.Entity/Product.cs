using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<ProductCategory> productCategory { get; set; }
    }
}
