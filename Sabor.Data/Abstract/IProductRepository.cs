using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        Product GetProductDetails(int id);
        int GetCountByCategory(string category);
        List<Product> GetProductByCategory(string name, int page, int pageSize);
        List<Product> LastProductGetAll();
        Product GetByWithCategoriesId(int id);
        void Update(Product Entity, int[] categoryIds);
        void Create(Product Entity, int[] categories);

    }
}
            