using ControlInventario.Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlInventario.Vistas.Extras
{
    public partial class VistaCaracteristicas : Form
    {
        public Dictionary<string, string> CaracteristicasGuardadas { get; private set; }
        public VistaCaracteristicas(Dictionary<string, string> existentes = null)
        {
            InitializeComponent();
            CaracteristicasGuardadas = new Dictionary<string, string>();

            // Si ya habían características guardadas, llenamos la grilla para que el usuario las vea/edite
            if (existentes != null)
            {
                foreach (var item in existentes)
                {
                    DgvCaracteristicas.Rows.Add(item.Key, item.Value);
                }
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            CaracteristicasGuardadas.Clear();

            foreach (DataGridViewRow row in DgvCaracteristicas.Rows)
            {
                if (!row.IsNewRow) // Ignoramos la última fila que siempre está en blanco
                {
                    string nombre = row.Cells[0].Value?.ToString().Trim();
                    string valor = row.Cells[1].Value?.ToString().Trim();

                    // Solo guardamos si ambos campos tienen texto
                    if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(valor))
                    {
                        // Evitamos que el programa explote si el usuario puso dos características con el mismo nombre
                        if (!CaracteristicasGuardadas.ContainsKey(nombre))
                        {
                            CaracteristicasGuardadas.Add(nombre, valor);
                        }
                    }
                }
            }

            // Indicamos que todo salió bien y cerramos la ventana
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void VistaCaracteristicas_Load(object sender, EventArgs e)
        {
            ClassHelper.AplicarTema(this);
        }

        private void btnAgregarFila_Click(object sender, EventArgs e)
        {
            string nombre = TxtNombre.Text.Trim();
            string valor = TxtValor.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Por favor, ingrese tanto el nombre como el valor de la característica.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in DgvCaracteristicas.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Esta característica ya se encuentra en la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DgvCaracteristicas.Rows.Add(nombre, valor);

            TxtNombre.Clear();
            TxtValor.Clear();
            TxtNombre.Focus();
        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            if (DgvCaracteristicas.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = DgvCaracteristicas.SelectedRows[0];

                if (!filaSeleccionada.IsNewRow)
                {
                    DgvCaracteristicas.Rows.Remove(filaSeleccionada);
                }
            }
            else if (DgvCaracteristicas.SelectedCells.Count > 0)
            {
                DataGridViewRow filaDeLaCelda = DgvCaracteristicas.Rows[DgvCaracteristicas.SelectedCells[0].RowIndex];

                if (!filaDeLaCelda.IsNewRow)
                {
                    DgvCaracteristicas.Rows.Remove(filaDeLaCelda);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione la característica que desea eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido de "beep" de Windows

                // 1. Validar que ninguno de los dos TextBoxes esté vacío
                if (string.IsNullOrWhiteSpace(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtValor.Text))
                {
                    MessageBox.Show("Por favor, ingrese tanto el nombre como el valor de la característica.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // 2. Un toque de usabilidad: Devolver el cursor al cuadro que está vacío
                    if (string.IsNullOrWhiteSpace(TxtNombre.Text))
                    {
                        TxtNombre.Focus();
                    }
                    else
                    {
                        TxtValor.Focus();
                    }

                    return; // Detiene el código aquí para que no intente guardar
                }

                // 3. Si ambos tienen texto, procedemos a llamar al botón "+"
                btnAgregarFila_Click(sender, e);
            }
        }
    }
}
