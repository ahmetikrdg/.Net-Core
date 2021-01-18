using Sabor.Business.Abstract;
using Sabor.Data.Abstract;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Concrate
{
    public class ProductManager:IProductServices
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Create(Product Entity)
        {
            _productRepository.Create(Entity);
        }

        public void Delete(Product Entity)
        {
            _productRepository.Delete(Entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public List<Product> GetProductByCategory(string name, int page, int pageSize)
        {
            return _productRepository.GetProductByCategory(name, page, pageSize);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
                
        public int GetCountByCategory(string category)
        {
            return _productRepository.GetCountByCategory(category);
        }

        public void Update(Product Entity)
        {
            _productRepository.Update(Entity);
        }

        public Product GetProductDetails(int id)
        {
           return _productRepository.GetProductDetails(id);
        }

        public List<Product> LastProductGetAll()
        {
            return _productRepository.LastProductGetAll();
        }

        public Product GetByWithCategoriesId(int id)
        {
           return _productRepository.GetByWithCategoriesId(id);
        }

        public void Update(Product Entity, int[] categoryIds)
        {
           _productRepository.Update(Entity, categoryIds);
        }

        public void Create(Product Entity, int[] categories)
        {
            _productRepository.Create(Entity, categories);
        }
    }
}
