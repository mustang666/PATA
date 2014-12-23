using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATA.ServiceReferenceWebservPATA;

namespace PATA
{
    public partial class login : Form
    {

        ServiceReferenceWebservPATA.Service1Client servico;
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
                        PATA.Properties.Settings.Default.token = token;
                        PATA.Properties.Settings.Default.Save();
                        Menu fMenu = new Menu();
                        fMenu.Show();
                        this.Hide();


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


    }
}
