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
    public partial class Menu : Form
    {
        private String xlsPath;
        private String xsdPath;
        private Boolean _isValid;
        private String token;
        private bool isNovoAdmin;
        private bool isEditarAdmin;
        private List<PacienteWEB> listaPacientes;
        private List<TerapeutaWEB> listaTerapeutas;
        private List<ContaWEB> listaContas;
        private ContaWEB c;
        private bool isEditAdmin;



        ServicePATA.Service1Client servico;



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

            servico = new ServicePATA.Service1Client();

            listaPacientes = new List<PacienteWEB>();
            listaTerapeutas = new List<TerapeutaWEB>();
            listaContas = new List<ContaWEB>();


            inicializarListViewAdmin();
            preencheAdmins();




            if (PATA.Properties.Settings.Default.firstUsage)
            {
                MessageBox.Show("Bem vindo à Plataforma Auxiliar ao Terapeuta de Acupunctura\nComo é a sua primeira vez aqui, comece por selecionar o caminho do ficheiro Excel a importar e proceda à sua importação! Obrigado.", "P.A.T.A.");
            }

            unblockButtons();




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
                listaDiagnosticosWEB.Add(diagnostico);
            }
            dadosWEB.listaDiagnosticos = listaDiagnosticosWEB.ToArray();



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

        private void btn_criar_utilizador_Click(object sender, EventArgs e)
        {
            criarUtilizador formCriarUtilizador = new criarUtilizador();
            formCriarUtilizador.Show();
        }

        public void limparCampos()
        {
            txt_username_admin.Text = "";
            txt_password_admin.Text = "";
        }


        private void btn_novo_admin_Click(object sender, EventArgs e)
        {
            limparCampos();
            blockButtons();
            isNovoAdmin = true;
            group_admin.Text = "Novo Administrador";
        }

        private void btn_guardar_admin_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txt_username_admin.Text) && !String.IsNullOrEmpty(txt_password_admin.Text))
            {

                if (isNovoAdmin)
                {
                    ContaWEB novaConta = new ContaWEB();
                    novaConta.username = txt_username_admin.Text;
                    novaConta.password = txt_password_admin.Text;
                    novaConta.isAdmin = true;

                    bool resultado = servico.addConta(token, novaConta);

                    if (resultado)
                    {
                        isNovoAdmin = false;
                        btn_novo_admin.Enabled = true;
                        limparFormularioAdmin();
                        preencheAdmins();

                        MessageBox.Show("Conta de Administrador adicionada com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Conta de Administrador adicionada com sucesso!");
                    }

                }
                else if (isEditAdmin)
                {


                    c.username = txt_username_admin.Text;
                    c.password = txt_password_admin.Text;


                    bool resultado = servico.editConta(token, c);

                    if (resultado)
                    {
                        isEditAdmin = false;
                        limparFormularioAdmin();
                        preencheAdmins();

                        MessageBox.Show("Conta de Administrador alterada com sucesso!");
                    }
                    else
                    {
                        limparFormularioAdmin();
                        unblockButtons();
                        MessageBox.Show("Não foi possível alterar a conta de administrador!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Campos por preencher!");
            }

        }

        private void limparFormularioAdmin()
        {
            unblockButtons();
            limparCampos();
        }

        public void blockButtons()
        {
            group_admin.Enabled = true;
            btn_editar_admin.Enabled = false;
            btn_novo_admin.Enabled = false;
            btn_remover_admin.Enabled = false;
            listViewAdmin.Enabled = false;
        }

        public void unblockButtons()
        {
            group_admin.Enabled = false;
            btn_editar_admin.Enabled = true;
            btn_novo_admin.Enabled = true;
            btn_remover_admin.Enabled = true;
            listViewAdmin.Enabled = true;
        }

        private void btn_editar_admin_Click(object sender, EventArgs e)
        {
            if (numItemsListAdmin() > 0)
            {
                if (c != null)
                {
                    blockButtons();
                    isEditAdmin = true;
                    group_admin.Text = "Novo Administrador";

                }
                else
                {
                    MessageBox.Show("Selecione um Administrador da lista!",
         "Aviso",
         MessageBoxButtons.OK,
         MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                MessageBox.Show("Não existem administradores para editar!",
             "Important Note",
             MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);
            }





        }

        public int numItemsListAdmin()
        {
            return listViewAdmin.Items.Count;
        }

        private void btn_cancelar_admin_Click(object sender, EventArgs e)
        {
            limparFormularioAdmin();
        }

        public void preencheAdmins()
        {
            listaContas = servico.getAllContas(token).ToList();
            listViewAdmin.Items.Clear();

            foreach (ContaWEB c in listaContas)
            {
                var itemListView = new ListViewItem(c.id.ToString());
                itemListView.SubItems.Add(c.username.ToString());
                listViewAdmin.Items.Add(itemListView);
            }
        }
        public void preencheTerapeutas()
        {
            listaTerapeutas = servico.getAllTerapeutas(token).ToList();
        }
        public void preenchePacientes()
        {
            listaPacientes = servico.getAllPacientes(token).ToList();

        }

        public void inicializarListViewAdmin()
        {
            listViewAdmin.GridLines = true;
            listViewAdmin.Sorting = SortOrder.Ascending;
            listViewAdmin.View = View.Details;
            listViewAdmin.FullRowSelect = true;
            listViewAdmin.LabelEdit = false;
            listViewAdmin.Columns.Add("ID", 50, HorizontalAlignment.Center);
            listViewAdmin.Columns.Add("Administrador", 252, HorizontalAlignment.Center);
        }

        private void listViewAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAdmin.Items.Count > 0)
            {
                if (listViewAdmin.SelectedItems.Count == 1)
                {
                    int idConta = Convert.ToInt32(listViewAdmin.SelectedItems[0].SubItems[0].Text);
                    ContaWEB aux = devolveConta(idConta);
                    if (aux != null)
                    {
                        c = aux;

                        txt_username_admin.Text = c.username;
                        txt_password_admin.Text = c.password;
                    }
                }
            }
        }

        public ContaWEB devolveConta(int idConta)
        {
            if (listaContas.Count > 0)
            {
                foreach (ContaWEB c in listaContas)
                {
                    if (c.id == idConta)
                    {
                        return c;
                    }
                }
            }
            return null;

        }

        private void btn_procurarExcel_Click_1(object sender, EventArgs e)
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

        private void btn_excelRead_Click_1(object sender, EventArgs e)
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

                MessageBox.Show("Resultado" + a.ToString());

                PATA.Properties.Settings.Default.firstUsage = false;
                PATA.Properties.Settings.Default.Save();
            }
        }

        private void btn_remover_admin_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                listaContas.Remove(c);
                string msg = servico.removeConta(token, c.id);
                limparCampos();
                preencheAdmins();

                MessageBox.Show(msg, "Remover Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }






    }
}
