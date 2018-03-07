using System.Net;
using System.Net.Sockets;

namespace Therezin.WakeOnLan
{
	public class Sender:UdpClient
	{
        public Sender():base()
        {

        }

        public void EnableBroadcastMode()
        {
            if (Active)
            {
                Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 0);
            }
        }

		public bool SendMagicPacket(byte[] macAddress)
		{
            Connect(new IPAddress(0xFFFFFFFF), 0x2FFF);
            EnableBroadcastMode();

            // Build magic packet: 6 repetitions of 0xFF, 16 of the MAC.
            byte[] Packet = new byte[102];
            for (int i = 0; i < 6; i++)
            {
                Packet[i] = 0xFF;
            }
            int Offset = 6;
            for (int i = 0; i < 16; i++)
            {
                macAddress.CopyTo(Packet, Offset);
                Offset += 6;
            }

            int ReturnValue = Send(Packet, 102);
            Close();
            return ReturnValue == 0;
        }
	}
}
