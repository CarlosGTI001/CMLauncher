namespace CMLauncher
{
    partial class Configuracion
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
            this.arrastrar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.guardarBtn = new System.Windows.Forms.Button();
            this.salirBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RMAX = new System.Windows.Forms.NumericUpDown();
            this.RMIN = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.directorio = new System.Windows.Forms.TextBox();
            this.examinarDirectorio = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fullScreenCheck = new System.Windows.Forms.CheckBox();
            this.resolucionPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xNum = new System.Windows.Forms.NumericUpDown();
            this.yNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.javaPath = new System.Windows.Forms.TextBox();
            this.examinarJavaPath = new System.Windows.Forms.Button();
            this.arrastrar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RMAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RMIN)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.resolucionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNum)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // arrastrar
            // 
            this.arrastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.arrastrar.Controls.Add(this.label3);
            this.arrastrar.Location = new System.Drawing.Point(-2, 0);
            this.arrastrar.Name = "arrastrar";
            this.arrastrar.Size = new System.Drawing.Size(783, 49);
            this.arrastrar.TabIndex = 6;
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
            this.label3.Size = new System.Drawing.Size(162, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Configuracion";
            // 
            // guardarBtn
            // 
            this.guardarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.guardarBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.guardarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.guardarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.guardarBtn.Location = new System.Drawing.Point(247, 600);
            this.guardarBtn.Name = "guardarBtn";
            this.guardarBtn.Size = new System.Drawing.Size(136, 48);
            this.guardarBtn.TabIndex = 7;
            this.guardarBtn.Text = "Guardar";
            this.guardarBtn.UseVisualStyleBackColor = false;
            this.guardarBtn.Click += new System.EventHandler(this.guardarBtn_Click);
            // 
            // salirBtn
            // 
            this.salirBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.salirBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.salirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.salirBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.salirBtn.Location = new System.Drawing.Point(405, 600);
            this.salirBtn.Name = "salirBtn";
            this.salirBtn.Size = new System.Drawing.Size(136, 48);
            this.salirBtn.TabIndex = 8;
            this.salirBtn.Text = "Cancelar";
            this.salirBtn.UseVisualStyleBackColor = false;
            this.salirBtn.Click += new System.EventHandler(this.salirBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(14, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "RAM Maxima (-Xmx)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(411, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "RAM Minima (-Xmn)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.RMAX);
            this.groupBox2.Controls.Add(this.RMIN);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Location = new System.Drawing.Point(12, 316);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(757, 123);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Memoria RAM";
            // 
            // RMAX
            // 
            this.RMAX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.RMAX.ForeColor = System.Drawing.Color.White;
            this.RMAX.Location = new System.Drawing.Point(246, 56);
            this.RMAX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.RMAX.Name = "RMAX";
            this.RMAX.Size = new System.Drawing.Size(86, 34);
            this.RMAX.TabIndex = 13;
            this.RMAX.ValueChanged += new System.EventHandler(this.RMAX_ValueChanged);
            this.RMAX.Leave += new System.EventHandler(this.RMAX_Leave);
            // 
            // RMIN
            // 
            this.RMIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.RMIN.ForeColor = System.Drawing.Color.White;
            this.RMIN.Location = new System.Drawing.Point(646, 56);
            this.RMIN.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.RMIN.Name = "RMIN";
            this.RMIN.Size = new System.Drawing.Size(86, 34);
            this.RMIN.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.directorio);
            this.groupBox1.Controls.Add(this.examinarDirectorio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 109);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directorio de Minecraft";
            // 
            // directorio
            // 
            this.directorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.directorio.ForeColor = System.Drawing.Color.White;
            this.directorio.Location = new System.Drawing.Point(35, 52);
            this.directorio.Name = "directorio";
            this.directorio.Size = new System.Drawing.Size(557, 34);
            this.directorio.TabIndex = 19;
            // 
            // examinarDirectorio
            // 
            this.examinarDirectorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.examinarDirectorio.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.examinarDirectorio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.examinarDirectorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examinarDirectorio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.examinarDirectorio.Location = new System.Drawing.Point(603, 44);
            this.examinarDirectorio.Name = "examinarDirectorio";
            this.examinarDirectorio.Size = new System.Drawing.Size(136, 48);
            this.examinarDirectorio.TabIndex = 18;
            this.examinarDirectorio.Text = "Examinar...";
            this.examinarDirectorio.UseVisualStyleBackColor = false;
            this.examinarDirectorio.Click += new System.EventHandler(this.examinarDirectorio_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.resolucionPanel);
            this.groupBox3.Controls.Add(this.fullScreenCheck);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Location = new System.Drawing.Point(12, 445);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(757, 123);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pantalla";
            // 
            // fullScreenCheck
            // 
            this.fullScreenCheck.AutoSize = true;
            this.fullScreenCheck.ForeColor = System.Drawing.Color.White;
            this.fullScreenCheck.Location = new System.Drawing.Point(18, 55);
            this.fullScreenCheck.Name = "fullScreenCheck";
            this.fullScreenCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fullScreenCheck.Size = new System.Drawing.Size(228, 33);
            this.fullScreenCheck.TabIndex = 0;
            this.fullScreenCheck.Text = "Pantalla Completa";
            this.fullScreenCheck.UseVisualStyleBackColor = true;
            this.fullScreenCheck.CheckedChanged += new System.EventHandler(this.fullScreenCheck_CheckedChanged);
            // 
            // resolucionPanel
            // 
            this.resolucionPanel.Controls.Add(this.yNum);
            this.resolucionPanel.Controls.Add(this.xNum);
            this.resolucionPanel.Controls.Add(this.label5);
            this.resolucionPanel.Controls.Add(this.label4);
            this.resolucionPanel.Location = new System.Drawing.Point(279, 26);
            this.resolucionPanel.Name = "resolucionPanel";
            this.resolucionPanel.Size = new System.Drawing.Size(462, 81);
            this.resolucionPanel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(293, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 29);
            this.label5.TabIndex = 22;
            this.label5.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(46, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 29);
            this.label4.TabIndex = 23;
            this.label4.Text = "Resolucion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label6.Location = new System.Drawing.Point(2, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Valor de RAM expresado en MB";
            // 
            // xNum
            // 
            this.xNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.xNum.ForeColor = System.Drawing.Color.White;
            this.xNum.Location = new System.Drawing.Point(192, 27);
            this.xNum.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.xNum.Name = "xNum";
            this.xNum.Size = new System.Drawing.Size(95, 34);
            this.xNum.TabIndex = 20;
            // 
            // yNum
            // 
            this.yNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.yNum.ForeColor = System.Drawing.Color.White;
            this.yNum.Location = new System.Drawing.Point(329, 27);
            this.yNum.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.yNum.Name = "yNum";
            this.yNum.Size = new System.Drawing.Size(95, 34);
            this.yNum.TabIndex = 24;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.javaPath);
            this.groupBox4.Controls.Add(this.examinarJavaPath);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox4.Location = new System.Drawing.Point(12, 195);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(757, 109);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Directorio de Java";
            // 
            // javaPath
            // 
            this.javaPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.javaPath.ForeColor = System.Drawing.Color.White;
            this.javaPath.Location = new System.Drawing.Point(35, 52);
            this.javaPath.Name = "javaPath";
            this.javaPath.Size = new System.Drawing.Size(557, 34);
            this.javaPath.TabIndex = 19;
            // 
            // examinarJavaPath
            // 
            this.examinarJavaPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.examinarJavaPath.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.examinarJavaPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.examinarJavaPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examinarJavaPath.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.examinarJavaPath.Location = new System.Drawing.Point(603, 44);
            this.examinarJavaPath.Name = "examinarJavaPath";
            this.examinarJavaPath.Size = new System.Drawing.Size(136, 48);
            this.examinarJavaPath.TabIndex = 18;
            this.examinarJavaPath.Text = "Examinar...";
            this.examinarJavaPath.UseVisualStyleBackColor = false;
            this.examinarJavaPath.Click += new System.EventHandler(this.examinarJavaPath_Click);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(781, 670);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.salirBtn);
            this.Controls.Add(this.guardarBtn);
            this.Controls.Add(this.arrastrar);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Configuracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.Configuracion_Load);
            this.arrastrar.ResumeLayout(false);
            this.arrastrar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RMAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RMIN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.resolucionPanel.ResumeLayout(false);
            this.resolucionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNum)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel arrastrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button guardarBtn;
        private System.Windows.Forms.Button salirBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown RMIN;
        private System.Windows.Forms.NumericUpDown RMAX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button examinarDirectorio;
        private System.Windows.Forms.TextBox directorio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox fullScreenCheck;
        private System.Windows.Forms.Panel resolucionPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown xNum;
        private System.Windows.Forms.NumericUpDown yNum;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox javaPath;
        private System.Windows.Forms.Button examinarJavaPath;
    }
}