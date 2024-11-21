namespace CapaUsuario
{
    partial class frmVentas
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel2 = new Panel();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            lbGanancias = new Label();
            label19 = new Label();
            label21 = new Label();
            label14 = new Label();
            lb = new Label();
            lbTotalGastado = new Label();
            label15 = new Label();
            lbTotalVendido = new Label();
            label16 = new Label();
            btnRegistrarVenta = new Button();
            gbVentas = new GroupBox();
            lbQuirarBusqueda = new Label();
            lbImportarExcel = new Label();
            pbBotonExcel = new PictureBox();
            lbRestablecerFecha = new Label();
            lbCambiarFecha = new Label();
            pbBotonRestablecerFecha = new PictureBox();
            pbBotonBuscarFecha = new PictureBox();
            pbBotonQuitarBusqueda = new PictureBox();
            pictureBox1 = new PictureBox();
            tbBuscarProducto = new TextBox();
            dgvVentas = new DataGridView();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            gbVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonExcel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonRestablecerFecha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonBuscarFecha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(btnRegistrarVenta);
            panel2.Controls.Add(gbVentas);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1024, 560);
            panel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(lbGanancias);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(label21);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(lb);
            panel1.Controls.Add(lbTotalGastado);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(lbTotalVendido);
            panel1.Controls.Add(label16);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 512);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 46);
            panel1.TabIndex = 21;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox2.BackgroundImage = CapaUsuario.Properties.Resources.business_color_money_coins_icon_icons_com_53446;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(680, 8);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 33);
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // lbGanancias
            // 
            lbGanancias.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbGanancias.AutoSize = true;
            lbGanancias.BackColor = Color.Transparent;
            lbGanancias.Font = new Font("Georgia", 18F);
            lbGanancias.ForeColor = Color.White;
            lbGanancias.Location = new Point(873, 7);
            lbGanancias.Name = "lbGanancias";
            lbGanancias.Size = new Size(64, 29);
            lbGanancias.TabIndex = 20;
            lbGanancias.Text = "0.00";
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label19.AutoSize = true;
            label19.BackColor = Color.Transparent;
            label19.Font = new Font("Georgia", 14.25F);
            label19.ForeColor = Color.White;
            label19.Location = new Point(726, 11);
            label19.Name = "label19";
            label19.Size = new Size(118, 23);
            label19.TabIndex = 18;
            label19.Text = "GANANCIA:";
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Georgia", 18F, FontStyle.Bold);
            label21.ForeColor = Color.White;
            label21.Location = new Point(850, 8);
            label21.Name = "label21";
            label21.Size = new Size(28, 29);
            label21.TabIndex = 19;
            label21.Text = "$";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.AutoSize = true;
            label14.Font = new Font("Georgia", 12F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(467, 16);
            label14.Name = "label14";
            label14.Size = new Size(112, 18);
            label14.TabIndex = 13;
            label14.Text = "Total Gastado:";
            // 
            // lb
            // 
            lb.Anchor = AnchorStyles.None;
            lb.AutoSize = true;
            lb.Font = new Font("Georgia", 12F);
            lb.ForeColor = Color.White;
            lb.Location = new Point(244, 16);
            lb.Name = "lb";
            lb.Size = new Size(110, 18);
            lb.TabIndex = 11;
            lb.Text = "Total vendido:";
            // 
            // lbTotalGastado
            // 
            lbTotalGastado.Anchor = AnchorStyles.None;
            lbTotalGastado.AutoSize = true;
            lbTotalGastado.Font = new Font("Georgia", 12F);
            lbTotalGastado.ForeColor = Color.White;
            lbTotalGastado.Location = new Point(593, 16);
            lbTotalGastado.Name = "lbTotalGastado";
            lbTotalGastado.Size = new Size(42, 18);
            lbTotalGastado.TabIndex = 17;
            lbTotalGastado.Text = "0.00";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.None;
            label15.AutoSize = true;
            label15.Font = new Font("Georgia", 12F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(358, 16);
            label15.Name = "label15";
            label15.Size = new Size(17, 18);
            label15.TabIndex = 14;
            label15.Text = "$";
            // 
            // lbTotalVendido
            // 
            lbTotalVendido.Anchor = AnchorStyles.None;
            lbTotalVendido.AutoSize = true;
            lbTotalVendido.Font = new Font("Georgia", 12F);
            lbTotalVendido.ForeColor = Color.White;
            lbTotalVendido.Location = new Point(373, 16);
            lbTotalVendido.Name = "lbTotalVendido";
            lbTotalVendido.Size = new Size(42, 18);
            lbTotalVendido.TabIndex = 16;
            lbTotalVendido.Text = "0.00";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.None;
            label16.AutoSize = true;
            label16.Font = new Font("Georgia", 12F);
            label16.ForeColor = Color.White;
            label16.Location = new Point(578, 16);
            label16.Name = "label16";
            label16.Size = new Size(17, 18);
            label16.TabIndex = 15;
            label16.Text = "$";
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRegistrarVenta.BackColor = Color.White;
            btnRegistrarVenta.Cursor = Cursors.Hand;
            btnRegistrarVenta.Font = new Font("Georgia", 9.75F);
            btnRegistrarVenta.Location = new Point(405, 12);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(248, 31);
            btnRegistrarVenta.TabIndex = 15;
            btnRegistrarVenta.Text = "Registrar nuevas ventas";
            btnRegistrarVenta.UseVisualStyleBackColor = false;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // gbVentas
            // 
            gbVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbVentas.BackColor = Color.Transparent;
            gbVentas.BackgroundImageLayout = ImageLayout.Stretch;
            gbVentas.Controls.Add(lbQuirarBusqueda);
            gbVentas.Controls.Add(lbImportarExcel);
            gbVentas.Controls.Add(pbBotonExcel);
            gbVentas.Controls.Add(lbRestablecerFecha);
            gbVentas.Controls.Add(lbCambiarFecha);
            gbVentas.Controls.Add(pbBotonRestablecerFecha);
            gbVentas.Controls.Add(pbBotonBuscarFecha);
            gbVentas.Controls.Add(pbBotonQuitarBusqueda);
            gbVentas.Controls.Add(pictureBox1);
            gbVentas.Controls.Add(tbBuscarProducto);
            gbVentas.Controls.Add(dgvVentas);
            gbVentas.Font = new Font("Georgia", 14.25F, FontStyle.Bold);
            gbVentas.Location = new Point(10, 48);
            gbVentas.Name = "gbVentas";
            gbVentas.Padding = new Padding(5);
            gbVentas.Size = new Size(998, 456);
            gbVentas.TabIndex = 11;
            gbVentas.TabStop = false;
            gbVentas.Text = "VENTAS DE ESTA SEMANA";
            // 
            // lbQuirarBusqueda
            // 
            lbQuirarBusqueda.AutoSize = true;
            lbQuirarBusqueda.Font = new Font("Georgia", 8.25F);
            lbQuirarBusqueda.Location = new Point(364, 65);
            lbQuirarBusqueda.Name = "lbQuirarBusqueda";
            lbQuirarBusqueda.Size = new Size(103, 14);
            lbQuirarBusqueda.TabIndex = 44;
            lbQuirarBusqueda.Text = "Quitar busqueda";
            lbQuirarBusqueda.Visible = false;
            // 
            // lbImportarExcel
            // 
            lbImportarExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbImportarExcel.AutoSize = true;
            lbImportarExcel.Font = new Font("Georgia", 9F);
            lbImportarExcel.Location = new Point(874, 88);
            lbImportarExcel.Name = "lbImportarExcel";
            lbImportarExcel.Size = new Size(102, 15);
            lbImportarExcel.TabIndex = 42;
            lbImportarExcel.Text = "Importar a excel";
            // 
            // pbBotonExcel
            // 
            pbBotonExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbBotonExcel.BackColor = Color.Transparent;
            pbBotonExcel.BackgroundImage = CapaUsuario.Properties.Resources.microsoft_excel_macos_bigsur_icon_189980;
            pbBotonExcel.BackgroundImageLayout = ImageLayout.Zoom;
            pbBotonExcel.Cursor = Cursors.Hand;
            pbBotonExcel.Location = new Point(891, 40);
            pbBotonExcel.Name = "pbBotonExcel";
            pbBotonExcel.Size = new Size(67, 45);
            pbBotonExcel.TabIndex = 41;
            pbBotonExcel.TabStop = false;
            pbBotonExcel.Click += pbBotonExcel_Click;
            // 
            // lbRestablecerFecha
            // 
            lbRestablecerFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRestablecerFecha.AutoSize = true;
            lbRestablecerFecha.Font = new Font("Georgia", 9F);
            lbRestablecerFecha.Location = new Point(759, 88);
            lbRestablecerFecha.Name = "lbRestablecerFecha";
            lbRestablecerFecha.Size = new Size(107, 15);
            lbRestablecerFecha.TabIndex = 34;
            lbRestablecerFecha.Text = "Restablecer fecha";
            lbRestablecerFecha.Visible = false;
            // 
            // lbCambiarFecha
            // 
            lbCambiarFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbCambiarFecha.AutoSize = true;
            lbCambiarFecha.Font = new Font("Georgia", 9F);
            lbCambiarFecha.Location = new Point(767, 88);
            lbCambiarFecha.Name = "lbCambiarFecha";
            lbCambiarFecha.Size = new Size(92, 15);
            lbCambiarFecha.TabIndex = 33;
            lbCambiarFecha.Text = "Cambiar fecha";
            // 
            // pbBotonRestablecerFecha
            // 
            pbBotonRestablecerFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbBotonRestablecerFecha.BackColor = Color.Transparent;
            pbBotonRestablecerFecha.BackgroundImage = CapaUsuario.Properties.Resources.calendar_remove_icon_242208__1_;
            pbBotonRestablecerFecha.BackgroundImageLayout = ImageLayout.Zoom;
            pbBotonRestablecerFecha.Cursor = Cursors.Hand;
            pbBotonRestablecerFecha.Enabled = false;
            pbBotonRestablecerFecha.Location = new Point(777, 37);
            pbBotonRestablecerFecha.Name = "pbBotonRestablecerFecha";
            pbBotonRestablecerFecha.Size = new Size(67, 48);
            pbBotonRestablecerFecha.TabIndex = 32;
            pbBotonRestablecerFecha.TabStop = false;
            pbBotonRestablecerFecha.Visible = false;
            pbBotonRestablecerFecha.Click += pbBotonRestablecerFecha_Click;
            // 
            // pbBotonBuscarFecha
            // 
            pbBotonBuscarFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbBotonBuscarFecha.BackColor = Color.Transparent;
            pbBotonBuscarFecha.BackgroundImage = CapaUsuario.Properties.Resources.gui_calendar_icon_157199__1_;
            pbBotonBuscarFecha.BackgroundImageLayout = ImageLayout.Zoom;
            pbBotonBuscarFecha.Cursor = Cursors.Hand;
            pbBotonBuscarFecha.Location = new Point(790, 41);
            pbBotonBuscarFecha.Name = "pbBotonBuscarFecha";
            pbBotonBuscarFecha.Size = new Size(44, 43);
            pbBotonBuscarFecha.TabIndex = 31;
            pbBotonBuscarFecha.TabStop = false;
            pbBotonBuscarFecha.Click += pictureBox2_Click;
            // 
            // pbBotonQuitarBusqueda
            // 
            pbBotonQuitarBusqueda.BackColor = Color.Transparent;
            pbBotonQuitarBusqueda.BackgroundImage = CapaUsuario.Properties.Resources.filter_remove_icon_242410;
            pbBotonQuitarBusqueda.BackgroundImageLayout = ImageLayout.Zoom;
            pbBotonQuitarBusqueda.Cursor = Cursors.Hand;
            pbBotonQuitarBusqueda.Enabled = false;
            pbBotonQuitarBusqueda.Location = new Point(395, 33);
            pbBotonQuitarBusqueda.Name = "pbBotonQuitarBusqueda";
            pbBotonQuitarBusqueda.Size = new Size(42, 30);
            pbBotonQuitarBusqueda.TabIndex = 30;
            pbBotonQuitarBusqueda.TabStop = false;
            pbBotonQuitarBusqueda.Visible = false;
            pbBotonQuitarBusqueda.Click += pbBotonQuitarBusqueda_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = CapaUsuario.Properties.Resources.game_magnifying_glass_tools_search_magnifier_zoom_find_controller_icon_262440;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(18, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 31);
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // tbBuscarProducto
            // 
            tbBuscarProducto.Font = new Font("Georgia", 9.75F);
            tbBuscarProducto.Location = new Point(66, 60);
            tbBuscarProducto.Name = "tbBuscarProducto";
            tbBuscarProducto.Size = new Size(293, 22);
            tbBuscarProducto.TabIndex = 23;
            tbBuscarProducto.KeyDown += tbBuscarProducto_KeyDown;
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            dgvVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Georgia", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Cursor = Cursors.Hand;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Georgia", 9.75F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvVentas.DefaultCellStyle = dataGridViewCellStyle6;
            dgvVentas.Location = new Point(20, 119);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(959, 323);
            dgvVentas.TabIndex = 12;
            dgvVentas.CellDoubleClick += dgvVentas_CellDoubleClick;
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 560);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            gbVentas.ResumeLayout(false);
            gbVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonExcel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonRestablecerFecha).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonBuscarFecha).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private GroupBox gbVentas;
        private Label lbTotalGastado;
        private Label lbTotalVendido;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label lb;
        private Label lbGanancias;
        private Label label21;
        private Label label19;
        private Button btnRegistrarVenta;
        private DataGridView dgvVentas;
        private TextBox tbBuscarProducto;
        private PictureBox pictureBox1;
        private PictureBox pbBotonQuitarBusqueda;
        private PictureBox pbBotonRestablecerFecha;
        private PictureBox pbBotonBuscarFecha;
        private Label lbCambiarFecha;
        private Label lbRestablecerFecha;
        private Label lbImportarExcel;
        private PictureBox pbBotonExcel;
        private Label lbQuirarBusqueda;
        private Panel panel1;
        private DataGridViewTextBoxColumn idVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadVendidaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private PictureBox pictureBox2;
    }
}