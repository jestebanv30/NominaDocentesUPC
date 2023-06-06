using Microsoft.Win32;
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
    public partial class FormListaDocentes : Form
    {
        OracleConnection conexion = new OracleConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public FormListaDocentes()
        {
            InitializeComponent();
            CargarGrilla();
        }

        void CargarGrilla()
        {
            txtFiltro.Text = "";
            conexion.Open();
            OracleCommand comando = new OracleCommand("seleccionarDocentes", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comando;
            
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            grillaDocentes.DataSource = tabla;

            conexion.Close();
        }
        void CargarGrillaOcasional()
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("seleccionarOcasionales", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            grillaDocentes.DataSource = tabla;

            conexion.Close();
        }
        void CargarGrillaCatedraticos()
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("seleccionarCatedraticos", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            grillaDocentes.DataSource = tabla;

            conexion.Close();
        }
        void Filtro()
        {
                if (txtFiltro.Text != "")
                {
                    grillaDocentes.CurrentCell = null;

                    foreach (DataGridViewRow fila in grillaDocentes.Rows)
                    {
                        fila.Visible = false;
                    }
                    foreach (DataGridViewRow fila in grillaDocentes.Rows)
                    {
                        foreach (DataGridViewCell celdas in fila.Cells)
                        {
                            if (celdas.Value.ToString().ToUpper().IndexOf(txtFiltro.Text.ToUpper()) == 0)
                            {
                                fila.Visible = true;
                                break;
                            }
                        }
                    }

                }
                else
                {
                    CargarGrilla();
                }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            Filtro();
        }

        private void panelEscritorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grillaDocentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarGrilla();
        }

        private void btnFiltroOcasional_Click(object sender, EventArgs e)
        {
            CargarGrillaOcasional();
        }

        private void btnFiltroCatedratico_Click(object sender, EventArgs e)
        {
            CargarGrillaCatedraticos();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
