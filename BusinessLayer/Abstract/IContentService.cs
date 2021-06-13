using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        int Count(Expression<Func<Content, bool>> filter = null);
        List<Content> GetAll(Expression<Func<Content, bool>> filter = null);
        Content GetById(int id);
        List<Content> GetByTitleId(int titleId);
        List<Content> GetByAuthorId(int authorId);
        void Add(Content content);
        void Delete(Content content);
        void Update(Content content);
    }
}
