using Sabor.Business.Abstract;
using Sabor.Data.Abstract;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Concrate
{
    public class SliderManager : ISliderServices
    {
        private ISliderRepository _sliderRepository;
        public SliderManager(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }
        public void Create(Slider Entity)
        {
            _sliderRepository.Create(Entity);
        }

        public void Delete(Slider Entity)
        {
            _sliderRepository.Delete(Entity);
        }

        public List<Slider> GetAll()
        {
            return _sliderRepository.GetAll();
        }

        public Slider GetById(int id)
        {
            return _sliderRepository.GetById(id);
        }

        public void Update(Slider Entity)
        {
            _sliderRepository.Update(Entity);
        }
    }
}
