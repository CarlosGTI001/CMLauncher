namespace CLauncher
{
    partial class info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(info));
            this.arrastrar = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.masInfo = new System.Windows.Forms.Button();
            this.donarBtn = new System.Windows.Forms.Button();
            this.arrastrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // arrastrar
            // 
            this.arrastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.arrastrar.Controls.Add(this.button1);
            this.arrastrar.Controls.Add(this.label3);
            this.arrastrar.Location = new System.Drawing.Point(1, 3);
            this.arrastrar.Name = "arrastrar";
            this.arrastrar.Size = new System.Drawing.Size(456, 49);
            this.arrastrar.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(412, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Acerca De";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(83, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 87);
            this.label1.TabIndex = 8;
            this.label1.Text = "Launcher de minecraft no oficial,\r\nCreado por un gamer para todos\r\nlos gamers\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 66);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // masInfo
            // 
            this.masInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.masInfo.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.masInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.masInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.masInfo.Location = new System.Drawing.Point(141, 190);
            this.masInfo.Name = "masInfo";
            this.masInfo.Size = new System.Drawing.Size(177, 44);
            this.masInfo.TabIndex = 10;
            this.masInfo.Text = "Mas informacion...";
            this.masInfo.UseVisualStyleBackColor = false;
            this.masInfo.Click += new System.EventHandler(this.masInfo_Click);
            // 
            // donarBtn
            // 
            this.donarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.donarBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.donarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.donarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donarBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.donarBtn.Location = new System.Drawing.Point(141, 240);
            this.donarBtn.Name = "donarBtn";
            this.donarBtn.Size = new System.Drawing.Size(177, 44);
            this.donarBtn.TabIndex = 11;
            this.donarBtn.Text = "Donar";
            this.donarBtn.UseVisualStyleBackColor = false;
            this.donarBtn.Click += new System.EventHandler(this.donarBtn_Click);
            // 
            // info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(457, 299);
            this.Controls.Add(this.donarBtn);
            this.Controls.Add(this.masInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.arrastrar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "info";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "info";
            this.arrastrar.ResumeLayout(false);
            this.arrastrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel arrastrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button masInfo;
        private System.Windows.Forms.Button donarBtn;
    }
}