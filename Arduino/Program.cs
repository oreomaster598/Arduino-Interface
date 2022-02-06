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
        public static string help = "Syntax: Arduino PortName";

        static void Main(string[] args)
        {
            if(args.Length >= 1)
            {
                Arduino arduino = new Arduino(args[0]);

                while(true)
                {
                    Console.Write(arduino.name+"> ");
                    string inp = Console.ReadLine();
                    if(inp == "exit")
                        Environment.Exit(0);
                    else
                    {
                        arduino.WriteToArduino(inp);
                        Console.WriteLine(arduino.ReadFromArduino());
                    }
                }
            }
            else
            {
                Console.WriteLine(help);
            }
        }
    }
}
