namespace CapaUsuario
{
    partial class frmRegistrarVenta
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarVenta));
            panel2 = new Panel();
            panel1 = new Panel();
            lbVentas = new Label();
            label9 = new Label();
            label5 = new Label();
            label6 = new Label();
            tbIdVenta = new TextBox();
            btnRegistrarVenta = new Button();
            dtpFechaVenta = new DateTimePicker();
            label4 = new Label();
            label7 = new Label();
            tbCantidadDisponible = new TextBox();
            ndCantidadVendida = new NumericUpDown();
            label3 = new Label();
            tbPrecioVenta = new TextBox();
            label1 = new Label();
            label8 = new Label();
            cbProducto = new ComboBox();
            label2 = new Label();
            panel3 = new Panel();
            groupBox2 = new GroupBox();
            lbQuirarBusqueda = new Label();
            pbBotonQuitarBusqueda = new PictureBox();
            pictureBox1 = new PictureBox();
            dgvProductos = new DataGridView();
            tbBuscarProducto = new TextBox();
            groupBox1 = new GroupBox();
            dgvVentas = new DataGridView();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ndCantidadVendida).BeginInit();
            panel3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.SeaGreen;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(tbIdVenta);
            panel2.Controls.Add(btnRegistrarVenta);
            panel2.Controls.Add(dtpFechaVenta);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(tbCantidadDisponible);
            panel2.Controls.Add(ndCantidadVendida);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(tbPrecioVenta);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(cbProducto);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(283, 641);
            panel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lbVentas);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label5);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(17, 425);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 198);
            panel1.TabIndex = 25;
            // 
            // lbVentas
            // 
            lbVentas.Anchor = AnchorStyles.None;
            lbVentas.AutoSize = true;
            lbVentas.Font = new Font("Georgia", 18F);
            lbVentas.Location = new Point(72, 100);
            lbVentas.Name = "lbVentas";
            lbVentas.Size = new Size(64, 29);
            lbVentas.TabIndex = 11;
            lbVentas.Text = "0.00";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Georgia", 18F, FontStyle.Bold);
            label9.Location = new Point(45, 101);
            label9.Name = "label9";
            label9.Size = new Size(28, 29);
            label9.TabIndex = 10;
            label9.Text = "$";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 11.25F, FontStyle.Bold);
            label5.Location = new Point(47, 71);
            label5.Name = "label5";
            label5.Size = new Size(153, 18);
            label5.TabIndex = 9;
            label5.Text = "TOTAL VENDIDO:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(14, 4);
            label6.Name = "label6";
            label6.Size = new Size(255, 18);
            label6.TabIndex = 8;
            label6.Text = "INFORMACIÓN DE LA VENTA";
            // 
            // tbIdVenta
            // 
            tbIdVenta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbIdVenta.Enabled = false;
            tbIdVenta.Location = new Point(83, 29);
            tbIdVenta.Name = "tbIdVenta";
            tbIdVenta.Size = new Size(17, 23);
            tbIdVenta.TabIndex = 11;
            tbIdVenta.Visible = false;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRegistrarVenta.BackColor = Color.White;
            btnRegistrarVenta.Cursor = Cursors.Hand;
            btnRegistrarVenta.Font = new Font("Georgia", 12F);
            btnRegistrarVenta.Location = new Point(17, 336);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(247, 59);
            btnRegistrarVenta.TabIndex = 24;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.UseVisualStyleBackColor = false;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // dtpFechaVenta
            // 
            dtpFechaVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaVenta.CalendarFont = new Font("Georgia", 9.75F);
            dtpFechaVenta.Cursor = Cursors.Hand;
            dtpFechaVenta.Font = new Font("Georgia", 9F);
            dtpFechaVenta.Location = new Point(19, 209);
            dtpFechaVenta.Name = "dtpFechaVenta";
            dtpFechaVenta.Size = new Size(246, 21);
            dtpFechaVenta.TabIndex = 23;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(19, 188);
            label4.Name = "label4";
            label4.Size = new Size(136, 18);
            label4.TabIndex = 22;
            label4.Text = "Fecha de la venta:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Georgia", 9.75F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(107, 31);
            label7.Name = "label7";
            label7.Size = new Size(81, 16);
            label7.TabIndex = 21;
            label7.Text = "Existencias:";
            label7.Visible = false;
            // 
            // tbCantidadDisponible
            // 
            tbCantidadDisponible.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbCantidadDisponible.Font = new Font("Georgia", 9.75F);
            tbCantidadDisponible.Location = new Point(194, 28);
            tbCantidadDisponible.Name = "tbCantidadDisponible";
            tbCantidadDisponible.Size = new Size(63, 22);
            tbCantidadDisponible.TabIndex = 20;
            tbCantidadDisponible.Visible = false;
            // 
            // ndCantidadVendida
            // 
            ndCantidadVendida.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ndCantidadVendida.Cursor = Cursors.Hand;
            ndCantidadVendida.Font = new Font("Georgia", 9.75F);
            ndCantidadVendida.Location = new Point(18, 287);
            ndCantidadVendida.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            ndCantidadVendida.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ndCantidadVendida.Name = "ndCantidadVendida";
            ndCantidadVendida.Size = new Size(247, 22);
            ndCantidadVendida.TabIndex = 19;
            ndCantidadVendida.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(18, 265);
            label3.Name = "label3";
            label3.Size = new Size(136, 18);
            label3.TabIndex = 18;
            label3.Text = "Cantidad vendida:";
            // 
            // tbPrecioVenta
            // 
            tbPrecioVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPrecioVenta.Enabled = false;
            tbPrecioVenta.Font = new Font("Georgia", 9.75F);
            tbPrecioVenta.Location = new Point(18, 136);
            tbPrecioVenta.Name = "tbPrecioVenta";
            tbPrecioVenta.Size = new Size(63, 22);
            tbPrecioVenta.TabIndex = 17;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(18, 115);
            label1.Name = "label1";
            label1.Size = new Size(57, 18);
            label1.TabIndex = 16;
            label1.Text = "Precio:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Enabled = false;
            label8.Font = new Font("Georgia", 9.75F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(19, 32);
            label8.Name = "label8";
            label8.Size = new Size(63, 16);
            label8.TabIndex = 12;
            label8.Text = "Id venta:";
            label8.Visible = false;
            // 
            // cbProducto
            // 
            cbProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProducto.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbProducto.DropDownStyle = ComboBoxStyle.Simple;
            cbProducto.Font = new Font("Georgia", 9.75F);
            cbProducto.FormattingEnabled = true;
            cbProducto.Location = new Point(18, 73);
            cbProducto.Name = "cbProducto";
            cbProducto.Size = new Size(246, 24);
            cbProducto.TabIndex = 3;
            cbProducto.SelectedIndexChanged += cbProducto_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(18, 52);
            label2.Name = "label2";
            label2.Size = new Size(77, 18);
            label2.TabIndex = 2;
            label2.Text = "Producto:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(groupBox2);
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(283, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(801, 641);
            panel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(lbQuirarBusqueda);
            groupBox2.Controls.Add(pbBotonQuitarBusqueda);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(dgvProductos);
            groupBox2.Controls.Add(tbBuscarProducto);
            groupBox2.Font = new Font("Georgia", 12F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(773, 294);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            groupBox2.Text = "SELECCIONE UN PRODUCTO";
            // 
            // lbQuirarBusqueda
            // 
            lbQuirarBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbQuirarBusqueda.AutoSize = true;
            lbQuirarBusqueda.Font = new Font("Georgia", 9F);
            lbQuirarBusqueda.Location = new Point(655, 45);
            lbQuirarBusqueda.Name = "lbQuirarBusqueda";
            lbQuirarBusqueda.Size = new Size(104, 15);
            lbQuirarBusqueda.TabIndex = 45;
            lbQuirarBusqueda.Text = "Quitar busqueda";
            lbQuirarBusqueda.Visible = false;
            // 
            // pbBotonQuitarBusqueda
            // 
            pbBotonQuitarBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbBotonQuitarBusqueda.BackColor = Color.Transparent;
            pbBotonQuitarBusqueda.BackgroundImage = CapaUsuario.Properties.Resources.filter_remove_icon_242410;
            pbBotonQuitarBusqueda.BackgroundImageLayout = ImageLayout.Zoom;
            pbBotonQuitarBusqueda.Cursor = Cursors.Hand;
            pbBotonQuitarBusqueda.Location = new Point(683, 15);
            pbBotonQuitarBusqueda.Name = "pbBotonQuitarBusqueda";
            pbBotonQuitarBusqueda.Size = new Size(42, 31);
            pbBotonQuitarBusqueda.TabIndex = 30;
            pbBotonQuitarBusqueda.TabStop = false;
            pbBotonQuitarBusqueda.Visible = false;
            pbBotonQuitarBusqueda.Click += pbBotonQuitarBusqueda_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = CapaUsuario.Properties.Resources.game_magnifying_glass_tools_search_magnifier_zoom_find_controller_icon_262440;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(315, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 31);
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.Location = new Point(12, 68);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(749, 210);
            dgvProductos.TabIndex = 18;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // tbBuscarProducto
            // 
            tbBuscarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbBuscarProducto.Font = new Font("Georgia", 9.75F);
            tbBuscarProducto.Location = new Point(359, 28);
            tbBuscarProducto.Name = "tbBuscarProducto";
            tbBuscarProducto.Size = new Size(293, 22);
            tbBuscarProducto.TabIndex = 20;
            tbBuscarProducto.KeyDown += tbBuscarProducto_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dgvVentas);
            groupBox1.Font = new Font("Georgia", 12F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 314);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(773, 311);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "VENTAS DE ESTE DÍA";
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.White;
            dgvVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Georgia", 9F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Cursor = Cursors.Hand;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Georgia", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvVentas.DefaultCellStyle = dataGridViewCellStyle5;
            dgvVentas.Location = new Point(12, 35);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(749, 257);
            dgvVentas.TabIndex = 23;
            dgvVentas.CellDoubleClick += dgvVentas_CellDoubleClick;
            // 
            // frmRegistrarVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 641);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmRegistrarVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar ventas";
            WindowState = FormWindowState.Maximized;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ndCantidadVendida).EndInit();
            panel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panel3;
        private ComboBox cbProducto;
        private Label label2;
        private Label label8;
        private TextBox tbIdVenta;
        private TextBox tbPrecioVenta;
        private Label label1;
        private NumericUpDown ndCantidadVendida;
        private Label label3;
        private Label label7;
        private TextBox tbCantidadDisponible;
        private DateTimePicker dtpFechaVenta;
        private Label label4;
        private Button btnRegistrarVenta;
        private TextBox tbBuscarProducto;
        private DataGridView dgvProductos;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private DataGridView dgvVentas;
        private Label label6;
        private Panel panel1;
        private Label lbVentas;
        private Label label9;
        private Label label5;
        private DataGridViewTextBoxColumn idVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cantidadVendidaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreCategoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDisponibleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idCategoriaDataGridViewTextBoxColumn;
        private PictureBox pictureBox1;
        private PictureBox pbBotonQuitarBusqueda;
        private Label lbQuirarBusqueda;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
    }
}