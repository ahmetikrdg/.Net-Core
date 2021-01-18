using Sabor.Data.Abstract;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Data.Concrate.EfCore
{
    public class SliderRepository:GenericRepository<Slider,SaborDbContext>,ISliderRepository
    {
    }
}
