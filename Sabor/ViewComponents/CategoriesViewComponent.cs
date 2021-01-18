using Microsoft.AspNetCore.Mvc;
using Sabor.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private ICategoryRepository _categoryRepository;
        public CategoriesViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["category"]!=null)//controllerdeki RouteDatadan categoriese gelen category değerini aldık
            
                ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_categoryRepository.GetAll());
        }
    }
}
