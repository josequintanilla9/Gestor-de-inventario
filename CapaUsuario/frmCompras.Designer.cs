namespace CapaUsuario
{
    partial class frmCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompras));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel2 = new Panel();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label19 = new Label();
            label21 = new Label();
            lbTotalGastado = new Label();
            btnRegistrarCompra = new Button();
            gbCompras = new GroupBox();
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
            dgvCompras = new DataGridView();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            gbCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonExcel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonRestablecerFecha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonBuscarFecha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(btnRegistrarCompra);
            panel2.Controls.Add(gbCompras);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1024, 560);
            panel2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(label21);
            panel1.Controls.Add(lbTotalGastado);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 512);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 46);
            panel1.TabIndex = 22;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(622, -4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(55, 48);
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label19.AutoSize = true;
            label19.Font = new Font("Georgia", 14.25F);
            label19.ForeColor = Color.White;
            label19.Location = new Point(679, 11);
            label19.Name = "label19";
            label19.Size = new Size(174, 23);
            label19.TabIndex = 18;
            label19.Text = "TOTAL GASTADO:";
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label21.AutoSize = true;
            label21.Font = new Font("Georgia", 18F, FontStyle.Bold);
            label21.ForeColor = Color.White;
            label21.Location = new Point(850, 8);
            label21.Name = "label21";
            label21.Size = new Size(28, 29);
            label21.TabIndex = 19;
            label21.Text = "$";
            // 
            // lbTotalGastado
            // 
            lbTotalGastado.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbTotalGastado.AutoSize = true;
            lbTotalGastado.Font = new Font("Georgia", 18F);
            lbTotalGastado.ForeColor = Color.White;
            lbTotalGastado.Location = new Point(873, 7);
            lbTotalGastado.Name = "lbTotalGastado";
            lbTotalGastado.Size = new Size(64, 29);
            lbTotalGastado.TabIndex = 20;
            lbTotalGastado.Text = "0.00";
            // 
            // btnRegistrarCompra
            // 
            btnRegistrarCompra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRegistrarCompra.BackColor = Color.White;
            btnRegistrarCompra.Cursor = Cursors.Hand;
            btnRegistrarCompra.Font = new Font("Georgia", 9.75F);
            btnRegistrarCompra.Location = new Point(405, 12);
            btnRegistrarCompra.Name = "btnRegistrarCompra";
            btnRegistrarCompra.Size = new Size(248, 31);
            btnRegistrarCompra.TabIndex = 17;
            btnRegistrarCompra.Text = "Registrar nuevas compras";
            btnRegistrarCompra.UseVisualStyleBackColor = false;
            btnRegistrarCompra.Click += btnRegistrarCompra_Click;
            // 
            // gbCompras
            // 
            gbCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbCompras.Controls.Add(lbQuirarBusqueda);
            gbCompras.Controls.Add(lbImportarExcel);
            gbCompras.Controls.Add(pbBotonExcel);
            gbCompras.Controls.Add(lbRestablecerFecha);
            gbCompras.Controls.Add(lbCambiarFecha);
            gbCompras.Controls.Add(pbBotonRestablecerFecha);
            gbCompras.Controls.Add(pbBotonBuscarFecha);
            gbCompras.Controls.Add(pbBotonQuitarBusqueda);
            gbCompras.Controls.Add(pictureBox1);
            gbCompras.Controls.Add(tbBuscarProducto);
            gbCompras.Controls.Add(dgvCompras);
            gbCompras.Font = new Font("Georgia", 14.25F, FontStyle.Bold);
            gbCompras.Location = new Point(10, 48);
            gbCompras.Name = "gbCompras";
            gbCompras.Size = new Size(998, 456);
            gbCompras.TabIndex = 14;
            gbCompras.TabStop = false;
            gbCompras.Text = "COMPRAS DE ESTA SEMANA";
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
            lbImportarExcel.Location = new Point(875, 86);
            lbImportarExcel.Name = "lbImportarExcel";
            lbImportarExcel.Size = new Size(102, 15);
            lbImportarExcel.TabIndex = 40;
            lbImportarExcel.Text = "Importar a excel";
            // 
            // pbBotonExcel
            // 
            pbBotonExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbBotonExcel.BackColor = Color.Transparent;
            pbBotonExcel.BackgroundImage = CapaUsuario.Properties.Resources.microsoft_excel_macos_bigsur_icon_189980;
            pbBotonExcel.BackgroundImageLayout = ImageLayout.Zoom;
            pbBotonExcel.Cursor = Cursors.Hand;
            pbBotonExcel.Location = new Point(892, 38);
            pbBotonExcel.Name = "pbBotonExcel";
            pbBotonExcel.Size = new Size(67, 45);
            pbBotonExcel.TabIndex = 39;
            pbBotonExcel.TabStop = false;
            pbBotonExcel.Click += pbBotonExcel_Click;
            // 
            // lbRestablecerFecha
            // 
            lbRestablecerFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRestablecerFecha.AutoSize = true;
            lbRestablecerFecha.Font = new Font("Georgia", 9F);
            lbRestablecerFecha.Location = new Point(760, 85);
            lbRestablecerFecha.Name = "lbRestablecerFecha";
            lbRestablecerFecha.Size = new Size(107, 15);
            lbRestablecerFecha.TabIndex = 38;
            lbRestablecerFecha.Text = "Restablecer fecha";
            lbRestablecerFecha.Visible = false;
            // 
            // lbCambiarFecha
            // 
            lbCambiarFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbCambiarFecha.AutoSize = true;
            lbCambiarFecha.Font = new Font("Georgia", 9F);
            lbCambiarFecha.Location = new Point(768, 85);
            lbCambiarFecha.Name = "lbCambiarFecha";
            lbCambiarFecha.Size = new Size(92, 15);
            lbCambiarFecha.TabIndex = 37;
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
            pbBotonRestablecerFecha.Location = new Point(778, 34);
            pbBotonRestablecerFecha.Name = "pbBotonRestablecerFecha";
            pbBotonRestablecerFecha.Size = new Size(67, 48);
            pbBotonRestablecerFecha.TabIndex = 36;
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
            pbBotonBuscarFecha.Location = new Point(791, 38);
            pbBotonBuscarFecha.Name = "pbBotonBuscarFecha";
            pbBotonBuscarFecha.Size = new Size(44, 43);
            pbBotonBuscarFecha.TabIndex = 35;
            pbBotonBuscarFecha.TabStop = false;
            pbBotonBuscarFecha.Click += pbBotonBuscarFecha_Click;
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
            tbBuscarProducto.TabIndex = 25;
            tbBuscarProducto.KeyDown += tbBuscarProducto_KeyDown;
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvCompras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Cursor = Cursors.Hand;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Georgia", 9.75F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCompras.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCompras.Location = new Point(18, 117);
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(963, 327);
            dgvCompras.TabIndex = 12;
            dgvCompras.CellDoubleClick += dgvCompras_CellDoubleClick;
            // 
            // frmCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 560);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCompras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCompras";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            gbCompras.ResumeLayout(false);
            gbCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonExcel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonRestablecerFecha).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonBuscarFecha).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private GroupBox gbCompras;
        private Label lbTotalGastado;
        private Label label21;
        private Label label19;
        private DataGridView dgvCompras;
        private Button btnRegistrarCompra;
        private TextBox tbBuscarProducto;
        private PictureBox pictureBox1;
        private PictureBox pbBotonQuitarBusqueda;
        private Label lbRestablecerFecha;
        private Label lbCambiarFecha;
        private PictureBox pbBotonRestablecerFecha;
        private PictureBox pbBotonBuscarFecha;
        private Label lbImportarExcel;
        private PictureBox pbBotonExcel;
        private Label lbQuirarBusqueda;
        private Panel panel1;
        private DataGridViewTextBoxColumn idCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadCompradaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private PictureBox pictureBox2;
    }
}