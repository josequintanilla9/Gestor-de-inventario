using CapaNegocio;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaUsuario
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();

            MostrarProductos();
        }



        // METODO PARA MOSTRAR  LOS PRODUCTOS
        public void MostrarProductos()
        {
            ProductosNegocio productos = new ProductosNegocio();

            try
            {
                DataTable dt = productos.ConsultarProductos();

                dgvProductos.DataSource = dt;

                // Ocultar la columna de ID
                dgvProductos.Columns["IdProducto"].Visible = false;
                dgvProductos.Columns["IdCategoria"].Visible = false;
                dgvProductos.Columns["Activo"].Visible = false;

                // Cambiar el nombre de la columna "NombreProducto" a "Productos"
                dgvProductos.Columns["NombreProducto"].HeaderText = "Productos";
                dgvProductos.Columns["Descripcion"].HeaderText = "Descripción";
                dgvProductos.Columns["PrecioCompra"].HeaderText = "Precio compra";
                dgvProductos.Columns["PrecioVenta"].HeaderText = "Precio venta";
                dgvProductos.Columns["NombreCategoria"].HeaderText = "Categoria";
                dgvProductos.Columns["CantidadDisponible"].HeaderText = "Cantidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        //BOTON PARA DIRIGIRSE A LA PANTALLA DE CATEGORIAS
        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias categorias = new frmCategorias(); //Crea una instancia del nuevo formulario

            categorias.CategoriaEditada += () =>
            {
                MostrarProductos();
            };

            categorias.CategoriaEliminada += () =>
            {
                MostrarProductos();
            };

            categorias.ShowDialog(); //Muestra el nuevo formulario
        }







        // EVENTO KEY DOWN DE TEXTBOX BUSCAR PRODUCTO: AL PRESIONAR ENTER EN EL TEXTBOX BUSCAR PRODUCTO BUSCARA EL PRODUCTO SIN NECESIDAD DEL BOTON
        private void tbBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                // Se toma el texto ingresado en la barra de busqueda y se almacena en la variable dato
                string dato = tbBuscarProducto.Text;

                ProductosNegocio productos = new ProductosNegocio();


                // Se asigna todos los datos a la tabla de productos por medio del metodo buscar productos del controlador
                dgvProductos.DataSource = productos.BuscarProductos(dato);

                pbBotonQuitarBusqueda.Visible = true;
                pbBotonQuitarBusqueda.Enabled = true;
                lbQuirarBusqueda.Visible = true;

                tbBuscarProducto.Text = "";

                e.SuppressKeyPress = true;
            }
        }





        // EVENTO CELL DOBLE CLIC DE DATAGRIDVIEW PRODUCTOS: Al seleccionar un campo de la tabla se abre un nuevo formulario para editar o eliminar el producto
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la fila seleccionada es válida (no es un encabezado o fuera de rango)
            if (e.RowIndex >= 0)
            {
                // Obtener la fila actual seleccionada
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

                var idProducto = row.Cells["IdProducto"].Value.ToString();
                var nombreProducto = row.Cells["NombreProducto"].Value.ToString();
                string? descripcion = row.Cells["Descripcion"].Value.ToString();
                decimal precioCompra = Convert.ToDecimal(row.Cells["PrecioCompra"].Value);
                decimal precioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value);
                int cantidadDisponible = Convert.ToInt32(row.Cells["CantidadDisponible"].Value);
                int idCategoria = Convert.ToInt32(row.Cells["IdCategoria"].Value);


                if (idProducto == null || string.IsNullOrEmpty(idProducto.ToString()) || nombreProducto == null || string.IsNullOrEmpty(nombreProducto.ToString()))
                {
                    MessageBox.Show("Ocurrio un error al mostrar el detalle de la venta, intentalo de nuevo.");
                    return;
                }

                // Crear una instancia del formulario de edición y pasar los valores
                frmEditarEliminarProducto frmeditareliminarproducto = new frmEditarEliminarProducto(
                    idProducto, nombreProducto, descripcion, precioCompra, precioVenta, cantidadDisponible, idCategoria);

                frmeditareliminarproducto.ProductoEditado += () => MostrarProductos();

                frmeditareliminarproducto.ProductoEliminado += () => MostrarProductos();

                // Suscribirse al evento ProductoEditado para que cada vez que se edite un producto la tabla se actualice
                frmeditareliminarproducto.ShowDialog(); ;
            }
        }




        // BOTON PARA IR A SECCION DE AGREGAR UN PRODUCTO
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            frmAgregarProducto frmagregarproducto = new frmAgregarProducto();

            // Suscribirse al evento ProductoAgregado para que cada vez que se agregue un producto la tabla se actualice
            frmagregarproducto.ProductoAgregado += () => MostrarProductos();

            frmagregarproducto.ShowDialog();

        }




        // BOTON PARA QUITAR LOS RESULTADOS DE BUSQUEDA
        private void pbBotonQuitarBusqueda_Click(object sender, EventArgs e)
        {
            tbBuscarProducto.Text = "";
            MostrarProductos();
            pbBotonQuitarBusqueda.Visible = false;
            pbBotonQuitarBusqueda.Enabled = false;
            lbQuirarBusqueda.Visible = false;
        }






        // BOTON PARA GENERAR UN EXCEL DEL INVENTARIO
        private void pbBotonExcel_Click(object sender, EventArgs e)
        {
            try
            {
                pbBotonExcel.BorderStyle = BorderStyle.Fixed3D;

                // Crear un nuevo libro de Excel
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Datos");

                    // Agregar encabezados del DataGridView
                    int colIndex = 1;
                    for (int i = 0; i < dgvProductos.Columns.Count; i++)
                    {
                        if (dgvProductos.Columns[i].Visible) // Verificar si la columna es visible
                        {
                            var cell = worksheet.Cell(1, colIndex);
                            cell.Value = dgvProductos.Columns[i].HeaderText;
                            cell.Style.Font.Bold = true; // Negrita
                            cell.Style.Fill.BackgroundColor = XLColor.LightGray; // Color de fondo
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Alinear al centro
                            colIndex++;
                        }

                    }

                    // Agregar los datos del DataGridView
                    for (int i = 0; i < dgvProductos.Rows.Count; i++)
                    {
                        colIndex = 1; // Reiniciar el índice de columna para cada fila
                        for (int j = 0; j < dgvProductos.Columns.Count; j++)
                        {
                            if (dgvProductos.Columns[j].Visible) // Verificar si la columna es visible
                            {
                                worksheet.Cell(i + 2, colIndex).Value = dgvProductos.Rows[i].Cells[j].Value?.ToString();
                                colIndex++;

                            }
                        }
                    }

                    // Ajustar el ancho de las columnas
                    for (int i = 1; i <= colIndex - 1; i++)
                    {
                        worksheet.Column(i).AdjustToContents(); // Ajustar automáticamente al contenido
                    }


                    // Agregar totales debajo de los datos
                    int rowCount = dgvProductos.Rows.Count + 3;


                    var totalComprasCell = worksheet.Cell(rowCount + 1, 1);
                    totalComprasCell.Value = "Fecha:";
                    totalComprasCell.Style.Font.Bold = true; // Negrita
                    totalComprasCell.Style.Fill.BackgroundColor = XLColor.BlueGray; // Color de fondo
                    worksheet.Cell(rowCount + 2, 1).Value = DateTime.Now.ToString("D");


                    // Ajustar el ancho de todas las columnas
                    worksheet.Columns().AdjustToContents();

                    pbBotonExcel.BorderStyle = BorderStyle.None;

                    // Guardar el archivo
                    var saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        Title = "Guardar archivo Excel",
                        FileName = "DatosExportados.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Exportación completada con éxito.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}");
            }
        }

    }
}
