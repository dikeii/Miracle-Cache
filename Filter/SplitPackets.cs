using System;
using System.Collections.Generic;
using System.Text;

namespace PacketMonitor.Filter
{
    internal class SplitPackets
    {
        public static int CurrentPos;
        public static bool issplit = false;
        public static int lastidentification;
        public static byte[] packet;
    }
}
