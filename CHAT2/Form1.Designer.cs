namespace CHAT2
{
    partial class Chat
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
            this.button2 = new System.Windows.Forms.Button();
            this.chatbox = new System.Windows.Forms.Label();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Lime;
            this.button2.Location = new System.Drawing.Point(390, 427);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chatbox
            // 
            this.chatbox.BackColor = System.Drawing.Color.Black;
            this.chatbox.ForeColor = System.Drawing.Color.Lime;
            this.chatbox.Location = new System.Drawing.Point(12, 9);
            this.chatbox.Name = "chatbox";
            this.chatbox.Size = new System.Drawing.Size(413, 415);
            this.chatbox.TabIndex = 1;
            this.chatbox.Text = "---";
            this.chatbox.Click += new System.EventHandler(this.chatbox_Click);
            // 
            // tbSend
            // 
            this.tbSend.BackColor = System.Drawing.Color.Black;
            this.tbSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSend.ForeColor = System.Drawing.Color.Lime;
            this.tbSend.Location = new System.Drawing.Point(12, 427);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(372, 13);
            this.tbSend.TabIndex = 2;
            this.tbSend.Text = "exemple";
            this.tbSend.WordWrap = false;
            this.tbSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSend_KeyUp);
            // 
            // Chat
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(437, 462);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.chatbox);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label chatbox;
        private System.Windows.Forms.TextBox tbSend;
    }
}

