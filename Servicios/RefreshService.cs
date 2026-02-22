using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ControlInventario.Servicios
{
    public class RefreshService
    {
        public void RefrescarCombo<T>(ComboBox combo, List<T> lista, string displayMember, string valueMember, string textoInicial)
        {
            // Crear un objeto ficticio dinámico con Id = 0 y Nombre = textoInicial
            var tipo = typeof(T);
            var objeto = Activator.CreateInstance(tipo);
            tipo.GetProperty(valueMember)?.SetValue(objeto, 0);
            tipo.GetProperty(displayMember)?.SetValue(objeto, textoInicial);

            lista.Insert(0, (T)objeto);

            combo.DataSource = lista;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.SelectedIndex = 0;
        }

        public static void RefrescarComboDT(ComboBox combo, DataTable dt, string displayMember, string valueMember, string textoInicial)
        {
            DataRow row = dt.NewRow();
            row[valueMember] = 0;
            row[displayMember] = textoInicial;
            dt.Rows.InsertAt(row, 0);

            combo.DataSource = dt;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.SelectedIndex = 0;
        }
    }
}
