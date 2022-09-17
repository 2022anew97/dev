using System;
using System.Text;

namespace TcpServer
{
    public static class Utils
    {
        public static string BcdStr(byte[] bytes)
        {
            string s = "";
            for (int i = 0; i < bytes.Length; ++i)
            {
                s += bytes[i].ToString("X2");
            }
            return s;
        }

        public static int BcdInt(byte[] bytes)
        {
            return int.Parse(BcdStr(bytes));
        }

        public static bool BcdTest(byte[] bytes)
        {
            foreach (var c in BytesToHexStr(bytes))
            {
                if (c < '0' || c > '9') return false;
            }
            return true;
        }

        public static byte[] HexStrToBytes(string hexStr)
        {
            string hex = hexStr.Replace(" ", "").Replace("\r", "").Replace("\n", "");
            if (hex.Length % 2 == 1)
            {
                throw new ArgumentException("Hex String length must be even number.");
            }
            byte[] arr = new byte[hex.Length >> 1];
            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }
            return arr;
        }

        public static string ByteToHexStr(byte b)
        {
            return BytesToHexStr(new byte[] { b });
        }

        public static string BytesToHexStr(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes) sb.AppendFormat("{0:X2}", b);
            return sb.ToString();
        }

        public static byte[] SubBytes(byte[] bytes, int off, int len)
        {
            byte[] bytes2 = new byte[len];
            for (int i = 0; i < len; i++)
            {
                bytes2[i] = bytes[i + off];
            }
            return bytes2;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            if ((val < '0' || val > '9') && (val < 'A' || val > 'F') && (val < 'a' || val > 'f'))
            {
                throw new Exception("Invalid hex char detected");
            }
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        public static byte GetLongRangeChecksum(byte[] bytes, int len)
        {
            byte b = 0x00;
            for (int i = 0; i < len; ++i)
            {
                b ^= bytes[i];
            }
            return b;
        }

        public static byte GetLongRangeChecksum(byte[] bytes)
        {
            return GetLongRangeChecksum(bytes, bytes.Length);
        }
    }
}
