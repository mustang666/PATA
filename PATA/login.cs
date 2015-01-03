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

namespace PATA
{
    public partial class login : Form
    {

        ServicePATA.Service1Client servico;
        public login()
        {
            InitializeComponent();
            servico = new Service1Client();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            if (isValidCredentials())
            {
                try
                {
                    String token = servico.logIn(txt_username.Text, txt_password.Text);
                    
                    if (token != "")
                    {
                        bool res = servico.isAdmin(token);

                        if (res)
                        {
                            PATA.Properties.Settings.Default.token = token;
                            PATA.Properties.Settings.Default.Save();
                            Menu fMenu = new Menu(this);

                            fMenu.Show();
                            txt_password.Text = "";
                            txt_username.Text = "";
                            this.Hide();
                        }
                        else {
                            DialogResult result1 = MessageBox.Show("Aplicação só disponível para administradores!",
           "Aviso",
           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                       
                       

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Ocorreu um erro ao efetuar o login");
                }

              

            }

        }


        public bool isValidCredentials()
        {
            string message = "";
            if (txt_username.Text == "")
            {
                message += "Introduza o username;\n";
            }
            if (txt_password.Text == "")
            {
                message += "Introduza a password;\n";
            }

            if (message == "")
            {
                return true;
            }
            MessageBox.Show(message);
            return false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this,"Tem a certeza que pretende sair?\nObrigado, João Nicolau & Nelson", "Sair", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }


    }
}
