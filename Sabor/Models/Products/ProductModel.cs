using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<ProductCategory> productCategory { get; set; }
        public List<Category> SelectedCategories { get; set; }        
    }
}
