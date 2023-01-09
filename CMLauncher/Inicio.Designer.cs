using System;

namespace CLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.jugarMC = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.snap = new System.Windows.Forms.CheckBox();
            this.acercaDe = new System.Windows.Forms.Button();
            this.abrirCarpeta = new System.Windows.Forms.Button();
            this.editarConfiguracionBtn = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.versionesCbx = new System.Windows.Forms.ComboBox();
            this.descargaBar = new System.Windows.Forms.ProgressBar();
            this.close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.arrastrar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cargaDeJson = new System.ComponentModel.BackgroundWorker();
            this.descargando = new System.ComponentModel.BackgroundWorker();
            this.cancelar = new System.Windows.Forms.Button();
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
            this.jugarMC.Location = new System.Drawing.Point(11, 377);
            this.jugarMC.Name = "jugarMC";
            this.jugarMC.Size = new System.Drawing.Size(177, 44);
            this.jugarMC.TabIndex = 0;
            this.jugarMC.Text = "Descargar";
            this.jugarMC.UseVisualStyleBackColor = false;
            this.jugarMC.Click += new System.EventHandler(this.jugarMC_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(10, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 508);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Novedades";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.snap);
            this.groupBox2.Controls.Add(this.acercaDe);
            this.groupBox2.Controls.Add(this.abrirCarpeta);
            this.groupBox2.Controls.Add(this.editarConfiguracionBtn);
            this.groupBox2.Controls.Add(this.userName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.versionesCbx);
            this.groupBox2.Controls.Add(this.jugarMC);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Location = new System.Drawing.Point(827, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 509);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuracion";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // snap
            // 
            this.snap.AutoSize = true;
            this.snap.Location = new System.Drawing.Point(11, 338);
            this.snap.Name = "snap";
            this.snap.Size = new System.Drawing.Size(151, 33);
            this.snap.TabIndex = 8;
            this.snap.Text = "Snaptshots";
            this.snap.UseVisualStyleBackColor = true;
            this.snap.CheckedChanged += new System.EventHandler(this.Snaptshot_CheckedChanged);
            // 
            // acercaDe
            // 
            this.acercaDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.acercaDe.BackgroundImage = global::CLauncher.Properties.Resources.info_2_48;
            this.acercaDe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.acercaDe.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.acercaDe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.acercaDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acercaDe.ForeColor = System.Drawing.Color.Transparent;
            this.acercaDe.Location = new System.Drawing.Point(132, 437);
            this.acercaDe.Name = "acercaDe";
            this.acercaDe.Size = new System.Drawing.Size(55, 55);
            this.acercaDe.TabIndex = 7;
            this.acercaDe.UseVisualStyleBackColor = false;
            this.acercaDe.Click += new System.EventHandler(this.acercaDe_Click);
            // 
            // abrirCarpeta
            // 
            this.abrirCarpeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.abrirCarpeta.BackgroundImage = global::CLauncher.Properties.Resources.folder_3_48;
            this.abrirCarpeta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.abrirCarpeta.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.abrirCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.abrirCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abrirCarpeta.ForeColor = System.Drawing.Color.Transparent;
            this.abrirCarpeta.Location = new System.Drawing.Point(72, 437);
            this.abrirCarpeta.Name = "abrirCarpeta";
            this.abrirCarpeta.Size = new System.Drawing.Size(55, 55);
            this.abrirCarpeta.TabIndex = 6;
            this.abrirCarpeta.UseVisualStyleBackColor = false;
            this.abrirCarpeta.Click += new System.EventHandler(this.abrirCarpeta_Click);
            // 
            // editarConfiguracionBtn
            // 
            this.editarConfiguracionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.editarConfiguracionBtn.BackgroundImage = global::CLauncher.Properties.Resources.settings_48;
            this.editarConfiguracionBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editarConfiguracionBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.editarConfiguracionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editarConfiguracionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editarConfiguracionBtn.ForeColor = System.Drawing.Color.Transparent;
            this.editarConfiguracionBtn.Location = new System.Drawing.Point(11, 437);
            this.editarConfiguracionBtn.Name = "editarConfiguracionBtn";
            this.editarConfiguracionBtn.Size = new System.Drawing.Size(55, 55);
            this.editarConfiguracionBtn.TabIndex = 5;
            this.editarConfiguracionBtn.UseVisualStyleBackColor = false;
            this.editarConfiguracionBtn.Click += new System.EventHandler(this.editarConfiguracionBtn_Click);
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.userName.ForeColor = System.Drawing.Color.White;
            this.userName.Location = new System.Drawing.Point(10, 225);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(177, 34);
            this.userName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(5, 195);
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
            this.label1.Location = new System.Drawing.Point(6, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Version";
            // 
            // versionesCbx
            // 
            this.versionesCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.versionesCbx.DropDownWidth = 177;
            this.versionesCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.versionesCbx.ForeColor = System.Drawing.Color.White;
            this.versionesCbx.FormattingEnabled = true;
            this.versionesCbx.IntegralHeight = false;
            this.versionesCbx.ItemHeight = 24;
            this.versionesCbx.Location = new System.Drawing.Point(10, 302);
            this.versionesCbx.Name = "versionesCbx";
            this.versionesCbx.Size = new System.Drawing.Size(177, 32);
            this.versionesCbx.TabIndex = 1;
            this.versionesCbx.SelectedIndexChanged += new System.EventHandler(this.versionesCbx_SelectedIndexChanged);
            this.versionesCbx.SelectedValueChanged += new System.EventHandler(this.versionesCbx_SelectedValueChanged);
            // 
            // descargaBar
            // 
            this.descargaBar.Location = new System.Drawing.Point(10, 561);
            this.descargaBar.Name = "descargaBar";
            this.descargaBar.Size = new System.Drawing.Size(811, 29);
            this.descargaBar.TabIndex = 8;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.White;
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
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
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
            this.label3.Size = new System.Drawing.Size(129, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "CLauncher";
            // 
            // descargando
            // 
            this.descargando.DoWork += new System.ComponentModel.DoWorkEventHandler(this.descargando_DoWork);
            this.descargando.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.descargando_RunWorkerCompleted);
            // 
            // cancelar
            // 
            this.cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(38)))));
            this.cancelar.Enabled = false;
            this.cancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowText;
            this.cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelar.Location = new System.Drawing.Point(827, 561);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(200, 29);
            this.cancelar.TabIndex = 8;
            this.cancelar.Text = "Cancelar Descarga";
            this.cancelar.UseVisualStyleBackColor = false;
            this.cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1039, 598);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.descargaBar);
            this.Controls.Add(this.arrastrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMLauncher";
            this.Deactivate += new System.EventHandler(this.Inicio_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inicio_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Inicio_FormClosed);
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.Shown += new System.EventHandler(this.Inicio_Shown);
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
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel arrastrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button editarConfiguracionBtn;
        private System.Windows.Forms.Button abrirCarpeta;
        private System.Windows.Forms.Button acercaDe;
        private System.Windows.Forms.ProgressBar descargaBar;
        private System.ComponentModel.BackgroundWorker cargaDeJson;
        private System.ComponentModel.BackgroundWorker descargando;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.CheckBox snap;
    }
}

