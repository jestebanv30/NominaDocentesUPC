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

namespace Presentación
{
    public partial class FormCrearCatedratico : Form
    {
        OracleConnection conexion = new OracleConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public FormCrearCatedratico()
        {
            InitializeComponent();
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

        }
        void Guardar()
        {
            conexion.Open();

            OracleCommand comandocatedratico = new OracleCommand("insertarDocenteCatedratico", conexion);
            comandocatedratico.CommandType = System.Data.CommandType.StoredProcedure;
            comandocatedratico.Parameters.Add("p_nombre_docente", OracleType.VarChar).Value = txtNombre.Text;
            comandocatedratico.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
            comandocatedratico.Parameters.Add("p_telefono", OracleType.VarChar).Value = txtTelefono.Text;
            comandocatedratico.Parameters.Add("p_fecha_nacimiento", OracleType.DateTime).Value = dtfecha.Value;
            comandocatedratico.Parameters.Add("p_id_postgrado", OracleType.Number).Value = idAsignadoPostgrado;
            comandocatedratico.Parameters.Add("p_id_semillero", OracleType.Number).Value = idAsigandoSemillero;
            comandocatedratico.Parameters.Add("p_num_horas", OracleType.Number).Value = txtHora.Text;
            comandocatedratico.Parameters.Add("p_valor_horas", OracleType.Number).Value = txtValor.Text;
            comandocatedratico.ExecuteNonQuery();
            MessageBox.Show("Docente Catedrático insertado correctamente", "AGREGAR DOCENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conexion.Close();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarForm_MouseEnter(object sender, EventArgs e)
        {
            btnCerrarForm.BackColor = Color.Red;
        }

        private void btnCerrarForm_MouseLeave(object sender, EventArgs e)
        {
            btnCerrarForm.BackColor = Color.FromArgb(34, 33, 74);
        }
        
        int idAsignadoPostgrado = 0;
        private void cbPosgrado_SelectedIndexChanged_1(object sender, EventArgs e)
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
        private void cbSemillero_SelectedIndexChanged_1(object sender, EventArgs e)
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

        void Limpiar()
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            dtfecha.Value = DateTime.Now;
            cbPosgrado.Items.Clear();
            cbSemillero.Items.Clear();
            txtHora.Text = "";
            txtValor.Text = "";
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
