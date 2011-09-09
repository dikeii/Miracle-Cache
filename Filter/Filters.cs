using System;
using System.Collections;

namespace PacketMonitor.Filter
{
    internal class Filters
    {
        public static ArrayList PacketIDFilterList = new ArrayList();
        public static ArrayList PortFilterList = new ArrayList();

        public static bool CheckFilter(ArrayList Filter, string check)
        {
            foreach (string filter in Filter)
            {
                if (filter == check)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
