namespace CMLauncher
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.barraDeCarga = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // barraDeCarga
            // 
            this.barraDeCarga.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraDeCarga.Location = new System.Drawing.Point(0, 302);
            this.barraDeCarga.MarqueeAnimationSpeed = 10;
            this.barraDeCarga.Name = "barraDeCarga";
            this.barraDeCarga.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.barraDeCarga.Size = new System.Drawing.Size(595, 35);
            this.barraDeCarga.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barraDeCarga.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 108);
            this.label1.TabIndex = 1;
            this.label1.Text = "CMLauncher";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(595, 337);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barraDeCarga);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cargando";
            this.Load += new System.EventHandler(this.Load_Load);
            this.Shown += new System.EventHandler(this.Load_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar barraDeCarga;
        private System.Windows.Forms.Label label1;
    }
}