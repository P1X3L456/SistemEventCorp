using SistemEventCorp.Clases;
using SistemEventCorp.Metodos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemEventCorp.Presentation.Forms
{
    public partial class CertificadosForm : Form
    {
        private readonly metodosCertificado metodosCertificado = new metodosCertificado();
        private readonly metodosConsulta consultas = new metodosConsulta();
        private ComboBox cboInscripciones;
        private DataTable certificadosActuales;
        public CertificadosForm()
        {
            InitializeComponent();
            configurarFormulario();

            btnPrimary.Click += btnPrimary_Click;
            btnSecondary.Click += btnSecondary_Click;
            dgvMain.CellClick += dgvMain_CellClick;

        }
        private void configurarFormulario()
        {
            lblField1.Text = "Inscripcion";
            lblField2.Text = "Ruta archivo";
            lblField3.Text = "Horas";
            lblField4.Text = "Estado";
            lblField5.Text = "Observacion";
            btnPrimary.Text = "Generar";
            btnSecondary.Text = "Cambiar estado";

            cboInscripciones = AyudaFormulario.CrearComboEnLugarDe(txtField1, groupForm);

            cboField4.Items.Clear();
            cboField4.Items.AddRange(new object[] { "Pendiente", "Generado", "Entregado", "Anulado" });
            cboField4.SelectedIndex = 1;

            txtField3.Text = "0";
            AyudaFormulario.PrepararGrilla(dgvMain);
        }
        private void progress1_Click(object sender, System.EventArgs e)
        {
            cargarCertificados();
        }

        private void lblMetric1_Click(object sender, System.EventArgs e)
        {
            cargarCertificados();
        }

        private void lblProgress2_Click(object sender, System.EventArgs e)
        {
            cboField4.Text = "Generado";
        }

        private void txtField5_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void CertificadosForm_Load(object sender, System.EventArgs e)
        {
            cargarCatalogos();
            cargarCertificados();
        }

        private void btnPrimary_Click(object sender, System.EventArgs e)
        {
            int idInscripcion;
            decimal horas;

            if (!AyudaFormulario.ObtenerIdCombo(cboInscripciones, "una inscripcion", out idInscripcion) ||
                !AyudaFormulario.ObtenerDecimal(txtField3, "horas", out horas))
            {
                return;
            }

            try
            {
                Certificado certificado = new Certificado
                {
                    CodigoCertificado = AyudaFormulario.CrearCodigo("CER"),
                    IdInscripcion = idInscripcion,
                    HorasReconocidas = horas,
                    FechaEmision = DateTime.Today,
                    Estado = cboField4.Text,
                    RutaArchivo = AyudaFormulario.Texto(txtField2),
                    Observacion = AyudaFormulario.Texto(txtField5)
                };

                metodosCertificado.generarCertificado(certificado);
                AyudaFormulario.Info("Certificado generado correctamente.");

                limpiarCampos();
                cargarCertificados();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo generar el certificado.", ex);
            }
        }

        private void btnSecondary_Click(object sender, System.EventArgs e)
        {
            int idCertificado;
            if (!AyudaFormulario.ObtenerIdFila(dgvMain, "IdCertificado", out idCertificado))
            {
                return;
            }

            try
            {
                Certificado certificado = new Certificado
                {
                    IdCertificado = idCertificado,
                    Estado = cboField4.Text,
                    Observacion = AyudaFormulario.Texto(txtField5)
                };

                metodosCertificado.cambiarEstadoCertificado(certificado);
                AyudaFormulario.Info("Estado del certificado actualizado.");
                cargarCertificados();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo cambiar el estado del certificado.", ex);
            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txtField2.Text = AyudaFormulario.ValorFila(dgvMain, "RutaArchivo");
            txtField3.Text = AyudaFormulario.ValorFila(dgvMain, "Horas");
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
                AyudaFormulario.CargarCombo(cboInscripciones, consultas.listarInscripcionesCatalogo(), "IdInscripcion", "Inscripcion");
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudieron cargar las inscripciones.", ex);
            }
        }
        private void cargarCertificados()
        {
            try
            {
                certificadosActuales = consultas.listarCertificados();
                AyudaFormulario.CargarGrilla(dgvMain, certificadosActuales, "IdCertificado", "RutaArchivo");
                actualizarMetricas();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudieron cargar los certificados.", ex);
            }
        }

        private void limpiarCampos()
        {
            if (cboInscripciones.Items.Count > 0)
            {
                cboInscripciones.SelectedIndex = 0;
            }

            txtField2.Clear();
            txtField3.Text = "0";
            txtField5.Clear();
            cboField4.SelectedIndex = 1;
        }

        private void actualizarMetricas()
        {
            int total = certificadosActuales == null ? 0 : certificadosActuales.Rows.Count;

            lblMetric1.Text = "Certificados" + Environment.NewLine + total;
            lblMetric2.Text = "Generados" + Environment.NewLine + AyudaFormulario.ContarEstado(certificadosActuales, "Estado", "Generado");
            lblMetric3.Text = "Entregados" + Environment.NewLine + AyudaFormulario.ContarEstado(certificadosActuales, "Estado", "Entregado");
            lblMetric4.Text = "Pendientes" + Environment.NewLine + AyudaFormulario.ContarEstado(certificadosActuales, "Estado", "Pendiente");

            progress1.Value = Math.Min(100, total * 10);
            progress2.Value = Math.Min(100, AyudaFormulario.ContarEstado(certificadosActuales, "Estado", "Generado") * 10);
            progress3.Value = Math.Min(100, AyudaFormulario.ContarEstado(certificadosActuales, "Estado", "Entregado") * 10);
            progress4.Value = Math.Min(100, AyudaFormulario.ContarEstado(certificadosActuales, "Estado", "Pendiente") * 10);
        }
    }
}