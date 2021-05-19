using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    

    public class AuthorManager :IAuthorService
    {

        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public void Add(Author author)
        {
            _authorDal.Add(author);
        }

        public int Count(Expression<Func<Author, bool>> filter = null)
        {
            return _authorDal.Count(filter);
        }

        public void Delete(Author author)
        {
            _authorDal.Delete(author);
        }

        public List<Author> GetAll(Expression<Func<Author, bool>> filter = null)
        {
            return _authorDal.GetAll(filter);
        }

        public Author GetById(int id)
        {
           return _authorDal.Get(a => a.Id == id);
        }

        public void Update(Author author)
        {
            _authorDal.Update(author);
        }
    }
}
