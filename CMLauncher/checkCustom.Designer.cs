namespace CLauncher
{
    partial class checkCustom
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.check = new System.Windows.Forms.Panel();
            this.change = new System.Windows.Forms.Label();
            this.check.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.title.Location = new System.Drawing.Point(50, 18);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(209, 29);
            this.title.TabIndex = 0;
            this.title.Text = "Pantalla Completa";
            // 
            // check
            // 
            this.check.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.check.Controls.Add(this.change);
            this.check.Location = new System.Drawing.Point(13, 15);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(31, 32);
            this.check.TabIndex = 1;
            this.check.Enter += new System.EventHandler(this.check_Enter);
            // 
            // change
            // 
            this.change.AutoSize = true;
            this.change.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.change.Location = new System.Drawing.Point(1, 0);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(27, 29);
            this.change.TabIndex = 2;
            this.change.Text = "✓";
            // 
            // checkCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.check);
            this.Controls.Add(this.title);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "checkCustom";
            this.Size = new System.Drawing.Size(268, 64);
            this.check.ResumeLayout(false);
            this.check.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel check;
        private System.Windows.Forms.Label change;
    }
}
