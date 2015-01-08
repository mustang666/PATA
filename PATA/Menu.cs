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
        private List<ContaWEB> listaContasTerapeutas;
        private ContaWEB c;
        private TerapeutaWEB t;
        private PacienteWEB p;
        private PacienteWEB pacienteNovo;
        private bool isEditAdmin;
        private login login;
        private bool isLogout;
        public static string tipoT = "T";
        public static string tipoA = "A";




        ServicePATA.Service1Client servico;
        private bool isNovoTerapeuta;
        private bool isEditarTerapeuta;
        private int idTerapeutaAssociar;
        private bool isEditarPaciente;
        private bool isNovoPaciente;





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
            listaContasTerapeutas = new List<ContaWEB>();


            inicializarListViewAdmin();
            preencheAdmins();
            inicializarListViewTerapeuta();
            preencheTerapeutas();
            inicializarListViewPaciente();
            preenchePacientes();
            inicializarListViewAssociarTerapeuta();
            preencheAssociarTerapeutas();
            idTerapeutaAssociar = 0;


            if (PATA.Properties.Settings.Default.firstUsage)
            {
                MessageBox.Show("Bem vindo à Plataforma Auxiliar ao Terapeuta de Acupunctura\nComo é a sua primeira vez aqui, comece por selecionar o caminho do ficheiro Excel a importar e proceda à sua importação! Obrigado.", "P.A.T.A.");
            }

            unblockButtonsAdmin();
            unblockButtonsTerapeuta();
            unblockPanelGestaoPaciente();

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
                bool a = false;
                try
                {
                    a = servico.carregaXml(token, dados);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

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

                string msg = servico.removeConta(token, c.id);

                preencheAdmins();
                limparCamposAdmin();

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
                    ContaWEB aux = devolveConta(idConta, tipoA);
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

        public ContaWEB devolveConta(int idConta, string tipo)
        {


            ContaWEB conta = new ContaWEB();
            if (tipoA.Equals(tipo))
            {
                if (listaContas.Count > 0)
                {
                    foreach (ContaWEB c in listaContas)
                    {
                        if (c.id == idConta)
                        {
                            conta = c;
                        }
                    }
                }
            }
            else
            {
                if (listaContasTerapeutas.Count > 0)
                {
                    foreach (ContaWEB c in listaContasTerapeutas)
                    {
                        if (c.id == idConta)
                        {
                            conta = c;
                        }
                    }
                }
            }

            return conta;

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
            limparCamposTerapeuta();



        }

        private void btn_editar_terapeuta_Click(object sender, EventArgs e)
        {
            if (listViewTerapeuta.SelectedItems.Count == 1)
            {
                isEditarTerapeuta = true;
                blockButtonsTerapeuta();
            }
            else
            {
                MessageBox.Show("Selecione um terapeuta da lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_remover_terapeuta_Click(object sender, EventArgs e)
        {
            bool res = false;
            if (listViewTerapeuta.SelectedItems.Count == 1)
            {
                if (t != null)
                {
                    res = servico.removeTerapeuta(token, t.contaID, t.id);

                    if (res)
                    {
                        MessageBox.Show("Terapeuta removido com sucesso!", "Remover Terapeuta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limparCamposTerapeuta();
                        preencheTerapeutas();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível remover o Terapeuta!", "Remover Terapeuta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }



            }
            else
            {
                MessageBox.Show("Selecione um terapeuta da lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_guardar_terapeuta_Click(object sender, EventArgs e)
        {
            if (validarDadosTerapeuta())
            {
                if (isNovoTerapeuta)
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
                        isNovoTerapeuta = false;
                        unblockButtonsTerapeuta();
                        limparCamposTerapeuta();
                    }

                }
                else if (isEditarTerapeuta)
                {

                    ContaWEB contaT = devolveConta(t.contaID, tipoT);
                    contaT.username = txt_username_terapeuta.Text;
                    contaT.password = txt_password_terapeuta.Text;


                    t.nome = txt_nome_terapeuta.Text;
                    t.cc = txt_cc_terapeuta.Text;
                    t.telefone = txt_telefone_terapeuta.Text;
                    t.dataNasc = getDataString(dt_dataNasc_terapeuta.Value);

                    bool resultado = servico.editTerapeuta(token, t, contaT);

                    if (resultado)
                    {
                        MessageBox.Show("Terapeuta adicionado com sucesso!");
                        isEditarTerapeuta = false;
                        unblockButtonsTerapeuta();
                        limparCamposTerapeuta();
                        preencheTerapeutas();
                    }
                    else
                    {
                        isEditarTerapeuta = false;
                        unblockButtonsTerapeuta();
                        limparCamposTerapeuta();
                        preencheTerapeutas();
                        MessageBox.Show("Não foi possível alterar o terapeuta, revertendo alterações!");
                    }
                    MessageBox.Show(listaTerapeutas[0].dataNasc.ToString());
                }
            }
            else
            {
                MessageBox.Show("Preencha os campos em falta!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private void listViewTerapeuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTerapeuta.Items.Count > 0)
            {
                if (listViewTerapeuta.SelectedItems.Count == 1)
                {
                    int terapeutaId = Convert.ToInt32(listViewTerapeuta.SelectedItems[0].SubItems[0].Text);
                    TerapeutaWEB aux = devolveTerapeuta(terapeutaId);
                    if (aux != null)
                    {
                        t = aux;
                        ContaWEB contaTerapeuta = devolveConta(t.contaID, tipoT);
                        if (contaTerapeuta != null)
                        {
                            txt_username_terapeuta.Text = contaTerapeuta.username;
                            txt_password_terapeuta.Text = contaTerapeuta.password;
                            txt_nome_terapeuta.Text = t.nome;
                            txt_cc_terapeuta.Text = t.cc;
                            txt_telefone_terapeuta.Text = t.telefone;


                            string dtNasc = t.dataNasc;
                            string[] dataPartes = dtNasc.Split('/');
                            string dia = dataPartes[0];
                            string mes = dataPartes[1];
                            string ano = dataPartes[2];

                            if (dia.Length == 1)
                            {
                                dia = "0" + dia;

                            }
                            if (mes.Length == 1)
                            {
                                mes = "0" + mes;
                            }
                            dtNasc = dia + "/" + mes + "/" + ano;

                            DateTime data = getData(dtNasc);
                            dt_dataNasc_terapeuta.Value = data;

                        }
                    }
                }
            }
        }

        public DateTime getData(string data)
        {
            DateTime result = new DateTime();
            DateTime date = new DateTime();
            if (DateTime.TryParseExact(data, "dd'/'MM'/'yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out date))
                result = date;



            return result;
        }

        public String getDataString(DateTime data)
        {
            String final = "";

            string dia = data.Day + "";
            string mes = data.Month + "";
            string ano = data.Year + "";

            if (dia.Length == 1)
            {
                dia = "0" + dia;

            }
            if (mes.Length == 1)
            {
                mes = "0" + mes;
            }
            final = dia + "/" + mes + "/" + ano;


            return final;
        }

        public TerapeutaWEB devolveTerapeuta(int terapeutaId)
        {
            TerapeutaWEB t = null;
            foreach (TerapeutaWEB item in listaTerapeutas)
            {
                if (item.id == terapeutaId)
                {
                    t = item;
                }
            }

            return t;
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
            if (listViewTerapeuta.Items.Count == 0)
            {
                btn_editar_terapeuta.Enabled = false;
                btn_remover_terapeuta.Enabled = false;

            }
            preencheContasTerapeutas();
            preencheAssociarTerapeutas();
        }

        public void preencheContasTerapeutas()
        {
            listaContasTerapeutas = servico.getAllContasTerapeutas(token).ToList();
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

        private void btnCancelarTerapeuta_Click(object sender, EventArgs e)
        {
            limparCamposTerapeuta();
            unblockButtonsTerapeuta();

        }


        //////////////////////////////////////////PACIENTE////////////////////////////////////////////////




        private void btn_novo_paciente_Click(object sender, EventArgs e)
        {
            limparCamposPaciente();
            isNovoPaciente = true;
            blockPanelGestaoPaciente();
            p = null;
            pacienteNovo = new PacienteWEB();

        }

        private void btn_editar_paciente_Click(object sender, EventArgs e)
        {

            pacienteNovo = null;
            if (listViewPaciente.Items.Count > 0)
            {
                if (listViewPaciente.SelectedItems.Count == 1)
                {
                    isEditarPaciente = true;
                    blockPanelGestaoPaciente();
                    
                }
                else
                {
                    MessageBox.Show("Selecione um paciente da lista!");
                }
            }
            else
            {
                MessageBox.Show("Não existem pacientes na lista!");
            }


        }

        private void btn_remover_paciente_Click(object sender, EventArgs e)
        {

            if (listViewPaciente.Items.Count > 0)
            {
                if (listViewPaciente.SelectedItems.Count == 1)
                {
                   
                   if(p!=null){
                       bool res=servico.removePaciente(token,p.id);
                       if (res)
                       {

                           MessageBox.Show("O paciente foi removido com sucesso!", "Alterar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           preenchePacientes();
                       }
                       else
                       {

                           MessageBox.Show("Não foi possível remover o paciente, a reverter alterações!", "Alterar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           preenchePacientes();
                           p = null;
                       }
                   
                   }
                    
                }
                else
                {
                    MessageBox.Show("Selecione um paciente da lista!");
                }
            }
            else
            {
                MessageBox.Show("Não existem pacientes na lista!");
            }
        }

        private void btn_guardarPaciente_Click(object sender, EventArgs e)
        {
            bool resultado = false;

            if (validarDadosPaciente())
            {
                if (isNovoPaciente)
                {


                    pacienteNovo.nome = txt_nome_paciente.Text;
                    pacienteNovo.cc = txt_cc_paciente.Text;
                    pacienteNovo.telefone = txt_telefone_paciente.Text;
                    pacienteNovo.dataNasc = getDataString(dt_dataNasc_paciente.Value);
                    pacienteNovo.morada = rich_morada_paciente.Text;

                    if (radioM_paciente.Checked)
                    {
                        pacienteNovo.sexo = "H";
                    }
                    else
                    {
                        pacienteNovo.sexo = "M";
                    }




                    resultado = servico.addPacienteClienteAdmin(token, pacienteNovo);

                    if (resultado)
                    {

                        MessageBox.Show("O paciente foi adicionado com sucesso!", "Alterar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        MessageBox.Show("Não foi possível adicionar o paciente, a reverter alterações!", "Alterar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    limparCamposPaciente();
                    preenchePacientes();
                    unblockPanelGestaoPaciente();
                    isNovoPaciente = false;
                    pacienteNovo = null;

                }


                else if (isEditarPaciente)
                {

                    if (p != null)
                    {

                        p.nome = txt_nome_paciente.Text;
                        p.cc = txt_cc_paciente.Text;
                        p.telefone = txt_telefone_paciente.Text;
                        p.dataNasc = getDataString(dt_dataNasc_paciente.Value);
                        p.morada = rich_morada_paciente.Text;

                        if (radioM_paciente.Checked)
                        {
                            p.sexo = "H";
                        }
                        else
                        {
                            p.sexo = "M";
                        }



                        resultado = servico.editPacienteClienteAdmin(token, p);

                        if (resultado)
                        {

                            MessageBox.Show("O paciente foi alterado com sucesso!", "Alterar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show("Não foi possível alterar o paciente, a reverter alterações!", "Alterar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        limparCamposPaciente();
                        preenchePacientes();
                        unblockPanelGestaoPaciente();
                        isEditarPaciente = false;
                        p = null;

                    }



                }


            }
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
            if (listViewPaciente.Items.Count == 0)
            {
                btn_editar_paciente.Enabled = false;
                btn_remover_paciente.Enabled = false;

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
            listViewAssociarTerapeuta.Columns.Add("Terapeuta a associar:", 275, HorizontalAlignment.Center);
        }



        public bool validarDadosPaciente()
        {

            if (txt_nome_paciente.Text != "" && txt_cc_paciente.Text != "" && txt_telefone_paciente.Text != "" && rich_morada_paciente.Text != "" && (radioF_paciente.Checked || radioM_paciente.Checked))
            {
                if (dt_dataNasc_paciente.Value <= DateTime.Today)
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



        private void listViewPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPaciente.Items.Count > 0)
            {
                if (listViewPaciente.SelectedItems.Count == 1)
                {
                  
                    limparCamposPaciente();
                    int pacienteId = Convert.ToInt32(listViewPaciente.SelectedItems[0].SubItems[0].Text);
                    PacienteWEB aux = devolvePaciente(pacienteId);
                    if (aux != null)
                    {
                        p = aux;

                        txt_nome_paciente.Text = p.nome;
                        txt_cc_paciente.Text = p.cc;
                        txt_telefone_paciente.Text = p.telefone;
                        rich_morada_paciente.Text = p.morada;



                        string dtNasc = p.dataNasc;
                        string[] dataPartes = dtNasc.Split('/');
                        string dia = dataPartes[0];
                        string mes = dataPartes[1];
                        string ano = dataPartes[2];

                        if (dia.Length == 1)
                        {
                            dia = "0" + dia;

                        }
                        if (mes.Length == 1)
                        {
                            mes = "0" + mes;
                        }
                        dtNasc = dia + "/" + mes + "/" + ano;

                        DateTime data = getData(dtNasc);
                        dt_dataNasc_paciente.Value = data;

                        if (p.sexo.Equals("H"))
                        {
                            radioM_paciente.Checked = true;
                        }
                        else
                        {
                            radioF_paciente.Checked = true;
                        }

                        if (p.terapeutaID != 0)
                        {
                            if (listViewAssociarTerapeuta.Items.Count > 0)
                            {
                                foreach (ListViewItem item in listViewAssociarTerapeuta.Items)
                                {

                                    if (Convert.ToInt32(item.Text) == p.terapeutaID)
                                    {
                                        txt_terapeuta_paciente.Text = item.SubItems[1].Text;

                                    }



                                }
                            }


                        }


                    }
                }
            }
        }

        public PacienteWEB devolvePaciente(int idPaciente)
        {
            PacienteWEB p = null;
            foreach (PacienteWEB item in listaPacientes)
            {
                if (item.id == idPaciente)
                {
                    p = item;
                }
            }

            return p;
        }

        public void blockPanelGestaoPaciente()
        {
            groupBoxPaciente.Enabled = true;
            groupGestaoPacientes.Enabled = false;

        }

        public void unblockPanelGestaoPaciente()
        {
            groupBoxPaciente.Enabled = false;
            groupGestaoPacientes.Enabled = true;

        }



        public void limparCamposPaciente()
        {
            txt_nome_paciente.Text = "";
            txt_cc_paciente.Text = "";
            txt_telefone_paciente.Text = "";
            dt_dataNasc_paciente.Value = DateTime.Today;
            radioF_paciente.Checked = false;
            radioM_paciente.Checked = false;
            txt_terapeuta_paciente.Text = "";
            rich_morada_paciente.Text = "";
        }

        private void btn_dessociar_terapeuta_Click(object sender, EventArgs e)
        {

            if (p != null)
            {
                if (p.terapeutaID != 0)
                {
                    p.terapeutaID = 0;
                    txt_terapeuta_paciente.Text = "";
                }
                else
                {
                    MessageBox.Show("O paciente não possui terapeuta!");

                }

            }
            if (pacienteNovo != null)
            {
                if (pacienteNovo.terapeutaID != 0)
                {
                    pacienteNovo.terapeutaID = 0;
                    txt_terapeuta_paciente.Text = "";
                }
                else
                {
                    MessageBox.Show("O paciente não possui terapeuta!");

                }
            }
        }

        private void btn_associarTerapeuta_Click(object sender, EventArgs e)
        {
            if (listViewAssociarTerapeuta.Items.Count > 0)
            {
                if (listViewAssociarTerapeuta.SelectedItems.Count == 1)
                {
                    if (isEditarPaciente)
                    {
                        if (p.terapeutaID == 0)
                        {

                            p.terapeutaID = Convert.ToInt32(listViewAssociarTerapeuta.SelectedItems[0].SubItems[0].Text);
                            txt_terapeuta_paciente.Text = listViewAssociarTerapeuta.SelectedItems[0].SubItems[1].Text;

                        }
                        else
                        {
                            MessageBox.Show("Paciente já possui terapeuta!");
                        }

                    }
                    else if (isNovoPaciente)
                    {
                        if (pacienteNovo.terapeutaID == 0)
                        {
                            pacienteNovo.terapeutaID = Convert.ToInt32(listViewAssociarTerapeuta.SelectedItems[0].SubItems[0].Text);
                            txt_terapeuta_paciente.Text = listViewAssociarTerapeuta.SelectedItems[0].SubItems[1].Text;
                        }
                        else
                        {
                            MessageBox.Show("Paciente já possui terapeuta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Selecione um terapeuta da lista!");
                }
            }
            else
            {
                MessageBox.Show("Não existem terapeutas na lista!");
            }



        }

        private void btn_cancelar_paciente_Click(object sender, EventArgs e)
        {
            limparCamposPaciente();
            unblockPanelGestaoPaciente();
        }












    }
}
