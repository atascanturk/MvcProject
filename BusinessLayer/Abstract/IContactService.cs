using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        int Count(Expression<Func<Contact, bool>> filter = null);
        List<Contact> GetAll(Expression<Func<Contact, bool>> filter = null);
        Contact GetById(int id);
        void Add(Contact contact);
        void Delete(Contact contact);
        void Update(Contact contact);
    }
}
