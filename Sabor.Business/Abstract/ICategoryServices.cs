using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Abstract
{
    public interface ICategoryServices
    {
        Category GetById(int id);
        List<Category> GetAll();
        void Create(Category Entity);
        void Update(Category Entity);
        void Delete(Category Entity);
    }
}
