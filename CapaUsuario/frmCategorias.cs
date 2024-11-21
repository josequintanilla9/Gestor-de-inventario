using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario
{
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
            MostrarCategorias();
        }




        // METODO PARA CARGAR LOS DATOS EN LA TABLA DE CATEGORIAS
        public void MostrarCategorias()
        {
            CategoriasNegocio categorias = new CategoriasNegocio();

            try
            {
                DataTable dt = categorias.ConsultarCategorias();

                dgvCategorias.DataSource = dt;

                // Ocultar la columna de ID
                dgvCategorias.Columns["IdCategoria"].Visible = false;

                // Cambiar el nombre de la columna "NombreCategoria" a "Categoría"
                dgvCategorias.Columns["NombreCategoria"].HeaderText = "Categoría";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }






        // BOTON PARA AGREGAR UNA NUEVA CATEGORIA
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if(tbNombreCategoria.Text !=  "")
            {
                try
                {
                    CategoriasNegocio categorias = new CategoriasNegocio();

                    bool agregado = categorias.agregarCategorias(tbNombreCategoria.Text);

                    if (agregado == true)
                    {
                        MostrarCategorias();
                        tbNombreCategoria.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Ya existe una categoria con ese nombre.", "INFORMACÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("La categoria debe de tener un nombre.", "INFORMACIÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }







        public event Action? CategoriaEditada;

        // BOTON PARA EDITAR UNA CATEGORIA
        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            if(tbIdCategoria.Text != "")
            {
                if(tbNombreCategoria.Text != "")
                {
                    // Mostrar un cuadro de diálogo de confirmación antes de eliminar
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas editar esta categoria?",
                                                             "Confirmar Cambios",
                                                             MessageBoxButtons.OKCancel,
                                                             MessageBoxIcon.Warning);

                    // Verificar si el usuario presionó el botón "OK"
                    if (resultado == DialogResult.OK)
                    {
                        CategoriasNegocio categorias = new CategoriasNegocio();

                        try
                        {
                            categorias.editarCategoria(Convert.ToInt32(tbIdCategoria.Text), tbNombreCategoria.Text);

                            tbIdCategoria.Text = "";
                            tbNombreCategoria.Text = "";

                            MostrarCategorias();

                            CategoriaEditada?.Invoke();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        
                    }
                    else
                    {
                        tbIdCategoria.Text = "";
                        tbNombreCategoria.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("La categoria debe de tener un nombre.", "INFORMACIÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoria de la tabla.", "INFORMACIÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }        
        }






        public event Action? CategoriaEliminada;

        // BOTON PARA ELIMINAR UNA CATEGORIA Y TODOS SUS PRODUCTOS
        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (tbIdCategoria.Text != "")
            {
                // Mostrar un cuadro de diálogo de confirmación antes de eliminar
                DialogResult resultado = MessageBox.Show("Tambien se eliminaran todos los productos que tengan esta categoria.",
                                                         "¿Estás seguro de que deseas eliminar esta categoria?",
                                                         MessageBoxButtons.OKCancel,
                                                         MessageBoxIcon.Warning);


                // Verificar si el usuario presionó el botón "OK"
                if (resultado == DialogResult.OK)
                {
                    CategoriasNegocio categorias = new CategoriasNegocio();

                    try
                    {
                        categorias.desactivarCategoria(Convert.ToInt32(tbIdCategoria.Text));

                        tbIdCategoria.Text = "";
                        tbNombreCategoria.Text = "";

                        MostrarCategorias();

                        CategoriaEliminada?.Invoke();
                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    tbIdCategoria.Text = "";
                    tbNombreCategoria.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoria de la tabla.", "INFORMACIÓN.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }      
        }






        // EVENTO CELL CLIC DE DATAGRIDVIEW CATEGORIAS: Al seleccionar un campo de la tabla se llenan los controles de agregar categorias
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la fila seleccionada es válida (no es un encabezado o fuera de rango)
            if (e.RowIndex >= 0)
            {
                // Selecciona la fila actual
                DataGridViewRow filaSeleccionada = dgvCategorias.Rows[e.RowIndex];

                tbIdCategoria.Text = filaSeleccionada.Cells[0].Value.ToString();

                tbNombreCategoria.Text = filaSeleccionada.Cells[1].Value.ToString(); 


            }
        }






        // EVENTO TEXTBOX: AL PRESIONAR ENTER EN EL TEXTBOX BUSCARCATEGORIA BUSCARA LA CATEGORIA SIN NECESIDAD DEL BOTON 
        private void tbBuscarCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Se toma el texto ingresado en la barra de busqueda y se almacena en la variable dato
                string dato = tbBuscarCategorias.Text;

                CategoriasNegocio categorias = new CategoriasNegocio();

                dgvCategorias.DataSource = categorias.BuscarCategorias(dato);

                // Ocultar la columna de ID
                dgvCategorias.Columns["IdCategoria"].Visible = false;

                // Cambiar el nombre de la columna "NombreCategoria" a "Categoría"
                dgvCategorias.Columns["NombreCategoria"].HeaderText = "Categoría";

                tbBuscarCategorias.Text = "";

                pbBotonQuitarBusqueda.Visible = true;
                pbBotonQuitarBusqueda.Enabled = true;

                e.SuppressKeyPress = true;
            }
        }






        //BOTON PARA QUITAR FILTRO DE BUSQUEDA
        private void pbBotonQuitarBusqueda_Click(object sender, EventArgs e)
        {
            tbBuscarCategorias.Text = "";
            MostrarCategorias();
            pbBotonQuitarBusqueda.Visible = false;
            pbBotonQuitarBusqueda.Enabled = false;
        }
    }
}
