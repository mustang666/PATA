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
    public partial class Menu : Form
    {
        private String xlsPath;
        private String xsdPath;
        private Boolean _isValid;
        private String token;
        ServiceReferenceWebservPATA.Service1Client servico;

        //public static Dados _dados;
        public Menu()
        {
            InitializeComponent();
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


            token = PATA.Properties.Settings.Default.token.ToString();

            servico = new ServiceReferenceWebservPATA.Service1Client();

            if (PATA.Properties.Settings.Default.firstUsage)
            {
                MessageBox.Show("Bem vindo à Plataforma Auxiliar ao Terapeuta de Acupunctura\nComo é a sua primeira vez aqui, comece por selecionar o caminho do ficheiro Excel a importar e proceda à sua importação! Obrigado.", "P.A.T.A.");
            }

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "João Nicolau & Nelson \n Are you sure you want to close?", "Obrigado!! Quantified Self", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }



        private void btn_procurarExcel_Click(object sender, EventArgs e)
        {


            if (DialogResult.OK == MessageBox.Show("Vamos escolher o ficheiro *.xls a migrar:"))
            {
                OpenFileDialog FD = new OpenFileDialog();
                FD.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                FD.Title = "Onde está o ficheiro de Excel?";

                FD.Filter = "Xls files (*.xls)|*.xls";

                if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileToOpen = FD.FileName;

                    xlsPath = FD.FileName;
                    txt_excelPath.Text = xlsPath;
                    txt_excelPath.ReadOnly = true;

                }

            }
            else
            {
                //do stuff if No
            }
        }

        private void btn_validarDados_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Vamos escolher o ficheiro *.xsd para validar:"))
            {
                OpenFileDialog FD = new OpenFileDialog();
                FD.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                FD.Title = "Onde está o ficheiro XSD?";
                FD.Filter = "Xsd files (*.xsd)|*.xsd";

                if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileToOpen = FD.FileName;

                    xsdPath = FD.FileName;

                }
            }

            try
            {
                String xmlPath = AppDomain.CurrentDomain.BaseDirectory + "acupuntura.xml";
                // _isValid = XmlHandler.XmlOperations.verificaXSD(xsdPath,xmlPath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine);
            }
            finally
            {
                MessageBox.Show(_isValid ? "O documento é válido!" : "O documento é inválido...");
            }

        }

        private void btn_gerarListaResultados_Click(object sender, EventArgs e)
        {
            ListaDiagnosticos l = new ListaDiagnosticos();
            l.ShowDialog();

        }

        private void btn_excelRead_Click(object sender, EventArgs e)
        {


            String path = txt_excelPath.Text;

            if (txt_excelPath.Text == "")
            {
                MessageBox.Show("Deve selecionar um caminho para o ficheiro *.xls a importar");
            }
            else
            {

                Dados d = ExcelHandler.readFromExcelFile(path);
                DadosWEB dados = dadosToWEB(d);
                bool a = servico.carregaXml(token, dados);

                MessageBox.Show("rESULTADO" + a.ToString());

                PATA.Properties.Settings.Default.firstUsage = false;
                PATA.Properties.Settings.Default.Save();
            }
        }

        private static DadosWEB dadosToWEB(Dados dados)
        {
            DadosWEB dadosWEB = new DadosWEB();

            List<DiagnosticoWEB> listaDiagnosticosWEB = new List<DiagnosticoWEB>();
            List<SintomaWEB> listaSintomasWEB = new List<SintomaWEB>();

            foreach (Sintoma s in dados._listSintomas)
            {
                SintomaWEB sintoma = new SintomaWEB();
                sintoma.nome = s.Nome;
                listaSintomasWEB.Add(sintoma);
            }
            dadosWEB.listaSintomas = listaSintomasWEB.ToArray();


            foreach (Diagnostico d in dados.ListDiagnosticos)
            {
                DiagnosticoWEB diagnostico = new DiagnosticoWEB();
                diagnostico.nome = d.Nome;
                diagnostico.orgao = d.Orgao;
                diagnostico.tratamento = d.Tratamento;
                List<SintomaWEB> listSintomasWEB = new List<SintomaWEB>();
                foreach (Sintoma sin in d.ListSintomas)
                {
                    SintomaWEB sintomaWebLista = new SintomaWEB();
                    sintomaWebLista.nome = sin.Nome;
                    listSintomasWEB.Add(sintomaWebLista);
                }
                diagnostico.listaSintomas = listSintomasWEB.ToArray();
            }



            return dadosWEB;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //VER ISTO!!!
            //_dados.saveXML();
        }

        private void richTextBox_teste_TextChanged(object sender, EventArgs e)
        {
            //
        }
    }
}
