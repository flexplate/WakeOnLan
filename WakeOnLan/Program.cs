using System;

namespace Therezin.WakeOnLan
{
    class Program
    {
        static void Main(string[] args)
        {
            var Client = new Sender();
            foreach (string Target in args)
            {
                if (Target.ValidateMacAddress())
                {
                    Console.Write("Sending magic packet to {0}...", Target);
                    try
                    {
                        Client.SendMagicPacket(Target.ToMacAddress());
                        Console.WriteLine("OK");
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("\"{0}\" is not a valid MAC address.", Target);
                }
            }
        }
    }
}
