using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ControlInventario.Servicios
{
    public class RefreshService
    {
        public static void RefrescarComboDT(ComboBox combo, DataTable dt, string displayMember, string valueMember, string textoInicial)
        {
            object valorSeleccionado = combo.SelectedValue;

            DataRow row = dt.NewRow();
            row[valueMember] = 0;
            row[displayMember] = textoInicial;
            dt.Rows.InsertAt(row, 0);

            combo.BeginUpdate();

            combo.DataSource = dt;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;

            if (valorSeleccionado != null)
            {
                combo.SelectedValue = valorSeleccionado;

                if(combo.SelectedIndex == -1)
                {
                    combo.SelectedIndex = 0;
                }
            }
            else
            {
                combo.SelectedIndex = 0;
            }

            combo.EndUpdate();
        }
    }
}
