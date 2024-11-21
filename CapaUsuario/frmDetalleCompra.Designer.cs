namespace CapaUsuario
{
    partial class frmDetalleCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleCompra));
            label19 = new Label();
            panel1 = new Panel();
            dgvDetalleCompra = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).BeginInit();
            SuspendLayout();
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Georgia", 14.25F, FontStyle.Bold);
            label19.ForeColor = Color.White;
            label19.Location = new Point(209, 9);
            label19.Name = "label19";
            label19.Size = new Size(450, 23);
            label19.TabIndex = 19;
            label19.Text = "TODAS LAS COMPRAS DE ESTE PRODUCTO";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = CapaUsuario.Properties.Resources.pxfuel;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label19);
            panel1.Controls.Add(dgvDetalleCompra);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(825, 371);
            panel1.TabIndex = 16;
            // 
            // dgvDetalleCompra
            // 
            dgvDetalleCompra.AllowUserToAddRows = false;
            dgvDetalleCompra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvDetalleCompra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetalleCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleCompra.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDetalleCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDetalleCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Georgia", 9.75F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDetalleCompra.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDetalleCompra.Location = new Point(12, 46);
            dgvDetalleCompra.Name = "dgvDetalleCompra";
            dgvDetalleCompra.ReadOnly = true;
            dgvDetalleCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleCompra.Size = new Size(801, 290);
            dgvDetalleCompra.TabIndex = 13;
            dgvDetalleCompra.CellDoubleClick += dgvDetalleCompra_CellDoubleClick;
            // 
            // frmDetalleCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 371);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmDetalleCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de compras";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label19;
        private Panel panel1;
        private DataGridView dgvDetalleCompra;
        private DataGridViewTextBoxColumn idCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadCompradaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}