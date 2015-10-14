using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Message
{
    public interface IMessage
    {
        void CreateMessage(string body, string recipients);
        void Send();


    }
}
