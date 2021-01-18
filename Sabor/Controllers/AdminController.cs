using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sabor.Business.Abstract;
using Sabor.Entity;
using Sabor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor.Controllers
{
    [Authorize]
    public class AdminController:Controller
    {
        private ISliderServices _sliderServices;
        private IVideoServices _videoServices;
        private IProductServices _productServices;  
        private ICategoryServices _categoryServices;
        private IPopularProductServices _popularProductServices;            

        public AdminController(ISliderServices sliderServices, IVideoServices videoServices, IProductServices productServices, ICategoryServices categoryServices, IPopularProductServices popularProductServices)
        {
            _sliderServices = sliderServices;
            _videoServices = videoServices;
            _productServices = productServices;
            _categoryServices = categoryServices;
            _popularProductServices = popularProductServices;
        }

        //------SLİDER OPERASYONLARI

        [HttpGet]
        public IActionResult SliderList()
        {
            return View(new SliderListViewModel { Sliders = _sliderServices.GetAll() });
        }
        [HttpGet]
        public IActionResult SliderCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SliderCreate (SliderModel sliderModel, IFormFile formFile)
        {
            var entity = new Slider()
            {
                Url=sliderModel.Url,                
            };

            if (formFile != null)
            {
                var extention = Path.GetExtension(formFile.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                entity.Image = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            _sliderServices.Create(entity);
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public IActionResult SliderEdit(int? id)
        {
            var entity = _sliderServices.GetById((int)id);

            var model = new SliderModel()
            {
                SliderId=entity.SliderId,
                Image=entity.Image,
                Url=entity.Url
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SliderEdit(SliderModel sliderModel,IFormFile formFile)
        {

            var entity = _sliderServices.GetById(sliderModel.SliderId);

            entity.SliderId = sliderModel.SliderId;
            entity.Url = sliderModel.Url;

            if (formFile != null)
            {
                var extention = Path.GetExtension(formFile.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                entity.Image = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            _sliderServices.Update(entity);
            return RedirectToAction("SliderList");
        }

        [HttpPost]
        public IActionResult SliderDelete(int SliderId)
        {
            var entity = _sliderServices.GetById(SliderId);
            if (entity!=null)
            {
                _sliderServices.Delete(entity);
            }
            return RedirectToAction("SliderList");
        }
        //------VİDEO OPERASYONLARI

        [HttpGet]
        public IActionResult VideoList()
        {
            return View(new VideoListViewModel { Videos = _videoServices.GetAll() });
        }

        [HttpGet]
        public IActionResult VideoCreate()      
        {
            return View();
        }

        [HttpPost]
        public IActionResult VideoCreate(VideoModel videoModel)
        {
            var entity = new Video()
            {
                Title=videoModel.Title,
                Url=videoModel.Url
            };
            _videoServices.Create(entity);
            return RedirectToAction("VideoList");
        }

        [HttpGet]
        public IActionResult VideoEdit(int? id)
        {
            var entity = _videoServices.GetById((int)id);

            var model = new VideoModel()
            {
                VideoId=entity.VideoId,
                Title=entity.Title,
                Url=entity.Url
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult VideoEdit(VideoModel videoModel )
        {
            var entity = _videoServices.GetById(videoModel.VideoId);

            entity.VideoId = videoModel.VideoId;
            entity.Title = videoModel.Title;
            entity.Url = videoModel.Url;

           
            _videoServices.Update(entity);
            return RedirectToAction("VideoList");
        }

        [HttpPost]
        public IActionResult VideoDelete(int VideoId)
        {
            var entity = _videoServices.GetById(VideoId);
            _videoServices.Delete(entity);
            return RedirectToAction("VideoList");
        }
        //------ÜRÜN OPERASYONLARI
        [HttpGet]
        public IActionResult ProductList()
        {
            return View(new ProductsListViewModel { Products = _productServices.LastProductGetAll() });
        }

        [HttpGet]
        public IActionResult ProductCreate()
        {
            ViewBag.Categories = _categoryServices.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel productModel, int[] categories,IFormFile formFile) 
        {
            var entity = new Product()
            {
                Title=productModel.Title,
                Description=productModel.Description,
            };

            if (formFile != null)
            {
                var extention = Path.GetExtension(formFile.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                entity.Image = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            _productServices.Create(entity, categories);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult ProductEdit(int? id)
        {
            var entity = _productServices.GetByWithCategoriesId((int)id);

            var model = new ProductModel()
            {
                ProductId=entity.ProductId,
                Title=entity.Title,
                Description=entity.Description,
                Image=entity.Image,
                SelectedCategories=entity.productCategory.Select(i=>i.Category).ToList()
            };
            ViewBag.Categories = _categoryServices.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel productModel,IFormFile formFile,int [] categoryIds)
        {
            var entity = _productServices.GetById(productModel.ProductId);

            entity.Title = productModel.Title;
            entity.Description = productModel.Description;

            if (formFile != null)
            {
                var extention = Path.GetExtension(formFile.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                entity.Image = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }

            _productServices.Update(entity, categoryIds);
            return RedirectToAction("ProductList");
        }

        [HttpPost]
        public IActionResult ProductDelete(int ProductId)     
        {
            var entity = _productServices.GetById(ProductId);
            if (entity!=null)           
            {
                _productServices.Delete(entity);                            
            }
            return RedirectToAction("ProductList");
        }
        //------KATEGORİ OPERASYONLARI

        [HttpGet]
        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel { Categories = _categoryServices.GetAll()});
        }

        [HttpGet]
        public IActionResult CategoryCreate()       
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model)
        {
            var entity = new Category()
            {
                Title = model.Title
            };
            _categoryServices.Create(entity);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            var entity = _categoryServices.GetById((int)id);

            var model = new CategoryModel()
            {
                CategoryId= entity.CategoryId,
                Title=entity.Title
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel categoryModel)
        {
            var entity = new Category()
            {
                CategoryId=categoryModel.CategoryId,
                Title=categoryModel.Title
            };
            _categoryServices.Update(entity);
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult CategoryDelete(int CategoryId)
        {
            var entity = _categoryServices.GetById(CategoryId);
            _categoryServices.Delete(entity);
            return RedirectToAction("CategoryList");
        }

        //------SİZİN İÇİN SEÇTİKLERİMİZ: POPULARP RRODUCT OPERASYONLARI

        [HttpGet]
        public IActionResult PopularProductList()
        {
            return View(new PopularProductListViewModel { popularProducts=_popularProductServices.GetAll()});
        }

        [HttpGet]
        public IActionResult PopularProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PopularProductCreate(PopularProductModel productModel, IFormFile formFile)
        {
            var entity = new PopularProduct()
            {
                Title = productModel.Title,
                Url = productModel.Url
            };

            if (formFile != null)
            {
                var extention = Path.GetExtension(formFile.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                entity.Image = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            _popularProductServices.Create(entity);
            return RedirectToAction("PopularProductList");
        }

        [HttpGet]
        public IActionResult PopularProductEdit(int id)
        {
            var entity = _popularProductServices.GetById(id);
            var model = new PopularProductModel()
            {
                PopularProductId = entity.PopularProductId,
                Title = entity.Title,
                Url = entity.Url,
                Image = entity.Image
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PopularProductEdit(PopularProductModel popularProductModel,IFormFile formFile)
        {
            var entity = _popularProductServices.GetById(popularProductModel.PopularProductId);
            entity.PopularProductId = popularProductModel.PopularProductId;
            entity.Title = popularProductModel.Title;
            entity.Url = popularProductModel.Url;

            if (formFile != null)
            {
                var extention = Path.GetExtension(formFile.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                entity.Image = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            _popularProductServices.Update(entity);
            return RedirectToAction("PopularProductList");
        }

        [HttpPost]
        public IActionResult PopularProductDelete(int PopularProductId)
        {
            var entity = _popularProductServices.GetById(PopularProductId);
            _popularProductServices.Delete(entity);
            return RedirectToAction("PopularProductList");
        }

    }
}
