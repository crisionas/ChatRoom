using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Implementation
{
    /// <summary>
    /// Store a message
    /// </summary>
    public class Message
    {
        public enum Header { REGISTER,JOIN,QUIT,JOIN_CR,QUIT_CR,CREATE_CR,LIST_CR,POST,LIST_USERS}
        private Header header;
        private List<string> messageList;

        public Header Head
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }

        public List<string> MessageList
        {
            get
            {
                return messageList;
            }
            set
            {
                messageList = value;
            }
        }

        public Message(Header head,string message)
        {
            this.Head = head;
            MessageList = new List<string>();
            MessageList.Add(message);

        }
        
        /// <summary>
        /// Add message in the list.
        /// </summary>
        /// <param name="message"></param>
          public void AddData(string message)
        {
            MessageList.Add(message);
        }
    }
}
