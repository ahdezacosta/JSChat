using JSChatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSChatServices
{
    public class MessageServices
    {
        public MessageRepository MessageRepository { get; set; }

        public MessageServices()
        {
            this.MessageRepository = new MessageRepository();
        }

        public List<tMessage> GetMessages()
        {
            return this.MessageRepository.GetAll().OrderByDescending(m => m.MDate).Take(50).ToList();
        }

        public tMessage Add(tMessage model)
        {
            return this.MessageRepository.Add(model);
        }
    }
}
