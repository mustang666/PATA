namespace PATA
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btn_procurarExcel = new System.Windows.Forms.Button();
            this.btn_validarDados = new System.Windows.Forms.Button();
            this.btn_gerarListaResultados = new System.Windows.Forms.Button();
            this.txt_excelPath = new System.Windows.Forms.TextBox();
            this.btn_excelRead = new System.Windows.Forms.Button();
            this.btn_criar_utilizador = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_procurarExcel
            // 
            this.btn_procurarExcel.Location = new System.Drawing.Point(425, 35);
            this.btn_procurarExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_procurarExcel.Name = "btn_procurarExcel";
            this.btn_procurarExcel.Size = new System.Drawing.Size(211, 56);
            this.btn_procurarExcel.TabIndex = 6;
            this.btn_procurarExcel.Text = "Procurar Excel";
            this.btn_procurarExcel.UseVisualStyleBackColor = true;
            this.btn_procurarExcel.Click += new System.EventHandler(this.btn_procurarExcel_Click);
            // 
            // btn_validarDados
            // 
            this.btn_validarDados.Location = new System.Drawing.Point(425, 292);
            this.btn_validarDados.Margin = new System.Windows.Forms.Padding(2);
            this.btn_validarDados.Name = "btn_validarDados";
            this.btn_validarDados.Size = new System.Drawing.Size(211, 56);
            this.btn_validarDados.TabIndex = 7;
            this.btn_validarDados.Text = "Validar Dados";
            this.btn_validarDados.UseVisualStyleBackColor = true;
            this.btn_validarDados.Click += new System.EventHandler(this.btn_validarDados_Click);
            // 
            // btn_gerarListaResultados
            // 
            this.btn_gerarListaResultados.Location = new System.Drawing.Point(425, 429);
            this.btn_gerarListaResultados.Margin = new System.Windows.Forms.Padding(2);
            this.btn_gerarListaResultados.Name = "btn_gerarListaResultados";
            this.btn_gerarListaResultados.Size = new System.Drawing.Size(211, 56);
            this.btn_gerarListaResultados.TabIndex = 8;
            this.btn_gerarListaResultados.Text = "Gerar Lista Resultados";
            this.btn_gerarListaResultados.UseVisualStyleBackColor = true;
            this.btn_gerarListaResultados.Click += new System.EventHandler(this.btn_gerarListaResultados_Click);
            // 
            // txt_excelPath
            // 
            this.txt_excelPath.Location = new System.Drawing.Point(109, 108);
            this.txt_excelPath.Margin = new System.Windows.Forms.Padding(2);
            this.txt_excelPath.Name = "txt_excelPath";
            this.txt_excelPath.Size = new System.Drawing.Size(858, 22);
            this.txt_excelPath.TabIndex = 10;
            // 
            // btn_excelRead
            // 
            this.btn_excelRead.Location = new System.Drawing.Point(425, 147);
            this.btn_excelRead.Margin = new System.Windows.Forms.Padding(2);
            this.btn_excelRead.Name = "btn_excelRead";
            this.btn_excelRead.Size = new System.Drawing.Size(211, 56);
            this.btn_excelRead.TabIndex = 11;
            this.btn_excelRead.Text = "ReadExcel";
            this.btn_excelRead.UseVisualStyleBackColor = true;
            this.btn_excelRead.Click += new System.EventHandler(this.btn_excelRead_Click);
            // 
            // btn_criar_utilizador
            // 
            this.btn_criar_utilizador.Location = new System.Drawing.Point(79, 240);
            this.btn_criar_utilizador.Name = "btn_criar_utilizador";
            this.btn_criar_utilizador.Size = new System.Drawing.Size(170, 59);
            this.btn_criar_utilizador.TabIndex = 12;
            this.btn_criar_utilizador.Text = "Criar Utilizador";
            this.btn_criar_utilizador.UseVisualStyleBackColor = true;
            this.btn_criar_utilizador.Click += new System.EventHandler(this.btn_criar_utilizador_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 533);
            this.Controls.Add(this.btn_criar_utilizador);
            this.Controls.Add(this.btn_excelRead);
            this.Controls.Add(this.txt_excelPath);
            this.Controls.Add(this.btn_gerarListaResultados);
            this.Controls.Add(this.btn_validarDados);
            this.Controls.Add(this.btn_procurarExcel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Menu";
            this.Text = "PATA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_procurarExcel;
        private System.Windows.Forms.Button btn_validarDados;
        private System.Windows.Forms.Button btn_gerarListaResultados;
        private System.Windows.Forms.TextBox txt_excelPath;
        private System.Windows.Forms.Button btn_excelRead;
        private System.Windows.Forms.Button btn_criar_utilizador;
    }
}

