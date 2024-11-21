namespace CapaUsuario
{
    partial class frmCategorias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategorias));
            groupBox1 = new GroupBox();
            label8 = new Label();
            tbIdCategoria = new TextBox();
            tbNombreCategoria = new TextBox();
            label2 = new Label();
            btnEditarCategoria = new Button();
            btnEliminarCategoria = new Button();
            btnAgregarCategoria = new Button();
            groupBox2 = new GroupBox();
            pbBotonQuitarBusqueda = new PictureBox();
            pictureBox1 = new PictureBox();
            tbBuscarCategorias = new TextBox();
            dgvCategorias = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(tbIdCategoria);
            groupBox1.Controls.Add(tbNombreCategoria);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Georgia", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(370, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "AGREGAR CATEGORIA";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Enabled = false;
            label8.Font = new Font("Georgia", 9.75F);
            label8.Location = new Point(258, 36);
            label8.Name = "label8";
            label8.Size = new Size(86, 16);
            label8.TabIndex = 15;
            label8.Text = "Id categoria:";
            label8.Visible = false;
            // 
            // tbIdCategoria
            // 
            tbIdCategoria.Enabled = false;
            tbIdCategoria.Location = new Point(257, 56);
            tbIdCategoria.Name = "tbIdCategoria";
            tbIdCategoria.Size = new Size(31, 22);
            tbIdCategoria.TabIndex = 14;
            tbIdCategoria.Visible = false;
            // 
            // tbNombreCategoria
            // 
            tbNombreCategoria.Font = new Font("Georgia", 9F);
            tbNombreCategoria.Location = new Point(6, 55);
            tbNombreCategoria.Name = "tbNombreCategoria";
            tbNombreCategoria.Size = new Size(227, 21);
            tbNombreCategoria.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9.75F);
            label2.Location = new Point(6, 34);
            label2.Name = "label2";
            label2.Size = new Size(155, 16);
            label2.TabIndex = 12;
            label2.Text = "Nombre de la categoria:";
            // 
            // btnEditarCategoria
            // 
            btnEditarCategoria.BackColor = Color.White;
            btnEditarCategoria.Font = new Font("Georgia", 9.75F);
            btnEditarCategoria.Location = new Point(191, 126);
            btnEditarCategoria.Name = "btnEditarCategoria";
            btnEditarCategoria.Size = new Size(191, 28);
            btnEditarCategoria.TabIndex = 13;
            btnEditarCategoria.Text = "Editar";
            btnEditarCategoria.UseVisualStyleBackColor = false;
            btnEditarCategoria.Click += btnEditarCategoria_Click;
            // 
            // btnEliminarCategoria
            // 
            btnEliminarCategoria.BackColor = Color.White;
            btnEliminarCategoria.Font = new Font("Georgia", 9.75F);
            btnEliminarCategoria.Location = new Point(12, 158);
            btnEliminarCategoria.Name = "btnEliminarCategoria";
            btnEliminarCategoria.Size = new Size(370, 28);
            btnEliminarCategoria.TabIndex = 12;
            btnEliminarCategoria.Text = "Eliminar";
            btnEliminarCategoria.UseVisualStyleBackColor = false;
            btnEliminarCategoria.Click += btnEliminarCategoria_Click;
            // 
            // btnAgregarCategoria
            // 
            btnAgregarCategoria.BackColor = Color.White;
            btnAgregarCategoria.Font = new Font("Georgia", 9.75F);
            btnAgregarCategoria.Location = new Point(12, 126);
            btnAgregarCategoria.Name = "btnAgregarCategoria";
            btnAgregarCategoria.Size = new Size(173, 28);
            btnAgregarCategoria.TabIndex = 11;
            btnAgregarCategoria.Text = "Agregar";
            btnAgregarCategoria.UseVisualStyleBackColor = false;
            btnAgregarCategoria.Click += btnAgregarCategoria_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(pbBotonQuitarBusqueda);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(tbBuscarCategorias);
            groupBox2.Controls.Add(dgvCategorias);
            groupBox2.Font = new Font("Georgia", 9.75F, FontStyle.Bold);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(9, 205);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(373, 265);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "LISTADO DE CATEGORIAS";
            // 
            // pbBotonQuitarBusqueda
            // 
            pbBotonQuitarBusqueda.BackColor = Color.Transparent;
            pbBotonQuitarBusqueda.BackgroundImage = Properties.Resources.filter_remove_icon_242410;
            pbBotonQuitarBusqueda.BackgroundImageLayout = ImageLayout.Zoom;
            pbBotonQuitarBusqueda.Cursor = Cursors.Hand;
            pbBotonQuitarBusqueda.Enabled = false;
            pbBotonQuitarBusqueda.Location = new Point(261, 34);
            pbBotonQuitarBusqueda.Name = "pbBotonQuitarBusqueda";
            pbBotonQuitarBusqueda.Size = new Size(42, 30);
            pbBotonQuitarBusqueda.TabIndex = 44;
            pbBotonQuitarBusqueda.TabStop = false;
            pbBotonQuitarBusqueda.Visible = false;
            pbBotonQuitarBusqueda.Click += pbBotonQuitarBusqueda_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.game_magnifying_glass_tools_search_magnifier_zoom_find_controller_icon_262440;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(17, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 31);
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // tbBuscarCategorias
            // 
            tbBuscarCategorias.BorderStyle = BorderStyle.None;
            tbBuscarCategorias.Font = new Font("Georgia", 9.75F);
            tbBuscarCategorias.Location = new Point(65, 45);
            tbBuscarCategorias.Name = "tbBuscarCategorias";
            tbBuscarCategorias.Size = new Size(190, 15);
            tbBuscarCategorias.TabIndex = 18;
            tbBuscarCategorias.KeyDown += tbBuscarCategorias_KeyDown;
            // 
            // dgvCategorias
            // 
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvCategorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Georgia", 9.75F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCategorias.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCategorias.Location = new Point(17, 78);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.Size = new Size(338, 179);
            dgvCategorias.TabIndex = 0;
            dgvCategorias.CellClick += dgvCategorias_CellClick;
            // 
            // frmCategorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pxfuel;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(393, 474);
            Controls.Add(groupBox2);
            Controls.Add(btnEditarCategoria);
            Controls.Add(btnEliminarCategoria);
            Controls.Add(btnAgregarCategoria);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmCategorias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categorias";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBotonQuitarBusqueda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbNombreCategoria;
        private Label label2;
        private Label label8;
        private TextBox tbIdCategoria;
        private Button btnEditarCategoria;
        private Button btnEliminarCategoria;
        private Button btnAgregarCategoria;
        private GroupBox groupBox2;
        private DataGridView dgvCategorias;
        private TextBox tbBuscarCategorias;
        private PictureBox pictureBox1;
        private PictureBox pbBotonQuitarBusqueda;
        private DataGridViewTextBoxColumn idCategoriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreCategoriaDataGridViewTextBoxColumn;
    }
}