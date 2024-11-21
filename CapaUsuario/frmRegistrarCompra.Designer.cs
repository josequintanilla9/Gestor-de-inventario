namespace CapaUsuario
{
    partial class frmRegistrarCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarCompra));
            panel2 = new Panel();
            panel1 = new Panel();
            lbCompras = new Label();
            label9 = new Label();
            label5 = new Label();
            label6 = new Label();
            tbIdCompra = new TextBox();
            btnRegistrarCompra = new Button();
            dtpFechaCompra = new DateTimePicker();
            label4 = new Label();
            label7 = new Label();
            tbCantidadDisponible = new TextBox();
            ndCantidadComprada = new NumericUpDown();
            label3 = new Label();
            tbPrecioCompra = new TextBox();
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
            dgvCompras = new DataGridView();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ndCantidadComprada).BeginInit();
            panel3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.DimGray;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(tbIdCompra);
            panel2.Controls.Add(btnRegistrarCompra);
            panel2.Controls.Add(dtpFechaCompra);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(tbCantidadDisponible);
            panel2.Controls.Add(ndCantidadComprada);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(tbPrecioCompra);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(cbProducto);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(283, 641);
            panel2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lbCompras);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label5);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(16, 425);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 198);
            panel1.TabIndex = 26;
            // 
            // lbCompras
            // 
            lbCompras.Anchor = AnchorStyles.None;
            lbCompras.AutoSize = true;
            lbCompras.Font = new Font("Georgia", 18F);
            lbCompras.Location = new Point(65, 98);
            lbCompras.Name = "lbCompras";
            lbCompras.Size = new Size(64, 29);
            lbCompras.TabIndex = 11;
            lbCompras.Text = "0.00";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Georgia", 18F, FontStyle.Bold);
            label9.Location = new Point(38, 99);
            label9.Name = "label9";
            label9.Size = new Size(28, 29);
            label9.TabIndex = 10;
            label9.Text = "$";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 12F, FontStyle.Bold);
            label5.Location = new Point(34, 71);
            label5.Name = "label5";
            label5.Size = new Size(177, 18);
            label5.TabIndex = 9;
            label5.Text = "TOTAL COMPRADO:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(9, 4);
            label6.Name = "label6";
            label6.Size = new Size(269, 18);
            label6.TabIndex = 8;
            label6.Text = "INFORMACIÓN DE LA COMPRA";
            // 
            // tbIdCompra
            // 
            tbIdCompra.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbIdCompra.Enabled = false;
            tbIdCompra.Location = new Point(86, 29);
            tbIdCompra.Name = "tbIdCompra";
            tbIdCompra.Size = new Size(17, 23);
            tbIdCompra.TabIndex = 11;
            tbIdCompra.Visible = false;
            // 
            // btnRegistrarCompra
            // 
            btnRegistrarCompra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRegistrarCompra.BackColor = Color.White;
            btnRegistrarCompra.Cursor = Cursors.Hand;
            btnRegistrarCompra.Font = new Font("Georgia", 12F);
            btnRegistrarCompra.ForeColor = Color.Black;
            btnRegistrarCompra.Location = new Point(16, 336);
            btnRegistrarCompra.Name = "btnRegistrarCompra";
            btnRegistrarCompra.Size = new Size(247, 59);
            btnRegistrarCompra.TabIndex = 24;
            btnRegistrarCompra.Text = "Registrar Compra";
            btnRegistrarCompra.UseVisualStyleBackColor = false;
            btnRegistrarCompra.Click += btnRegistrarCompra_Click;
            // 
            // dtpFechaCompra
            // 
            dtpFechaCompra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaCompra.CalendarFont = new Font("Georgia", 9.75F);
            dtpFechaCompra.Cursor = Cursors.Hand;
            dtpFechaCompra.Font = new Font("Georgia", 9F);
            dtpFechaCompra.Location = new Point(18, 208);
            dtpFechaCompra.Name = "dtpFechaCompra";
            dtpFechaCompra.Size = new Size(246, 21);
            dtpFechaCompra.TabIndex = 23;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(18, 187);
            label4.Name = "label4";
            label4.Size = new Size(149, 18);
            label4.TabIndex = 22;
            label4.Text = "Fecha de la compra:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Georgia", 9.75F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(120, 32);
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
            tbCantidadDisponible.Location = new Point(207, 26);
            tbCantidadDisponible.Name = "tbCantidadDisponible";
            tbCantidadDisponible.Size = new Size(63, 22);
            tbCantidadDisponible.TabIndex = 20;
            tbCantidadDisponible.Visible = false;
            // 
            // ndCantidadComprada
            // 
            ndCantidadComprada.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ndCantidadComprada.Cursor = Cursors.Hand;
            ndCantidadComprada.Font = new Font("Georgia", 9.75F);
            ndCantidadComprada.Location = new Point(17, 286);
            ndCantidadComprada.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            ndCantidadComprada.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ndCantidadComprada.Name = "ndCantidadComprada";
            ndCantidadComprada.Size = new Size(247, 22);
            ndCantidadComprada.TabIndex = 19;
            ndCantidadComprada.Value = new decimal(new int[] { 1, 0, 0, 0 });
            ndCantidadComprada.Validating += ndCantidadComprada_Validating;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(17, 264);
            label3.Name = "label3";
            label3.Size = new Size(150, 18);
            label3.TabIndex = 18;
            label3.Text = "Cantidad comprada:";
            // 
            // tbPrecioCompra
            // 
            tbPrecioCompra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPrecioCompra.Enabled = false;
            tbPrecioCompra.Font = new Font("Georgia", 9.75F);
            tbPrecioCompra.Location = new Point(18, 138);
            tbPrecioCompra.Name = "tbPrecioCompra";
            tbPrecioCompra.Size = new Size(63, 22);
            tbPrecioCompra.TabIndex = 17;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(18, 117);
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
            label8.Location = new Point(8, 32);
            label8.Name = "label8";
            label8.Size = new Size(76, 16);
            label8.TabIndex = 12;
            label8.Text = "Id compra:";
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
            cbProducto.Location = new Point(18, 72);
            cbProducto.Name = "cbProducto";
            cbProducto.Size = new Size(252, 24);
            cbProducto.TabIndex = 3;
            cbProducto.SelectedIndexChanged += cbProducto_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(18, 51);
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
            panel3.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox2.Controls.Add(lbQuirarBusqueda);
            groupBox2.Controls.Add(pbBotonQuitarBusqueda);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(dgvProductos);
            groupBox2.Controls.Add(tbBuscarProducto);
            groupBox2.Font = new Font("Georgia", 12F, FontStyle.Bold);
            groupBox2.ForeColor = Color.Black;
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
            lbQuirarBusqueda.ForeColor = Color.Black;
            lbQuirarBusqueda.Location = new Point(655, 45);
            lbQuirarBusqueda.Name = "lbQuirarBusqueda";
            lbQuirarBusqueda.Size = new Size(104, 15);
            lbQuirarBusqueda.TabIndex = 46;
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
            dataGridViewCellStyle2.ForeColor = Color.Black;
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
            groupBox1.Controls.Add(dgvCompras);
            groupBox1.Font = new Font("Georgia", 12F, FontStyle.Bold);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(12, 314);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(773, 311);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "COMPRAS DE ESTE DÍA";
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.White;
            dgvCompras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Georgia", 9F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Cursor = Cursors.Hand;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Georgia", 9F);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvCompras.DefaultCellStyle = dataGridViewCellStyle5;
            dgvCompras.Location = new Point(12, 35);
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(749, 257);
            dgvCompras.TabIndex = 23;
            dgvCompras.CellDoubleClick += dgvCompras_CellDoubleClick;
            // 
            // frmRegistrarCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 641);
            Controls.Add(panel3);
            Controls.Add(panel2);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmRegistrarCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar compras";
            WindowState = FormWindowState.Maximized;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ndCantidadComprada).EndInit();
            panel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label6;
        private TextBox tbIdCompra;
        private Button btnRegistrarCompra;
        private DateTimePicker dtpFechaCompra;
        private Label label4;
        private Label label7;
        private TextBox tbCantidadDisponible;
        private NumericUpDown ndCantidadComprada;
        private Label label3;
        private TextBox tbPrecioCompra;
        private Label label1;
        private Label label8;
        private ComboBox cbProducto;
        private Label label2;
        private Panel panel3;
        private GroupBox groupBox2;
        private DataGridView dgvProductos;
        private TextBox tbBuscarProducto;
        private GroupBox groupBox1;
        private DataGridView dgvCompras;
        private Panel panel1;
        private Label lbCompras;
        private Label label9;
        private Label label5;
        private PictureBox pictureBox1;
        private PictureBox pbBotonQuitarBusqueda;
        private Label lbQuirarBusqueda;
        private DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreCategoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDisponibleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idCategoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn precioCompraDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cantidadCompradaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn1;
    }
}