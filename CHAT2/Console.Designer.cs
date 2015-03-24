namespace CHAT2
{
    partial class console
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
            this.console_output = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // console_output
            // 
            this.console_output.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.console_output.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.console_output.Location = new System.Drawing.Point(-1, -1);
            this.console_output.Name = "console_output";
            this.console_output.Size = new System.Drawing.Size(821, 315);
            this.console_output.TabIndex = 0;
            this.console_output.Click += new System.EventHandler(this.console_output_Click);
            // 
            // console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 311);
            this.Controls.Add(this.console_output);
            this.Name = "console";
            this.Text = "Console";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label console_output;
    }
}