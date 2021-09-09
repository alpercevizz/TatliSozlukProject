using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void AddMessage(Message message)
        {
            _messageDal.Insert(message);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetMessageListDrafts()
        {
            return _messageDal.List(x => x.MessageStatus == "Taslak");
        }

        public List<Message> GetMessageListInbox(string mail)
        {
            return _messageDal.List(x=>x.ReceiverMail == mail);
        }


        public List<Message> GetMessageListSendbox(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail);
        }

        public List<Message> GetMessageListTrash()
        {
            return _messageDal.List(x => x.MessageStatus == "Çöp"); 
        }

        public void MessagetDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
