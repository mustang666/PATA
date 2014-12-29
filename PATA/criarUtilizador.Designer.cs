namespace PATA
{
    partial class criarUtilizador
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
            this.btn_guardar_uilizador = new System.Windows.Forms.Button();
            this.ck_isadmin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_username_novo = new System.Windows.Forms.TextBox();
            this.txt_password_novo = new System.Windows.Forms.TextBox();
            this.txt_nome_utilizador = new System.Windows.Forms.TextBox();
            this.txt_cc_utilizador = new System.Windows.Forms.TextBox();
            this.dt_data_nasc_utilizador = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.group_terapeuta = new System.Windows.Forms.GroupBox();
            this.group_utilizador = new System.Windows.Forms.GroupBox();
            this.txt_telefoneTerapeuta = new System.Windows.Forms.TextBox();
            this.group_terapeuta.SuspendLayout();
            this.group_utilizador.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_guardar_uilizador
            // 
            this.btn_guardar_uilizador.Location = new System.Drawing.Point(560, 237);
            this.btn_guardar_uilizador.Name = "btn_guardar_uilizador";
            this.btn_guardar_uilizador.Size = new System.Drawing.Size(111, 31);
            this.btn_guardar_uilizador.TabIndex = 0;
            this.btn_guardar_uilizador.Text = "Guardar";
            this.btn_guardar_uilizador.UseVisualStyleBackColor = true;
            this.btn_guardar_uilizador.Click += new System.EventHandler(this.btn_guardar_uilizador_Click);
            // 
            // ck_isadmin
            // 
            this.ck_isadmin.AutoSize = true;
            this.ck_isadmin.Location = new System.Drawing.Point(21, 132);
            this.ck_isadmin.Name = "ck_isadmin";
            this.ck_isadmin.Size = new System.Drawing.Size(125, 21);
            this.ck_isadmin.TabIndex = 1;
            this.ck_isadmin.Text = "Administrador?";
            this.ck_isadmin.UseVisualStyleBackColor = true;
            this.ck_isadmin.CheckedChanged += new System.EventHandler(this.ck_isadmin_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // txt_username_novo
            // 
            this.txt_username_novo.Location = new System.Drawing.Point(97, 34);
            this.txt_username_novo.Name = "txt_username_novo";
            this.txt_username_novo.Size = new System.Drawing.Size(143, 22);
            this.txt_username_novo.TabIndex = 4;
            // 
            // txt_password_novo
            // 
            this.txt_password_novo.Location = new System.Drawing.Point(97, 81);
            this.txt_password_novo.Name = "txt_password_novo";
            this.txt_password_novo.Size = new System.Drawing.Size(143, 22);
            this.txt_password_novo.TabIndex = 5;
            // 
            // txt_nome_utilizador
            // 
            this.txt_nome_utilizador.Location = new System.Drawing.Point(88, 36);
            this.txt_nome_utilizador.Name = "txt_nome_utilizador";
            this.txt_nome_utilizador.Size = new System.Drawing.Size(269, 22);
            this.txt_nome_utilizador.TabIndex = 0;
            // 
            // txt_cc_utilizador
            // 
            this.txt_cc_utilizador.Location = new System.Drawing.Point(88, 77);
            this.txt_cc_utilizador.Name = "txt_cc_utilizador";
            this.txt_cc_utilizador.Size = new System.Drawing.Size(269, 22);
            this.txt_cc_utilizador.TabIndex = 1;
            // 
            // dt_data_nasc_utilizador
            // 
            this.dt_data_nasc_utilizador.Location = new System.Drawing.Point(157, 184);
            this.dt_data_nasc_utilizador.Name = "dt_data_nasc_utilizador";
            this.dt_data_nasc_utilizador.Size = new System.Drawing.Size(200, 22);
            this.dt_data_nasc_utilizador.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "CC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Telefone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Data de Nascimento";
            // 
            // group_terapeuta
            // 
            this.group_terapeuta.Controls.Add(this.txt_telefoneTerapeuta);
            this.group_terapeuta.Controls.Add(this.label6);
            this.group_terapeuta.Controls.Add(this.txt_nome_utilizador);
            this.group_terapeuta.Controls.Add(this.label5);
            this.group_terapeuta.Controls.Add(this.txt_cc_utilizador);
            this.group_terapeuta.Controls.Add(this.label4);
            this.group_terapeuta.Controls.Add(this.label3);
            this.group_terapeuta.Controls.Add(this.dt_data_nasc_utilizador);
            this.group_terapeuta.Location = new System.Drawing.Point(68, 264);
            this.group_terapeuta.Name = "group_terapeuta";
            this.group_terapeuta.Size = new System.Drawing.Size(452, 273);
            this.group_terapeuta.TabIndex = 7;
            this.group_terapeuta.TabStop = false;
            this.group_terapeuta.Text = "Terapeuta";
            // 
            // group_utilizador
            // 
            this.group_utilizador.Controls.Add(this.label1);
            this.group_utilizador.Controls.Add(this.txt_password_novo);
            this.group_utilizador.Controls.Add(this.ck_isadmin);
            this.group_utilizador.Controls.Add(this.txt_username_novo);
            this.group_utilizador.Controls.Add(this.label2);
            this.group_utilizador.Location = new System.Drawing.Point(68, 12);
            this.group_utilizador.Name = "group_utilizador";
            this.group_utilizador.Size = new System.Drawing.Size(452, 230);
            this.group_utilizador.TabIndex = 8;
            this.group_utilizador.TabStop = false;
            this.group_utilizador.Text = "Utilizador";
            // 
            // txt_telefoneTerapeuta
            // 
            this.txt_telefoneTerapeuta.Location = new System.Drawing.Point(88, 128);
            this.txt_telefoneTerapeuta.Name = "txt_telefoneTerapeuta";
            this.txt_telefoneTerapeuta.Size = new System.Drawing.Size(269, 22);
            this.txt_telefoneTerapeuta.TabIndex = 9;
            // 
            // criarUtilizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 564);
            this.Controls.Add(this.group_utilizador);
            this.Controls.Add(this.btn_guardar_uilizador);
            this.Controls.Add(this.group_terapeuta);
            this.Name = "criarUtilizador";
            this.Text = "Novo Utilizador";
            this.group_terapeuta.ResumeLayout(false);
            this.group_terapeuta.PerformLayout();
            this.group_utilizador.ResumeLayout(false);
            this.group_utilizador.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_guardar_uilizador;
        private System.Windows.Forms.CheckBox ck_isadmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_username_novo;
        private System.Windows.Forms.TextBox txt_password_novo;
        private System.Windows.Forms.TextBox txt_nome_utilizador;
        private System.Windows.Forms.TextBox txt_cc_utilizador;
        private System.Windows.Forms.DateTimePicker dt_data_nasc_utilizador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox group_terapeuta;
        private System.Windows.Forms.GroupBox group_utilizador;
        private System.Windows.Forms.TextBox txt_telefoneTerapeuta;
    }
}