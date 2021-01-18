using Microsoft.AspNetCore.Mvc;
using Sabor.Business.Abstract;
using Sabor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor.ViewComponents
{
    public class SliderViewComponent:ViewComponent
    {
        private ISliderServices _sliderServices;
        public SliderViewComponent(ISliderServices sliderServices)
        {
            _sliderServices = sliderServices;
        }

        public IViewComponentResult Invoke()
        {
            return View(new SliderListViewModel { Sliders = _sliderServices.GetAll() });
        }
    }
}
