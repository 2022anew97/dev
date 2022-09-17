using System;

namespace TcpServer
{
    public class LogItem
    {
        private readonly DateTime createdTime = DateTime.Now;

        private string simpleStr = "";

        public byte[] SendRecvData
        {
            get;
        }

        public LogItem(string simpleStr, byte[] sendRecvData = null)
        {
            this.simpleStr = simpleStr;
            this.SendRecvData = sendRecvData;
        }

        public override string ToString()
        {
            var timeStr = DateTime.Now.ToString("HH:mm:ss.fff");
            return timeStr + " - " + simpleStr;
        }
    }
}
