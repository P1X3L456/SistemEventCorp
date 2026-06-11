namespace SistemEventCorp.Presentation.Forms
{
    partial class ConferenciasForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pagePanel = new System.Windows.Forms.Panel();
            this.groupList = new System.Windows.Forms.GroupBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupForm = new System.Windows.Forms.GroupBox();
            this.btnSecondary = new System.Windows.Forms.Button();
            this.btnPrimary = new System.Windows.Forms.Button();
            this.txtField5 = new System.Windows.Forms.TextBox();
            this.lblField5 = new System.Windows.Forms.Label();
            this.cboField4 = new System.Windows.Forms.ComboBox();
            this.lblField4 = new System.Windows.Forms.Label();
            this.txtField3 = new System.Windows.Forms.TextBox();
            this.lblField3 = new System.Windows.Forms.Label();
            this.txtField2 = new System.Windows.Forms.TextBox();
            this.lblField2 = new System.Windows.Forms.Label();
            this.txtField1 = new System.Windows.Forms.TextBox();
            this.lblField1 = new System.Windows.Forms.Label();
            this.groupStatus = new System.Windows.Forms.GroupBox();
            this.progress4 = new System.Windows.Forms.ProgressBar();
            this.lblProgress4 = new System.Windows.Forms.Label();
            this.progress3 = new System.Windows.Forms.ProgressBar();
            this.lblProgress3 = new System.Windows.Forms.Label();
            this.progress2 = new System.Windows.Forms.ProgressBar();
            this.lblProgress2 = new System.Windows.Forms.Label();
            this.progress1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress1 = new System.Windows.Forms.Label();
            this.metricsPanel = new System.Windows.Forms.Panel();
            this.lblMetric1 = new System.Windows.Forms.Label();
            this.lblMetric2 = new System.Windows.Forms.Label();
            this.lblMetric3 = new System.Windows.Forms.Label();
            this.lblMetric4 = new System.Windows.Forms.Label();
            this.heroPanel = new System.Windows.Forms.Panel();
            this.lblHeroText = new System.Windows.Forms.Label();
            this.lblHeroTitle = new System.Windows.Forms.Label();
            this.accentPanel = new System.Windows.Forms.Panel();
            this.pagePanel.SuspendLayout();
            this.groupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.topLayout.SuspendLayout();
            this.groupForm.SuspendLayout();
            this.groupStatus.SuspendLayout();
            this.metricsPanel.SuspendLayout();
            this.heroPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagePanel
            // 
            this.pagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pagePanel.Controls.Add(this.groupList);
            this.pagePanel.Controls.Add(this.topLayout);
            this.pagePanel.Controls.Add(this.metricsPanel);
            this.pagePanel.Controls.Add(this.heroPanel);
            this.pagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePanel.Location = new System.Drawing.Point(0, 0);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Padding = new System.Windows.Forms.Padding(24);
            this.pagePanel.Size = new System.Drawing.Size(1000, 620);
            this.pagePanel.TabIndex = 0;
            // 
            // groupList
            // 
            this.groupList.BackColor = System.Drawing.Color.White;
            this.groupList.Controls.Add(this.dgvMain);
            this.groupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.groupList.Location = new System.Drawing.Point(24, 478);
            this.groupList.Name = "groupList";
            this.groupList.Padding = new System.Windows.Forms.Padding(12, 32, 12, 12);
            this.groupList.Size = new System.Drawing.Size(952, 118);
            this.groupList.TabIndex = 0;
            this.groupList.TabStop = false;
            this.groupList.Text = "Agenda de conferencias";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMain.ColumnHeadersHeight = 34;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6});
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.dgvMain.Location = new System.Drawing.Point(12, 50);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 30;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(928, 56);
            this.dgvMain.TabIndex = 0;
            // 
            // col1
            // 
            this.col1.HeaderText = "Hora";
            this.col1.Name = "col1";
            this.col1.ReadOnly = true;
            // 
            // col2
            // 
            this.col2.HeaderText = "Conferencia";
            this.col2.Name = "col2";
            this.col2.ReadOnly = true;
            // 
            // col3
            // 
            this.col3.HeaderText = "Ponente";
            this.col3.Name = "col3";
            this.col3.ReadOnly = true;
            // 
            // col4
            // 
            this.col4.HeaderText = "Sala";
            this.col4.Name = "col4";
            this.col4.ReadOnly = true;
            // 
            // col5
            // 
            this.col5.HeaderText = "Cupo";
            this.col5.Name = "col5";
            this.col5.ReadOnly = true;
            // 
            // col6
            // 
            this.col6.HeaderText = "Estado";
            this.col6.Name = "col6";
            this.col6.ReadOnly = true;
            // 
            // topLayout
            // 
            this.topLayout.ColumnCount = 2;
            this.topLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.topLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.topLayout.Controls.Add(this.groupForm, 0, 0);
            this.topLayout.Controls.Add(this.groupStatus, 1, 0);
            this.topLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLayout.Location = new System.Drawing.Point(24, 191);
            this.topLayout.Name = "topLayout";
            this.topLayout.RowCount = 1;
            this.topLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topLayout.Size = new System.Drawing.Size(952, 287);
            this.topLayout.TabIndex = 1;
            // 
            // groupForm
            // 
            this.groupForm.BackColor = System.Drawing.Color.White;
            this.groupForm.Controls.Add(this.btnSecondary);
            this.groupForm.Controls.Add(this.btnPrimary);
            this.groupForm.Controls.Add(this.txtField5);
            this.groupForm.Controls.Add(this.lblField5);
            this.groupForm.Controls.Add(this.cboField4);
            this.groupForm.Controls.Add(this.lblField4);
            this.groupForm.Controls.Add(this.txtField3);
            this.groupForm.Controls.Add(this.lblField3);
            this.groupForm.Controls.Add(this.txtField2);
            this.groupForm.Controls.Add(this.lblField2);
            this.groupForm.Controls.Add(this.txtField1);
            this.groupForm.Controls.Add(this.lblField1);
            this.groupForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupForm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.groupForm.Location = new System.Drawing.Point(0, 0);
            this.groupForm.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.groupForm.Name = "groupForm";
            this.groupForm.Size = new System.Drawing.Size(397, 287);
            this.groupForm.TabIndex = 0;
            this.groupForm.TabStop = false;
            this.groupForm.Text = "Programar conferencia";
            // 
            // btnSecondary
            // 
            this.btnSecondary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnSecondary.FlatAppearance.BorderSize = 0;
            this.btnSecondary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecondary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSecondary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.btnSecondary.Location = new System.Drawing.Point(164, 236);
            this.btnSecondary.Name = "btnSecondary";
            this.btnSecondary.Size = new System.Drawing.Size(132, 32);
            this.btnSecondary.TabIndex = 0;
            this.btnSecondary.Text = "Revisar hora";
            this.btnSecondary.UseVisualStyleBackColor = false;
            // 
            // btnPrimary
            // 
            this.btnPrimary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(184)))), ((int)(((byte)(166)))));
            this.btnPrimary.FlatAppearance.BorderSize = 0;
            this.btnPrimary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrimary.ForeColor = System.Drawing.Color.White;
            this.btnPrimary.Location = new System.Drawing.Point(20, 236);
            this.btnPrimary.Name = "btnPrimary";
            this.btnPrimary.Size = new System.Drawing.Size(132, 32);
            this.btnPrimary.TabIndex = 1;
            this.btnPrimary.Text = "Anadir agenda";
            this.btnPrimary.UseVisualStyleBackColor = false;
            // 
            // txtField5
            // 
            this.txtField5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtField5.Location = new System.Drawing.Point(20, 177);
            this.txtField5.Multiline = true;
            this.txtField5.Name = "txtField5";
            this.txtField5.Size = new System.Drawing.Size(356, 48);
            this.txtField5.TabIndex = 2;
            // 
            // lblField5
            // 
            this.lblField5.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblField5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(132)))));
            this.lblField5.Location = new System.Drawing.Point(20, 157);
            this.lblField5.Name = "lblField5";
            this.lblField5.Size = new System.Drawing.Size(356, 18);
            this.lblField5.TabIndex = 3;
            this.lblField5.Text = "Detalle";
            // 
            // cboField4
            // 
            this.cboField4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboField4.Location = new System.Drawing.Point(204, 120);
            this.cboField4.Name = "cboField4";
            this.cboField4.Size = new System.Drawing.Size(172, 23);
            this.cboField4.TabIndex = 4;
            // 
            // lblField4
            // 
            this.lblField4.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblField4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(132)))));
            this.lblField4.Location = new System.Drawing.Point(204, 100);
            this.lblField4.Name = "lblField4";
            this.lblField4.Size = new System.Drawing.Size(172, 18);
            this.lblField4.TabIndex = 5;
            this.lblField4.Text = "Estado";
            // 
            // txtField3
            // 
            this.txtField3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtField3.Location = new System.Drawing.Point(20, 120);
            this.txtField3.Name = "txtField3";
            this.txtField3.Size = new System.Drawing.Size(172, 23);
            this.txtField3.TabIndex = 6;
            // 
            // lblField3
            // 
            this.lblField3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblField3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(132)))));
            this.lblField3.Location = new System.Drawing.Point(20, 100);
            this.lblField3.Name = "lblField3";
            this.lblField3.Size = new System.Drawing.Size(172, 18);
            this.lblField3.TabIndex = 7;
            this.lblField3.Text = "Hora";
            // 
            // txtField2
            // 
            this.txtField2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtField2.Location = new System.Drawing.Point(204, 61);
            this.txtField2.Name = "txtField2";
            this.txtField2.Size = new System.Drawing.Size(172, 23);
            this.txtField2.TabIndex = 8;
            // 
            // lblField2
            // 
            this.lblField2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblField2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(132)))));
            this.lblField2.Location = new System.Drawing.Point(204, 41);
            this.lblField2.Name = "lblField2";
            this.lblField2.Size = new System.Drawing.Size(172, 18);
            this.lblField2.TabIndex = 9;
            this.lblField2.Text = "Ponente";
            // 
            // txtField1
            // 
            this.txtField1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtField1.Location = new System.Drawing.Point(20, 61);
            this.txtField1.Name = "txtField1";
            this.txtField1.Size = new System.Drawing.Size(172, 23);
            this.txtField1.TabIndex = 10;
            // 
            // lblField1
            // 
            this.lblField1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblField1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(132)))));
            this.lblField1.Location = new System.Drawing.Point(20, 41);
            this.lblField1.Name = "lblField1";
            this.lblField1.Size = new System.Drawing.Size(172, 18);
            this.lblField1.TabIndex = 11;
            this.lblField1.Text = "Tema";
            // 
            // groupStatus
            // 
            this.groupStatus.BackColor = System.Drawing.Color.White;
            this.groupStatus.Controls.Add(this.progress4);
            this.groupStatus.Controls.Add(this.lblProgress4);
            this.groupStatus.Controls.Add(this.progress3);
            this.groupStatus.Controls.Add(this.lblProgress3);
            this.groupStatus.Controls.Add(this.progress2);
            this.groupStatus.Controls.Add(this.lblProgress2);
            this.groupStatus.Controls.Add(this.progress1);
            this.groupStatus.Controls.Add(this.lblProgress1);
            this.groupStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.groupStatus.Location = new System.Drawing.Point(421, 0);
            this.groupStatus.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(531, 287);
            this.groupStatus.TabIndex = 1;
            this.groupStatus.TabStop = false;
            this.groupStatus.Text = "Cuidado de agenda";
            // 
            // progress4
            // 
            this.progress4.Location = new System.Drawing.Point(24, 218);
            this.progress4.Name = "progress4";
            this.progress4.Size = new System.Drawing.Size(470, 18);
            this.progress4.TabIndex = 0;
            this.progress4.Value = 72;
            // 
            // lblProgress4
            // 
            this.lblProgress4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProgress4.Location = new System.Drawing.Point(24, 195);
            this.lblProgress4.Name = "lblProgress4";
            this.lblProgress4.Size = new System.Drawing.Size(470, 20);
            this.lblProgress4.TabIndex = 1;
            // 
            // progress3
            // 
            this.progress3.Location = new System.Drawing.Point(24, 166);
            this.progress3.Name = "progress3";
            this.progress3.Size = new System.Drawing.Size(470, 18);
            this.progress3.TabIndex = 2;
            this.progress3.Value = 64;
            // 
            // lblProgress3
            // 
            this.lblProgress3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProgress3.Location = new System.Drawing.Point(24, 143);
            this.lblProgress3.Name = "lblProgress3";
            this.lblProgress3.Size = new System.Drawing.Size(470, 20);
            this.lblProgress3.TabIndex = 3;
            // 
            // progress2
            // 
            this.progress2.Location = new System.Drawing.Point(24, 114);
            this.progress2.Name = "progress2";
            this.progress2.Size = new System.Drawing.Size(470, 18);
            this.progress2.TabIndex = 4;
            this.progress2.Value = 80;
            // 
            // lblProgress2
            // 
            this.lblProgress2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProgress2.Location = new System.Drawing.Point(24, 91);
            this.lblProgress2.Name = "lblProgress2";
            this.lblProgress2.Size = new System.Drawing.Size(470, 20);
            this.lblProgress2.TabIndex = 5;
            // 
            // progress1
            // 
            this.progress1.Location = new System.Drawing.Point(24, 62);
            this.progress1.Name = "progress1";
            this.progress1.Size = new System.Drawing.Size(470, 18);
            this.progress1.TabIndex = 6;
            this.progress1.Value = 88;
            // 
            // lblProgress1
            // 
            this.lblProgress1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProgress1.Location = new System.Drawing.Point(24, 39);
            this.lblProgress1.Name = "lblProgress1";
            this.lblProgress1.Size = new System.Drawing.Size(470, 20);
            this.lblProgress1.TabIndex = 7;
            // 
            // metricsPanel
            // 
            this.metricsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.metricsPanel.Controls.Add(this.lblMetric1);
            this.metricsPanel.Controls.Add(this.lblMetric2);
            this.metricsPanel.Controls.Add(this.lblMetric3);
            this.metricsPanel.Controls.Add(this.lblMetric4);
            this.metricsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.metricsPanel.Location = new System.Drawing.Point(24, 114);
            this.metricsPanel.Name = "metricsPanel";
            this.metricsPanel.Size = new System.Drawing.Size(952, 77);
            this.metricsPanel.TabIndex = 2;
            // 
            // lblMetric1
            // 
            this.lblMetric1.BackColor = System.Drawing.Color.White;
            this.lblMetric1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMetric1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.lblMetric1.Location = new System.Drawing.Point(0, 0);
            this.lblMetric1.Name = "lblMetric1";
            this.lblMetric1.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.lblMetric1.Size = new System.Drawing.Size(226, 70);
            this.lblMetric1.TabIndex = 0;
            // 
            // lblMetric2
            // 
            this.lblMetric2.BackColor = System.Drawing.Color.White;
            this.lblMetric2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMetric2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.lblMetric2.Location = new System.Drawing.Point(238, 0);
            this.lblMetric2.Name = "lblMetric2";
            this.lblMetric2.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.lblMetric2.Size = new System.Drawing.Size(226, 70);
            this.lblMetric2.TabIndex = 1;
            // 
            // lblMetric3
            // 
            this.lblMetric3.BackColor = System.Drawing.Color.White;
            this.lblMetric3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMetric3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.lblMetric3.Location = new System.Drawing.Point(476, 0);
            this.lblMetric3.Name = "lblMetric3";
            this.lblMetric3.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.lblMetric3.Size = new System.Drawing.Size(226, 70);
            this.lblMetric3.TabIndex = 2;
            // 
            // lblMetric4
            // 
            this.lblMetric4.BackColor = System.Drawing.Color.White;
            this.lblMetric4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMetric4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.lblMetric4.Location = new System.Drawing.Point(714, 0);
            this.lblMetric4.Name = "lblMetric4";
            this.lblMetric4.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.lblMetric4.Size = new System.Drawing.Size(226, 70);
            this.lblMetric4.TabIndex = 3;
            // 
            // heroPanel
            // 
            this.heroPanel.BackColor = System.Drawing.Color.White;
            this.heroPanel.Controls.Add(this.lblHeroText);
            this.heroPanel.Controls.Add(this.lblHeroTitle);
            this.heroPanel.Controls.Add(this.accentPanel);
            this.heroPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.heroPanel.Location = new System.Drawing.Point(24, 24);
            this.heroPanel.Name = "heroPanel";
            this.heroPanel.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.heroPanel.Size = new System.Drawing.Size(952, 90);
            this.heroPanel.TabIndex = 3;
            // 
            // lblHeroText
            // 
            this.lblHeroText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeroText.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHeroText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(132)))));
            this.lblHeroText.Location = new System.Drawing.Point(26, 52);
            this.lblHeroText.Name = "lblHeroText";
            this.lblHeroText.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblHeroText.Size = new System.Drawing.Size(906, 22);
            this.lblHeroText.TabIndex = 0;
            this.lblHeroText.Text = "Ordena temas, ponentes, salas y horarios para que nadie llegue perdido.";
            // 
            // lblHeroTitle
            // 
            this.lblHeroTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeroTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.lblHeroTitle.Location = new System.Drawing.Point(26, 16);
            this.lblHeroTitle.Name = "lblHeroTitle";
            this.lblHeroTitle.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblHeroTitle.Size = new System.Drawing.Size(906, 36);
            this.lblHeroTitle.TabIndex = 1;
            this.lblHeroTitle.Text = "La agenda debe ser facil de seguir.";
            // 
            // accentPanel
            // 
            this.accentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(184)))), ((int)(((byte)(166)))));
            this.accentPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.accentPanel.Location = new System.Drawing.Point(20, 16);
            this.accentPanel.Name = "accentPanel";
            this.accentPanel.Size = new System.Drawing.Size(6, 58);
            this.accentPanel.TabIndex = 2;
            // 
            // ConferenciasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.pagePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ConferenciasForm";
            this.Text = "Conferencias";
            this.pagePanel.ResumeLayout(false);
            this.groupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.topLayout.ResumeLayout(false);
            this.groupForm.ResumeLayout(false);
            this.groupForm.PerformLayout();
            this.groupStatus.ResumeLayout(false);
            this.metricsPanel.ResumeLayout(false);
            this.heroPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel pagePanel, heroPanel, accentPanel, metricsPanel;
        private System.Windows.Forms.TableLayoutPanel topLayout;
        private System.Windows.Forms.GroupBox groupForm, groupStatus, groupList;
        private System.Windows.Forms.Label lblHeroTitle, lblHeroText, lblMetric1, lblMetric2, lblMetric3, lblMetric4;
        private System.Windows.Forms.Label lblField1, lblField2, lblField3, lblField4, lblField5;
        private System.Windows.Forms.Label lblProgress1, lblProgress2, lblProgress3, lblProgress4;
        private System.Windows.Forms.TextBox txtField1, txtField2, txtField3, txtField5;
        private System.Windows.Forms.ComboBox cboField4;
        private System.Windows.Forms.Button btnPrimary, btnSecondary;
        private System.Windows.Forms.ProgressBar progress1, progress2, progress3, progress4;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1, col2, col3, col4, col5, col6;
    }
}
