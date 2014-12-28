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
    public partial class ListaDiagnosticos : Form
    {
        String xmlPath = "";
        ServicePATA.Service1Client servico;
        /*
         * 
         * 
         * A FAZER:
         * -Campo de pesquisa que diminui valores da lista
         * -Pesquisar e apresentar
         * 
         */

        public ListaDiagnosticos()
        {
            InitializeComponent();
            servico = new ServicePATA.Service1Client();

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
            // Set the Size of the form to Auto Size
            this.AutoSize = true;
            dataGridView1.AllowUserToAddRows = false;


            foreach (SintomaWEB s in servico.lerSintomasXML(PATA.Properties.Settings.Default.token).ToList())
            {
                listBox1.Items.Add(s.nome.ToString());
            }

            
            if (PATA.Properties.Settings.Default.xmlPath.Equals("-1"))
            {
                OpenFileDialog FD = new OpenFileDialog();
                FD.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                FD.Title = "Onde está o ficheiro XML?";

                FD.Filter = "XML files (*.xml)|*.xml";

                if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileToOpen = FD.FileName;
                    PATA.Properties.Settings.Default.xmlPath = FD.FileName;
                    PATA.Properties.Settings.Default.Save();
                    xmlPath = PATA.Properties.Settings.Default.xmlPath;
                }


                //foreach (String s in XmlHandler.XmlOperations.listaSintomas(xmlPath))
                //{
                //    listBox1.Items.Add(s.ToString());
                //}

            }
            else
            {
                if (PATA.Properties.Settings.Default.xmlPath == "-1")
                {
                    OpenFileDialog FD = new OpenFileDialog();
                    FD.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    FD.Title = "Onde está o ficheiro XML?";

                    FD.Filter = "XML files (*.xml)|*.xml";

                    if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string fileToOpen = FD.FileName;
                        PATA.Properties.Settings.Default.xmlPath = FD.FileName;

                        PATA.Properties.Settings.Default.Save();
                        xmlPath = PATA.Properties.Settings.Default.xmlPath;
                    }
                }

                xmlPath = PATA.Properties.Settings.Default.xmlPath;


                //foreach (String s in )
                //{
                //  listBox1.Items.Add(s.ToString());
                // }
            }






        }

        //public ListaDiagnosticos( _dados)
        //{
        //    InitializeComponent();
        //    this._dados = _dados;
        //    foreach (Sintoma s in _dados._listSintomas)
        //    {
        //        listBox1.Items.Add(s.Nome.ToString());
        //    }
        //}


        private void btn_removerSintoma_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
                listBox1.Sorted = true;
                listBox2.Sorted = true;
            }



        }

        private void btn_AdicionarSintoma_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                if (listBox2.Items.Count < 11)
                {
                    listBox2.Items.Add(listBox1.SelectedItem);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    listBox1.Sorted = true;
                    listBox2.Sorted = true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                if (listBox2.Items.Count < 11)
                {
                    listBox2.Items.Add(listBox1.SelectedItem);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    listBox1.Sorted = true;
                    listBox2.Sorted = true;
                }
            }
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
                listBox1.Sorted = true;
                listBox2.Sorted = true;
            }
        }

        private void btn_Procurar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            List<String> lista = new List<String>();
            foreach (String s in listBox2.Items)
            {
                lista.Add(s);
            }
            //List<String> listaFinal = XmlHandler.XmlOperations.procuraSintomas(lista, xmlPath);

            String[] linhas;
            int i = 1;
            //foreach (String l in listaFinal)
            //{

            //    linhas = l.Split('|');
            //    dataGridView1.Rows.Add(i + "º", linhas[1], linhas[2], linhas[3], linhas[0] + "%");
            //    i++;
            //}
            //SPLIT para adicionar a GRID
            /*   dataGridView1.Rows.Add("1º", "Coração", "Vazio de Yang","5mc;7c;18v;3f;6f;4vc;20vg;36e", "100%");
            dataGridView1.Rows.Add("2º", "Braço", "Vazio de Yang", "5mc;7c;18v;3f;6f;4vc;20vg;36e", "100%");
            dataGridView1.Rows.Add("3º", "Perna", "Vazio de Yang", "5mc;7c;18v;3f;6f;4vc;20vg;36e", "100%");*/

        }



        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            String sintoma = "";
            int position = -1;
            if (textBox1.Text != "")
            {
                sintoma = textBox1.Text;

                position = listBox1.FindString(sintoma);
                if (position != -1)
                {

                    listBox1.TopIndex = position;
                }
            }
            else
            {
                listBox1.TopIndex = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            FD.Title = "Onde está o ficheiro XML?";

            FD.Filter = "XML files (*.xml)|*.xml";

            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                PATA.Properties.Settings.Default.xmlPath = FD.FileName;

                PATA.Properties.Settings.Default.Save();
                xmlPath = PATA.Properties.Settings.Default.xmlPath;
            }

            ListaDiagnosticos l = new ListaDiagnosticos();
            l.ShowDialog();
            this.Close();
        }









    }
}
