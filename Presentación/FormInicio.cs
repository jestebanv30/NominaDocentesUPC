using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentación
{
    public partial class FormInicio : Form
    {
        private Form formabrir;
        public FormInicio()
        {
            InitializeComponent();
            DiseñoPanel();
        }
        private void DiseñoPanel()
        {
            panelList1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }
        private void OcultarPanel()
        {
            if (panelList1.Visible == true)
            {
                panelList1.Visible = false;
            }
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            if (panel3.Visible == true)
            {
                panel3.Visible = false;
            }
        }
        private void MostrarPanel(Panel subpanel) // Tomo como parametro el panel que se desea mostrar u ocultar
        {
            // Metodo para reciclar en cualquier panel
            if (subpanel.Visible == false)
            {
                subpanel.Visible = true;
            }
            else
            {
                subpanel.Visible = false;
            }
        }
        void Abrirformdentro(Form formdentro)
        {
            if (formabrir != null)
                formabrir.Close();
            formabrir = formdentro;
            formdentro.TopLevel = false;
            formdentro.FormBorderStyle = FormBorderStyle.None;
            formdentro.Dock = DockStyle.Fill;
            panelEscritorio.Controls.Add(formdentro);
            panelEscritorio.Tag = formdentro;
            formdentro.BringToFront();
            formdentro.Show();
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            DiseñoPanel();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelList1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconbtnDocentes_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelList1);
        }

        private void iconbtnOcasional_Click(object sender, EventArgs e)
        {
            MostrarPanel(panel1);
        }

        private void iconbtnCatedratico_Click(object sender, EventArgs e)
        {
            MostrarPanel(panel2);
        }

        private void iconbtnRecibo_Click(object sender, EventArgs e)
        {
            MostrarPanel(panel3);
        }

        private void btnListaDocente_Click(object sender, EventArgs e)
        {
            Abrirformdentro(new FormListaDocentes());
            OcultarPanel();
        }

        private void btnCrearOcasional_Click(object sender, EventArgs e)
        {
            Abrirformdentro(new FormCrearOcasional());
            OcultarPanel();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButtonSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e) // Crear docente catedratico
        {
            Abrirformdentro(new FormCrearCatedratico());
            OcultarPanel();
        }
    }
}
