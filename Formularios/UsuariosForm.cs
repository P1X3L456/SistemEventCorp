using SistemEventCorp.Clases;
using SistemEventCorp.Metodos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemEventCorp.Presentation.Forms
{
    public partial class UsuariosForm : Form
    {
        private readonly metodosUsuario metodosUsuario = new metodosUsuario();
        private readonly metodosConsulta consultas = new metodosConsulta();
        private DataTable usuariosActuales;
        public UsuariosForm()
        {
            InitializeComponent();
            configurarFormulario();

            Load += UsuariosForm_Load;
            btnPrimary.Click += btnPrimary_Click;
            btnSecondary.Click += btnSecondary_Click;
            dgvMain.CellClick += dgvMain_CellClick;
        }
        private void configurarFormulario()
        {
            lblField1.Text = "Usuario";
            lblField2.Text = "Correo";
            lblField3.Text = "Nombre completo";
            lblField4.Text = "Rol";
            lblField5.Text = "Clave";
            btnPrimary.Text = "Guardar acceso";
            btnSecondary.Text = "Activar/Inactivar";

            AyudaFormulario.PrepararGrilla(dgvMain);
        }

        private void btnPrimary_Click(object sender, System.EventArgs e)
        {
            if (!AyudaFormulario.Requerido(txtField1, "usuario") ||
              !AyudaFormulario.Requerido(txtField2, "correo") ||
              !AyudaFormulario.Requerido(txtField3, "nombre completo") ||
              !AyudaFormulario.Requerido(txtField5, "clave"))
            {
                return;
            }

            int idRol;
            if (!AyudaFormulario.ObtenerIdCombo(cboField4, "un rol", out idRol))
            {
                return;
            }

            try
            {
                string nombres;
                string apellidos;
                AyudaFormulario.SepararNombre(AyudaFormulario.Texto(txtField3), out nombres, out apellidos);

                Usuario usuario = new Usuario
                {
                    IdRol = idRol,
                    Nombres = nombres,
                    Apellidos = apellidos,
                    Correo = AyudaFormulario.Texto(txtField2),
                    NombreUsuario = AyudaFormulario.Texto(txtField1),
                    Clave = AyudaFormulario.Texto(txtField5)
                };

                int idUsuario = metodosUsuario.crearUsuario(usuario);
                AyudaFormulario.Info("Usuario guardado correctamente. Codigo interno: " + idUsuario);

                limpiarCampos();
                cargarUsuarios();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo guardar el usuario.", ex);
            }
        }

        private void btnSecondary_Click(object sender, System.EventArgs e)
        {
            int idUsuario;
            int idRol;

            if (!AyudaFormulario.ObtenerIdFila(dgvMain, "IdUsuario", out idUsuario) ||
                !obtenerRolParaActualizacion(out idRol))
            {
                return;
            }

            try
            {
                string estadoActual = AyudaFormulario.ValorFila(dgvMain, "Estado");
                string nuevoEstado = string.Equals(estadoActual, "Activo", StringComparison.OrdinalIgnoreCase) ? "Inactivo" : "Activo";

                Usuario usuario = new Usuario
                {
                    IdUsuario = idUsuario,
                    IdRol = idRol,
                    Estado = nuevoEstado
                };

                metodosUsuario.actualizarAccesoUsuario(usuario);
                AyudaFormulario.Info("Acceso actualizado a estado: " + nuevoEstado);
                cargarUsuarios();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudo actualizar el acceso.", ex);
            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }

            txtField1.Text = AyudaFormulario.ValorFila(dgvMain, "Usuario");
            txtField3.Text = AyudaFormulario.ValorFila(dgvMain, "Responsabilidad");
            txtField5.Clear();

            string idRol = AyudaFormulario.ValorFila(dgvMain, "IdRol");
            int rol;
            if (int.TryParse(idRol, out rol))
            {
                cboField4.SelectedValue = rol;
            }
        }

        private void UsuariosForm_Load(object sender, System.EventArgs e)
        {
            cargarRoles();
            cargarUsuarios();
        }
        private void cargarRoles()
        {
            try
            {
                AyudaFormulario.CargarCombo(cboField4, consultas.listarRoles(), "IdRol", "Rol");
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudieron cargar los roles.", ex);
            }
        }

        private void cargarUsuarios()
        {
            try
            {
                usuariosActuales = consultas.listarUsuarios();
                AyudaFormulario.CargarGrilla(dgvMain, usuariosActuales, "IdUsuario", "IdRol");
                actualizarMetricas();
            }
            catch (Exception ex)
            {
                AyudaFormulario.Error("No se pudieron cargar los usuarios.", ex);
            }
        }

        private bool obtenerRolParaActualizacion(out int idRol)
        {
            if (AyudaFormulario.ObtenerIdCombo(cboField4, "un rol", out idRol))
            {
                return true;
            }

            string valorFila = AyudaFormulario.ValorFila(dgvMain, "IdRol");
            return int.TryParse(valorFila, out idRol);
        }

        private void limpiarCampos()
        {
            txtField1.Clear();
            txtField2.Clear();
            txtField3.Clear();
            txtField5.Clear();

            if (cboField4.Items.Count > 0)
            {
                cboField4.SelectedIndex = 0;
            }

            txtField1.Focus();
        }

        private void actualizarMetricas()
        {
            int total = usuariosActuales == null ? 0 : usuariosActuales.Rows.Count;

            lblMetric1.Text = "Usuarios" + Environment.NewLine + total;
            lblMetric2.Text = "Activos" + Environment.NewLine + AyudaFormulario.ContarEstado(usuariosActuales, "Estado", "Activo");
            lblMetric3.Text = "Roles" + Environment.NewLine + (cboField4.Items == null ? 0 : cboField4.Items.Count);
            lblMetric4.Text = "Ultimo" + Environment.NewLine + AyudaFormulario.PrimerValor(usuariosActuales, "Usuario");

            progress1.Value = Math.Min(100, total * 10);
            progress2.Value = Math.Min(100, AyudaFormulario.ContarEstado(usuariosActuales, "Estado", "Activo") * 10);
            progress3.Value = cboField4.Items.Count > 0 ? 80 : 0;
            progress4.Value = total > 0 ? 65 : 0;
        }
    }
}