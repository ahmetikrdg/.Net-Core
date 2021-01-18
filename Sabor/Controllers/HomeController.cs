using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sabor.Business.Abstract;
using Sabor.Entity;
using Sabor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductServices _productServices;
        private IVideoServices _videoServices;
        private ISliderServices _sliderServices;
        public HomeController(ILogger<HomeController> logger, IProductServices productServices, IVideoServices videoServices, ISliderServices sliderServices)
        {
            _logger = logger;
            _productServices = productServices;
            _videoServices = videoServices;
            _sliderServices = sliderServices;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Productses(string category,int pages=1) //buraya page değeri routeden geliyor
        {
            const int pageSize = 1;
            ProductsListViewModel productsListViewModel = new ProductsListViewModel()
            {
                pageInfo = new PageInfo()
                {
                    TotalItems = _productServices.GetCountByCategory(category),
                    CurrentPage = pages,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = _productServices.GetProductByCategory(category, pages, pageSize)
            };
            return View(productsListViewModel);
        }

        public IActionResult ProductDetail(int Urunid)
        {
            Product product= _productServices.GetProductDetails(Urunid);
            return View(new ProductDetailModel {Product=product });
        }

        public IActionResult SaborTv()
        {
            return View(new VideoListViewModel {Videos=_videoServices.LastGetAll() });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
