using System;
using System.Collections.Generic;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static string UInt32ToIP(uint ip)
        {
            string Bin = Convert.ToString(ip, 2).PadLeft(32, '0');
            List<byte> Bytes = new List<byte>();
            for (int i = 0; i < Bin.Length / 8; i++)
            {
                Bytes.Add(Convert.ToByte(Bin.Substring(8*i, 8), 2));
            }

            return string.Join('.', Bytes);
            
            //best p. System.Net => new IPAddress(ip).ToString()
        }
    }
}