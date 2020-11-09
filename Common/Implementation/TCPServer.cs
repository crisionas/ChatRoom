using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using Xceed.Wpf.Toolkit;

namespace Common.Implementation
{
    [Serializable]
    public abstract class TCPServer
    {
        protected volatile TcpClient commSocket;
        protected volatile TcpListener tcpListener;
        protected volatile Boolean running;
        protected int port;
        protected Thread checkDataThread;
        protected Thread checkQuitThread;
        protected Thread listenerThread;

        public bool Running
        {
            get
            {
                return running;
            }
            set
            {
                running = value;
            }
        }

        /// <summary>
        /// Start Server
        /// </summary>
        public void StartServer()
        {
            int port = 4040;
            Running = false;
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            try
            {
                tcpListener = new TcpListener(ipAddress, port);
                tcpListener.Start();
                this.Running = true;
            }
            catch (SocketException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Stop Server
        /// </summary>
        public void StopServer()
        {
            this.Running = false;
            tcpListener.Stop();
        }

        /// <summary>
        /// Get a message from a given client
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public Message GetMessage(Socket socket)
        {
            try
            {
                NetworkStream stream = new NetworkStream(socket);
                IFormatter formatter = new BinaryFormatter();
                Message message = (Message)formatter.Deserialize(stream);
                return message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Send message to a given client.
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <param name="socket">Client to send message to</param>
        public void SendMessage(Message message, Socket socket)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                NetworkStream stream = new NetworkStream(socket);
                formatter.Serialize(stream, message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        

    }
}
