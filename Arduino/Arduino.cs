using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Arduino
{
    public class Arduino
    {
        private SerialPort serialPort;
        public string log;
        public bool PrintPortStream = false;
        public string name;

        public Arduino(string portName)
        {
            serialPort = new SerialPort(portName);
            serialPort.BaudRate = 9600;
            serialPort.ReadTimeout = 2000;
            serialPort.WriteTimeout = 2000;
            serialPort.DataReceived += DataReceived;
            serialPort.Open();
            name = portName;
        }
        private void DataReceived(object s, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[1024];
            int bytesRead = serialPort.Read(data, 0, data.Length);
            if(PrintPortStream)
                Console.Write(Encoding.ASCII.GetString(data, 0, bytesRead));
            log+=Encoding.ASCII.GetString(data, 0, bytesRead);
        }
        public void Write(string text)
        {
            serialPort.WriteLine(text);
        }
    }
}
