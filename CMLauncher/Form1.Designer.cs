namespace CMLauncher
{
    partial class Inicio
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.jugarMC = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.novedades = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.editarConfiguracionBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.versionesCbx = new System.Windows.Forms.ComboBox();
            this.close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.arrastrar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.novedades)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.arrastrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // jugarMC
            // 
            this.jugarMC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.jugarMC.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.jugarMC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.jugarMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jugarMC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.jugarMC.Location = new System.Drawing.Point(14, 414);
            this.jugarMC.Name = "jugarMC";
            this.jugarMC.Size = new System.Drawing.Size(177, 44);
            this.jugarMC.TabIndex = 0;
            this.jugarMC.Text = "Descargar";
            this.jugarMC.UseVisualStyleBackColor = false;
            this.jugarMC.Click += new System.EventHandler(this.jugarMC_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.novedades);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(10, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 542);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Novedades";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // novedades
            // 
            this.novedades.AllowExternalDrop = true;
            this.novedades.CreationProperties = null;
            this.novedades.DefaultBackgroundColor = System.Drawing.Color.White;
            this.novedades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.novedades.Location = new System.Drawing.Point(3, 30);
            this.novedades.Name = "novedades";
            this.novedades.Size = new System.Drawing.Size(805, 509);
            this.novedades.Source = new System.Uri("https://www.minecraft.net/es-es", System.UriKind.Absolute);
            this.novedades.TabIndex = 0;
            this.novedades.ZoomFactor = 1D;
            this.novedades.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.novedades_NavigationCompleted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.editarConfiguracionBtn);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.versionesCbx);
            this.groupBox2.Controls.Add(this.jugarMC);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Location = new System.Drawing.Point(827, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 542);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuracion";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.button3.BackgroundImage = global::CMLauncher.Properties.Resources.info_2_48;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(135, 474);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 55);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.button2.BackgroundImage = global::CMLauncher.Properties.Resources.folder_3_48;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(75, 474);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 55);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // editarConfiguracionBtn
            // 
            this.editarConfiguracionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.editarConfiguracionBtn.BackgroundImage = global::CMLauncher.Properties.Resources.settings_48;
            this.editarConfiguracionBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editarConfiguracionBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.editarConfiguracionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editarConfiguracionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editarConfiguracionBtn.ForeColor = System.Drawing.Color.Transparent;
            this.editarConfiguracionBtn.Location = new System.Drawing.Point(14, 474);
            this.editarConfiguracionBtn.Name = "editarConfiguracionBtn";
            this.editarConfiguracionBtn.Size = new System.Drawing.Size(55, 55);
            this.editarConfiguracionBtn.TabIndex = 5;
            this.editarConfiguracionBtn.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 287);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 34);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(8, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gamertag";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(9, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Version";
            // 
            // versionesCbx
            // 
            this.versionesCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.versionesCbx.FormattingEnabled = true;
            this.versionesCbx.Location = new System.Drawing.Point(13, 364);
            this.versionesCbx.Name = "versionesCbx";
            this.versionesCbx.Size = new System.Drawing.Size(177, 32);
            this.versionesCbx.TabIndex = 1;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.close.Location = new System.Drawing.Point(992, 9);
            this.close.Margin = new System.Windows.Forms.Padding(0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(35, 29);
            this.close.TabIndex = 3;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(946, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "-";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // arrastrar
            // 
            this.arrastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.arrastrar.Controls.Add(this.label3);
            this.arrastrar.Location = new System.Drawing.Point(0, 0);
            this.arrastrar.Name = "arrastrar";
            this.arrastrar.Size = new System.Drawing.Size(943, 49);
            this.arrastrar.TabIndex = 5;
            this.arrastrar.Paint += new System.Windows.Forms.PaintEventHandler(this.arrastrar_Paint);
            this.arrastrar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.arrastrar_MouseDown);
            this.arrastrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.arrastrar_MouseMove);
            this.arrastrar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.arrastrar_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "CMLauncher";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1039, 598);
            this.Controls.Add(this.arrastrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.novedades)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.arrastrar.ResumeLayout(false);
            this.arrastrar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button jugarMC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox versionesCbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private Microsoft.Web.WebView2.WinForms.WebView2 novedades;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel arrastrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button editarConfiguracionBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

