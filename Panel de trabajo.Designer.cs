namespace SistemEventCorp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuPanel = new System.Windows.Forms.Panel();
            this.navPanel = new System.Windows.Forms.Panel();
            this.activeLine = new System.Windows.Forms.Panel();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCertificados = new System.Windows.Forms.Button();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.btnInscripciones = new System.Windows.Forms.Button();
            this.btnParticipantes = new System.Windows.Forms.Button();
            this.btnConferencias = new System.Windows.Forms.Button();
            this.btnEventos = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.brandPanel = new System.Windows.Forms.Panel();
            this.lblBrandSubtitle = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.menuPanel.SuspendLayout();
            this.navPanel.SuspendLayout();
            this.brandPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.menuPanel.Controls.Add(this.navPanel);
            this.menuPanel.Controls.Add(this.brandPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Padding = new System.Windows.Forms.Padding(18, 20, 18, 18);
            this.menuPanel.Size = new System.Drawing.Size(254, 749);
            this.menuPanel.TabIndex = 0;
            // 
            // navPanel
            // 
            this.navPanel.Controls.Add(this.activeLine);
            this.navPanel.Controls.Add(this.btnUsuarios);
            this.navPanel.Controls.Add(this.btnReportes);
            this.navPanel.Controls.Add(this.btnCertificados);
            this.navPanel.Controls.Add(this.btnAsistencia);
            this.navPanel.Controls.Add(this.btnInscripciones);
            this.navPanel.Controls.Add(this.btnParticipantes);
            this.navPanel.Controls.Add(this.btnConferencias);
            this.navPanel.Controls.Add(this.btnEventos);
            this.navPanel.Controls.Add(this.btnDashboard);
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navPanel.Location = new System.Drawing.Point(18, 92);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(218, 472);
            this.navPanel.TabIndex = 1;
            // 
            // activeLine
            // 
            this.activeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(184)))), ((int)(((byte)(166)))));
            this.activeLine.Location = new System.Drawing.Point(0, 2);
            this.activeLine.Name = "activeLine";
            this.activeLine.Size = new System.Drawing.Size(4, 42);
            this.activeLine.TabIndex = 9;
            this.activeLine.Visible = false;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.btnUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.btnUsuarios.Location = new System.Drawing.Point(8, 400);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(218, 46);
            this.btnUsuarios.TabIndex = 8;
            this.btnUsuarios.Text = "Usuarios\r\nAccesos";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.btnReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.btnReportes.Location = new System.Drawing.Point(8, 350);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(195, 46);
            this.btnReportes.TabIndex = 7;
            this.btnReportes.Text = "Reportes\r\nDecisiones";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnCertificados
            // 
            this.btnCertificados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnCertificados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCertificados.FlatAppearance.BorderSize = 0;
            this.btnCertificados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCertificados.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.btnCertificados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.btnCertificados.Location = new System.Drawing.Point(8, 300);
            this.btnCertificados.Name = "btnCertificados";
            this.btnCertificados.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCertificados.Size = new System.Drawing.Size(181, 46);
            this.btnCertificados.TabIndex = 6;
            this.btnCertificados.Text = "Certificados\r\nReconocimiento";
            this.btnCertificados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCertificados.UseVisualStyleBackColor = false;
            this.btnCertificados.Click += new System.EventHandler(this.btnCertificados_Click);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnAsistencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsistencia.FlatAppearance.BorderSize = 0;
            this.btnAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsistencia.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.btnAsistencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.btnAsistencia.Location = new System.Drawing.Point(8, 250);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnAsistencia.Size = new System.Drawing.Size(181, 46);
            this.btnAsistencia.TabIndex = 5;
            this.btnAsistencia.Text = "Asistencia\r\nRecepcion";
            this.btnAsistencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsistencia.UseVisualStyleBackColor = false;
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // btnInscripciones
            // 
            this.btnInscripciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnInscripciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInscripciones.FlatAppearance.BorderSize = 0;
            this.btnInscripciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInscripciones.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.btnInscripciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.btnInscripciones.Location = new System.Drawing.Point(8, 200);
            this.btnInscripciones.Name = "btnInscripciones";
            this.btnInscripciones.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnInscripciones.Size = new System.Drawing.Size(181, 46);
            this.btnInscripciones.TabIndex = 4;
            this.btnInscripciones.Text = "Inscripciones\r\nConfirmaciones";
            this.btnInscripciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInscripciones.UseVisualStyleBackColor = false;
            this.btnInscripciones.Click += new System.EventHandler(this.btnInscripciones_Click);
            // 
            // btnParticipantes
            // 
            this.btnParticipantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnParticipantes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParticipantes.FlatAppearance.BorderSize = 0;
            this.btnParticipantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParticipantes.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.btnParticipantes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.btnParticipantes.Location = new System.Drawing.Point(8, 150);
            this.btnParticipantes.Name = "btnParticipantes";
            this.btnParticipantes.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnParticipantes.Size = new System.Drawing.Size(181, 46);
            this.btnParticipantes.TabIndex = 3;
            this.btnParticipantes.Text = "Participantes\r\nPersonas";
            this.btnParticipantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParticipantes.UseVisualStyleBackColor = false;
            this.btnParticipantes.Click += new System.EventHandler(this.btnParticipantes_Click);
            // 
            // btnConferencias
            // 
            this.btnConferencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnConferencias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConferencias.FlatAppearance.BorderSize = 0;
            this.btnConferencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConferencias.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.btnConferencias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.btnConferencias.Location = new System.Drawing.Point(8, 100);
            this.btnConferencias.Name = "btnConferencias";
            this.btnConferencias.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnConferencias.Size = new System.Drawing.Size(195, 46);
            this.btnConferencias.TabIndex = 2;
            this.btnConferencias.Text = "Conferencias\r\nAgenda";
            this.btnConferencias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConferencias.UseVisualStyleBackColor = false;
            this.btnConferencias.Click += new System.EventHandler(this.btnConferencias_Click);
            // 
            // btnEventos
            // 
            this.btnEventos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnEventos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEventos.FlatAppearance.BorderSize = 0;
            this.btnEventos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEventos.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.btnEventos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.btnEventos.Location = new System.Drawing.Point(5, 50);
            this.btnEventos.Name = "btnEventos";
            this.btnEventos.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnEventos.Size = new System.Drawing.Size(184, 46);
            this.btnEventos.TabIndex = 1;
            this.btnEventos.Text = "Eventos\r\nPlanificacion";
            this.btnEventos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEventos.UseVisualStyleBackColor = false;
            this.btnEventos.Click += new System.EventHandler(this.btnEventos_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.btnDashboard.Location = new System.Drawing.Point(8, 4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(159, 42);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Panel de trabajo\r\nVista general";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // brandPanel
            // 
            this.brandPanel.Controls.Add(this.lblBrandSubtitle);
            this.brandPanel.Controls.Add(this.lblBrand);
            this.brandPanel.Controls.Add(this.lblLogo);
            this.brandPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.brandPanel.Location = new System.Drawing.Point(18, 20);
            this.brandPanel.Name = "brandPanel";
            this.brandPanel.Size = new System.Drawing.Size(218, 72);
            this.brandPanel.TabIndex = 0;
            // 
            // lblBrandSubtitle
            // 
            this.lblBrandSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBrandSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(231)))));
            this.lblBrandSubtitle.Location = new System.Drawing.Point(66, 36);
            this.lblBrandSubtitle.Name = "lblBrandSubtitle";
            this.lblBrandSubtitle.Size = new System.Drawing.Size(137, 37);
            this.lblBrandSubtitle.TabIndex = 2;
            this.lblBrandSubtitle.Text = "Gestion de eventos y conferencias";
            // 
            // lblBrand
            // 
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(66, 8);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(150, 26);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "EventCorp";
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(184)))), ((int)(((byte)(166)))));
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 4);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(54, 54);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "EC";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(254, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(30, 14, 30, 10);
            this.headerPanel.Size = new System.Drawing.Size(1026, 78);
            this.headerPanel.TabIndex = 1;
            this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanel_Paint);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(132)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 48);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(966, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Resumen visual para organizar eventos, conferencias y personas.";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(966, 34);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Panel de trabajo";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(254, 78);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1026, 671);
            this.contentPanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1280, 749);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.menuPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1180, 718);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventCorp Solutions - Sistema de eventos y conferencias";
            this.menuPanel.ResumeLayout(false);
            this.navPanel.ResumeLayout(false);
            this.brandPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Panel activeLine;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCertificados;
        private System.Windows.Forms.Button btnAsistencia;
        private System.Windows.Forms.Button btnInscripciones;
        private System.Windows.Forms.Button btnParticipantes;
        private System.Windows.Forms.Button btnConferencias;
        private System.Windows.Forms.Button btnEventos;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel brandPanel;
        private System.Windows.Forms.Label lblBrandSubtitle;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel contentPanel;
    }
}
