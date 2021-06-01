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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public int Count(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.Count();
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAll(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.GetAll(filter);
        }

        public List<Message> GetAllForInbox(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.GetAll(x => x.From == "admin@FROM.com");
        }

        public List<Message> GetAllForSentMessages(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.GetAll(x => x.To == "admin@TO.com");
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.Id == id);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
