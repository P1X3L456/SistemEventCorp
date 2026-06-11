using SistemEventCorp.Presentation.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemEventCorp
{
    public partial class Form1 : Form
    {
        private Form activeForm;
        private Button activeButton;

        public Form1()
        {
            InitializeComponent();
            ShowModule(new DashboardForm(), "Panel de trabajo", "Resumen visual para organizar eventos, conferencias y personas.", btnDashboard);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowModule(new DashboardForm(), "Panel de trabajo", "Resumen visual para organizar eventos, conferencias y personas.", btnDashboard);
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            ShowModule(new EventosForm(), "Eventos", "Crea y organiza la informacion principal de cada evento.", btnEventos);
        }

        private void btnConferencias_Click(object sender, EventArgs e)
        {
            ShowModule(new ConferenciasForm(), "Conferencias", "Gestiona ponentes, salas y horarios de cada actividad.", btnConferencias);
        }

        private void btnParticipantes_Click(object sender, EventArgs e)
        {
            ShowModule(new ParticipantesForm(), "Participantes", "Registra a las personas que asistiran a los eventos.", btnParticipantes);
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            ShowModule(new InscripcionesForm(), "Inscripciones", "Controla solicitudes, confirmaciones y cupos disponibles.", btnInscripciones);
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            ShowModule(new AsistenciaForm(), "Asistencia", "Valida llegadas y acompana el ingreso de participantes.", btnAsistencia);
        }

        private void btnCertificados_Click(object sender, EventArgs e)
        {
            ShowModule(new CertificadosForm(), "Certificados", "Disena el seguimiento visual de constancias digitales.", btnCertificados);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ShowModule(new ReportesForm(), "Reportes", "Convierte los datos del evento en informacion facil de leer.", btnReportes);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ShowModule(new UsuariosForm(), "Usuarios", "Administra roles y permisos del equipo de trabajo.", btnUsuarios);
        }

        private void ShowModule(Form moduleForm, string title, string subtitle, Button menuButton)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            lblTitle.Text = title;
            lblSubtitle.Text = subtitle;

            activeForm = moduleForm;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;

            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(activeForm);
            activeForm.Show();

            MarkButton(menuButton);
        }

        private void MarkButton(Button selectedButton)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.FromArgb(20, 32, 54);
                activeButton.ForeColor = Color.FromArgb(198, 211, 231);
                activeButton.Font = new Font("Segoe UI", 9.2F, FontStyle.Regular);
            }

            activeButton = selectedButton;
            activeButton.BackColor = Color.FromArgb(34, 52, 84);
            activeButton.ForeColor = Color.White;
            activeButton.Font = new Font("Segoe UI", 9.2F, FontStyle.Bold);

            activeLine.Visible = true;
            activeLine.Location = new Point(0, activeButton.Top + 2);
            activeLine.BringToFront();
        }

        private void headerPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
