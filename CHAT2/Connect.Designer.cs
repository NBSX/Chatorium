namespace CHAT2
{
    partial class Connect
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
            this.btConnect = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(13, 50);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(136, 29);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(169, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 66);
            this.button2.TabIndex = 1;
            this.button2.Text = "Listen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(13, 12);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(136, 20);
            this.tbIP.TabIndex = 2;
            this.tbIP.Text = "IP";
            this.tbIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 92);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Connect";
            this.Text = "Connect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbIP;
    }
}