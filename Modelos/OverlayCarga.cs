using System.Drawing;
using System.Windows.Forms;

namespace ControlInventario.Modelos
{
    public class OverlayCarga
    {
        private readonly PictureBox spinner;
        private readonly Form parentForm;

        public OverlayCarga(Form parentForm)
        {
            this.parentForm = parentForm;

            // Crear spinner (GIF de carga)
            spinner = new PictureBox
            {
                Image = Properties.Resources.Spinner, // tu GIF transparente
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            parentForm.Controls.Add(spinner);
            spinner.BringToFront();

            // Centrar spinner dinámicamente cuando el formulario cambie de tamaño
            parentForm.Resize += (s, e) => CentrarSpinner();
        }

        private void CentrarSpinner()
        {
            spinner.Location = new Point(
                (parentForm.ClientSize.Width - spinner.Width) / 2,
                (parentForm.ClientSize.Height - spinner.Height) / 2
            );
        }

        public void Mostrar()
        {
            CentrarSpinner();
            spinner.Visible = true;
            Application.DoEvents(); // refresca la UI
        }

        public void Ocultar()
        {
            spinner.Visible = false;
        }
    }
}