using SistemEventCorp.Clases;
using SistemEventCorp.Metodos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemEventCorp.Presentation.Forms
{
    public partial class ConferenciasForm : Form
    {
        private readonly metodosConferencia metodosConferencia = new metodosConferencia();
        private readonly metodosConsulta consultas = new metodosConsulta();
        private DataTable agendaActual;
        private bool cargandoCatalogos;
        public ConferenciasForm()
        {
            InitializeComponent();
            configurarFormulario();

            Load += ConferenciasForm_Load;
            btnPrimary.Click += btnPrimary_Click;
            btnSecondary.Click += btnSecondary_Click;
            cboField4.SelectedIndexChanged += cboField4_SelectedIndexChanged;
            dgvMain.CellClick += dgvMain_CellClick;
        }
        private void configurarFormulario()
        {
            lblField3.Text = "Hora inicio";
            lblField4.Text = "Evento";
            lblField5.Text = "Sala";
            btnPrimary.Text = "Anadir agenda";
            btnSecondary.Text = "Limpiar";

            txtField3.Text = DateTime.Now.ToString("HH:mm");
            AyudaFormulario.PrepararGrilla(dgvMain);
        }

        private void ConferenciasForm_Load(object sender, System.EventArgs e)
        {
            cargarCatalogos();
            cargarAgenda();
        }

        private void btnPrimary_Click(object sender, System.EventArgs e)
        {
            if (!AyudaFormulario.Requerido(txtField1, "tema") ||
                !AyudaFormulario.Requerido(txtField2, "ponente") ||
                !AyudaFormulario.Requerido(txtField5, "sala"))
            {
                return;
            }

            int idEvento;
            TimeSpan horaInicio;

            if (!AyudaFormulario.ObtenerIdCombo(cboField4, "un evento", out idEvento) ||
                !AyudaFormulario.ObtenerHora(txtField3, "hora inicio", out horaInicio))
            {
                return;
            }

            try
            {
                Conferencia conferencia = new Conferencia
                {
                    IdEvento = idEvento,
                    Titulo = AyudaFormulario.Texto(txtField1),
                    Descripcion = "Conferencia registrada desde SistemEventCorp.",
                    Ponente = AyudaFormulario.Texto(txtField2),
                    Sala = AyudaFormulario.Texto(txtField5),
                    Fecha = DateTime.Today,
                    HoraInicio = horaInicio,
                    HoraFin = null,
                    Cupo = 0
                };

                int idConferencia = metodosConferencia.crearConferencia(conferencia);
                AyudaFormulario.Info("Conferencia agregada correctamente. Codigo interno: " + idConferencia);

                limpiarCampos();
                cargarAgenda();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo guardar la conferencia.", ex);
            }
        }

        private void btnSecondary_Click(object sender, System.EventArgs e)
        {
            limpiarCampos();
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txtField1.Text = AyudaFormulario.ValorFila(dgvMain, "Conferencia");
            txtField2.Text = AyudaFormulario.ValorFila(dgvMain, "Ponente");
            txtField3.Text = AyudaFormulario.ValorFila(dgvMain, "Hora");
            txtField5.Text = AyudaFormulario.ValorFila(dgvMain, "Sala");
        }

        private void cboField4_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            if (!cargandoCatalogos)
            {
                cargarAgenda();
            }
        }

        private void cargarCatalogos()
        {
            try
            {
                cargandoCatalogos = true;
                AyudaFormulario.CargarCombo(cboField4, consultas.listarEventosCatalogo(), "IdEvento", "Evento");
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudieron cargar los eventos para la agenda.", ex);
            }
            finally
            {
                cargandoCatalogos = false;
            }
        }

        private void cargarAgenda()
        {
            try
            {
                int idEvento;
                if (obtenerEventoSeleccionado(out idEvento))
                {
                    try
                    {
                        agendaActual = metodosConferencia.listarAgendaEvento(new Evento { IdEvento = idEvento });
                    }
                    catch
                    {
                        agendaActual = consultas.listarConferencias();
                    }
                }
                else
                {
                    agendaActual = consultas.listarConferencias();
                }

                AyudaFormulario.CargarGrilla(dgvMain, agendaActual, "IdConferencia", "IdEvento");
                actualizarMetricas();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo cargar la agenda.", ex);
            }
        }

        private bool obtenerEventoSeleccionado(out int idEvento)
        {
            idEvento = 0;
            return cboField4.SelectedValue != null && int.TryParse(cboField4.SelectedValue.ToString(), out idEvento);
        }

        private void limpiarCampos()
        {
            txtField1.Clear();
            txtField2.Clear();
            txtField3.Text = DateTime.Now.ToString("HH:mm");
            txtField5.Clear();
            txtField1.Focus();
        }

        private void actualizarMetricas()
        {
            int total = agendaActual == null ? 0 : agendaActual.Rows.Count;

            lblMetric1.Text = "Conferencias" + Environment.NewLine + total;
            lblMetric2.Text = "Programadas" + Environment.NewLine + AyudaFormulario.ContarEstado(agendaActual, "Estado", "Programada");
            lblMetric3.Text = "Cupos" + Environment.NewLine + AyudaFormulario.SumarEnteros(agendaActual, "Cupo");
            lblMetric4.Text = "Proxima" + Environment.NewLine + AyudaFormulario.PrimerValor(agendaActual, "Hora");

            progress1.Value = Math.Min(100, total * 10);
            progress2.Value = total > 0 ? 80 : 0;
            progress3.Value = Math.Min(100, AyudaFormulario.SumarEnteros(agendaActual, "Cupo"));
            progress4.Value = total > 0 ? 70 : 0;
        }
    }
}