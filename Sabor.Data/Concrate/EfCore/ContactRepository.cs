using Sabor.Data.Abstract;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Data.Concrate.EfCore
{
    public class ContactRepository:GenericRepository<Contact,SaborDbContext>,IContactRepository
    {
    }
}
