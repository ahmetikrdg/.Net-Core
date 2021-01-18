using Microsoft.AspNetCore.Mvc;
using Sabor.Data.Abstract;
using Sabor.Data.Concrate.EfCore;
using Sabor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor.ViewComponents
{
    public class PopularProductGetAllViewComponent:ViewComponent
    {
        private IPopularProductRepository _popularProductRepository;
        public PopularProductGetAllViewComponent(IPopularProductRepository popularProductRepository)
        {
            _popularProductRepository = popularProductRepository;
        }
        public IViewComponentResult Invoke()
        {

            return View(new PopularProductListViewModel
            {
                popularProducts = _popularProductRepository.GetAll()
            });//Sizin için seçtiklerimiz kısmı ne kadar ürün koyduysa o kadar gösterilir
        }
    }
}
