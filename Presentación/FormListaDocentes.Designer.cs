namespace Presentación
{
    partial class FormListaDocentes
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
            this.grillaDocentes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.panelEscritorio = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFiltroOcasional = new System.Windows.Forms.Button();
            this.btnFiltroCatedratico = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.btnCerrarForm = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDocentes)).BeginInit();
            this.panelEscritorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaDocentes
            // 
            this.grillaDocentes.AllowUserToAddRows = false;
            this.grillaDocentes.AllowUserToDeleteRows = false;
            this.grillaDocentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grillaDocentes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.grillaDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaDocentes.Location = new System.Drawing.Point(14, 131);
            this.grillaDocentes.Name = "grillaDocentes";
            this.grillaDocentes.ReadOnly = true;
            this.grillaDocentes.Size = new System.Drawing.Size(890, 426);
            this.grillaDocentes.TabIndex = 1;
            this.grillaDocentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaDocentes_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "FILTRO";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(78, 105);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(266, 20);
            this.txtFiltro.TabIndex = 5;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // panelEscritorio
            // 
            this.panelEscritorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelEscritorio.CausesValidation = false;
            this.panelEscritorio.Controls.Add(this.label2);
            this.panelEscritorio.Controls.Add(this.btnReset);
            this.panelEscritorio.Controls.Add(this.btnFiltroOcasional);
            this.panelEscritorio.Controls.Add(this.btnFiltroCatedratico);
            this.panelEscritorio.Controls.Add(this.btnEliminar);
            this.panelEscritorio.Controls.Add(this.iconPictureBox1);
            this.panelEscritorio.Controls.Add(this.txtFiltro);
            this.panelEscritorio.Controls.Add(this.btnCerrarForm);
            this.panelEscritorio.Controls.Add(this.label1);
            this.panelEscritorio.Controls.Add(this.btnEditar);
            this.panelEscritorio.Controls.Add(this.grillaDocentes);
            this.panelEscritorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEscritorio.Location = new System.Drawing.Point(0, 0);
            this.panelEscritorio.Name = "panelEscritorio";
            this.panelEscritorio.Size = new System.Drawing.Size(916, 639);
            this.panelEscritorio.TabIndex = 16;
            this.panelEscritorio.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEscritorio_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SlateBlue;
            this.label2.Location = new System.Drawing.Point(374, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 17);
            this.label2.TabIndex = 44;
            this.label2.Text = "L I S T A   D O C E N T E S";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(350, 104);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(45, 20);
            this.btnReset.TabIndex = 43;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFiltroOcasional
            // 
            this.btnFiltroOcasional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltroOcasional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.btnFiltroOcasional.FlatAppearance.BorderSize = 0;
            this.btnFiltroOcasional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroOcasional.ForeColor = System.Drawing.Color.White;
            this.btnFiltroOcasional.Location = new System.Drawing.Point(504, 583);
            this.btnFiltroOcasional.Name = "btnFiltroOcasional";
            this.btnFiltroOcasional.Size = new System.Drawing.Size(84, 26);
            this.btnFiltroOcasional.TabIndex = 42;
            this.btnFiltroOcasional.Text = "Ocasionales";
            this.btnFiltroOcasional.UseVisualStyleBackColor = false;
            this.btnFiltroOcasional.Click += new System.EventHandler(this.btnFiltroOcasional_Click);
            // 
            // btnFiltroCatedratico
            // 
            this.btnFiltroCatedratico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltroCatedratico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.btnFiltroCatedratico.FlatAppearance.BorderSize = 0;
            this.btnFiltroCatedratico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroCatedratico.ForeColor = System.Drawing.Color.White;
            this.btnFiltroCatedratico.Location = new System.Drawing.Point(610, 583);
            this.btnFiltroCatedratico.Name = "btnFiltroCatedratico";
            this.btnFiltroCatedratico.Size = new System.Drawing.Size(84, 26);
            this.btnFiltroCatedratico.TabIndex = 41;
            this.btnFiltroCatedratico.Text = "Catedráticos";
            this.btnFiltroCatedratico.UseVisualStyleBackColor = false;
            this.btnFiltroCatedratico.Click += new System.EventHandler(this.btnFiltroCatedratico_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(820, 583);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(84, 26);
            this.btnEliminar.TabIndex = 40;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.SlateBlue;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ListUl;
            this.iconPictureBox1.IconColor = System.Drawing.Color.SlateBlue;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 36;
            this.iconPictureBox1.Location = new System.Drawing.Point(337, 0);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(40, 36);
            this.iconPictureBox1.TabIndex = 37;
            this.iconPictureBox1.TabStop = false;
            // 
            // btnCerrarForm
            // 
            this.btnCerrarForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnCerrarForm.FlatAppearance.BorderSize = 0;
            this.btnCerrarForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarForm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrarForm.Location = new System.Drawing.Point(0, 0);
            this.btnCerrarForm.Name = "btnCerrarForm";
            this.btnCerrarForm.Size = new System.Drawing.Size(36, 25);
            this.btnCerrarForm.TabIndex = 35;
            this.btnCerrarForm.Text = "X";
            this.btnCerrarForm.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(714, 583);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(84, 26);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // FormListaDocentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 639);
            this.Controls.Add(this.panelEscritorio);
            this.Name = "FormListaDocentes";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaDocentes)).EndInit();
            this.panelEscritorio.ResumeLayout(false);
            this.panelEscritorio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaDocentes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Panel panelEscritorio;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Button btnCerrarForm;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFiltroOcasional;
        private System.Windows.Forms.Button btnFiltroCatedratico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
    }
}