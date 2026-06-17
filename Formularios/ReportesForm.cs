using SistemEventCorp.Clases;
using SistemEventCorp.Metodos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemEventCorp.Presentation.Forms
{
    public partial class ReportesForm : Form
    {
        private readonly metodosReporte metodosReporte = new metodosReporte();
        private DataTable ultimoReporte;
        public ReportesForm()
        {
            InitializeComponent();
            configurarFormulario();

            Load += ReportesForm_Load;
            btnPrimary.Click += btnPrimary_Click;
            btnSecondary.Click += btnSecondary_Click;
            cboField4.SelectedIndexChanged += cboField4_SelectedIndexChanged;

        }
        private void configurarFormulario()
        {
            lblField1.Text = "Id evento";
            lblField2.Text = "Periodo";
            lblField3.Text = "Responsable";
            lblField4.Text = "Reporte";
            lblField5.Text = "Pregunta guia";
            btnPrimary.Text = "Generar vista";
            btnSecondary.Text = "Exportar CSV";

            cboField4.Items.Clear();
            cboField4.Items.AddRange(new object[] { "Resumen de eventos", "Participantes por evento", "Certificados pendientes" });
            cboField4.SelectedIndex = 0;

            txtField2.Text = "Actual";
            txtField5.Text = "Que debemos revisar ahora?";
            AyudaFormulario.PrepararGrilla(dgvMain);
        }
        private void lblProgress4_Click(object sender, System.EventArgs e)
        {
            generarReporte();
        }

        private void btnPrimary_Click(object sender, System.EventArgs e)
        {
            generarReporte();
        }

        private void btnSecondary_Click(object sender, System.EventArgs e)
        {
            AyudaFormulario.ExportarCsv(ultimoReporte);
        }

        private void ReportesForm_Load(object sender, System.EventArgs e)
        {
            generarReporte();
        }

        private void cboField4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboField4.Text == "Participantes por evento")
            {
                txtField5.Text = "Quienes estan vinculados al evento seleccionado?";
                txtField1.Focus();
            }
            else if (cboField4.Text == "Certificados pendientes")
            {
                txtField5.Text = "Que constancias necesitan seguimiento?";
            }
            else
            {
                txtField5.Text = "Como esta avanzando la cartera de eventos?";
            }
        }
        private void generarReporte()
        {
            try
            {
                if (cboField4.Text == "Participantes por evento")
                {
                    int idEvento;
                    if (!AyudaFormulario.ObtenerEntero(txtField1, "id evento", out idEvento) || idEvento <= 0)
                    {
                        AyudaFormulario.Aviso("Escribe el id del evento para generar este reporte.");
                        return;
                    }

                    ultimoReporte = metodosReporte.obtenerParticipantesPorEvento(new Evento { IdEvento = idEvento });
                }
                else if (cboField4.Text == "Certificados pendientes")
                {
                    ultimoReporte = metodosReporte.obtenerCertificadosPendientes();
                }
                else
                {
                    ultimoReporte = metodosReporte.obtenerResumenEventos();
                }

                AyudaFormulario.CargarGrilla(dgvMain, ultimoReporte);
                actualizarMetricas();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo generar el reporte.", ex);
            }
        }

        private void actualizarMetricas()
        {
            int total = ultimoReporte == null ? 0 : ultimoReporte.Rows.Count;

            lblMetric1.Text = "Reporte" + Environment.NewLine + cboField4.Text;
            lblMetric2.Text = "Filas" + Environment.NewLine + total;
            lblMetric3.Text = "Periodo" + Environment.NewLine + AyudaFormulario.Texto(txtField2);
            lblMetric4.Text = "Estado" + Environment.NewLine + (total > 0 ? "Con datos" : "Sin datos");

            progress1.Value = total > 0 ? 90 : 0;
            progress2.Value = Math.Min(100, total * 10);
            progress3.Value = !string.IsNullOrWhiteSpace(txtField3.Text) ? 75 : 35;
            progress4.Value = total > 0 ? 80 : 20;
        }
    }
}