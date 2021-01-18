using Microsoft.EntityFrameworkCore;
using Sabor.Data.Abstract;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sabor.Data.Concrate.EfCore
{
    public class ProductRepository : GenericRepository<Product, SaborDbContext>, IProductRepository
    {
        public List<Product> GetProductByCategory(string name, int page, int pageSize)
        {
            using (var context = new SaborDbContext())
            {
                var products = context.Products.OrderByDescending(i => i.ProductId).AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                        .Include(i => i.productCategory)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.productCategory.Any(a => a.Category.Title == name));
                }
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }       
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new SaborDbContext())
            {
                var product = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))    
                {
                    product = product.Include(i => i.productCategory).ThenInclude(i => i.Category).Where(i => i.productCategory.Any(a => a.Category.Title == category));
                }
                return product.Count();
            }
        }

        public Product GetProductDetails(int id)
        {
            using(var context=new SaborDbContext())
            {
                return context.Products.Where(i => i.ProductId == id).FirstOrDefault();
            }
        }

        public List<Product> LastProductGetAll()
        {
            using (var context = new SaborDbContext())
            {
                return context.Products.OrderByDescending(i => i.ProductId).Take(8).ToList();
            }
        }

        public Product GetByWithCategoriesId(int id)
        {
            using (var context = new SaborDbContext())
            {
                return context.Products.Where(i => i.ProductId == id).Include(i => i.productCategory).ThenInclude(i => i.Category).FirstOrDefault();
            }
        }

        public void Update(Product Entity, int[] categoryIds)
        {
            using(var context=new SaborDbContext())
            {
                var product = context.Products
                    .Include(i=>i.productCategory)
                    .FirstOrDefault(i => i.ProductId == Entity.ProductId);

                if(product!=null)
                {
                    product.Title = Entity.Title;
                    product.Description = Entity.Description;
                    product.Image = Entity.Image;
                    product.productCategory = categoryIds.Select(i => new ProductCategory
                    {
                        ProductId=Entity.ProductId,
                        CategoryId=i
                    }).ToList();
                    context.SaveChanges();
                }
            }
        }

        public void Create(Product Entity, int[] categories)
        {
            using(var context=new SaborDbContext())
            {
                var _product = new Product();
                _product = Entity;


                _product.productCategory = categories.Select(i => new ProductCategory
                {
                    ProductId=_product.ProductId,
                    CategoryId=i
                }).ToList();

                context.Products.Add(_product);
                context.SaveChanges();
            }
        }
    }
}
