namespace CapaUsuario
{
    partial class frmProductos
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
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnCategorias = new Button();
            btnAgregarProducto = new Button();
            groupBox2 = new GroupBox();
            lbQuirarBusqueda = new Label();
            lbImportarExcel = new Label();
            pbBotonExcel = new PictureBox();
            pbBotonQuitarBusqueda = new PictureBox();
            pictureBox1 = new PictureBox();
            tbBuscarProducto = new TextBox();
            dgvProductos = new DataGridView();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonExcel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(groupBox2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1024, 560);
            panel2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(btnCategorias, 2, 0);
            tableLayoutPanel1.Controls.Add(btnAgregarProducto, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 23);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(998, 39);
            tableLayoutPanel1.TabIndex = 23;
            // 
            // btnCategorias
            // 
            btnCategorias.Anchor = AnchorStyles.None;
            btnCategorias.BackColor = Color.White;
            btnCategorias.Cursor = Cursors.Hand;
            btnCategorias.Font = new Font("Georgia", 9.75F);
            btnCategorias.Location = new Point(501, 4);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(243, 31);
            btnCategorias.TabIndex = 22;
            btnCategorias.Text = "Ver categorias";
            btnCategorias.UseVisualStyleBackColor = false;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Anchor = AnchorStyles.None;
            btnAgregarProducto.BackColor = Color.White;
            btnAgregarProducto.Cursor = Cursors.Hand;
            btnAgregarProducto.Font = new Font("Georgia", 9.75F);
            btnAgregarProducto.Location = new Point(252, 4);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(243, 31);
            btnAgregarProducto.TabIndex = 18;
            btnAgregarProducto.Text = "Agregar producto";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.BackgroundImageLayout = ImageLayout.Stretch;
            groupBox2.Controls.Add(lbQuirarBusqueda);
            groupBox2.Controls.Add(lbImportarExcel);
            groupBox2.Controls.Add(pbBotonExcel);
            groupBox2.Controls.Add(pbBotonQuitarBusqueda);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(tbBuscarProducto);
            groupBox2.Controls.Add(dgvProductos);
            groupBox2.Font = new Font("Georgia", 14.25F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 68);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(998, 478);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "LISTADO DE PRODUCTOS";
            // 
            // lbQuirarBusqueda
            // 
            lbQuirarBusqueda.AutoSize = true;
            lbQuirarBusqueda.Font = new Font("Georgia", 8.25F);
            lbQuirarBusqueda.Location = new Point(460, 76);
            lbQuirarBusqueda.Name = "lbQuirarBusqueda";
            lbQuirarBusqueda.Size = new Size(103, 14);
            lbQuirarBusqueda.TabIndex = 43;
            lbQuirarBusqueda.Text = "Quitar busqueda";
            lbQuirarBusqueda.Visible = false;
            // 
            // lbImportarExcel
            // 
            lbImportarExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbImportarExcel.AutoSize = true;
            lbImportarExcel.Font = new Font("Georgia", 9F);
            lbImportarExcel.Location = new Point(878, 95);
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
            pbBotonExcel.Location = new Point(895, 44);
            pbBotonExcel.Name = "pbBotonExcel";
            pbBotonExcel.Size = new Size(67, 45);
            pbBotonExcel.TabIndex = 41;
            pbBotonExcel.TabStop = false;
            pbBotonExcel.Click += pbBotonExcel_Click;
            // 
            // pbBotonQuitarBusqueda
            // 
            pbBotonQuitarBusqueda.BackColor = Color.Transparent;
            pbBotonQuitarBusqueda.BackgroundImage = CapaUsuario.Properties.Resources.filter_remove_icon_242410;
            pbBotonQuitarBusqueda.BackgroundImageLayout = ImageLayout.Zoom;
            pbBotonQuitarBusqueda.Cursor = Cursors.Hand;
            pbBotonQuitarBusqueda.Enabled = false;
            pbBotonQuitarBusqueda.Location = new Point(488, 44);
            pbBotonQuitarBusqueda.Name = "pbBotonQuitarBusqueda";
            pbBotonQuitarBusqueda.Size = new Size(42, 30);
            pbBotonQuitarBusqueda.TabIndex = 29;
            pbBotonQuitarBusqueda.TabStop = false;
            pbBotonQuitarBusqueda.Visible = false;
            pbBotonQuitarBusqueda.Click += pbBotonQuitarBusqueda_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = CapaUsuario.Properties.Resources.game_magnifying_glass_tools_search_magnifier_zoom_find_controller_icon_262440;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(18, 59);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 31);
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // tbBuscarProducto
            // 
            tbBuscarProducto.Font = new Font("Georgia", 9.75F);
            tbBuscarProducto.Location = new Point(62, 68);
            tbBuscarProducto.Name = "tbBuscarProducto";
            tbBuscarProducto.Size = new Size(390, 22);
            tbBuscarProducto.TabIndex = 15;
            tbBuscarProducto.KeyDown += tbBuscarProducto_KeyDown;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Georgia", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Cursor = Cursors.Hand;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Georgia", 9.75F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.NullValue = "null";
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProductos.GridColor = Color.DarkGray;
            dgvProductos.Location = new Point(18, 126);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(963, 327);
            dgvProductos.TabIndex = 12;
            dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 560);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProductos";
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonExcel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private GroupBox groupBox2;
        private DataGridView dgvProductos;
        private TextBox tbBuscarProducto;
        private Button btnCategorias;
        private DataGridViewTextBoxColumn idCategoria1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idProducto1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProducto1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripcion1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioCompra1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioVenta1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDisponible1DataGridViewTextBoxColumn;
        private Button btnAgregarProducto;
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
        private Label lbImportarExcel;
        private PictureBox pbBotonExcel;
        private Label lbQuirarBusqueda;
        private TableLayoutPanel tableLayoutPanel1;
    }
}