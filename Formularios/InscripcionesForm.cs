using SistemEventCorp.Clases;
using SistemEventCorp.Metodos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemEventCorp.Presentation.Forms
{
    public partial class InscripcionesForm : Form
    {
        private readonly metodosInscripcion metodosInscripcion = new metodosInscripcion();
        private readonly metodosConsulta consultas = new metodosConsulta();
        private ComboBox cboParticipantes;
        private ComboBox cboEventos;
        private DataTable inscripcionesActuales;
        public InscripcionesForm()
        {
            InitializeComponent();
            Load += InscripcionesForm_Load;
            btnPrimary.Click += btnPrimary_Click;
            btnSecondary.Click += btnSecondary_Click;
            dgvMain.CellClick += dgvMain_CellClick;

        }
        private void configurarFormulario()
        {
            lblField1.Text = "Participante";
            lblField2.Text = "Evento";
            lblField3.Text = "Codigo";
            lblField4.Text = "Estado";
            btnPrimary.Text = "Registrar inscripcion";
            btnSecondary.Text = "Cambiar estado";

            cboParticipantes = AyudaFormulario.CrearComboEnLugarDe(txtField1, groupForm);
            cboEventos = AyudaFormulario.CrearComboEnLugarDe(txtField2, groupForm);

            cboField4.Items.Clear();
            cboField4.Items.AddRange(new object[] { "Pendiente", "Confirmada", "Cancelada" });
            cboField4.SelectedIndex = 0;

            txtField3.Text = AyudaFormulario.CrearCodigo("INS");
            AyudaFormulario.PrepararGrilla(dgvMain);
        }
        private void txtField3_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void InscripcionesForm_Load(object sender, System.EventArgs e)
        {
            cargarCatalogos();
            cargarInscripciones();
        }

        private void btnPrimary_Click(object sender, System.EventArgs e)
        {
            int idParticipante;
            int idEvento;

            if (!AyudaFormulario.ObtenerIdCombo(cboParticipantes, "un participante", out idParticipante) ||
                !AyudaFormulario.ObtenerIdCombo(cboEventos, "un evento", out idEvento) ||
                !AyudaFormulario.Requerido(txtField3, "codigo"))
            {
                return;
            }

            try
            {
                Inscripcion inscripcion = new Inscripcion
                {
                    CodigoInscripcion = AyudaFormulario.Texto(txtField3),
                    IdEvento = idEvento,
                    IdParticipante = idParticipante,
                    Estado = cboField4.Text,
                    Observacion = AyudaFormulario.Texto(txtField5)
                };

                int idInscripcion = metodosInscripcion.registrarInscripcion(inscripcion);
                AyudaFormulario.Info("Inscripcion registrada correctamente. Codigo interno: " + idInscripcion);

                limpiarCampos();
                cargarInscripciones();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo registrar la inscripcion.", ex);
            }
        }

        private void btnSecondary_Click(object sender, System.EventArgs e)
        {
            int idInscripcion;
            if (!AyudaFormulario.ObtenerIdFila(dgvMain, "IdInscripcion", out idInscripcion))
            {
                return;
            }

            try
            {
                Inscripcion inscripcion = new Inscripcion
                {
                    IdInscripcion = idInscripcion,
                    Estado = cboField4.Text,
                    Observacion = AyudaFormulario.Texto(txtField5)
                };

                metodosInscripcion.cambiarEstadoInscripcion(inscripcion);
                AyudaFormulario.Info("Estado de inscripcion actualizado.");
                cargarInscripciones();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo cambiar el estado de la inscripcion.", ex);
            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            seleccionarValor(cboParticipantes, AyudaFormulario.ValorFila(dgvMain, "IdParticipante"));
            seleccionarValor(cboEventos, AyudaFormulario.ValorFila(dgvMain, "IdEvento"));
            txtField3.Text = AyudaFormulario.ValorFila(dgvMain, "Inscripcion");
            txtField5.Text = AyudaFormulario.ValorFila(dgvMain, "Observacion");

            string estado = AyudaFormulario.ValorFila(dgvMain, "Estado");
            if (!string.IsNullOrWhiteSpace(estado) && !cboField4.Items.Contains(estado))
            {
                cboField4.Items.Add(estado);
            }

            if (!string.IsNullOrWhiteSpace(estado))
            {
                cboField4.Text = estado;
            }
        }
        private void cargarCatalogos()
        {
            try
            {
                AyudaFormulario.CargarCombo(cboParticipantes, consultas.listarParticipantesCatalogo(), "IdParticipante", "Participante");
                AyudaFormulario.CargarCombo(cboEventos, consultas.listarEventosCatalogo(), "IdEvento", "Evento");
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudieron cargar participantes o eventos.", ex);
            }
        }

        private void cargarInscripciones()
        {
            try
            {
                inscripcionesActuales = consultas.listarInscripciones();
                AyudaFormulario.CargarGrilla(dgvMain, inscripcionesActuales, "IdInscripcion", "IdEvento", "IdParticipante");
                actualizarMetricas();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudieron cargar las inscripciones.", ex);
            }
        }

        private void limpiarCampos()
        {
            if (cboParticipantes.Items.Count > 0)
            {
                cboParticipantes.SelectedIndex = 0;
            }

            if (cboEventos.Items.Count > 0)
            {
                cboEventos.SelectedIndex = 0;
            }

            txtField3.Text = AyudaFormulario.CrearCodigo("INS");
            cboField4.SelectedIndex = 0;
            txtField5.Clear();
        }

        private void seleccionarValor(ComboBox combo, string valor)
        {
            int id;
            if (int.TryParse(valor, out id))
            {
                combo.SelectedValue = id;
            }
        }

        private void actualizarMetricas()
        {
            int total = inscripcionesActuales == null ? 0 : inscripcionesActuales.Rows.Count;

            lblMetric1.Text = "Inscripciones" + Environment.NewLine + total;
            lblMetric2.Text = "Confirmadas" + Environment.NewLine + AyudaFormulario.ContarEstado(inscripcionesActuales, "Estado", "Confirmada");
            lblMetric3.Text = "Pendientes" + Environment.NewLine + AyudaFormulario.ContarEstado(inscripcionesActuales, "Estado", "Pendiente");
            lblMetric4.Text = "Ultima" + Environment.NewLine + AyudaFormulario.PrimerValor(inscripcionesActuales, "Inscripcion");

            progress1.Value = Math.Min(100, total * 10);
            progress2.Value = Math.Min(100, AyudaFormulario.ContarEstado(inscripcionesActuales, "Estado", "Confirmada") * 10);
            progress3.Value = Math.Min(100, AyudaFormulario.ContarEstado(inscripcionesActuales, "Estado", "Pendiente") * 10);
            progress4.Value = total > 0 ? 70 : 0;
        }
    }
}