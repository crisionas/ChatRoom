using Common.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for ChatRoomWindow.xaml
    /// </summary>
    public partial class ChatRoomWindow : Window
    {
        private Client client;
        public ChatRoomWindow(Client clientParam)
        {
            InitializeComponent();
            client = clientParam;
        }

        private void chatroomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void createChatroomButton_Click(object sender, RoutedEventArgs e)
        {
            Message message = new Message(Message.Header.CREATE_CR);
            message.addData(chatroomTextBox.Text);


            if (chatroomTextBox.Text != "")
            {
                client.sendMessage(message);

                Message reply = client.getMessage();

                if (reply == null)
                {
                    MessageBox.Show("Server failure",
                        "Connection error",
                        MessageBoxButton.OK,MessageBoxImage.Error);
                }

                if (reply.MessageList.First() == "success")
                {
                    this.Close();
                }
                else if (reply.MessageList.First() == "error")
                {
                    MessageBox.Show(reply.MessageList[1],
                        "Could not create chatroom",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a chatroom name",
                        "Chatroom empty",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
