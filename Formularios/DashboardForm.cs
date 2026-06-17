using SistemEventCorp.Clases;
using SistemEventCorp.Metodos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemEventCorp.Presentation.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly metodosConsulta consultas = new metodosConsulta();
        private DataTable agendaActual;
        public DashboardForm()
        {
            InitializeComponent();
            configurarFormulario();

            Load += DashboardForm_Load;
            btnPrimary.Click += btnPrimary_Click;
            btnSecondary.Click += btnSecondary_Click;
        }
        private void configurarFormulario()
        {
            btnPrimary.Text = "Actualizar agenda";
            btnSecondary.Text = "Registrar aviso";

            cboField4.Items.Clear();
            cboField4.Items.AddRange(new object[] { "Alta", "Media", "Baja" });
            cboField4.SelectedIndex = 1;

            txtField3.Text = DateTime.Today.ToString("yyyy-MM-dd");
            AyudaFormulario.PrepararGrilla(dgvMain);
        }
        private void btnPrimary_Click(object sender, System.EventArgs e)
        {
            cargarPanel();
        }

        private void btnSecondary_Click(object sender, System.EventArgs e)
        {
            string aviso = AyudaFormulario.Texto(txtField5);
            if (string.IsNullOrWhiteSpace(aviso))
            {
                AyudaFormulario.Aviso("Escribe una nota para el equipo antes de registrarla.");
                return;
            }

            AyudaFormulario.Info("Aviso listo para compartir con el equipo: " + aviso);
        }

        private void cargarPanel()
        {
            try
            {
                agendaActual = consultas.listarAgendaDia();
                AyudaFormulario.CargarGrilla(dgvMain, agendaActual);
                actualizarResumen();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo cargar el panel de trabajo.", ex);
            }
        }

        private void actualizarResumen()
        {
            int eventos = consultas.contarRegistros("eventos", "evento");
            int participantes = consultas.contarRegistros("participantes", "participante");
            int inscripciones = consultas.contarRegistros("inscripciones", "inscripcion");
            int pendientes = consultas.contarCertificadosPendientes();

            lblMetric1.Text = "Eventos" + Environment.NewLine + eventos;
            lblMetric2.Text = "Participantes" + Environment.NewLine + participantes;
            lblMetric3.Text = "Inscripciones" + Environment.NewLine + inscripciones;
            lblMetric4.Text = "Certificados pendientes" + Environment.NewLine + pendientes;

            txtField1.Text = AyudaFormulario.PrimerValor(agendaActual, "Conferencia");
            txtField2.Text = AyudaFormulario.PrimerValor(agendaActual, "Ponente");
            txtField5.Text = "Revisar agenda y confirmar recursos del dia.";

            progress1.Value = Math.Min(100, eventos * 10);
            progress2.Value = Math.Min(100, participantes * 5);
            progress3.Value = Math.Min(100, inscripciones * 5);
            progress4.Value = pendientes > 0 ? 45 : 90;
        }
        private void DashboardForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}