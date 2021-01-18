using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Abstract
{
    public interface IContactServices
    {
        Contact GetById(int id);
        List<Contact> GetAll();
        void Create(Contact Entity);
        void Update(Contact Entity);
        void Delete(Contact Entity);
    }
}
