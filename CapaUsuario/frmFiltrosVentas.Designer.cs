namespace CapaUsuario
{
    partial class frmFiltrosVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltrosVentas));
            panel2 = new Panel();
            btnFiltrarSemana = new Button();
            dtpFiltrarSemana = new DateTimePicker();
            label3 = new Label();
            btnFiltrarAño = new Button();
            btnFiltrarDia = new Button();
            btnFiltrarMesAño = new Button();
            dtpFiltrarAño = new DateTimePicker();
            label2 = new Label();
            dtpAño = new DateTimePicker();
            cbMes = new ComboBox();
            label1 = new Label();
            dtpFiltrarDia = new DateTimePicker();
            label14 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = CapaUsuario.Properties.Resources.pxfuel;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(btnFiltrarSemana);
            panel2.Controls.Add(dtpFiltrarSemana);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnFiltrarAño);
            panel2.Controls.Add(btnFiltrarDia);
            panel2.Controls.Add(btnFiltrarMesAño);
            panel2.Controls.Add(dtpFiltrarAño);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dtpAño);
            panel2.Controls.Add(cbMes);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dtpFiltrarDia);
            panel2.Controls.Add(label14);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(354, 376);
            panel2.TabIndex = 0;
            // 
            // btnFiltrarSemana
            // 
            btnFiltrarSemana.BackColor = Color.White;
            btnFiltrarSemana.Cursor = Cursors.Hand;
            btnFiltrarSemana.Font = new Font("Georgia", 9.75F);
            btnFiltrarSemana.Location = new Point(275, 127);
            btnFiltrarSemana.Name = "btnFiltrarSemana";
            btnFiltrarSemana.Size = new Size(66, 26);
            btnFiltrarSemana.TabIndex = 34;
            btnFiltrarSemana.Text = "Aplicar";
            btnFiltrarSemana.UseVisualStyleBackColor = false;
            btnFiltrarSemana.Click += btnFiltrarSemana_Click;
            // 
            // dtpFiltrarSemana
            // 
            dtpFiltrarSemana.Cursor = Cursors.Hand;
            dtpFiltrarSemana.Font = new Font("Georgia", 9F);
            dtpFiltrarSemana.Location = new Point(12, 130);
            dtpFiltrarSemana.Name = "dtpFiltrarSemana";
            dtpFiltrarSemana.Size = new Size(260, 21);
            dtpFiltrarSemana.TabIndex = 33;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9.75F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 107);
            label3.Name = "label3";
            label3.Size = new Size(133, 16);
            label3.TabIndex = 32;
            label3.Text = "Mostrar semana del:";
            // 
            // btnFiltrarAño
            // 
            btnFiltrarAño.BackColor = Color.White;
            btnFiltrarAño.Cursor = Cursors.Hand;
            btnFiltrarAño.Font = new Font("Georgia", 9.75F);
            btnFiltrarAño.Location = new Point(275, 321);
            btnFiltrarAño.Name = "btnFiltrarAño";
            btnFiltrarAño.Size = new Size(66, 26);
            btnFiltrarAño.TabIndex = 31;
            btnFiltrarAño.Text = "Aplicar";
            btnFiltrarAño.UseVisualStyleBackColor = false;
            btnFiltrarAño.Click += btnFiltrarAño_Click;
            // 
            // btnFiltrarDia
            // 
            btnFiltrarDia.BackColor = Color.White;
            btnFiltrarDia.Cursor = Cursors.Hand;
            btnFiltrarDia.Font = new Font("Georgia", 9.75F);
            btnFiltrarDia.Location = new Point(275, 41);
            btnFiltrarDia.Name = "btnFiltrarDia";
            btnFiltrarDia.Size = new Size(66, 26);
            btnFiltrarDia.TabIndex = 30;
            btnFiltrarDia.Text = "Aplicar";
            btnFiltrarDia.UseVisualStyleBackColor = false;
            btnFiltrarDia.Click += btnFiltrarDia_Click;
            // 
            // btnFiltrarMesAño
            // 
            btnFiltrarMesAño.BackColor = Color.White;
            btnFiltrarMesAño.Cursor = Cursors.Hand;
            btnFiltrarMesAño.Font = new Font("Georgia", 9.75F);
            btnFiltrarMesAño.Location = new Point(275, 223);
            btnFiltrarMesAño.Name = "btnFiltrarMesAño";
            btnFiltrarMesAño.Size = new Size(66, 26);
            btnFiltrarMesAño.TabIndex = 29;
            btnFiltrarMesAño.Text = "Aplicar";
            btnFiltrarMesAño.UseVisualStyleBackColor = false;
            btnFiltrarMesAño.Click += btnFiltrarMesAño_Click;
            // 
            // dtpFiltrarAño
            // 
            dtpFiltrarAño.CalendarFont = new Font("Georgia", 12F);
            dtpFiltrarAño.Cursor = Cursors.Hand;
            dtpFiltrarAño.CustomFormat = "yyyy";
            dtpFiltrarAño.Font = new Font("Georgia", 9.75F);
            dtpFiltrarAño.Format = DateTimePickerFormat.Custom;
            dtpFiltrarAño.Location = new Point(12, 325);
            dtpFiltrarAño.Name = "dtpFiltrarAño";
            dtpFiltrarAño.ShowUpDown = true;
            dtpFiltrarAño.Size = new Size(260, 22);
            dtpFiltrarAño.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9.75F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 293);
            label2.Name = "label2";
            label2.Size = new Size(112, 16);
            label2.TabIndex = 27;
            label2.Text = "Mostrar por año:";
            label2.Click += label2_Click;
            // 
            // dtpAño
            // 
            dtpAño.CalendarFont = new Font("Georgia", 12F);
            dtpAño.Cursor = Cursors.Hand;
            dtpAño.CustomFormat = "yyyy";
            dtpAño.Font = new Font("Georgia", 9.75F);
            dtpAño.Format = DateTimePickerFormat.Custom;
            dtpAño.Location = new Point(215, 227);
            dtpAño.Name = "dtpAño";
            dtpAño.ShowUpDown = true;
            dtpAño.Size = new Size(57, 22);
            dtpAño.TabIndex = 26;
            // 
            // cbMes
            // 
            cbMes.Cursor = Cursors.Hand;
            cbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMes.Font = new Font("Georgia", 9.75F);
            cbMes.FormattingEnabled = true;
            cbMes.Location = new Point(12, 226);
            cbMes.Name = "cbMes";
            cbMes.Size = new Size(197, 24);
            cbMes.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 9.75F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 203);
            label1.Name = "label1";
            label1.Size = new Size(151, 16);
            label1.TabIndex = 16;
            label1.Text = "Mostrar por mes y año:";
            // 
            // dtpFiltrarDia
            // 
            dtpFiltrarDia.Cursor = Cursors.Hand;
            dtpFiltrarDia.Font = new Font("Georgia", 9F);
            dtpFiltrarDia.Location = new Point(12, 44);
            dtpFiltrarDia.Name = "dtpFiltrarDia";
            dtpFiltrarDia.Size = new Size(260, 21);
            dtpFiltrarDia.TabIndex = 15;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Georgia", 9.75F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(12, 21);
            label14.Name = "label14";
            label14.Size = new Size(83, 16);
            label14.TabIndex = 14;
            label14.Text = "Mostrar día:";
            // 
            // frmFiltrosVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 376);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmFiltrosVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cambiar fecha";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label label1;
        private DateTimePicker dtpFiltrarDia;
        private Label label14;
        private DateTimePicker dtpFiltrarAño;
        private Label label2;
        private DateTimePicker dtpAño;
        private ComboBox cbMes;
        private Button btnFiltrarMesAño;
        private Button btnFiltrarAño;
        private Button btnFiltrarDia;
        private Button btnFiltrarSemana;
        private DateTimePicker dtpFiltrarSemana;
        private Label label3;
    }
}