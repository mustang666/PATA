using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATA.ServicePATA;
using System.Globalization;



namespace PATA
{
    public partial class criarUtilizador : Form
    {

        Service1Client servico;
        ContaWEB c;
        String token;
        public criarUtilizador()
        {
            InitializeComponent();
            servico = new Service1Client();
            group_terapeuta.Hide();
            ck_isadmin.CheckState=CheckState.Checked;
            c = new ContaWEB();
            token = PATA.Properties.Settings.Default.token;

        }

        private void btn_guardar_uilizador_Click(object sender, EventArgs e)
        {
            string username = "";
            string password = "";
            bool isAdmin = false;
            string nomeTerapeuta = "";
            string ccTerapeuta = "";
            string telefoneTerapeuta = "";
            DateTime dataNascTerapeuta;

            int idConta = 0;


            if (!String.IsNullOrEmpty(txt_username_novo.Text) && !String.IsNullOrEmpty(txt_password_novo.Text))
            {
                username = txt_username_novo.Text;
                password = txt_password_novo.Text;

                c.username = username;
                c.password = password;

                if (ck_isadmin.Checked)
                {
                    isAdmin = true;

                    c.isAdmin = isAdmin;
                    
                     bool resultado = servico.addConta(token, c);

                     if(resultado){
                        MessageBox.Show("Conta de Administrador adicionada com sucesso!");
                    }
                     else
                         MessageBox.Show("Conta de Administrador adicionada com sucesso!");

                }
                else
                {
                    isAdmin = false;
                    c.isAdmin = isAdmin;
                    bool  resultado = servico.addConta(token, c);



                    if (!String.IsNullOrEmpty(txt_cc_utilizador.Text) && !String.IsNullOrEmpty(txt_nome_utilizador.Text) && !String.IsNullOrEmpty(txt_telefoneTerapeuta.Text) && dt_data_nasc_utilizador.Value > DateTime.Today ? false : true)
                    {
                        nomeTerapeuta = txt_nome_utilizador.Text;
                        ccTerapeuta = txt_cc_utilizador.Text;
                        telefoneTerapeuta = txt_telefoneTerapeuta.Text;
                        dataNascTerapeuta = dt_data_nasc_utilizador.Value;

                        string s = dt_data_nasc_utilizador.Value.Date.Day + "/" + dt_data_nasc_utilizador.Value.Month + "/" + dt_data_nasc_utilizador.Value.Year;


                        TerapeutaWEB t = new TerapeutaWEB();
                        t.contaID = idConta;
                        t.nome = nomeTerapeuta;
                        t.cc = ccTerapeuta;
                        t.dataNasc = s;
                        t.telefone = telefoneTerapeuta;
                        string res = servico.addTerapeuta(token, t);
                        if (res.ToLower().Equals("ok"))
                            MessageBox.Show("NICE");
                        //if (resultado && idConta > -1)
                        //{
                        //    MessageBox.Show("Terapeuta adicionado com sucesso!");
                        //}
                        //else {
                        //    MessageBox.Show("Não foi possivel adicionar o terapeuta!");
                        //}

                    }
                    else
                    {
                        MessageBox.Show("Alguns dos campos de dados por preencher!");
                    }

                }
            }
            else
            {
                MessageBox.Show("Campos por preencher!");//melhorar
            }
        }

        private void ck_isadmin_CheckedChanged(object sender, EventArgs e)
        {
            if (!ck_isadmin.Checked)
            {
                group_terapeuta.Show();
            }
            else
            {
                group_terapeuta.Hide();
            }
        }


    }
}
