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
        private login login;
        private bool isLogout;



        ServicePATA.Service1Client servico;
        private bool isNovoTerapeuta;
        private bool isEditarTerapeuta;




        //public static Dados _dados;
        public Menu(login login)
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

            this.login = login;



            token = PATA.Properties.Settings.Default.token.ToString();

            servico = new ServicePATA.Service1Client();

            listaPacientes = new List<PacienteWEB>();
            listaTerapeutas = new List<TerapeutaWEB>();
            listaContas = new List<ContaWEB>();


            inicializarListViewAdmin();
            preencheAdmins();
            inicializarListViewTerapeuta();
            preencheTerapeutas();
            inicializarListViewPaciente();
            preenchePacientes();
            inicializarListViewAssociarTerapeuta();
            preencheAssociarTerapeutas();


            if (PATA.Properties.Settings.Default.firstUsage)
            {
                MessageBox.Show("Bem vindo à Plataforma Auxiliar ao Terapeuta de Acupunctura\nComo é a sua primeira vez aqui, comece por selecionar o caminho do ficheiro Excel a importar e proceda à sua importação! Obrigado.", "P.A.T.A.");
            }

            unblockButtonsAdmin();
            unblockButtonsTerapeuta();

        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!isLogout)
            {
                base.OnFormClosing(e);

                if (e.CloseReason == CloseReason.WindowsShutDown) return;

                // Confirm user wants to close
                switch (MessageBox.Show(this, "Tem a certeza que pretende sair?\n A sua sessão será terminada.\nObrigado, João Nicolau & Nelson", "Sair", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        servico.logOut(token);
                        isLogout = true;
                        login.Show();
                        this.Close();
                        PATA.Properties.Settings.Default.token = "";
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Pretende terminar a sua sessão?",
       "Aviso",
       MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result1 == DialogResult.OK)
            {
                servico.logOut(token);
                PATA.Properties.Settings.Default.token = "";
                login.Show();
                isLogout = true;
                this.Close();

            }


        }
        //--------------------HANDLERS EXCEL------------------------------------------------------------
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


        //////////////////////////////////////////ADMINISTRADORES////////////////////////////////////////////////

        private void btn_novo_admin_Click(object sender, EventArgs e)
        {
            limparCamposAdmin();
            blockButtonsAdmin();
            isNovoAdmin = true;
            group_admin.Text = "Novo Administrador";
        }

        private void btn_editar_admin_Click(object sender, EventArgs e)
        {
            if (numItemsListAdmin() > 0)
            {
                if (c != null)
                {
                    blockButtonsAdmin();
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
             MessageBoxIcon.Exclamation);
            }

        }

        private void btn_remover_admin_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                listaContas.Remove(c);
                string msg = servico.removeConta(token, c.id);
                limparCamposAdmin();
                preencheAdmins();

                MessageBox.Show(msg, "Remover Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
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
                        MessageBox.Show("Não foi possível adicionar a conta de administrador!");
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
                        unblockButtonsAdmin();
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
            unblockButtonsAdmin();
            limparCamposAdmin();
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


        public void blockButtonsAdmin()
        {
            group_admin.Enabled = true;
            btn_editar_admin.Enabled = false;
            btn_novo_admin.Enabled = false;
            btn_remover_admin.Enabled = false;
            listViewAdmin.Enabled = false;
        }

        public void unblockButtonsAdmin()
        {
            group_admin.Enabled = false;
            btn_editar_admin.Enabled = true;
            btn_novo_admin.Enabled = true;
            btn_remover_admin.Enabled = true;
            listViewAdmin.Enabled = true;
        }



        public void limparCamposAdmin()
        {
            txt_username_admin.Text = "";
            txt_password_admin.Text = "";
        }


        //////////////////////////////////////////TERAPEUTA////////////////////////////////////////////////



        private void btn_novo_terapeuta_Click(object sender, EventArgs e)
        {
            isNovoTerapeuta = true;
            blockButtonsTerapeuta();



        }

        private void btn_editar_terapeuta_Click(object sender, EventArgs e)
        {
            isEditarTerapeuta = true;
            blockButtonsAdmin();
        }

        private void btn_remover_terapeuta_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardar_terapeuta_Click(object sender, EventArgs e)
        {
            if (isNovoTerapeuta)
            {
                if (validarDadosTerapeuta())
                {

                    ContaWEB conta = new ContaWEB();
                    conta.username = txt_username_terapeuta.Text;
                    conta.password = txt_password_terapeuta.Text;
                    conta.isAdmin = false;

                    TerapeutaWEB t = new TerapeutaWEB();
                    t.nome = txt_nome_terapeuta.Text;
                    t.cc = txt_cc_terapeuta.Text;
                    t.dataNasc = dt_dataNasc_terapeuta.Value.ToString("dd/MM/yyyy");
                    t.telefone = txt_telefone_terapeuta.Text;
                    

                    bool res = servico.addTerapeuta(token, t, conta);

                    if (res)
                    {
                        MessageBox.Show("Terapeuta adicionado com sucesso!");
                        isNovoTerapeuta = false;
                        unblockButtonsTerapeuta();
                        limparCamposTerapeuta();
                        preencheTerapeutas();
                    }
                    else
                    {

                        MessageBox.Show("Não foi possível adicionar o terapeuta!");
                    }
                }
            }
            else if (isEditarTerapeuta)
            {

            }
        }


        private void listViewTerapeuta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public bool validarDadosTerapeuta()
        {

            if (txt_username_terapeuta.Text != "" && txt_password_terapeuta.Text != "" && txt_nome_terapeuta.Text != "" && txt_cc_terapeuta.Text != "" && txt_telefone_terapeuta.Text != "")
            {
                if (dt_dataNasc_terapeuta.Value <= DateTime.Today)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("A data de nascimento não pode ser maior do que o presente dia!",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos, pf!",
             "Aviso",
             MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation);
                return false;
            }


            return false;
        }

        public void limparCamposTerapeuta()
        {
            txt_username_terapeuta.Text = "";
            txt_password_terapeuta.Text = "";
            txt_nome_terapeuta.Text = "";
            txt_cc_terapeuta.Text = "";
            txt_telefone_terapeuta.Text = "";
            dt_dataNasc_terapeuta.Value = DateTime.Today;

        }

        public void blockButtonsTerapeuta()
        {
            group_terapeuta.Enabled = true;
            btn_novo_terapeuta.Enabled = false;
            btn_editar_terapeuta.Enabled = false;
            btn_remover_terapeuta.Enabled = false;
            listViewTerapeuta.Enabled = false;

        }

        public void unblockButtonsTerapeuta()
        {
            group_terapeuta.Enabled = false; ;
            btn_novo_terapeuta.Enabled = true;
            btn_editar_terapeuta.Enabled = true;
            btn_remover_terapeuta.Enabled = true;
            listViewTerapeuta.Enabled = true;

        }

        public void preencheTerapeutas()
        {
            listaTerapeutas = servico.getAllTerapeutas(token).ToList();
            listViewTerapeuta.Items.Clear();
            foreach (TerapeutaWEB t in listaTerapeutas)
            {
                var itemListView = new ListViewItem(t.id.ToString());
                itemListView.SubItems.Add(t.nome.ToString());
                listViewTerapeuta.Items.Add(itemListView);
            }

        }

        public void inicializarListViewTerapeuta()
        {
            listViewTerapeuta.GridLines = true;
            listViewTerapeuta.Sorting = SortOrder.Ascending;
            listViewTerapeuta.View = View.Details;
            listViewTerapeuta.FullRowSelect = true;
            listViewTerapeuta.LabelEdit = false;
            listViewTerapeuta.Columns.Add("ID", 50, HorizontalAlignment.Center);
            listViewTerapeuta.Columns.Add("Terapeuta", 252, HorizontalAlignment.Center);
        }


        //////////////////////////////////////////PACIENTE////////////////////////////////////////////////
        private void btn_associarTerapeuta_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardarPaciente_Click(object sender, EventArgs e)
        {

        }

        private void btn_novo_paciente_Click(object sender, EventArgs e)
        {

        }

        private void btn_editar_paciente_Click(object sender, EventArgs e)
        {

        }

        private void btn_remover_paciente_Click(object sender, EventArgs e)
        {

        }

        public void preencheAssociarTerapeutas()
        {
            listaTerapeutas = servico.getAllTerapeutas(token).ToList();
            listViewAssociarTerapeuta.Items.Clear();
            foreach (TerapeutaWEB t in listaTerapeutas)
            {
                var itemListView = new ListViewItem(t.id.ToString());
                itemListView.SubItems.Add(t.nome.ToString());
                listViewAssociarTerapeuta.Items.Add(itemListView);
            }

        }
        public void preenchePacientes()
        {
            listaPacientes = servico.getAllPacientes(token).ToList();
            listViewPaciente.Items.Clear();
            foreach (PacienteWEB p in listaPacientes)
            {
                var itemListView = new ListViewItem(p.id.ToString());
                itemListView.SubItems.Add(p.nome.ToString());
                listViewPaciente.Items.Add(itemListView);
            }
        }


        public void inicializarListViewPaciente()
        {
            listViewPaciente.GridLines = true;
            listViewPaciente.Sorting = SortOrder.Ascending;
            listViewPaciente.View = View.Details;
            listViewPaciente.FullRowSelect = true;
            listViewPaciente.LabelEdit = false;
            listViewPaciente.Columns.Add("ID", 50, HorizontalAlignment.Center);
            listViewPaciente.Columns.Add("Paciente", 252, HorizontalAlignment.Center);
        }

        public void inicializarListViewAssociarTerapeuta()
        {
            listViewAssociarTerapeuta.GridLines = true;
            listViewAssociarTerapeuta.Sorting = SortOrder.Ascending;
            listViewAssociarTerapeuta.View = View.Details;
            listViewAssociarTerapeuta.FullRowSelect = true;
            listViewAssociarTerapeuta.LabelEdit = false;
            listViewAssociarTerapeuta.Columns.Add("ID", 50, HorizontalAlignment.Center);
            listViewAssociarTerapeuta.Columns.Add("Terapeuta a associar:", 252, HorizontalAlignment.Center);
        }









    }
}
