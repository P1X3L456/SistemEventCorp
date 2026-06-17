using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemEventCorp.Clases
{
    internal class AyudaFormulario
    {
        public static void PrepararGrilla(DataGridView grilla)
        {
            grilla.ReadOnly = true;
            grilla.MultiSelect = false;
            grilla.AllowUserToAddRows = false;
            grilla.AllowUserToDeleteRows = false;
            grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grilla.AutoGenerateColumns = true;
        }

        public static void CargarGrilla(DataGridView grilla, DataTable tabla, params string[] columnasOcultas)
        {
            PrepararGrilla(grilla);
            grilla.DataSource = null;
            grilla.Columns.Clear();
            grilla.DataSource = tabla ?? new DataTable();

            foreach (string columna in columnasOcultas)
            {
                if (grilla.Columns.Contains(columna))
                {
                    grilla.Columns[columna].Visible = false;
                }
            }
        }

        public static void CargarCombo(ComboBox combo, DataTable tabla, string valor, string texto)
        {
            combo.DataSource = null;
            combo.Items.Clear();
            combo.DropDownStyle = ComboBoxStyle.DropDownList;

            if (tabla == null || tabla.Rows.Count == 0)
            {
                return;
            }

            if (!tabla.Columns.Contains(valor) || !tabla.Columns.Contains(texto))
            {
                throw new InvalidOperationException("El catalogo no tiene las columnas esperadas.");
            }

            combo.ValueMember = valor;
            combo.DisplayMember = texto;
            combo.DataSource = tabla;
        }

        public static ComboBox CrearComboEnLugarDe(TextBox cajaTexto, Control contenedor)
        {
            ComboBox combo = new ComboBox();
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Font = cajaTexto.Font;
            combo.Location = cajaTexto.Location;
            combo.Size = cajaTexto.Size;
            combo.Anchor = cajaTexto.Anchor;
            combo.TabIndex = cajaTexto.TabIndex;

            cajaTexto.Visible = false;
            contenedor.Controls.Add(combo);
            combo.BringToFront();

            return combo;
        }

        public static string Texto(TextBox cajaTexto)
        {
            return cajaTexto.Text.Trim();
        }

        public static bool Requerido(TextBox cajaTexto, string campo)
        {
            if (!string.IsNullOrWhiteSpace(cajaTexto.Text))
            {
                return true;
            }

            Aviso("Completa el campo " + campo + " para continuar.");
            cajaTexto.Focus();
            return false;
        }

        public static bool ObtenerEntero(TextBox cajaTexto, string campo, out int valor)
        {
            if (int.TryParse(Texto(cajaTexto), out valor) && valor >= 0)
            {
                return true;
            }

            Aviso("Escribe un numero valido en " + campo + ".");
            cajaTexto.Focus();
            return false;
        }

        public static bool ObtenerDecimal(TextBox cajaTexto, string campo, out decimal valor)
        {
            string texto = Texto(cajaTexto);

            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out valor) ||
                decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
            {
                return true;
            }

            Aviso("Escribe un valor valido en " + campo + ".");
            cajaTexto.Focus();
            return false;
        }

        public static bool ObtenerFecha(TextBox cajaTexto, string campo, out DateTime fecha)
        {
            if (DateTime.TryParse(Texto(cajaTexto), out fecha))
            {
                return true;
            }

            Aviso("Escribe una fecha valida en " + campo + ".");
            cajaTexto.Focus();
            return false;
        }

        public static bool ObtenerHora(TextBox cajaTexto, string campo, out TimeSpan hora)
        {
            if (TimeSpan.TryParse(Texto(cajaTexto), out hora))
            {
                return true;
            }

            Aviso("Escribe una hora valida en " + campo + ". Ejemplo: 09:30");
            cajaTexto.Focus();
            return false;
        }

        public static bool ObtenerIdCombo(ComboBox combo, string campo, out int valor)
        {
            valor = 0;

            if (combo.SelectedValue != null &&
                combo.SelectedValue != DBNull.Value &&
                int.TryParse(combo.SelectedValue.ToString(), out valor))
            {
                return true;
            }

            Aviso("Selecciona " + campo + " para continuar.");
            combo.Focus();
            return false;
        }

        public static bool ObtenerIdFila(DataGridView grilla, string columna, out int valor)
        {
            valor = 0;

            if (grilla.CurrentRow == null || !grilla.Columns.Contains(columna))
            {
                Aviso("Selecciona un registro de la lista.");
                return false;
            }

            object dato = grilla.CurrentRow.Cells[columna].Value;
            if (dato != null && dato != DBNull.Value && int.TryParse(dato.ToString(), out valor))
            {
                return true;
            }

            Aviso("El registro seleccionado no tiene identificador valido.");
            return false;
        }

        public static string ValorFila(DataGridView grilla, string columna)
        {
            if (grilla.CurrentRow == null || !grilla.Columns.Contains(columna))
            {
                return string.Empty;
            }

            object dato = grilla.CurrentRow.Cells[columna].Value;
            return dato == null || dato == DBNull.Value ? string.Empty : dato.ToString();
        }

        public static string CrearCodigo(string prefijo)
        {
            return prefijo + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public static void SepararNombre(string nombreCompleto, out string nombres, out string apellidos)
        {
            string limpio = (nombreCompleto ?? string.Empty).Trim();
            string[] partes = limpio.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length <= 1)
            {
                nombres = limpio;
                apellidos = string.Empty;
                return;
            }

            apellidos = partes[partes.Length - 1];
            nombres = limpio.Substring(0, limpio.Length - apellidos.Length).Trim();
        }

        public static int ContarEstado(DataTable tabla, string columna, string estado)
        {
            if (tabla == null || !tabla.Columns.Contains(columna))
            {
                return 0;
            }

            int total = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                string valor = Convert.ToString(fila[columna]);
                if (string.Equals(valor, estado, StringComparison.OrdinalIgnoreCase))
                {
                    total++;
                }
            }

            return total;
        }

        public static int SumarEnteros(DataTable tabla, string columna)
        {
            if (tabla == null || !tabla.Columns.Contains(columna))
            {
                return 0;
            }

            int total = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                int valor;
                if (fila[columna] != DBNull.Value && int.TryParse(fila[columna].ToString(), out valor))
                {
                    total += valor;
                }
            }

            return total;
        }

        public static string PrimerValor(DataTable tabla, string columna)
        {
            if (tabla == null || tabla.Rows.Count == 0 || !tabla.Columns.Contains(columna))
            {
                return "-";
            }

            object valor = tabla.Rows[0][columna];
            return valor == DBNull.Value ? "-" : Convert.ToString(valor);
        }

        public static void Info(string mensaje)
        {
            MessageBox.Show(mensaje, "SistemEventCorp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "SistemEventCorp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string mensaje, Exception ex)
        {
            MessageBox.Show(mensaje + Environment.NewLine + ex.Message, "SistemEventCorp", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ExportarCsv(DataTable tabla)
        {
            if (tabla == null || tabla.Rows.Count == 0)
            {
                Aviso("No hay datos para exportar.");
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "Archivo CSV (*.csv)|*.csv";
                dialogo.FileName = "reporte_eventcorp.csv";

                if (dialogo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                File.WriteAllText(dialogo.FileName, CrearCsv(tabla), Encoding.UTF8);
                Info("Reporte exportado correctamente.");
            }
        }

        private static string CrearCsv(DataTable tabla)
        {
            StringBuilder contenido = new StringBuilder();

            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                if (i > 0)
                {
                    contenido.Append(",");
                }

                contenido.Append(EscaparCsv(tabla.Columns[i].ColumnName));
            }

            contenido.AppendLine();

            foreach (DataRow fila in tabla.Rows)
            {
                for (int i = 0; i < tabla.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        contenido.Append(",");
                    }

                    contenido.Append(EscaparCsv(Convert.ToString(fila[i])));
                }

                contenido.AppendLine();
            }

            return contenido.ToString();
        }

        private static string EscaparCsv(string valor)
        {
            valor = valor ?? string.Empty;
            return "\"" + valor.Replace("\"", "\"\"") + "\"";
        }
    }
}
