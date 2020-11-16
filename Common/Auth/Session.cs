using Common.Implementation;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Common.Auth
{
    /// <summary>
    /// Create a session for each user
    /// </summary>
    public class Session
    {
        Guid token;
        User user;
        TcpClient client;

        /// <summary>
        /// Each session has an unique token
        /// </summary>
        public Guid Token
        {
            get
            {
                return token;
            }

            set
            {
                token = value;
            }
        }

        public User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public TcpClient Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }

        public Session()
        {
            this.Token = Guid.NewGuid();
            this.Client = null;
            this.User = null;
        }
    }
}
