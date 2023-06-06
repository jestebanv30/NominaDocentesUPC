using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Presentación
{
    public partial class FormCrearOcasional : Form
    {
        OracleConnection conexion = new OracleConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public FormCrearOcasional()
        {
            InitializeComponent();

            //txtHora.Enabled = false;
            //txtValor.Enabled = false;
            txtTelefono.MaxLength = 10;

            cbPosgrado.Items.Add("Especializacion");
            cbPosgrado.Items.Add("Maestria");
            cbPosgrado.Items.Add("Doctorado");
            cbPosgrado.Items.Add("Postdoctorado");

            cbSemillero.Items.Add("A1");
            cbSemillero.Items.Add("A");
            cbSemillero.Items.Add("B");
            cbSemillero.Items.Add("C");
            cbSemillero.Items.Add("Semillero");
            cbSemillero.Items.Add("Reconocidos por Colciencias");

            cbOcasional.Items.Add("Auxiliar de tiempo completo");
            cbOcasional.Items.Add("Auxiliar de medio tiempo");
            cbOcasional.Items.Add("Asistente de tiempo completo");
            cbOcasional.Items.Add("Asistente de medio tiempo");
            cbOcasional.Items.Add("Asociacion de tiempo completo");
            cbOcasional.Items.Add("Asociacion de medio tiempo");
            cbOcasional.Items.Add("Titular de tiempo completo");
            cbOcasional.Items.Add("Titular de medio tiempo");
        }

        void Guardar()
        {
            conexion.Open();

                OracleCommand comandoocasional = new OracleCommand("insertarDocenteOcasional", conexion);
                comandoocasional.CommandType = System.Data.CommandType.StoredProcedure;
                comandoocasional.Parameters.Add("p_nombre_docente", OracleType.VarChar).Value = txtNombre.Text;
                comandoocasional.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                comandoocasional.Parameters.Add("p_telefono", OracleType.VarChar).Value = txtTelefono.Text;
                comandoocasional.Parameters.Add("p_fecha_nacimiento", OracleType.DateTime).Value = dtfecha.Value;
                comandoocasional.Parameters.Add("p_id_postgrado", OracleType.Number).Value = idAsignadoPostgrado;
                comandoocasional.Parameters.Add("p_id_semillero", OracleType.Number).Value = idAsigandoSemillero;
                comandoocasional.Parameters.Add("p_id_cargo_ocasional", OracleType.Number).Value = idCargo_ocasional;
                comandoocasional.ExecuteNonQuery();
                MessageBox.Show("Docente Ocasional insertado correctamente", "AGREGAR DOCENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
        }

        //    if (txtId.Text == "" || txtNombre.Text == "" || txtCorreo.Text == "" || txtTelefono.Text == "" || dtfecha.Value == dtfecha.MinDate
        //        || cbPosgrado.Text == "" || cbSemillero.Text == "" || rdOcasional.Checked == false && rdCatedraticos.Checked == false)
        //    {
        //        MessageBox.Show("FALTAN DATOS POR COMPLETAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {

        //    }
        
        int idAsignadoPostgrado = 0;
        private void cbPosgrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcionSeleccionada = cbPosgrado.SelectedItem.ToString();

            switch (opcionSeleccionada)
            {
                case "Especializacion":
                    idAsignadoPostgrado = 41;
                    break;
                case "Maestria":
                    idAsignadoPostgrado = 42;
                    break;
                case "Doctorado":
                    idAsignadoPostgrado = 43;
                    break;
                case "Postdoctorado":
                    idAsignadoPostgrado = 44;
                    break;
            }
        }

        int idAsigandoSemillero = 0;
        private void cbSemillero_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcionSeleccionada = cbSemillero.SelectedItem.ToString();

            switch (opcionSeleccionada)
            {
                case "A1":
                    idAsigandoSemillero = 1;
                    break;
                case "A":
                    idAsigandoSemillero = 2;
                    break;
                case "B":
                    idAsigandoSemillero = 3;
                    break;
                case "C":
                    idAsigandoSemillero = 4;
                    break;
                case "Semillero":
                    idAsigandoSemillero = 5;
                    break;
                case "Reconocidos por Colciencias":
                    idAsigandoSemillero = 6;
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        int idCargo_ocasional = 0;
        private void cbOcasional_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcionSeleccionada = cbOcasional.SelectedItem.ToString();

            switch (opcionSeleccionada)
            {
                case "Auxiliar de tiempo completo":
                    idCargo_ocasional = 1;
                    break;
                case "Auxiliar de medio tiempo":
                    idCargo_ocasional = 2;
                    break;
                case "Asistente de tiempo completo":
                    idCargo_ocasional = 3;
                    break;
                case "Asistente de medio tiempo":
                    idCargo_ocasional = 4;
                    break;
                case "Asociado de tiempo completo":
                    idCargo_ocasional = 5;
                    break;
                case "Asociado de medio tiempo":
                    idCargo_ocasional = 6;
                    break;
                case "Titular de tiempo completo":
                    idCargo_ocasional = 7;
                    break;
                case "Titular de medio tiempo":
                    idCargo_ocasional = 8;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarForm_MouseEnter(object sender, EventArgs e)
        {
            btnCerrarForm.BackColor = Color.Red;
        }

        private void btnCerrarForm_MouseLeave(object sender, EventArgs e)
        {
            btnCerrarForm.BackColor = Color.FromArgb(34, 33, 74);
        }

        private void panelEscritorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }
        void Limpiar()
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            dtfecha.Value = DateTime.Now;
            cbPosgrado.Items.Clear();
            cbSemillero.Items.Clear();
            cbOcasional.Items.Clear();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
