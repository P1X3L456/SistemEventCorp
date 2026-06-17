using SistemEventCorp.Clases;
using SistemEventCorp.Metodos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemEventCorp.Presentation.Forms
{
    public partial class EventosForm : Form
    {
        private readonly metodosEvento metodosEvento = new metodosEvento();
        private readonly metodosConsulta consultas = new metodosConsulta();
        private DataTable eventosActuales;
        public EventosForm()
        {
            InitializeComponent();
            Load += EventosForm_Load;
            btnPrimary.Click += btnPrimary_Click;
            btnSecondary.Click += btnSecondary_Click;
            dgvMain.CellClick += dgvMain_CellClick;
        }
        private void configurarFormulario()
        {
            lblField2.Text = "Fecha inicio";
            lblField4.Text = "Modalidad";
            lblField5.Text = "Capacidad";
            btnPrimary.Text = "Guardar evento";
            btnSecondary.Text = "Limpiar";

            cboField4.Items.Clear();
            cboField4.Items.AddRange(new object[] { "Presencial", "Virtual", "Hibrido" });
            cboField4.SelectedIndex = 0;

            txtField2.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtField5.Text = "100";
        }

        private void btnPrimary_Click(object sender, EventArgs e)
        {
            if (!AyudaFormulario.Requerido(txtField1, "nombre") ||
                !AyudaFormulario.Requerido(txtField3, "lugar"))
            {
                return;
            }

            DateTime fechaInicio;
            int capacidad;

            if (!AyudaFormulario.ObtenerFecha(txtField2, "fecha inicio", out fechaInicio) ||
                !AyudaFormulario.ObtenerEntero(txtField5, "capacidad", out capacidad))
            {
                return;
            }

            try
            {
                Evento evento = new Evento
                {
                    CodigoEvento = AyudaFormulario.CrearCodigo("EVT"),
                    Nombre = AyudaFormulario.Texto(txtField1),
                    Descripcion = "Evento registrado desde SistemEventCorp.",
                    FechaInicio = fechaInicio,
                    Lugar = AyudaFormulario.Texto(txtField3),
                    Modalidad = cboField4.Text,
                    Capacidad = capacidad,
                    IdResponsable = null
                };

                int idEvento = metodosEvento.crearEvento(evento);
                AyudaFormulario.Info("Evento guardado correctamente. Codigo interno: " + idEvento);

                limpiarCampos();
                cargarEventos();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo guardar el evento.", ex);
            }
        }

        private void btnSecondary_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txtField1.Text = AyudaFormulario.ValorFila(dgvMain, "Evento");
            txtField2.Text = formatearFecha(AyudaFormulario.ValorFila(dgvMain, "Fecha"));
            txtField3.Text = AyudaFormulario.ValorFila(dgvMain, "Lugar");
            txtField5.Text = AyudaFormulario.ValorFila(dgvMain, "Capacidad");

            string modalidad = AyudaFormulario.ValorFila(dgvMain, "Modalidad");
            if (!string.IsNullOrWhiteSpace(modalidad) && !cboField4.Items.Contains(modalidad))
            {
                cboField4.Items.Add(modalidad);
            }

            if (!string.IsNullOrWhiteSpace(modalidad))
            {
                cboField4.Text = modalidad;
            }
        }
        
        private void cargarEventos()
        {
            try
            {
                eventosActuales = consultas.listarEventos();
                AyudaFormulario.CargarGrilla(dgvMain, eventosActuales, "IdEvento");
                actualizarMetricas();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudieron cargar los eventos.", ex);
            }
        }

        private void limpiarCampos()
        {
            txtField1.Clear();
            txtField2.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtField3.Clear();
            txtField5.Text = "100";
            cboField4.SelectedIndex = 0;
            txtField1.Focus();
        }

        private void actualizarMetricas()
        {
            int total = eventosActuales == null ? 0 : eventosActuales.Rows.Count;
            int activos = AyudaFormulario.ContarEstado(eventosActuales, "Estado", "Activo");
            int cupos = AyudaFormulario.SumarEnteros(eventosActuales, "Capacidad");

            lblMetric1.Text = "Eventos" + Environment.NewLine + total;
            lblMetric2.Text = "Activos" + Environment.NewLine + activos;
            lblMetric3.Text = "Cupos" + Environment.NewLine + cupos;
            lblMetric4.Text = "Proximo" + Environment.NewLine + AyudaFormulario.PrimerValor(eventosActuales, "Fecha");

            progress1.Value = Math.Min(100, total * 10);
            progress2.Value = Math.Min(100, activos * 10);
            progress3.Value = Math.Min(100, cupos > 0 ? 75 : 0);
            progress4.Value = total > 0 ? 90 : 0;
        }

        private string formatearFecha(string valor)
        {
            DateTime fecha;
            return DateTime.TryParse(valor, out fecha) ? fecha.ToString("yyyy-MM-dd") : valor;
        }

        private void EventosForm_Load(object sender, EventArgs e)
        {
            cargarEventos();
        }
    }
}