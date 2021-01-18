using Microsoft.AspNetCore.Mvc;
using Sabor.Business.Abstract;
using Sabor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor.ViewComponents
{
    public class VideoOneViewComponent:ViewComponent
    {
        private IVideoServices _videoServices;
        public VideoOneViewComponent(IVideoServices videoServices)
        {
            _videoServices = videoServices;
        }

        public IViewComponentResult Invoke()
        {
            return View(new VideoListViewModel { Videos = _videoServices.LastOneGetAll() });
        }
    }
}
