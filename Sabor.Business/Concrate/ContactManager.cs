using Sabor.Business.Abstract;
using Sabor.Data.Abstract;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Concrate
{
    public class ContactManager : IContactServices
    {
        private IContactRepository _contactRepository;
        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public void Create(Contact Entity)
        {
            _contactRepository.Create(Entity);
        }

        public void Delete(Contact Entity)
        {
            _contactRepository.Delete(Entity);
        }

        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactRepository.GetById(id);
        }

        public void Update(Contact Entity)
        {
            _contactRepository.Update(Entity);
        }
    }
}
