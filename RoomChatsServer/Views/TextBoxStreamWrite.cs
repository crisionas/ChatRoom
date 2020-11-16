using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;

namespace RoomChatsServer.Views
{
    public class TextBoxStreamWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxStreamWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            try
            {
                _output.Dispatcher.BeginInvoke(() =>
                {
                    _output.AppendText(value.ToString());
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
