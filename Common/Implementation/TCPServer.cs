﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using Xceed.Wpf.Toolkit;

namespace Common.Implementation
{
    /// <summary>
    /// TCPServer
    /// </summary>
    [Serializable]
    public abstract class TCPServer
    {
        protected volatile TcpClient commSocket;
        protected volatile TcpListener tcpListener;
        protected volatile Boolean running;
        protected string IP = "127.0.0.1";
        protected int port = 4040;
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
        /// Start the server, locally
        /// </summary>
        /// <param name="port"></param>
        public void startServer()
        {
            this.port = 4040;
            this.Running = false;
            IPAddress ipAddress = IPAddress.Parse(IP);

            try
            {

                tcpListener = new TcpListener(ipAddress, port);
                tcpListener.Start();

                

                this.Running = true;
            }
            catch (SocketException e)
            {
                Console.WriteLine("Connection impossible: " + e.Message);
            }

        }

        /// <summary>
        /// Stop the server
        /// </summary>
        public void stopServer()
        {
            Console.WriteLine("Stopping the server");
            this.Running = false;
            tcpListener.Stop();
        }

        /// <summary>
        /// Get a message object from a given client
        /// </summary>
        /// <param name="socket">Client to listen to</param>
        /// <returns>Deserialized Message object</returns>
        public Message getMessage(Socket socket)
        {
            Console.WriteLine("## TCPServer Receiving a message");

            try
            {
                NetworkStream strm = new NetworkStream(socket);
                IFormatter formatter = new BinaryFormatter();
                Message message = (Message)formatter.Deserialize(strm);
                Console.WriteLine("- message header: " + message.Head);
                return message;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("TCPClient sendMessage exception: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("TCPClient sendMessage exception: " + e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("TCPClient sendMessage exception: " + e.Message);
            }

            return null;
        }

        /// <summary>
        /// Send a message to a given client
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <param name="socket">Client to send the message to</param>
        public void sendMessage(Message message, Socket socket)
        {
            Console.WriteLine("## TCPServer Sending a message: " + message.Head);

            try
            {
                IFormatter formatter = new BinaryFormatter();
                NetworkStream strm = new NetworkStream(socket);
                formatter.Serialize(strm, message);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("TCPClient sendMessage exception: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("TCPClient sendMessage exception: " + e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("TCPClient sendMessage exception: " + e.Message);
            }
        }
    

    }
}
