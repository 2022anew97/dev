using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TcpServer
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;
        private TcpClient tcpClient;

        public Form1()
        {
            InitializeComponent();
        }

        private void MsgErr(string text, string title = "Error")
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void AppendLog(string simplestr, byte[] sendRecvData = null)
        {
            lbxLog.SelectedIndex = lbxLog.Items.Add(new LogItem(simplestr, sendRecvData));
        }

        private enum ServerEvent
        {
            STARTING,
            STARTED,
            STOPPING,
            STOPPED
        }

        private void UpdateUI(ServerEvent serverEvent)
        {
            this.txtListenPort.ReadOnly = true;
            this.btnClearLog.Enabled = false;
            this.btnStart.Enabled = false;
            if (serverEvent == ServerEvent.STARTING ||
                serverEvent == ServerEvent.STOPPING)
            {
                return;
            }
            if (serverEvent == ServerEvent.STARTED)
            {
                this.btnStart.Text = "&Stop";
                this.btnStart.Enabled = true;
                return;
            }
            if (serverEvent == ServerEvent.STOPPED)
            {
                this.txtListenPort.ReadOnly = false;
                this.btnStart.Text = "&Start";
                this.btnStart.Enabled = true;
                this.btnClearLog.Enabled = true;
                return;
            }
        }

        private void SafeTcpCleanup()
        {
            try
            {
                this.tcpListener?.Stop();
            }
            catch (Exception)
            {
            }
            try
            {
                this.tcpClient?.Close();
            }
            catch (Exception)
            {
            }
            this.tcpListener = null;
            this.tcpClient = null;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (this.tcpListener != null)
            {
                UpdateUI(ServerEvent.STOPPING);
                if (this.tcpClient != null)
                {
                    AppendLog("Disconnecting client and stopping server.");
                    this.tcpClient.Close();
                }
                else
                {
                    AppendLog("Stopping server.");
                }
                this.tcpListener.Stop();
                return;
            }
            ushort port;
            if (!ushort.TryParse(txtListenPort.Text, out port))
            {
                MsgErr("Port must be a number between 0 and 65535.");
                txtListenPort.SelectAll();
                txtListenPort.Focus();
                return;
            }
            try
            {
                AppendLog("Starting server.");
                UpdateUI(ServerEvent.STARTING);
                this.tcpListener = new TcpListener(IPAddress.Any, port);
                this.tcpListener.Start();
                AppendLog($"Server started, listening port {port}.");
                UpdateUI(ServerEvent.STARTED);
                while (true)
                {
                    this.tcpClient = await tcpListener.AcceptTcpClientAsync();
                    AppendLog("Client connected.");
                    for (var stream = this.tcpClient.GetStream(); ;)
                    {
                        byte[] buffer = new byte[65535];
                        int cbRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        if (cbRead < 1) break;
                        AppendLog($"Received {cbRead} byte(s).", Utils.SubBytes(buffer, 0, cbRead));
                    }
                    AppendLog("Client disconnected.");
                }
            }
            catch (ObjectDisposedException)
            {
                AppendLog("Server stopped.");
                SafeTcpCleanup();
                UpdateUI(ServerEvent.STOPPED);
            }
            catch (Exception ex)
            {
                AppendLog("Unexpected: " + ex.Message);
                SafeTcpCleanup();
                UpdateUI(ServerEvent.STOPPED);
                return;
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lbxLog.Items.Clear();
        }

        private void OnUserInvokeLogListboxItem()
        {
            var logItem = lbxLog.SelectedItem as LogItem;
            if (logItem?.SendRecvData != null)
            {
                new Form_InspectLogItem(logItem).Show();
            }
        }

        private void lbxLog_DoubleClick(object sender, EventArgs e)
        {
            OnUserInvokeLogListboxItem();
        }

        private void lbxLog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnUserInvokeLogListboxItem();
            }
        }
    }
}
