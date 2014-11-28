namespace PATA
{
    partial class ListaDiagnosticos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaDiagnosticos));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btn_Procurar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orgao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tratamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_removerSintoma = new System.Windows.Forms.Button();
            this.btn_AdicionarSintoma = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(52, 131);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(434, 554);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(1166, 86);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(434, 604);
            this.listBox2.TabIndex = 1;
            this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // btn_Procurar
            // 
            this.btn_Procurar.Location = new System.Drawing.Point(650, 581);
            this.btn_Procurar.Name = "btn_Procurar";
            this.btn_Procurar.Size = new System.Drawing.Size(410, 55);
            this.btn_Procurar.TabIndex = 4;
            this.btn_Procurar.Text = "Gerar Lista Diagnósticos";
            this.btn_Procurar.UseVisualStyleBackColor = true;
            this.btn_Procurar.Click += new System.EventHandler(this.btn_Procurar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lista de Sintomas:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1166, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sintomas Detetados:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(434, 31);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Insira aqui o sintoma ...";
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordem,
            this.orgao,
            this.diagnostico,
            this.tratamento,
            this.percentagem});
            this.dataGridView1.Location = new System.Drawing.Point(52, 706);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1548, 445);
            this.dataGridView1.TabIndex = 10;
            // 
            // ordem
            // 
            this.ordem.HeaderText = "Ordem";
            this.ordem.Name = "ordem";
            this.ordem.ReadOnly = true;
            this.ordem.Width = 40;
            // 
            // orgao
            // 
            this.orgao.HeaderText = "Orgão";
            this.orgao.Name = "orgao";
            this.orgao.ReadOnly = true;
            this.orgao.Width = 110;
            // 
            // diagnostico
            // 
            this.diagnostico.HeaderText = "Diagnóstico";
            this.diagnostico.Name = "diagnostico";
            this.diagnostico.ReadOnly = true;
            this.diagnostico.Width = 200;
            // 
            // tratamento
            // 
            this.tratamento.HeaderText = "Tratamento";
            this.tratamento.Name = "tratamento";
            this.tratamento.ReadOnly = true;
            this.tratamento.Width = 300;
            // 
            // percentagem
            // 
            this.percentagem.HeaderText = "Percentagem";
            this.percentagem.Name = "percentagem";
            this.percentagem.ReadOnly = true;
            this.percentagem.Width = 80;
            // 
            // btn_removerSintoma
            // 
            this.btn_removerSintoma.BackgroundImage = global::PATA.Properties.Resources.back_icon;
            this.btn_removerSintoma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_removerSintoma.Location = new System.Drawing.Point(780, 256);
            this.btn_removerSintoma.Name = "btn_removerSintoma";
            this.btn_removerSintoma.Size = new System.Drawing.Size(129, 130);
            this.btn_removerSintoma.TabIndex = 3;
            this.btn_removerSintoma.UseVisualStyleBackColor = true;
            this.btn_removerSintoma.Click += new System.EventHandler(this.btn_removerSintoma_Click);
            // 
            // btn_AdicionarSintoma
            // 
            this.btn_AdicionarSintoma.BackgroundImage = global::PATA.Properties.Resources.forward_icon;
            this.btn_AdicionarSintoma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AdicionarSintoma.Location = new System.Drawing.Point(780, 95);
            this.btn_AdicionarSintoma.Name = "btn_AdicionarSintoma";
            this.btn_AdicionarSintoma.Size = new System.Drawing.Size(129, 130);
            this.btn_AdicionarSintoma.TabIndex = 2;
            this.btn_AdicionarSintoma.UseVisualStyleBackColor = true;
            this.btn_AdicionarSintoma.Click += new System.EventHandler(this.btn_AdicionarSintoma_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 67);
            this.button1.TabIndex = 11;
            this.button1.Text = "Abrir XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListaDiagnosticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 1045);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Procurar);
            this.Controls.Add(this.btn_removerSintoma);
            this.Controls.Add(this.btn_AdicionarSintoma);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListaDiagnosticos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListaDiagnosticos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btn_AdicionarSintoma;
        private System.Windows.Forms.Button btn_removerSintoma;
        private System.Windows.Forms.Button btn_Procurar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordem;
        private System.Windows.Forms.DataGridViewTextBoxColumn orgao;
        private System.Windows.Forms.DataGridViewTextBoxColumn diagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn tratamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentagem;
        private System.Windows.Forms.Button button1;
    }
}