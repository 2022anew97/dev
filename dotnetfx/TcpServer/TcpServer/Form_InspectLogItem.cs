using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TcpServer
{
    public partial class Form_InspectLogItem : Form
    {
        private readonly LogItem logItem;

        public Form_InspectLogItem(LogItem logItem)
        {
            this.logItem = logItem;
            InitializeComponent();
            Enable_Ctrl_A_to_SelectAll();
        }

        private void Enable_Ctrl_A_to_SelectAll()
        {
            foreach (var control in Controls)
            {
                var txt = control as TextBox;
                if (txt != null) txt.KeyDown += (a1, a2) =>
                {
                    if (a2.Control && a2.KeyCode == Keys.A) txt.SelectAll();
                };
            }
        }

        private void Form_InspectLogItem_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(ClientSize.Width, 120);
            MinimumSize = new Size(500, Height);
            MaximumSize = new Size(int.MaxValue, Height);

            Text = $"Inspect {logItem.SendRecvData.Length} byte(s)";
            txtContext.Text = logItem.ToString();
            txtASCII.Text = Encoding.ASCII.GetString(logItem.SendRecvData);
            txtHexStr.Text = Utils.BytesToHexStr(logItem.SendRecvData);
        }

        private void Form_InspectLogItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
