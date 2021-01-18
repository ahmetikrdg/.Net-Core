using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Abstract
{
    public interface IPopularProductServices
    {
        PopularProduct GetById(int id);
        List<PopularProduct> GetAll();
        void Create(PopularProduct Entity);
        void Update(PopularProduct Entity);
        void Delete(PopularProduct Entity);
    }
}
        