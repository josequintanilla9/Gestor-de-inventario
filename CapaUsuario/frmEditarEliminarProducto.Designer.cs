namespace CapaUsuario
{
    partial class frmEditarEliminarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarEliminarProducto));
            tbIdProducto = new TextBox();
            label8 = new Label();
            panel2 = new Panel();
            btnEliminarProducto = new Button();
            btnEditarProducto = new Button();
            cbCategorias = new ComboBox();
            label3 = new Label();
            tbDescripcion = new TextBox();
            label1 = new Label();
            ndCantidadDisponible = new NumericUpDown();
            label12 = new Label();
            tbPrecioVenta = new TextBox();
            label11 = new Label();
            tbPrecioCompra = new TextBox();
            label4 = new Label();
            tbNombreProducto = new TextBox();
            label2 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ndCantidadDisponible).BeginInit();
            SuspendLayout();
            // 
            // tbIdProducto
            // 
            tbIdProducto.Enabled = false;
            tbIdProducto.Location = new Point(214, 90);
            tbIdProducto.Name = "tbIdProducto";
            tbIdProducto.Size = new Size(21, 23);
            tbIdProducto.TabIndex = 42;
            tbIdProducto.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Enabled = false;
            label8.Font = new Font("Georgia", 8.25F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(136, 94);
            label8.Name = "label8";
            label8.Size = new Size(76, 14);
            label8.TabIndex = 43;
            label8.Text = "Id producto:";
            label8.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = CapaUsuario.Properties.Resources.pxfuel;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(tbIdProducto);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(btnEliminarProducto);
            panel2.Controls.Add(btnEditarProducto);
            panel2.Controls.Add(cbCategorias);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(tbDescripcion);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(ndCantidadDisponible);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(tbPrecioVenta);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(tbPrecioCompra);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(tbNombreProducto);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(266, 455);
            panel2.TabIndex = 2;
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.BackColor = Color.White;
            btnEliminarProducto.Font = new Font("Georgia", 9.75F);
            btnEliminarProducto.Location = new Point(136, 420);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(110, 28);
            btnEliminarProducto.TabIndex = 56;
            btnEliminarProducto.Text = "Eliminar";
            btnEliminarProducto.UseVisualStyleBackColor = false;
            btnEliminarProducto.Click += btnEliminarProducto_Click;
            // 
            // btnEditarProducto
            // 
            btnEditarProducto.BackColor = Color.White;
            btnEditarProducto.Font = new Font("Georgia", 9.75F);
            btnEditarProducto.Location = new Point(20, 420);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(110, 28);
            btnEditarProducto.TabIndex = 55;
            btnEditarProducto.Text = "Editar";
            btnEditarProducto.UseVisualStyleBackColor = false;
            btnEditarProducto.Click += btnEditarProducto_Click;
            // 
            // cbCategorias
            // 
            cbCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategorias.Font = new Font("Georgia", 9.75F);
            cbCategorias.FormattingEnabled = true;
            cbCategorias.Location = new Point(20, 271);
            cbCategorias.Name = "cbCategorias";
            cbCategorias.Size = new Size(226, 24);
            cbCategorias.TabIndex = 53;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9.75F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(19, 250);
            label3.Name = "label3";
            label3.Size = new Size(138, 16);
            label3.TabIndex = 52;
            label3.Text = "Seleccione categoria:";
            // 
            // tbDescripcion
            // 
            tbDescripcion.Font = new Font("Georgia", 8.25F);
            tbDescripcion.Location = new Point(19, 335);
            tbDescripcion.Multiline = true;
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.Size = new Size(228, 66);
            tbDescripcion.TabIndex = 51;
            tbDescripcion.DoubleClick += tbDescripcion_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 9.75F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(19, 314);
            label1.Name = "label1";
            label1.Size = new Size(205, 16);
            label1.TabIndex = 50;
            label1.Text = "Añadir descripcion al producto:";
            // 
            // ndCantidadDisponible
            // 
            ndCantidadDisponible.Font = new Font("Georgia", 9.75F);
            ndCantidadDisponible.Location = new Point(22, 207);
            ndCantidadDisponible.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            ndCantidadDisponible.Name = "ndCantidadDisponible";
            ndCantidadDisponible.Size = new Size(49, 22);
            ndCantidadDisponible.TabIndex = 49;
            ndCantidadDisponible.Validating += ndCantidadDisponible_Validating;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 9.75F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(19, 184);
            label12.Name = "label12";
            label12.Size = new Size(134, 16);
            label12.TabIndex = 48;
            label12.Text = "Cantidad disponible:";
            // 
            // tbPrecioVenta
            // 
            tbPrecioVenta.Font = new Font("Georgia", 9.75F);
            tbPrecioVenta.Location = new Point(20, 150);
            tbPrecioVenta.Name = "tbPrecioVenta";
            tbPrecioVenta.Size = new Size(51, 22);
            tbPrecioVenta.TabIndex = 47;
            tbPrecioVenta.Text = "0.00";
            tbPrecioVenta.DoubleClick += tbPrecioVenta_DoubleClick;
            tbPrecioVenta.Validating += tbPrecioVenta_Validating;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Georgia", 9.75F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(19, 127);
            label11.Name = "label11";
            label11.Size = new Size(89, 16);
            label11.TabIndex = 46;
            label11.Text = "Precio venta:";
            // 
            // tbPrecioCompra
            // 
            tbPrecioCompra.Font = new Font("Georgia", 9.75F);
            tbPrecioCompra.Location = new Point(20, 88);
            tbPrecioCompra.Name = "tbPrecioCompra";
            tbPrecioCompra.Size = new Size(51, 22);
            tbPrecioCompra.TabIndex = 45;
            tbPrecioCompra.Text = "0.00";
            tbPrecioCompra.DoubleClick += tbPrecioCompra_DoubleClick;
            tbPrecioCompra.Validating += tbPrecioCompra_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 9.75F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(19, 65);
            label4.Name = "label4";
            label4.Size = new Size(102, 16);
            label4.TabIndex = 44;
            label4.Text = "Precio compra:";
            // 
            // tbNombreProducto
            // 
            tbNombreProducto.Font = new Font("Georgia", 9.75F);
            tbNombreProducto.Location = new Point(20, 30);
            tbNombreProducto.Name = "tbNombreProducto";
            tbNombreProducto.Size = new Size(227, 22);
            tbNombreProducto.TabIndex = 41;
            tbNombreProducto.DoubleClick += tbNombreProducto_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9.75F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(20, 9);
            label2.Name = "label2";
            label2.Size = new Size(145, 16);
            label2.TabIndex = 40;
            label2.Text = "Nombre del producto:";
            // 
            // frmEditarEliminarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 455);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmEditarEliminarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ndCantidadDisponible).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox tbIdProducto;
        private Label label8;
        private Panel panel2;
        private Button btnEliminarProducto;
        private Button btnEditarProducto;
        private ComboBox cbCategorias;
        private Label label3;
        private TextBox tbDescripcion;
        private Label label1;
        private NumericUpDown ndCantidadDisponible;
        private Label label12;
        private TextBox tbPrecioVenta;
        private Label label11;
        private TextBox tbPrecioCompra;
        private Label label4;
        private TextBox tbNombreProducto;
        private Label label2;
    }
}