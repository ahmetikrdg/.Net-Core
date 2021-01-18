using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Abstract
{
    public interface ISliderServices
    {
        Slider GetById(int id);
        List<Slider> GetAll();
        void Create(Slider Entity);
        void Update(Slider Entity);
        void Delete(Slider Entity);
    }           
}
