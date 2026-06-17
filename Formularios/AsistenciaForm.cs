using SistemEventCorp.Clases;
using SistemEventCorp.Metodos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemEventCorp.Presentation.Forms
{
    public partial class AsistenciaForm : Form
    {
        private readonly metodosAsistencia metodosAsistencia = new metodosAsistencia();
        private readonly metodosConsulta consultas = new metodosConsulta();
        private ComboBox cboInscripciones;
        private ComboBox cboConferencias;
        private DataTable asistenciaActual;
        public AsistenciaForm()
        {
            InitializeComponent();
            configurarFormulario();

            btnPrimary.Click += btnPrimary_Click;
            btnSecondary.Click += btnSecondary_Click;
        }
        private void configurarFormulario()
        {
            lblField1.Text = "Inscripcion";
            lblField2.Text = "Conferencia";
            lblField3.Text = "Hora llegada";
            lblField4.Text = "Estado";
            lblField5.Text = "Observacion";
            btnPrimary.Text = "Marcar presente";
            btnSecondary.Text = "Agregar nota";

            cboInscripciones = AyudaFormulario.CrearComboEnLugarDe(txtField1, groupForm);
            cboConferencias = AyudaFormulario.CrearComboEnLugarDe(txtField2, groupForm);

            cboField4.Items.Clear();
            cboField4.Items.AddRange(new object[] { "Presente", "Tarde", "Ausente", "Observado" });
            cboField4.SelectedIndex = 0;

            txtField3.Text = DateTime.Now.ToString("HH:mm");
            AyudaFormulario.PrepararGrilla(dgvMain);
        }
        private void progress1_Click(object sender, System.EventArgs e)
        {
            cargarAsistencia();
        }

        private void AsistenciaForm_Load(object sender, System.EventArgs e)
        {
            cargarCatalogos();
            cargarAsistencia();
        }

        private void lblMetric2_Click(object sender, System.EventArgs e)
        {

        }

        private void btnPrimary_Click(object sender, EventArgs e)
        {
            registrarAsistencia(false);
        }

        private void btnSecondary_Click(object sender, EventArgs e)
        {
            if (!AyudaFormulario.Requerido(txtField5, "observacion"))
            {
                return;
            }

            cboField4.Text = "Observado";
            registrarAsistencia(true);
        }
        private void registrarAsistencia(bool esNota)
        {
            int idInscripcion;
            TimeSpan horaLlegada;

            if (!AyudaFormulario.ObtenerIdCombo(cboInscripciones, "una inscripcion", out idInscripcion) ||
                !AyudaFormulario.ObtenerHora(txtField3, "hora llegada", out horaLlegada))
            {
                return;
            }

            try
            {
                int idConferencia;
                int? conferenciaSeleccionada = AyudaFormulario.ObtenerIdCombo(cboConferencias, "una conferencia", out idConferencia)
                    ? (int?)idConferencia
                    : null;

                Asistencia asistencia = new Asistencia
                {
                    IdInscripcion = idInscripcion,
                    IdConferencia = conferenciaSeleccionada,
                    FechaAsistencia = DateTime.Today,
                    HoraLlegada = horaLlegada,
                    Estado = cboField4.Text,
                    AtendidoPor = null,
                    Observacion = AyudaFormulario.Texto(txtField5)
                };

                metodosAsistencia.marcarAsistencia(asistencia);
                AyudaFormulario.Info(esNota ? "Nota de asistencia registrada." : "Asistencia marcada correctamente.");

                txtField5.Clear();
                cargarAsistencia();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo registrar la asistencia.", ex);
            }
        }

        private void cargarCatalogos()
        {
            try
            {
                AyudaFormulario.CargarCombo(cboInscripciones, consultas.listarInscripcionesCatalogo(), "IdInscripcion", "Inscripcion");
                AyudaFormulario.CargarCombo(cboConferencias, consultas.listarConferenciasCatalogo(), "IdConferencia", "Conferencia");
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudieron cargar inscripciones o conferencias.", ex);
            }
        }

        private void cargarAsistencia()
        {
            try
            {
                asistenciaActual = consultas.listarAsistenciaDia();
                AyudaFormulario.CargarGrilla(dgvMain, asistenciaActual, "IdAsistencia");
                actualizarMetricas();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo cargar la asistencia del dia.", ex);
            }
        }

        private void actualizarMetricas()
        {
            int total = asistenciaActual == null ? 0 : asistenciaActual.Rows.Count;

            lblMetric1.Text = "Registros" + Environment.NewLine + total;
            lblMetric2.Text = "Presentes" + Environment.NewLine + AyudaFormulario.ContarEstado(asistenciaActual, "Estado", "Presente");
            lblMetric3.Text = "Tarde" + Environment.NewLine + AyudaFormulario.ContarEstado(asistenciaActual, "Estado", "Tarde");
            lblMetric4.Text = "Ultima llegada" + Environment.NewLine + AyudaFormulario.PrimerValor(asistenciaActual, "Llegada");

            progress1.Value = Math.Min(100, total * 10);
            progress2.Value = Math.Min(100, AyudaFormulario.ContarEstado(asistenciaActual, "Estado", "Presente") * 10);
            progress3.Value = Math.Min(100, AyudaFormulario.ContarEstado(asistenciaActual, "Estado", "Tarde") * 10);
            progress4.Value = total > 0 ? 85 : 0;
        }
    }
}