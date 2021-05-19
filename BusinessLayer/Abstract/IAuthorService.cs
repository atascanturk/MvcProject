using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthorService
    {
        int Count(Expression<Func<Author, bool>> filter = null);
        List<Author> GetAll(Expression<Func<Author, bool>> filter = null);
        Author GetById(int id);
        void Add(Author author);
        void Delete(Author author);
        void Update(Author author);
    }
}
