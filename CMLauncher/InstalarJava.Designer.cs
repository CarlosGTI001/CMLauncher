namespace CLauncher
{
    partial class InstalarJava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstalarJava));
            this.caption = new System.Windows.Forms.Label();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.javaPortable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // caption
            // 
            this.caption.AutoSize = true;
            this.caption.Location = new System.Drawing.Point(12, 9);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(391, 24);
            this.caption.TabIndex = 0;
            this.caption.Text = "No se encontro una version de Java instalada";
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.cancelarBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.cancelarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelarBtn.Location = new System.Drawing.Point(278, 401);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(134, 50);
            this.cancelarBtn.TabIndex = 12;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = false;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // javaPortable
            // 
            this.javaPortable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.javaPortable.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.javaPortable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.javaPortable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.javaPortable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.javaPortable.Location = new System.Drawing.Point(134, 401);
            this.javaPortable.Name = "javaPortable";
            this.javaPortable.Size = new System.Drawing.Size(134, 50);
            this.javaPortable.TabIndex = 13;
            this.javaPortable.Text = "Descargar";
            this.javaPortable.UseVisualStyleBackColor = false;
            this.javaPortable.Click += new System.EventHandler(this.javaPortable_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(52, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 319);
            this.label1.TabIndex = 14;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstalarJava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(545, 489);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.javaPortable);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.caption);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "InstalarJava";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InstalarJava";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label caption;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.Button javaPortable;
        private System.Windows.Forms.Label label1;
    }
}