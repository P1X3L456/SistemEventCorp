using SistemEventCorp.Clases;
using SistemEventCorp.Metodos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemEventCorp.Presentation.Forms
{
    public partial class ParticipantesForm : Form
    {
        private readonly metodosParticipante metodosParticipante = new metodosParticipante();
        private readonly metodosConsulta consultas = new metodosConsulta();
        private DataTable participantesActuales;
        public ParticipantesForm()
        {
            InitializeComponent();
            configurarFormulario();
            
            Load += ParticipantesForm_Load;
            btnPrimary.Click += btnPrimary_Click;
            btnSecondary.Click += btnSecondary_Click;
            dgvMain.CellClick += dgvMain_CellClick;
        }
        private void configurarFormulario()
        {
            lblField1.Text = "Nombre completo";
            lblField4.Text = "Interes";
            lblField5.Text = "Observacion";
            btnPrimary.Text = "Guardar participante";
            btnSecondary.Text = "Buscar";

            cboField4.Items.Clear();
            cboField4.Items.AddRange(new object[] { "General", "Certificado", "Networking", "Ponente", "Invitado" });
            cboField4.SelectedIndex = 0;

            AyudaFormulario.PrepararGrilla(dgvMain);
        }

        private void btnPrimary_Click(object sender, System.EventArgs e)
        {
            if (!AyudaFormulario.Requerido(txtField1, "nombre completo") ||
                !AyudaFormulario.Requerido(txtField2, "documento") ||
                !AyudaFormulario.Requerido(txtField3, "correo"))
            {
                return;
            }

            try
            {
                string nombres;
                string apellidos;
                AyudaFormulario.SepararNombre(AyudaFormulario.Texto(txtField1), out nombres, out apellidos);

                Participante participante = new Participante
                {
                    TipoDocumento = "DNI",
                    NumeroDocumento = AyudaFormulario.Texto(txtField2),
                    Nombres = nombres,
                    Apellidos = apellidos,
                    Correo = AyudaFormulario.Texto(txtField3),
                    Telefono = string.Empty,
                    Institucion = string.Empty,
                    Interes = cboField4.Text,
                    Observacion = AyudaFormulario.Texto(txtField5)
                };

                int idParticipante = metodosParticipante.registrarParticipante(participante);
                AyudaFormulario.Info("Participante guardado correctamente. Codigo interno: " + idParticipante);

                limpiarCampos();
                cargarParticipantes();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo guardar el participante.", ex);
            }
        }

        private void ParticipantesForm_Load(object sender, System.EventArgs e)
        {
            cargarParticipantes();
        }

        private void btnSecondary_Click(object sender, EventArgs e)
        {
            string filtro = !string.IsNullOrWhiteSpace(txtField2.Text) ? AyudaFormulario.Texto(txtField2) : AyudaFormulario.Texto(txtField1);

            try
            {
                participantesActuales = metodosParticipante.buscarParticipante(filtro);
                AyudaFormulario.CargarGrilla(dgvMain, participantesActuales, "IdParticipante");
                actualizarMetricas();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo buscar participantes.", ex);
            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txtField1.Text = AyudaFormulario.ValorFila(dgvMain, "Participante");
            txtField2.Text = AyudaFormulario.ValorFila(dgvMain, "Documento");
            txtField3.Text = AyudaFormulario.ValorFila(dgvMain, "Correo");

            string interes = AyudaFormulario.ValorFila(dgvMain, "Interes");
            if (!string.IsNullOrWhiteSpace(interes) && !cboField4.Items.Contains(interes))
            {
                cboField4.Items.Add(interes);
            }

            if (!string.IsNullOrWhiteSpace(interes))
            {
                cboField4.Text = interes;
            }
        }
        private void cargarParticipantes()
        {
            try
            {
                participantesActuales = consultas.listarParticipantes();
                AyudaFormulario.CargarGrilla(dgvMain, participantesActuales, "IdParticipante");
                actualizarMetricas();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudieron cargar los participantes.", ex);
            }
        }

        private void limpiarCampos()
        {
            txtField1.Clear();
            txtField2.Clear();
            txtField3.Clear();
            txtField5.Clear();
            cboField4.SelectedIndex = 0;
            txtField1.Focus();
        }

        private void actualizarMetricas()
        {
            int total = participantesActuales == null ? 0 : participantesActuales.Rows.Count;
            int activos = AyudaFormulario.ContarEstado(participantesActuales, "Estado", "Activo");

            lblMetric1.Text = "Participantes" + Environment.NewLine + total;
            lblMetric2.Text = "Activos" + Environment.NewLine + activos;
            lblMetric3.Text = "Interes" + Environment.NewLine + AyudaFormulario.PrimerValor(participantesActuales, "Interes");
            lblMetric4.Text = "Ultimo" + Environment.NewLine + AyudaFormulario.PrimerValor(participantesActuales, "Participante");

            progress1.Value = Math.Min(100, total * 10);
            progress2.Value = Math.Min(100, activos * 10);
            progress3.Value = total > 0 ? 80 : 0;
            progress4.Value = total > 0 ? 65 : 0;
        }
    }
}