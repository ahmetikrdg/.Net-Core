using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Abstract
{
    public interface IProductServices
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Create(Product Entity, int[] categories);
        void Update(Product Entity, int[] categoryIds);        
        void Delete(Product Entity);
        int GetCountByCategory(string category);
        List<Product> GetProductByCategory(string name, int page, int pageSize);
        Product GetProductDetails(int id);
        List<Product> LastProductGetAll();
        Product GetByWithCategoriesId(int id);

    }
}
