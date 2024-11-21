namespace CapaUsuario
{
    partial class frmAgregarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarProducto));
            tbIdProducto = new TextBox();
            label8 = new Label();
            panel2 = new Panel();
            btnAgregar = new Button();
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
            tbIdProducto.Location = new Point(202, 101);
            tbIdProducto.Name = "tbIdProducto";
            tbIdProducto.Size = new Size(26, 23);
            tbIdProducto.TabIndex = 42;
            tbIdProducto.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Enabled = false;
            label8.Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(120, 105);
            label8.Name = "label8";
            label8.Size = new Size(76, 14);
            label8.TabIndex = 43;
            label8.Text = "Id producto:";
            label8.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(tbIdProducto);
            panel2.Controls.Add(btnAgregar);
            panel2.Controls.Add(label8);
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
            panel2.Size = new Size(266, 453);
            panel2.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.White;
            btnAgregar.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAgregar.Location = new Point(20, 414);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(226, 28);
            btnAgregar.TabIndex = 55;
            btnAgregar.Text = "Agregar producto";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // cbCategorias
            // 
            cbCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategorias.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbCategorias.FormattingEnabled = true;
            cbCategorias.Location = new Point(20, 273);
            cbCategorias.Name = "cbCategorias";
            cbCategorias.Size = new Size(226, 26);
            cbCategorias.TabIndex = 53;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(19, 250);
            label3.Name = "label3";
            label3.Size = new Size(138, 16);
            label3.TabIndex = 52;
            label3.Text = "Seleccione categoria:";
            // 
            // tbDescripcion
            // 
            tbDescripcion.Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbDescripcion.Location = new Point(19, 336);
            tbDescripcion.Multiline = true;
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.Size = new Size(228, 66);
            tbDescripcion.TabIndex = 51;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(19, 315);
            label1.Name = "label1";
            label1.Size = new Size(205, 16);
            label1.TabIndex = 50;
            label1.Text = "Añadir descripcion al producto:";
            // 
            // ndCantidadDisponible
            // 
            ndCantidadDisponible.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ndCantidadDisponible.Location = new Point(20, 207);
            ndCantidadDisponible.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            ndCantidadDisponible.Name = "ndCantidadDisponible";
            ndCantidadDisponible.Size = new Size(49, 22);
            ndCantidadDisponible.TabIndex = 49;
            ndCantidadDisponible.Validating += ndCantidadDisponible_Validating;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(19, 186);
            label12.Name = "label12";
            label12.Size = new Size(134, 16);
            label12.TabIndex = 48;
            label12.Text = "Cantidad disponible:";
            // 
            // tbPrecioVenta
            // 
            tbPrecioVenta.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbPrecioVenta.Location = new Point(20, 150);
            tbPrecioVenta.Name = "tbPrecioVenta";
            tbPrecioVenta.Size = new Size(51, 22);
            tbPrecioVenta.TabIndex = 47;
            tbPrecioVenta.Text = "0.00";
            tbPrecioVenta.Click += tbPrecioVenta_Click;
            tbPrecioVenta.Validating += tbPrecioVenta_Validating;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Gadugi", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(19, 129);
            label11.Name = "label11";
            label11.Size = new Size(81, 16);
            label11.TabIndex = 46;
            label11.Text = "Precio venta:";
            // 
            // tbPrecioCompra
            // 
            tbPrecioCompra.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbPrecioCompra.Location = new Point(20, 88);
            tbPrecioCompra.Name = "tbPrecioCompra";
            tbPrecioCompra.Size = new Size(51, 22);
            tbPrecioCompra.TabIndex = 45;
            tbPrecioCompra.Text = "0.00";
            tbPrecioCompra.Click += tbPrecioCompra_Click;
            tbPrecioCompra.Validating += tbPrecioCompra_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(19, 67);
            label4.Name = "label4";
            label4.Size = new Size(102, 16);
            label4.TabIndex = 44;
            label4.Text = "Precio compra:";
            // 
            // tbNombreProducto
            // 
            tbNombreProducto.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbNombreProducto.Location = new Point(19, 30);
            tbNombreProducto.Name = "tbNombreProducto";
            tbNombreProducto.Size = new Size(227, 22);
            tbNombreProducto.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(19, 9);
            label2.Name = "label2";
            label2.Size = new Size(145, 16);
            label2.TabIndex = 40;
            label2.Text = "Nombre del producto:";
            // 
            // frmAgregarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 453);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmAgregarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ndCantidadDisponible).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label label8;
        private TextBox tbIdProducto;
        private Button btnAgregar;
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