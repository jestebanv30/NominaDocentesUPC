using Entidades;
using Lógica.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using Org.BouncyCastle.Bcpg.OpenPgp;
using iTextSharp.tool.xml.html.head;
using static System.Net.WebRequestMethods;

namespace Presentación
{
    public partial class Form1 : Form
    {
        DocentesService docentesService = new DocentesService(ConfigConnection.conexionstring);
        OcasionalesService ocasionalesService = new OcasionalesService(ConfigConnection.conexionstring);
        RecibosService recibosService = new RecibosService(ConfigConnection.conexionstring);
        CatedraticosService catedraticosService = new CatedraticosService(ConfigConnection.conexionstring);
        public Form1()
        {
            InitializeComponent();
            CargarGrilla(docentesService.GetAll());
            CargarGrillaOcasional(ocasionalesService.GettAll());
            CargarGrillaCatedraticos(catedraticosService.GetAll());

            txtReferencia.Enabled = false;
            txtNombreRecibo.Enabled = false;
            txtNomina.Enabled = false;
            cbOcasional.Enabled = false;
            txtHora.Enabled = false;
            txtValor.Enabled = false;
            txtPhone.MaxLength = 10;

            cbPosgrado.Items.Add("Especializacion");
            cbPosgrado.Items.Add("Maestria");
            cbPosgrado.Items.Add("Doctorado");
            cbPosgrado.Items.Add("Postdoctorado");

            cbPostgradoOcasionalE.Items.Add("Especializacion");
            cbPostgradoOcasionalE.Items.Add("Maestria");
            cbPostgradoOcasionalE.Items.Add("Doctorado");
            cbPostgradoOcasionalE.Items.Add("Postdoctorado");

            cbSemillero.Items.Add("A1");
            cbSemillero.Items.Add("A");
            cbSemillero.Items.Add("B");
            cbSemillero.Items.Add("C");
            cbSemillero.Items.Add("Semillero");
            cbSemillero.Items.Add("Reconocidos por Colciencias");

            cbSemilleroOcasionalE.Items.Add("A1");
            cbSemilleroOcasionalE.Items.Add("A");
            cbSemilleroOcasionalE.Items.Add("B");
            cbSemilleroOcasionalE.Items.Add("C");
            cbSemilleroOcasionalE.Items.Add("Semillero");
            cbSemilleroOcasionalE.Items.Add("Reconocidos por Colciencias");

            cbOcasional.Items.Add("Auxiliar de tiempo completo");
            cbOcasional.Items.Add("Auxiliar de medio tiempo");
            cbOcasional.Items.Add("Asistente de tiempo completo");
            cbOcasional.Items.Add("Asistente de medio tiempo");
            cbOcasional.Items.Add("Asociado de tiempo completo");
            cbOcasional.Items.Add("Asociado de medio tiempo");
            cbOcasional.Items.Add("Titular de tiempo completo");
            cbOcasional.Items.Add("Titular de medio tiempo");

            cbCargoOcasional.Items.Add("Auxiliar de tiempo completo");
            cbCargoOcasional.Items.Add("Auxiliar de medio tiempo");
            cbCargoOcasional.Items.Add("Asistente de tiempo completo");
            cbCargoOcasional.Items.Add("Asistente de medio tiempo");
            cbCargoOcasional.Items.Add("Asociado de tiempo completo");
            cbCargoOcasional.Items.Add("Asociado de medio tiempo");
            cbCargoOcasional.Items.Add("Titular de tiempo completo");
            cbCargoOcasional.Items.Add("Titular de medio tiempo");

            cbPostgradoCatedratico.Items.Add("Especializacion");
            cbPostgradoCatedratico.Items.Add("Maestria");
            cbPostgradoCatedratico.Items.Add("Doctorado");
            cbPostgradoCatedratico.Items.Add("Postdoctorado");

            cbPostgradoSemillero.Items.Add("A1");
            cbPostgradoSemillero.Items.Add("A");
            cbPostgradoSemillero.Items.Add("B");
            cbPostgradoSemillero.Items.Add("C");
            cbPostgradoSemillero.Items.Add("Semillero");
            cbPostgradoSemillero.Items.Add("Reconocidos por Colciencias");
        }
        private void CargarGrilla(List<Docentes> lista)
        {
            try
            {
                dataGridView1.Rows.Clear();

                foreach (var docente in lista)
                {
                    dataGridView1.Rows.Add(new object[]
                    {
                        docente.Id_docente,
                        docente.Nombre,
                        docente.Correo,
                        docente.Telefono,
                        docente.Fecha_nacimiento,
                        docente.Postgrados.Nombre_postgrado,
                        docente.Grupos.Nombre_semillero,
                        docente.Recibos.Nomina
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarGrilla(docentesService.GetAll());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrilla(docentesService.GetAll());
            CargarGrillaOcasional(ocasionalesService.GettAll());
            CargarGrillaCatedraticos(catedraticosService.GetAll());
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla(docentesService.GetAllFiltro(txtFiltro.Text));
        }

        void Guardar()
        {
            if (txtName.Text == "" || txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == ""
                || cbPosgrado.Text == "" || cbSemillero.Text == "" || rdOcasional.Checked == false && rdCatedraticos.Checked == false)
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {

                    if (rdOcasional.Checked == true)
                    {
                        Ocasionales ocasionales = new Ocasionales()
                        {
                            Nombre = txtName.Text,
                            Correo = txtEmail.Text,
                            Telefono = txtPhone.Text,
                            Fecha_nacimiento = dtFecha.Value,
                            Postgrados = new Postgrados()
                            {
                                Id_postgrado = idAsignadoPostgrado,
                            },
                            Grupos = new Grupos()
                            {
                                Id_semillero = idAsigandoSemillero,
                            },
                            Cargos_Ocasionales = new Cargos_ocasionales()
                            {
                                Id_cargo_ocasional = idCargo_ocasional,
                            }
                        };
                        var msj = ocasionalesService.Insert(ocasionales);
                        MessageBox.Show(msj, "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Catedraticos catedraticos = new Catedraticos()
                        {
                            Nombre = txtName.Text,
                            Correo = txtEmail.Text,
                            Telefono = txtPhone.Text,
                            Fecha_nacimiento = dtFecha.Value,
                            Postgrados = new Postgrados()
                            {
                                Id_postgrado = idAsignadoPostgrado,
                            },
                            Grupos = new Grupos()
                            {
                                Id_semillero = idAsigandoSemillero,
                            },
                            Num_horas = Convert.ToInt32(txtHora.Text),
                            Valor_hora = Convert.ToDouble(txtValor.Text),
                        };
                        var msj = catedraticosService.Insert(catedraticos);
                        MessageBox.Show(msj, "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Limpiar();
            }
        }


        int idAsignadoPostgrado = 0;
        private void Elegirpostgrado(ComboBox comboBox)
        {
            string opcionSeleccionada = comboBox.SelectedItem.ToString();

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
        private void ElegirSemillero(ComboBox comboBox)
        {
            string opcionSeleccionada = comboBox.SelectedItem.ToString();

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

        int idCargo_ocasional = 0;
        private void ElegircargoOcasional(ComboBox comboBox)
        {
            string opcionSeleccionada = comboBox.SelectedItem.ToString();

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

        private void cbPosgrado_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Elegirpostgrado(cbPosgrado);
        }

        private void rdOcasional_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdOcasional.Checked == true)
            {
                cbOcasional.Enabled = true;
            }
            else
            {
                cbOcasional.Enabled = false;
                cbOcasional.SelectedIndex = -1;
            }
        }

        private void rdCatedraticos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdCatedraticos.Checked == true)
            {
                txtHora.Enabled = true; txtValor.Enabled = true;
            }
            else
            {
                txtHora.Enabled = false; txtValor.Enabled = false;
                txtHora.Clear(); txtValor.Clear();
            }
        }

        private void cbOcasional_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegircargoOcasional(cbOcasional);
        }

        private void cbSemillero_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegirSemillero(cbSemillero);
        }

        private void Limpiar()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            dtFecha.Value = DateTime.Now;
            cbPosgrado.Items.Clear();
            cbSemillero.Items.Clear();
            cbOcasional.Items.Clear();
            rdOcasional.Checked = false;
            rdCatedraticos.Checked = false;
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
            cbOcasional.Items.Add("Asociado de tiempo completo");
            cbOcasional.Items.Add("Asociado de medio tiempo");
            cbOcasional.Items.Add("Titular de tiempo completo");
            cbOcasional.Items.Add("Titular de medio tiempo");
        }

        private void CargarGrillaOcasional(List<Ocasionales> listaOcasionales)
        {
            try
            {
                grillaOcasionales.Rows.Clear();

                foreach (var ocasional in listaOcasionales)
                {
                    grillaOcasionales.Rows.Add(new object[]
                    {
                        ocasional.Id_ocasional,
                        ocasional.Nombre,
                        ocasional.Correo,
                        ocasional.Telefono,
                        ocasional.Fecha_nacimiento,
                        ocasional.Postgrados.Nombre_postgrado,
                        ocasional.Grupos.Nombre_semillero,
                        ocasional.Cargos_Ocasionales.Cargo_tiempo,
                        ocasional.Cargos_Ocasionales.Salario_cargo,
                        ocasional.Recibos.Nomina
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void grillaOcasionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarGrillaOcasional(ocasionalesService.GettAll());
        }

        private void ListOcasional_Click(object sender, EventArgs e)
        {

        }

        int IdOcasional = 0;
        DateTime FechaOcasional;
        private void EditarOcasional()
        {
            if (grillaOcasionales.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = grillaOcasionales.SelectedRows[0];

                IdOcasional = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                string Nombre = filaSeleccionada.Cells[1].Value.ToString();
                string Correo = filaSeleccionada.Cells[2].Value.ToString();
                string Telefono = filaSeleccionada.Cells[3].Value.ToString();
                FechaOcasional = Convert.ToDateTime(filaSeleccionada.Cells[4].Value);

                txtNombreOcasional.Text = Nombre;
                txtCorreoOcasional.Text = Correo;
                txtTelefonoOcasional.Text = Telefono;
                dtFechaOcasional.Value = FechaOcasional;

            }
            else
            {
                MessageBox.Show("Seleccione un docente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void grillaOcasionales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cbPostgradoOcasionalE_SelectedIndexChanged(object sender, EventArgs e)
        {
            Elegirpostgrado(cbPostgradoOcasionalE);
        }

        private void cbSemilleroOcasionalE_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegirSemillero(cbSemilleroOcasionalE);
        }

        private void cbCargoOcasional_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegircargoOcasional(cbCargoOcasional);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarOcasional();
        }

        private void GuardarCambiosUpdate()
        {
            if (txtNombreOcasional.Text == "" || txtCorreoOcasional.Text == "" || txtTelefonoOcasional.Text == ""
                || cbPostgradoOcasionalE.Text == "" || cbSemilleroOcasionalE.Text == "" || cbCargoOcasional.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Ocasionales ocasionales = new Ocasionales()
                {
                    Id_ocasional = IdOcasional,
                    Nombre = txtNombreOcasional.Text,
                    Correo = txtCorreoOcasional.Text,
                    Telefono = txtTelefonoOcasional.Text,
                    Fecha_nacimiento = FechaOcasional,
                    Postgrados = new Postgrados()
                    {
                        Id_postgrado = idAsignadoPostgrado,
                    },
                    Grupos = new Grupos()
                    {
                        Id_semillero = idAsigandoSemillero,
                    },
                    Cargos_Ocasionales = new Cargos_ocasionales()
                    {
                        Id_cargo_ocasional = idCargo_ocasional,
                    }
                };
                var msj = ocasionalesService.Update(ocasionales);
                MessageBox.Show(msj, "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarGuardarCambiosOcasional();
            }
        }

        private void LimpiarGuardarCambiosOcasional()
        {
            txtNombreOcasional.Text = "";
            txtCorreoOcasional.Text = "";
            txtTelefonoOcasional.Text = "";
            dtFechaOcasional.Value = DateTime.Now;
            cbPostgradoOcasionalE.Items.Clear();
            cbSemilleroOcasionalE.Items.Clear();
            cbCargoOcasional.Items.Clear();
            cbPostgradoOcasionalE.Items.Add("Especializacion");
            cbPostgradoOcasionalE.Items.Add("Maestria");
            cbPostgradoOcasionalE.Items.Add("Doctorado");
            cbPostgradoOcasionalE.Items.Add("Postdoctorado");

            cbSemilleroOcasionalE.Items.Add("A1");
            cbSemilleroOcasionalE.Items.Add("A");
            cbSemilleroOcasionalE.Items.Add("B");
            cbSemilleroOcasionalE.Items.Add("C");
            cbSemilleroOcasionalE.Items.Add("Semillero");
            cbSemilleroOcasionalE.Items.Add("Reconocidos por Colciencias");

            cbCargoOcasional.Items.Add("Auxiliar de tiempo completo");
            cbCargoOcasional.Items.Add("Auxiliar de medio tiempo");
            cbCargoOcasional.Items.Add("Asistente de tiempo completo");
            cbCargoOcasional.Items.Add("Asistente de medio tiempo");
            cbCargoOcasional.Items.Add("Asociado de tiempo completo");
            cbCargoOcasional.Items.Add("Asociado de medio tiempo");
            cbCargoOcasional.Items.Add("Titular de tiempo completo");
            cbCargoOcasional.Items.Add("Titular de medio tiempo");
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            GuardarCambiosUpdate();
            CargarGrillaOcasional(ocasionalesService.GettAll());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarGuardarCambiosOcasional();
        }

        private void txtFiltroOcasional_TextChanged(object sender, EventArgs e)
        {
            CargarGrillaOcasional(ocasionalesService.GetAllFiltro(txtFiltroOcasional.Text));
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }
        int Referencia = 0;
        string TelefonoRecibo;
        string DevengoPostgrado;
        string DevengoGrupo;
        double NominaRecibo;
        private void GenerarRecibo()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                Referencia = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                string Nombre = filaSeleccionada.Cells[1].Value.ToString();
                TelefonoRecibo = filaSeleccionada.Cells[3].Value.ToString();
                DevengoPostgrado = filaSeleccionada.Cells[5].Value.ToString();
                DevengoGrupo = filaSeleccionada.Cells[6].Value.ToString();
                NominaRecibo = Convert.ToDouble(filaSeleccionada.Cells[7].Value);

                txtReferencia.Text = Referencia.ToString();
                txtNombreRecibo.Text = Nombre;
                txtNomina.Text = NominaRecibo.ToString();
                dtRecibo.Value = DateTime.Now;

            }
            else
            {
                MessageBox.Show("Seleccione un docente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnGenerarRecibo_Click(object sender, EventArgs e)
        {
            GenerarRecibo();
        }

        private void ConfirmarRecibo()
        {
            if (txtReferencia.Text == "" || txtNomina.Text == "" || txtObservacion.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Recibos recibos = new Recibos()
                {
                    Docentes = new Docentes()
                    {
                        Id_docente = Referencia
                    },
                    Fecha = dtRecibo.Value,
                    Observaciones = txtObservacion.Text,
                };
                var msj = recibosService.Update(recibos);
                MessageBox.Show(msj, "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Editar recurso html
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = txtNombreRecibo.Text;
                saveFile.Filter = "Archivos PDF (*.pdf)|*.pdf";
                saveFile.ShowDialog();

                string paginahhtml_texto = Properties.Resources.plantilla.ToString();
                paginahhtml_texto = paginahhtml_texto.Replace("@EMPLEADO", txtNombreRecibo.Text);
                paginahhtml_texto = paginahhtml_texto.Replace("@TELEFONO", TelefonoRecibo);
                paginahhtml_texto = paginahhtml_texto.Replace("@FECHA", dtRecibo.Value.ToString("dd/MM//yyyy"));
                paginahhtml_texto = paginahhtml_texto.Replace("@RFERENCIA", Referencia.ToString());
                paginahhtml_texto = paginahhtml_texto.Replace("@TOTAL", NominaRecibo.ToString());

                string filas;

                filas = "<tr><td>Postgrado: " + DevengoPostgrado + "</td><td>APORTES SALUD EMPLEADO</td></tr><tr><td>Grupo: " + DevengoGrupo + "</td><td>APORTES PENSIÓN EMPLEADO</td></tr>";

                paginahhtml_texto = paginahhtml_texto.Replace("@FILAS", filas);

                double deducido;
                deducido = NominaRecibo * 0.08; //Salud y pension

                paginahhtml_texto = paginahhtml_texto.Replace("@DEDUCIDO", deducido.ToString());

                if (saveFile.ShowDialog() == DialogResult.OK) 
                {
                    using(FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);//Margenes
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream); //Cada cambio lo guarda inmediatamente en el archivo de memoria

                        pdfDoc.Open();
                        pdfDoc.Add(new Phrase(""));

                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.iconupc, System.Drawing.Imaging.ImageFormat.Png);
                        img.ScaleToFit(80, 60); // ancho, alto de la imagen
                        img.Alignment = iTextSharp.text.Image.UNDERLYING; // NO importa si hay algo pero pinta la imagen
                        img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                        pdfDoc.Add(img);

                        iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(Properties.Resources.imagedefinitivaupc, System.Drawing.Imaging.ImageFormat.Png);
                        img2.Alignment = iTextSharp.text.Image.UNDERLYING; // NO importa si hay algo pero pinta la imagen
                        img2.SetAbsolutePosition(pdfDoc.LeftMargin - 35, pdfDoc.Top - 370);
                        pdfDoc.Add(img2);

                        using (StringReader  sr = new StringReader(paginahhtml_texto))
                        {
                            // con el objeto sr StringReader pueda leer la estructura html
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr); //Escritor (writer) ten en cuenta en el pdf que puedas añadir el texto html 
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }
                }
                LimpiarDatosRecibo();
            }
        }

        private void LimpiarDatosRecibo()
        {
            txtReferencia.Text = "";
            txtNombreRecibo.Text = "";
            txtNomina.Text = "";
            txtTelefonoOcasional.Text = "";
            dtRecibo.Value = DateTime.Now;
            txtObservacion.Text = "";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ConfirmarRecibo();
        }

        private void btnCancelarRecibo_Click(object sender, EventArgs e)
        {
            LimpiarDatosRecibo();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }   

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtHora_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Guardar();
            CargarGrilla(docentesService.GetAll());
        }

        private void btnLimpiarInicio_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void CargarGrillaCatedraticos(List<Catedraticos> listaCatedraticos)
        {
            try
            {
                GrillaCatedraticos.Rows.Clear();

                foreach (var catedraticos in listaCatedraticos)
                {
                    GrillaCatedraticos.Rows.Add(new object[]
                    {
                        catedraticos.Id_catedratico,
                        catedraticos.Nombre,
                        catedraticos.Correo,
                        catedraticos.Telefono,
                        catedraticos.Fecha_nacimiento,
                        catedraticos.Postgrados.Nombre_postgrado,
                        catedraticos.Grupos.Nombre_semillero,
                        catedraticos.Num_horas,
                        catedraticos.Valor_hora,
                        catedraticos.Salario_bruto,
                        catedraticos.Recibos.Nomina
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GrillaCatedraticos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarGrillaCatedraticos(catedraticosService.GetAll());
        }

        int IdCatedratico = 0;
        DateTime FechaCatedratico;
        private void EditarCatedratico()
        {
            if (GrillaCatedraticos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = GrillaCatedraticos.SelectedRows[0];

                IdCatedratico = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                string Nombre = filaSeleccionada.Cells[1].Value.ToString();
                string Correo = filaSeleccionada.Cells[2].Value.ToString();
                string Telefono = filaSeleccionada.Cells[3].Value.ToString();
                FechaCatedratico = Convert.ToDateTime(filaSeleccionada.Cells[4].Value);
                int Num_hora = Convert.ToInt32(filaSeleccionada.Cells[7].Value);
                int Valor_hora = Convert.ToInt32(filaSeleccionada.Cells[8].Value);

                txtNombreCatedratico.Text = Nombre;
                txtCorreoCatedratico.Text = Correo;
                txtTelefonoCatedratico.Text = Telefono;
                dtFechaCatedratico.Value = FechaCatedratico;
                txtHorasCatedraticos.Text = Num_hora.ToString();
                txtValorHoraCatedratico.Text = Valor_hora.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione un docente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnEditarCatedratico_Click(object sender, EventArgs e)
        {
            EditarCatedratico();
        }

        private void cbPostgradoCatedratico_SelectedIndexChanged(object sender, EventArgs e)
        {
            Elegirpostgrado(cbPostgradoCatedratico);
        }

        private void cbPostgradoSemillero_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegirSemillero(cbPostgradoSemillero);
        }

        private void LimpiarGuardarCambiosCatedraticos()
        {
            txtNombreCatedratico.Text = "";
            txtCorreoCatedratico.Text = "";
            txtTelefonoCatedratico.Text = "";
            dtFechaCatedratico.Value = DateTime.Now;
            txtHorasCatedraticos.Text = "";
            txtValorHoraCatedratico.Text = "";
            cbPostgradoCatedratico.Items.Clear();
            cbPostgradoSemillero.Items.Clear();
            cbPostgradoCatedratico.Items.Add("Especializacion");
            cbPostgradoCatedratico.Items.Add("Maestria");
            cbPostgradoCatedratico.Items.Add("Doctorado");
            cbPostgradoCatedratico.Items.Add("Postdoctorado");

            cbPostgradoSemillero.Items.Add("A1");
            cbPostgradoSemillero.Items.Add("A");
            cbPostgradoSemillero.Items.Add("B");
            cbPostgradoSemillero.Items.Add("C");
            cbPostgradoSemillero.Items.Add("Semillero");
            cbPostgradoSemillero.Items.Add("Reconocidos por Colciencias");
        }

        private void GuardarCambiosCatedratico()
        {
            if (txtNombreCatedratico.Text == "" || txtCorreoCatedratico.Text == "" || txtTelefonoCatedratico.Text == ""
               || cbPostgradoCatedratico.Text == "" || cbPostgradoSemillero.Text == "" || txtHorasCatedraticos.Text == "" || txtValorHoraCatedratico.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Catedraticos catedraticos = new Catedraticos()
                {
                    Id_catedratico = IdCatedratico,
                    Nombre = txtNombreCatedratico.Text,
                    Correo = txtCorreoCatedratico.Text,
                    Telefono = txtTelefonoCatedratico.Text,
                    Fecha_nacimiento = dtFechaCatedratico.Value,
                    Postgrados = new Postgrados()
                    {
                        Id_postgrado = idAsignadoPostgrado,
                    },
                    Grupos = new Grupos()
                    {
                        Id_semillero = idAsigandoSemillero,
                    },
                    Num_horas = Convert.ToInt32(txtHorasCatedraticos.Text),
                    Valor_hora = Convert.ToDouble(txtValorHoraCatedratico.Text),
                };
                var msj = catedraticosService.Update(catedraticos);
                MessageBox.Show(msj, "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarGuardarCambiosCatedraticos();
            }
        }
        private void btnGuardarCambiosCatedratico_Click(object sender, EventArgs e)
        {
            GuardarCambiosCatedratico();
            CargarGrillaCatedraticos(catedraticosService.GetAll());
        }

        private void txtFiltroCatedratico_TextChanged(object sender, EventArgs e)
        {
            CargarGrillaCatedraticos(catedraticosService.GetAllFiltro(txtFiltroCatedratico.Text));
        }

        private void btnCancelarCatedratico_Click(object sender, EventArgs e)
        {
            LimpiarGuardarCambiosCatedraticos();
        }
    }
}
