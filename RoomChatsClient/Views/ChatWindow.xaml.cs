using Common.Auth;
using Common.Chat;
using Common.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RoomChatsClient.Views
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private Client client;
        private Thread checkChatrooms;
        private Thread checkUsers;
        private Thread checkServer;
        private ThreadedBindingList<Chatroom> chatroomsBindingList;
        private ThreadedBindingList<User> usersBindingList;
        private ThreadedBindingList<string> messagesBindingList;
        private Chatroom defaultChatroom;

        public ChatWindow(Client clientParam)
        {
            InitializeComponent();
            client = clientParam;
            Load();
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            Message messageToSend = new Message(Message.Header.POST);
            messageToSend.addData(messageTextBox.Text);
            client.sendMessage(messageToSend);
            messageTextBox.Clear();
        }

        private void createChatroomButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new ChatRoomWindow(client);
            window.Closing += delegate { this.Show(); };
            window.Show();
        }

        private void chatrooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chatrooms.SelectedIndex = 1;
            if (chatrooms.Text == "Select a chatroom")
            {
                chatrooms.SelectedIndex = -1;
                Message quitCr = new Message(Message.Header.QUIT_CR);
                client.sendMessage(quitCr);
                if (messagesBindingList != null && usersBindingList != null)
                {
                    messagesBindingList.Clear();
                    usersBindingList.Clear();
                }
            }
            // Join the chatroom wanted otherwise
            if (chatrooms.Text != "" &&
                chatrooms.Text != "Select a chatroom" &&
                chatrooms.SelectedItem != null)
            {
                client.User.Chatroom = new Chatroom(chatrooms.Text);
                Message joinCr = new Message(Message.Header.JOIN_CR);
                joinCr.addData(chatrooms.Text);
                client.sendMessage(joinCr);
            }
        }
        private void getUsers()
        {
            while (!client.Quit)
            {
                try
                {
                    // Now, check the users
                    if (client.User.Chatroom != null && client.User.Chatroom.Name != "")
                    {
                        // We need to invoke chatrooms (UI thread) to see the selected index
                        chatrooms.Dispatcher.BeginInvoke(
                            (Action)(() =>
                            {
                                // If we are indeed connected to a chatroom
                                if (chatrooms.Text != "")
                                {
                                    Message messageUsers = new Message(Message.Header.LIST_USERS);
                                    messageUsers.addData(chatrooms.Text);

                                    client.sendMessage(messageUsers);
                                }
                            })
                        );

                        Thread.Sleep(2000);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


        }

        private void getChatrooms()
        {
            while (!client.Quit)
            {
                try
                {
                    Message messageChatrooms = new Message(Message.Header.LIST_CR);
                    client.sendMessage(messageChatrooms);
                    Thread.Sleep(2000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Periodically check if the server is available
        /// </summary>
        private void getServer()
        {
            while (!client.Quit)
            {
                Thread.Sleep(2000);
            }

            if (client.Quit)
            {
                // Close the chat if the server is no longer available
                Console.WriteLine("Close from getServer");
                MessageBox.Show("The server is unreachable, please retry.",
                    "Connection error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                chatrooms.Dispatcher.BeginInvoke(
                    (Action)(() =>
                    {
                        this.Close();
                    })
                );
            }
        }

        private void Load()
        {
            nickname.Text = client.User.Login;

            chatroomsBindingList = new ThreadedBindingList<Chatroom>();
            client.ChatroomsBindingList = chatroomsBindingList;
            defaultChatroom = new Chatroom("Select a chatroom");
            chatroomsBindingList.Add(defaultChatroom);
            chatrooms.ItemsSource= chatroomsBindingList;

            usersBindingList = new ThreadedBindingList<User>();
            client.UsersBindingList = usersBindingList;
            userlist.ItemsSource = usersBindingList;
            

            messagesBindingList = new ThreadedBindingList<string>();
            client.MessagesBindingList = messagesBindingList;
            messages.ItemsSource = messagesBindingList;


            // Start the thread to check the chatrooms available
            checkChatrooms = new Thread(new ThreadStart(this.getChatrooms));
            checkChatrooms.Start();

            // Start the thread to check the users connected to the current chatroom
            checkUsers = new Thread(new ThreadStart(this.getUsers));
            checkUsers.Start();

            // Start the thread to check server
            checkServer = new Thread(new ThreadStart(this.getServer));
            checkServer.Start();
        }

        private void messageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void userlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
