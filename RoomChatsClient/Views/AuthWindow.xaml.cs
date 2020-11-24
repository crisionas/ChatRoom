using Common.Algorithms;
using Common.Auth;
using Common.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {

        private Client client = new Client();
        public AuthWindow()
        {
            InitializeComponent();
            client.connect();
            client.run();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Message messageJoin = new Message(Message.Header.JOIN);
            messageJoin.addData(usernameTextBox.Text);
            string passwordEncrypt = AESAlg.EncryptData(passwordTextBox.Password, usernameTextBox.Text);

            messageJoin.addData(passwordEncrypt);
            client.sendMessage(messageJoin);

            Message reply = client.getMessage();

            if (reply == null)
            {
                MessageBox.Show("Server failure",
                     "Connection error",
                     MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (reply.MessageList.First() == "success")
            {
                client.User = new User(usernameTextBox.Text, passwordTextBox.Password);
                DSAAlg.connectionKey = reply.MessageList[1];
                MessageBox.Show($"\rSuccessfull authentication! \r\n Your connection key: \r\n {reply.MessageList[1]} ", "Connection successfull", MessageBoxButton.OK, MessageBoxImage.Information);

                var form = new ChatWindow(client);
                 form.Show();
                this.Hide();
            }
            else if (reply.MessageList.First() == "error")
            {
                MessageBox.Show("Wrong username or password.",
                     "Connection error",
                     MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Message messageRegister = new Message(Message.Header.REGISTER);
            messageRegister.addData(usernameTextBox.Text);
            string passwordEncrypt = AESAlg.EncryptData(passwordTextBox.Password,usernameTextBox.Text);

            messageRegister.addData(passwordEncrypt);

            if (usernameTextBox.Text == "" || passwordTextBox.Password == "")
            {
                MessageBox.Show("Fill username and password",
                    "Username and password cannot be empty",
                     MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                client.sendMessage(messageRegister);

                Message register = client.getMessage();

                if (register == null)
                {
                    MessageBox.Show("Server failure",
                         "Connection error",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (register.MessageList.First() == "success")
                {
                    MessageBox.Show("Registration success. You can now login using your credentials.",
                        "Registration success.",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (register.MessageList.First() == "error")
                {
                    MessageBox.Show("Could not register",
                         "Connection error",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
