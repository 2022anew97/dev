namespace TcpServer
{
    partial class Form_InspectLogItem
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
            this.txtContext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtASCII = new System.Windows.Forms.TextBox();
            this.txtHexStr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtContext
            // 
            this.txtContext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContext.Location = new System.Drawing.Point(10, 9);
            this.txtContext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContext.Name = "txtContext";
            this.txtContext.ReadOnly = true;
            this.txtContext.Size = new System.Drawing.Size(724, 23);
            this.txtContext.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hex String:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "As ASCII:";
            // 
            // txtASCII
            // 
            this.txtASCII.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtASCII.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtASCII.Location = new System.Drawing.Point(81, 69);
            this.txtASCII.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtASCII.Name = "txtASCII";
            this.txtASCII.ReadOnly = true;
            this.txtASCII.Size = new System.Drawing.Size(653, 25);
            this.txtASCII.TabIndex = 2;
            // 
            // txtHexStr
            // 
            this.txtHexStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHexStr.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHexStr.Location = new System.Drawing.Point(81, 39);
            this.txtHexStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHexStr.Name = "txtHexStr";
            this.txtHexStr.ReadOnly = true;
            this.txtHexStr.Size = new System.Drawing.Size(653, 25);
            this.txtHexStr.TabIndex = 2;
            // 
            // Form_InspectLogItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(746, 106);
            this.Controls.Add(this.txtHexStr);
            this.Controls.Add(this.txtASCII);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContext);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_InspectLogItem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspect";
            this.Load += new System.EventHandler(this.Form_InspectLogItem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_InspectLogItem_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtASCII;
        private System.Windows.Forms.TextBox txtHexStr;
    }
}