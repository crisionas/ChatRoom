using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RoomChatsServer.Views
{
    /// <summary>
    /// Interaction logic for ServerGUI.xaml
    /// </summary>
    public partial class ServerGUI : Window
    {
        TextWriter _writer = null;
        private Server server;
        public ServerGUI()
        {
            InitializeComponent();
            StartServer();
            // Instantiate the writer
            _writer = new TextBoxStreamWriter(txtConsole);
            // Redirect the out Console stream
            Console.SetOut(_writer);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
        }
        
        public void StartServer()
        {
            if (StartButton.Content.ToString() == "Start Server")
            {
                server = new Server();
                server.startServer();
                StartButton.Content = "Stop Server";

                if (server.Running)
                {
                    server.run();
                }
                else
                {
                    MessageBox.Show("Server failure", "Connection error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                StartButton.Content = "Start Server";
                server.stopServer();
            }
        }
    }
}
