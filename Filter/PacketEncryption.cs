using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace PacketMonitor.Filter
{
    internal class PacketEncryption
    {
        public static bool isfirst = true;
        public static byte[] RIV;
        public static byte[] SIV;

        /*//[DllImport("PacketEnc.dll")]
        public static extern void Decrypt(byte[] packet, int size, byte[] ivSend);
        //[DllImport("PacketEnc.dll")]
        public static extern int GenerateIV(byte[] IV);
        //[DllImport("PacketEnc.dll")]
        public static extern int GetPacketLength(byte[] header);*/
    }
}
