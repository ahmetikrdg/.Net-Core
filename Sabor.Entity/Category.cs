using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public List<ProductCategory> productCategory { get; set; }
    }
}
