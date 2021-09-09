using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessageListInbox(string mail);
        List<Message> GetMessageListSendbox(string mail);
        List<Message> GetMessageListDrafts();
        List<Message> GetMessageListTrash();
        void AddMessage(Message message);
        Message GetById(int id);

        void MessagetDelete(Message message);
        void MessageUpdate(Message message);

    }
}
