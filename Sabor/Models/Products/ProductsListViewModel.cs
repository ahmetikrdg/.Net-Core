using Sabor.Entity;
using Sabor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor.Models
{
    public class ProductsListViewModel  
    {   
        public List<Product> Products { get; set; }
        public PageInfo pageInfo { get; set; }
    }
}
