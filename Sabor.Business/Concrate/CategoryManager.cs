using Sabor.Business.Abstract;
using Sabor.Data.Abstract;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Concrate
{
    public class CategoryManager : ICategoryServices
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Create(Category Entity)
        {
            _categoryRepository.Create(Entity);
        }

        public void Delete(Category Entity)
        {
            _categoryRepository.Delete(Entity);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Update(Category Entity)
        {
            _categoryRepository.Update(Entity);
        }
    }
}
