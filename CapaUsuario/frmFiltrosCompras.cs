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
    public partial class frmFiltrosCompras : Form
    {
        public frmFiltrosCompras()
        {
            InitializeComponent();
            fijarMesCombobox(); // Carga los meses del año en el combobox cbmeses
        }



        //METODO QUE LLENA EL COMBOBOX CON LOS MESES DEL AÑO TENIENDO POR DEFECTO EL MES ACTUAL
        public void fijarMesCombobox()
        {
            // Llenar el ComboBox con los nombres de los meses
            cbMes.Items.AddRange(new string[]
            {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            });

            // Seleccionar el mes actual por defecto
            cbMes.SelectedIndex = DateTime.Now.Month - 1;
        }






        // EVENTOS PARA MANDAR LA FECHA SELECCIONADA DEL DATETIMEPICKER DTPFILTRARDIA DEL FORMULARIO "FRMFILTROSCOMPRAS A EL FORMULARIO "FRMCOMPRAS".
        public delegate void FiltrarDiaEventHandler(DateTime fecha);
        public event FiltrarDiaEventHandler FiltrarDia;


        // BOTON PARA MOSTRAR LAS COMPRAS SELECCIONANDO EL DIA ESPECIFICO
        private void btnFiltrarDia_Click(object sender, EventArgs e)
        {
            FiltrarDia?.Invoke(dtpFiltrarDia.Value); // Aquí mandas el valor del DateTimePicker al formulario frmcompras que esta suscrito a este evento

            this.Close(); // Cierra el formulario después de enviar los datos
        }









        // EVENTOS PARA MANDAR LA SEMANA SELECCIONADA DEL DATETIMEPICKER DTPSEMANA DEL FORMULARIO "FRMFILTROSCOMPRAS A EL FORMULARIO "FRMCOMPRAS".
        public delegate void FiltrarSemanaEventHandler(DateTime fecha); // EVENTOS PARA FILTRAR POR SEMANA
        public event FiltrarSemanaEventHandler FiltrarSemana;

        // BOTON PARA FILTRAR COMPRAS POR SEMANA
        private void btnFiltrarSemana_Click(object sender, EventArgs e)
        {
            FiltrarSemana?.Invoke(dtpFiltrarSemana.Value); // Aquí mandas el valor del DateTimePicker al formulario frmcompras que esta suscrito a este evento

            this.Close(); // Cierra el formulario después de enviar los datos
        }






        // EVENTOS PARA MANDAR EL MES Y EL AÑO SELECCIONADO EN EL COMBOBOX CBMES Y EL DATETIMEPICKER DTPAÑO DEL FORMULARIO "FRMFILTROSCOMPRAS A EL FORMULARIO "FRMCOMPRAS".
        public delegate void FiltrarMesAñoEventHandler(int mes, int año); // EVENTOS PARA FILTRAR POR MES Y AÑO
        public event FiltrarMesAñoEventHandler FiltrarMesAño;

        //BOTON PARA MOSTRAR LAS COMPRAS SELECCIONANDO EL MES Y EL AÑO
        private void btnFiltrarMesAño_Click(object sender, EventArgs e)
        {
            FiltrarMesAño?.Invoke(cbMes.SelectedIndex + 1, dtpAño.Value.Year); // Aquí mandas el valor del Combobox y del DateTimePicker al formulario frmcompras que esta suscrito a este evento

            this.Close(); // Cierra el formulario después de enviar los datos
        }







        // EVENTOS PARA MANDAR EL AÑO SELECCIONADO DEL DATETIMEPICKER DTPFILTRARAÑO DEL FORMULARIO "FRMFILTROSCOMPRAS A EL FORMULARIO "FRMCOMPRAS".
        public delegate void FiltrarAñoEventHandler(int año); // EVENTOS PARA FILTRAR POR SEMANA
        public event FiltrarAñoEventHandler FiltrarAño;

        // BOTON PARA FILTRAR LAS COMPRAS POR AÑO
        private void btnFiltrarAño_Click(object sender, EventArgs e)
        {
            FiltrarAño?.Invoke(dtpFiltrarAño.Value.Year); // Aquí mandas el valor del DateTimePicker al formulario frmventas que esta suscrito a este evento

            this.Close(); // Cierra el formulario después de enviar los datos
        }
    }
}
