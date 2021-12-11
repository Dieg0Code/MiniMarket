
namespace UI
{
    partial class FromTipoDocumento
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
            this.btnAcualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.dgvTipoDocumento = new System.Windows.Forms.DataGridView();
            this.Borrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAcualizar
            // 
            this.btnAcualizar.Location = new System.Drawing.Point(531, 202);
            this.btnAcualizar.Name = "btnAcualizar";
            this.btnAcualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAcualizar.TabIndex = 0;
            this.btnAcualizar.Text = "Actualizar";
            this.btnAcualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(531, 259);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 20);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(531, 145);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipodocumento";
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.Location = new System.Drawing.Point(256, 68);
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtTipoDocumento.TabIndex = 4;
            // 
            // dgvTipoDocumento
            // 
            this.dgvTipoDocumento.AllowUserToAddRows = false;
            this.dgvTipoDocumento.AllowUserToDeleteRows = false;
            this.dgvTipoDocumento.AllowUserToOrderColumns = true;
            this.dgvTipoDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoDocumento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Borrar});
            this.dgvTipoDocumento.Location = new System.Drawing.Point(126, 131);
            this.dgvTipoDocumento.Name = "dgvTipoDocumento";
            this.dgvTipoDocumento.ReadOnly = true;
            this.dgvTipoDocumento.Size = new System.Drawing.Size(329, 189);
            this.dgvTipoDocumento.TabIndex = 5;
            // 
            // Borrar
            // 
            this.Borrar.HeaderText = "x";
            this.Borrar.Name = "Borrar";
            this.Borrar.ReadOnly = true;
            // 
            // FromTipoDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTipoDocumento);
            this.Controls.Add(this.txtTipoDocumento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAcualizar);
            this.Name = "FromTipoDocumento";
            this.Text = "FromTipoDocumento";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoDocumento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAcualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.DataGridView dgvTipoDocumento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Borrar;
    }
}