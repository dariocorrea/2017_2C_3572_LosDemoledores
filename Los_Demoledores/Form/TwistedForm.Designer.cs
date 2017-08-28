namespace Los_Demoledores.Form
{
    partial class TwistedForm
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
            this.panel3D = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            this.panel3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3D.Location = new System.Drawing.Point(0, 0);
            this.panel3D.Name = "panel3D";
            this.panel3D.Size = new System.Drawing.Size(784, 561);
            this.panel3D.TabIndex = 0;
            // 
            // TwistedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 968);
            this.Controls.Add(this.panel3D);
            this.Name = "TwistedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TwistedForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TwistedForm_FormClosing);
            this.Load += new System.EventHandler(this.TwistedForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3D;
    }
}