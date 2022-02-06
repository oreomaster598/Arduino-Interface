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
        public string name;

        public Arduino(string portName, int BaudRate = 9600)
        {
            
            serialPort = new SerialPort(portName);
            serialPort.BaudRate = BaudRate;
            serialPort.ReadTimeout = 2000;
            serialPort.WriteTimeout = 2000;
            serialPort.Open();
            name = portName;
        }
        public void WriteToArduino(string text)
        {
            serialPort.WriteLine(text);
        }

        public string ReadFromArduino()
        {
            return serialPort.ReadLine();
        }
    }
}
