using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        int Count(Expression<Func<Message, bool>> filter = null);
        List<Message> GetAll(Expression<Func<Message, bool>> filter = null);
        List<Message> GetAllForInbox(Expression<Func<Message, bool>> filter = null);
        List<Message> GetAllForSentMessages(Expression<Func<Message, bool>> filter = null);
        Message GetById(int id);
        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
    }
}
