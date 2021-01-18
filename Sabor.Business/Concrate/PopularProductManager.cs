using Sabor.Business.Abstract;
using Sabor.Data.Abstract;
using Sabor.Data.Concrate.EfCore;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Concrate
{
    public class PopularProductManager : IPopularProductServices
    {
        private IPopularProductRepository _popularProductRepository;
        public PopularProductManager(IPopularProductRepository popularProductRepository)
        {
            _popularProductRepository = popularProductRepository;
        }

        public void Create(PopularProduct Entity)
        {
            _popularProductRepository.Create(Entity);
        }

        public void Delete(PopularProduct Entity)
        {
            _popularProductRepository.Delete(Entity);
        }

        public List<PopularProduct> GetAll()
        {
            return _popularProductRepository.GetAll();
        }

        public PopularProduct GetById(int id)
        {
            return _popularProductRepository.GetById(id);
        }

        public void Update(PopularProduct Entity)
        {
            _popularProductRepository.Update(Entity);
        }
    }
}
