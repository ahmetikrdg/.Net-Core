using Microsoft.AspNetCore.Mvc;
using Sabor.Business.Abstract;
using Sabor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor.ViewComponents
{
    public class ProductLastGetAllViewComponent:ViewComponent
    {
        private IProductServices _productServices;
        public ProductLastGetAllViewComponent(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public IViewComponentResult Invoke()
        {

            return View(new ProductsListViewModel
            {
                Products = _productServices.LastProductGetAll()//son 8 ürünü getiren operasyon
            });
        }
    }
}
            