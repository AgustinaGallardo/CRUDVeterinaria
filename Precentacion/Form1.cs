using CRUDveterinaria.Datos;
using CRUDveterinaria.Dominio;
using CRUDveterinaria.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDveterinaria
{
    public partial class frmAltaMascota : Form
    {
        private IServicio gestor;
        private Mascota nueva;
        public frmAltaMascota()
        {
            InitializeComponent();
            gestor = new Servicio();
            nueva = new Mascota();
        }

        private void frmAltaMascota_Load(object sender, EventArgs e)
        {
            ObtenerProximo();
            CargarTipos();
            CargarClientes();
        }

        private void CargarClientes()
        {
            cboCliente.ValueMember = "IdCliente";
            cboCliente.DisplayMember = "Nombre";
            cboCliente.DataSource = gestor.ObtenerClientes();
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarTipos()
        {
            cboTipoMas.ValueMember = "IdTipo";
            cboTipoMas.DisplayMember = "NombreTipo";
            cboTipoMas.DataSource = gestor.ObtenerTipos();
            cboTipoMas.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ObtenerProximo()
        {
            int Next = gestor.ObtenerProximo();
            if (Next > 0)
            {
                lblNext.Text = "Nro Mascota " + Next.ToString();
            }
            else
            {
                MessageBox.Show("No se puede obtener la proxima mascota", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtAtencion.Text == "")
            {
                MessageBox.Show("Tiene que agregar una atencion", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            if (txtImporte.Text == "")
            {
                MessageBox.Show("Tiene que agregar un importe", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            string descripcion = txtAtencion.Text;
            double importe = Convert.ToDouble(txtImporte.Text);
            DateTime fecha = dtpFecha.Value;

            Atencion aten = new Atencion(descripcion, importe, fecha);
            nueva.AgregarAtencion(aten);

            dgvMascotas.Rows.Add(aten.Descripcion,
                                   aten.Importe,
                                   aten.Fecha
                );

            txtTotal.Text = nueva.CalcularTotal().ToString();
            LimpiarAtencion();
        }
        private void LimpiarAtencion()
        {
            txtAtencion.Text = "";
            txtImporte.Text = "";
            dtpFecha.Value = DateTime.Now;
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Tiene que agregar un nombre de mascota", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            if (txtEdad.Text == String.Empty)
            {
                MessageBox.Show("Tiene que agregar una edad de mascota", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            if(cboTipoMas.SelectedIndex == -1)
            {
                MessageBox.Show("Tiene que seleccionar un tipo de mascota", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            if (cboCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Tiene que seleccionar un dueño de mascota", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            GuardarAtencion();
        }

        private void GuardarAtencion()
        {
            Cliente c = (Cliente)cboCliente.SelectedItem;
            nueva.Cliente = c;
            nueva.Nombre=txtNombre.Text;
            nueva.Edad = Convert.ToInt32(txtEdad.Text);
            TipoMascota t = (TipoMascota)cboTipoMas.SelectedItem;
            nueva.Tipo=t;

            if (Helper.ObtenerInstancia().ConformarMascota(nueva))
            {
                MessageBox.Show("Se inserto con exito la mascota", "CONFIRMADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar un dueño de mascota", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtAtencion.Text = "";
            txtNombre.Text="";
            txtEdad.Text="";
            cboCliente.SelectedIndex=-1;
            cboTipoMas.SelectedIndex=-1;
            txtImporte.Text="";
            txtTotal.Text="";
            dgvMascotas.Rows.Clear();   
        }
    }

}


