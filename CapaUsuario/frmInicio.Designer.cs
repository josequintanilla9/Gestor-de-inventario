namespace CapaUsuario
{
    partial class frmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            panel3 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnVentas = new Button();
            btnCompras = new Button();
            btnProductos = new Button();
            panel1 = new Panel();
            label1 = new Label();
            contenedor = new Panel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(btnVentas);
            panel3.Controls.Add(btnCompras);
            panel3.Controls.Add(btnProductos);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 48);
            panel3.Name = "panel3";
            panel3.Size = new Size(1008, 42);
            panel3.TabIndex = 8;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackgroundImage = CapaUsuario.Properties.Resources._3440924_box_delivery_ecommerce_package_shipping_shop_shopping_107533;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(595, -1);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(42, 42);
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackgroundImage = CapaUsuario.Properties.Resources.shopping_commerce_money_balance_deposit_pay_cash_payment_wallet_icon_210820;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(419, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(34, 33);
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox1.BackgroundImage = CapaUsuario.Properties.Resources.cart_add_new_shop_ecommerce_icon_150698;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(221, -5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 47);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // btnVentas
            // 
            btnVentas.Anchor = AnchorStyles.None;
            btnVentas.BackColor = Color.White;
            btnVentas.Cursor = Cursors.Hand;
            btnVentas.Font = new Font("Georgia", 9.75F);
            btnVentas.Location = new Point(276, 4);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(117, 34);
            btnVentas.TabIndex = 5;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnCompras
            // 
            btnCompras.Anchor = AnchorStyles.None;
            btnCompras.BackColor = Color.White;
            btnCompras.Cursor = Cursors.Hand;
            btnCompras.Font = new Font("Georgia", 9.75F);
            btnCompras.Location = new Point(459, 4);
            btnCompras.Name = "btnCompras";
            btnCompras.Size = new Size(117, 34);
            btnCompras.TabIndex = 9;
            btnCompras.Text = "Compras";
            btnCompras.UseVisualStyleBackColor = false;
            btnCompras.Click += btnCompras_Click;
            // 
            // btnProductos
            // 
            btnProductos.Anchor = AnchorStyles.None;
            btnProductos.BackColor = Color.White;
            btnProductos.Cursor = Cursors.Hand;
            btnProductos.Font = new Font("Georgia", 9.75F);
            btnProductos.Location = new Point(643, 4);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(117, 33);
            btnProductos.TabIndex = 10;
            btnProductos.Text = "Inventario";
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = CapaUsuario.Properties.Resources.pxfuel;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1008, 48);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Impact", 18F);
            label1.ForeColor = Color.LightYellow;
            label1.ImageKey = "(ninguna)";
            label1.Location = new Point(412, 9);
            label1.Name = "label1";
            label1.Size = new Size(203, 29);
            label1.TabIndex = 2;
            label1.Text = "PIÑATERIA ARCOIRIS";
            // 
            // contenedor
            // 
            contenedor.BackColor = Color.White;
            contenedor.Dock = DockStyle.Fill;
            contenedor.Location = new Point(0, 90);
            contenedor.Name = "contenedor";
            contenedor.Size = new Size(1008, 471);
            contenedor.TabIndex = 9;
            // 
            // frmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 561);
            Controls.Add(contenedor);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor financiero";
            WindowState = FormWindowState.Maximized;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btnVentas;
        private Button btnCompras;
        private Button btnProductos;
        private Panel panel1;
        private Label label1;
        private Panel contenedor;
    }
}