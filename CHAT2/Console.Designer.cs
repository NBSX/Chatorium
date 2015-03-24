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
            this.console_output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // console_output
            // 
            this.console_output.BackColor = System.Drawing.SystemColors.InfoText;
            this.console_output.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.console_output.Location = new System.Drawing.Point(-2, -2);
            this.console_output.Multiline = true;
            this.console_output.Name = "console_output";
            this.console_output.Size = new System.Drawing.Size(821, 316);
            this.console_output.TabIndex = 0;
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox console_output;

    }
}