using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace Arduino
{
    class Program
    {
        public static string help = "Syntax: Arduino PortName [PrintPortStream (true/false)]";

        static void Main(string[] args)
        {
            if(args.Length >= 1)
            {
                Arduino arduino = new Arduino(args[0]);
                if(args.Length >= 2)
                 if(args[1] == "true")
                    arduino.PrintPortStream = true;

                while(true)
                {
                    Console.Write("Write to arduino: ");
                    string str = Console.ReadLine();
                    Console.Clear();
                    arduino.Write(str);
                    Thread.Sleep(75);
                    Console.WriteLine($"Arduino ({arduino.name}) Connected\n"+arduino.log);
                }
            }
            else
            {
                Console.WriteLine(help);
            }
        }
    }
}
