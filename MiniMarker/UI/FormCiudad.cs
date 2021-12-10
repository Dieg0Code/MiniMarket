using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica;

namespace UI
{
    public partial class FormCiudad : Form
    {
        public FormCiudad()
        {
            InitializeComponent();
        }

        private void FormCiudad_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Listar();
            this.txtId_Ciudad.Enabled = false;
        }

        // Declaracion de variable respuesta
        string respuesta = "";

        // Metodo para agregar ciudad
        private void Guardar()
        {
            try
            {
                respuesta = LogicaCiudad.Guardar(this.txtCiudad.Text.Trim().ToUpper());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }

            if (respuesta.Equals("Guardado"))
            {
                respuesta = "Guardado con exito!";
            }
            else
            {
                respuesta = "Registro no guardado";
            }

            Listar();
            Limpiar();
            
        }

        // Metodo para actualizar ciudad
        private void Actualizar()
        {
            try
            {
                respuesta = LogicaCiudad.Actualizar(int.Parse(this.txtId_Ciudad.Text),
                                                    this.txtCiudad.Text.Trim().ToUpper());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }

            if (respuesta.Equals("Actualizado"))
            {
                respuesta = "Actualizado con exito!";
            }
            else
            {
                respuesta = "Registro no actualizado";
            }

            this.Listar();
            this.Limpiar();
        }

        // Metodo para eliminar ciudad
        private void Eliminar()
        {
            try
            {
                DialogResult advertencia;
                advertencia = MessageBox.Show("Desea eliminar los registros", "Sistema", 
                                              MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (advertencia == DialogResult.OK)
                {
                    string codigo;
                    string respuesta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            respuesta = LogicaCiudad.Eliminar(Convert.ToInt32(codigo));
                        }
                    }
                    this.Listar();
                    this.Limpiar();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }

        // Metodo listar ciudades
        private void Listar()
        {
            this.dgvListado.DataSource = LogicaCiudad.Listar();
        }

        // Metodo para limpiar los textbox
        private void Limpiar()
        {
            this.txtId_Ciudad.Text = string.Empty;
            this.txtCiudad.Text = string.Empty;
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtId_Ciudad.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["ID_CIUDAD"].Value);
            this.txtCiudad.Text = Convert.ToString(this.dgvListado.CurrentRow.Cells["CIU_NOMBRE"].Value);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Borrar"].Index)
            {
                DataGridViewCheckBoxCell borrar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Borrar"];
                borrar.Value = !Convert.ToBoolean(borrar.Value);
            }
        }
    }
}
