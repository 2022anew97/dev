namespace TcpServer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            this.txtListenPort = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 15);
            label1.TabIndex = 2;
            label1.Text = "Listen Port:";
            // 
            // txtListenPort
            // 
            this.txtListenPort.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtListenPort.Location = new System.Drawing.Point(82, 11);
            this.txtListenPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtListenPort.MaxLength = 5;
            this.txtListenPort.Name = "txtListenPort";
            this.txtListenPort.Size = new System.Drawing.Size(53, 25);
            this.txtListenPort.TabIndex = 1;
            this.txtListenPort.Text = "9000";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(141, 9);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 28);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbxLog
            // 
            this.lbxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.ItemHeight = 15;
            this.lbxLog.Location = new System.Drawing.Point(10, 49);
            this.lbxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.ScrollAlwaysVisible = true;
            this.lbxLog.Size = new System.Drawing.Size(666, 289);
            this.lbxLog.TabIndex = 101;
            this.lbxLog.DoubleClick += new System.EventHandler(this.lbxLog_DoubleClick);
            this.lbxLog.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbxLog_KeyUp);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(227, 9);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(80, 28);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 346);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.lbxLog);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtListenPort);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TcpServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtListenPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.Button btnClearLog;
    }
}

