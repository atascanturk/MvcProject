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

        public int Count(Expression<Func<Author, bool>> filter = null)
        {
            return _authorDal.Count(filter);
        }

        public List<Author> GetAll(Expression<Func<Author, bool>> filter = null)
        {
            return _authorDal.GetAll(filter);
        }
    }
}
