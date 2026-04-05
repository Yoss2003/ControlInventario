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
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add(valueMember, typeof(int));
                dt.Columns.Add(displayMember, typeof(string));
            }

            object valorSeleccionado = combo.SelectedValue;

            DataRow row = dt.NewRow();
            row[valueMember] = 0;
            row[displayMember] = textoInicial;
            dt.Rows.InsertAt(row, 0);

            combo.DataSource = null;
            combo.Items.Clear();

            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.DataSource = dt;

            if (valorSeleccionado != null && valorSeleccionado.ToString() != "0")
            {
                try { combo.SelectedValue = valorSeleccionado; } catch { }
            }

            if (combo.SelectedIndex <= -1)
            {
                combo.SelectedIndex = 0;
            }
        }
    }
}
