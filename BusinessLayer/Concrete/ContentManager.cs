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
    public class ContentManager : IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;           
        }

        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        public int Count(Expression<Func<Content, bool>> filter = null)
        {
            return _contentDal.Count(filter);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll(Expression<Func<Content, bool>> filter = null)
        {
           return  _contentDal.GetAll(filter, c=>c.Title, c=>c.Author);
        }

        public List<Content> GetByAuthorId(int authorId)
        {
            return _contentDal.GetAll(x => x.Author.Id == authorId, x => x.Author,x=>x.Title);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.Id == id);
        }

        public List<Content> GetByTitleId(int titleId)
        {
           return _contentDal.GetAll(x => x.TitleId== titleId,x=>x.Author,x=>x.Title);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
