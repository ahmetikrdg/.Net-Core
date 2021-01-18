using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public List<ProductCategory> productCategory { get; set; }
    }
}
