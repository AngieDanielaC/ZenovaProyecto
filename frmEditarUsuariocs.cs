using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmEditarUsuariocs : Form
    {
        private int idUsuario;
        private int idRolOriginal;
        private string nombreRolOriginal;


        private List<int> deportesSeleccionados =
            new List<int>();
        public frmEditarUsuariocs(int idUsuario)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
        }
        public frmEditarUsuariocs()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }
        private void CargarUsuario()
        {
            csConectaSQL conexion =
                new csConectaSQL();

            if (conexion.abrirConexion())
            {
                try
                {
                    string consulta = @"
                SELECT
                    U.Foto,
                    U.Nombres,
                    U.Apellidos,
                    U.Telefono,
                    U.Direccion,
                    U.Correo,
                    U.IdRol,
                    R.NombreRol
                FROM Usuarios U
                INNER JOIN Roles R
                    ON U.IdRol = R.IdRol
                WHERE U.IdUsuario = @IdUsuario;
            ";

                    SqlCommand comando =
                        new SqlCommand(
                            consulta,
                            conexion.oCon);

                    comando.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);

                    SqlDataReader lector =
                        comando.ExecuteReader();

                    if (lector.Read())
                    {
                        // ==============================
                        // NOMBRES
                        // ==============================
                        txtNombres.Text =
                            lector["Nombres"].ToString();


                        // ==============================
                        // APELLIDOS
                        // ==============================
                        txtApellidos.Text =
                            lector["Apellidos"].ToString();


                        // ==============================
                        // TELÉFONO
                        // ==============================
                        txtTelefono.Text =
                            lector["Telefono"].ToString();


                        // ==============================
                        // DIRECCIÓN
                        // ==============================
                        txtDireccion.Text =
                            lector["Direccion"].ToString();


                        // ==============================
                        // CORREO
                        // ==============================
                        txtCorreo.Text =
                            lector["Correo"].ToString();


                        // ==============================
                        // ROL
                        // ==============================
                        int idRol =
                            Convert.ToInt32(
                                lector["IdRol"]);

                        string nombreRol =
                            lector["NombreRol"].ToString();
                        idRolOriginal = idRol;
                        nombreRolOriginal = nombreRol;

                        cmbRol.SelectedValue =
                            idRol;


                        // ==============================
                        // FOTO
                        // ==============================
                        if (lector["Foto"] != DBNull.Value)
                        {
                            byte[] bytesFoto =
                                (byte[])lector["Foto"];

                            using (MemoryStream ms =
                                   new MemoryStream(bytesFoto))
                            {
                                using (Image imagen =
                                       Image.FromStream(ms))
                                {
                                    picFoto.Image =
                                        new Bitmap(imagen);
                                }
                            }

                            picFoto.SizeMode =
                                PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            picFoto.Image = null;
                        }


                        // Cerramos lector antes de
                        // hacer otra consulta
                        lector.Close();


                        // ==============================
                        // SI ES ENTRENADOR
                        // ==============================
                        if (nombreRol == "Entrenador")
                        {
                            pnlDatosEntrenador.Visible = true;

                            CargarDeportesEntrenador();
                        }
                        else
                        {
                            pnlDatosEntrenador.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al cargar el usuario:\n\n" +
                        ex.Message,
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    conexion.cerrarConexion();
                }
            }
        }
        private void CargarDeportesEntrenador()
        {
            deportesSeleccionados.Clear();
            lstDeportes.Items.Clear();

            csConectaSQL conexion = new csConectaSQL();

            if (conexion.abrirConexion())
            {
                try
                {
                    string consulta = @"
                SELECT
                    D.IdDeporte,
                    D.NombreDeporte
                FROM Entrenadores E
                INNER JOIN EntrenadorDeporte ED
                    ON E.IdEntrenador = ED.IdEntrenador
                INNER JOIN Deportes D
                    ON ED.IdDeporte = D.IdDeporte
                WHERE
                    E.IdUsuario = @IdUsuario
                    AND ED.Activo = 1
                ORDER BY D.NombreDeporte;
            ";

                    SqlCommand comando =
                        new SqlCommand(
                            consulta,
                            conexion.oCon);

                    comando.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);

                    SqlDataReader lector =
                        comando.ExecuteReader();

                    while (lector.Read())
                    {
                        int idDeporte =
                            Convert.ToInt32(
                                lector["IdDeporte"]);

                        string nombreDeporte =
                            lector["NombreDeporte"].ToString();

                        deportesSeleccionados.Add(idDeporte);

                        lstDeportes.Items.Add(nombreDeporte);
                    }

                    lector.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al cargar los deportes del entrenador:\n\n" +
                        ex.Message,
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    conexion.cerrarConexion();
                }
            }
        }

        private void frmEditarUsuariocs_Load(object sender, EventArgs e)
        {
            pnlDatosEntrenador.Visible = false;

            CargarRoles();

            CargarDeportes();

            CargarUsuario();
        }
        private void CargarRoles()
        {
            csConectaSQL conexion =
                new csConectaSQL();

            if (conexion.abrirConexion())
            {
                try
                {
                    string consulta = @"
                        SELECT
                            IdRol,
                            NombreRol
                        FROM Roles
                        WHERE Activo = 1
                        ORDER BY NombreRol;
                    ";

                    SqlDataAdapter adaptador =
                        new SqlDataAdapter(
                            consulta,
                            conexion.oCon);

                    DataTable tabla =
                        new DataTable();

                    adaptador.Fill(tabla);

                    cmbRol.DataSource = tabla;

                    cmbRol.DisplayMember =
                        "NombreRol";

                    cmbRol.ValueMember =
                        "IdRol";

                    cmbRol.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al cargar los roles:\n\n" +
                        ex.Message,
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    conexion.cerrarConexion();
                }
            }
        }
        private void CargarDeportes()
        {
            csConectaSQL conexion =
                new csConectaSQL();

            if (conexion.abrirConexion())
            {
                try
                {
                    string consulta = @"
                        SELECT
                            IdDeporte,
                            NombreDeporte
                        FROM Deportes
                        WHERE Activo = 1
                        ORDER BY NombreDeporte;
                    ";

                    SqlDataAdapter adaptador =
                        new SqlDataAdapter(
                            consulta,
                            conexion.oCon);

                    DataTable tabla =
                        new DataTable();

                    adaptador.Fill(tabla);

                    cmbDeporte.DataSource = tabla;

                    cmbDeporte.DisplayMember =
                        "NombreDeporte";

                    cmbDeporte.ValueMember =
                        "IdDeporte";

                    cmbDeporte.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al cargar los deportes:\n\n" +
                        ex.Message,
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    conexion.cerrarConexion();
                }
            }
        }

        private void btnAgregarDeporte_Click(object sender, EventArgs e)
        {
            if (cmbDeporte.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un deporte.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idDeporte =
                Convert.ToInt32(
                    cmbDeporte.SelectedValue);

            string nombreDeporte =
                cmbDeporte.Text;


            // Evitar repetidos
            if (deportesSeleccionados.Contains(
                idDeporte))
            {
                MessageBox.Show(
                    "Este deporte ya está asignado.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            deportesSeleccionados.Add(
                idDeporte);

            lstDeportes.Items.Add(
                nombreDeporte);

            cmbDeporte.SelectedIndex = -1;
        }

        private void btnQuitarDeporte_Click(object sender, EventArgs e)
        {
            if (lstDeportes.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el deporte que desea quitar.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // Si sigue siendo entrenador,
            // debe conservar mínimo un deporte
            if (cmbRol.Text == "Entrenador" &&
                deportesSeleccionados.Count == 1)
            {
                MessageBox.Show(
                    "Un entrenador debe tener al menos un deporte asignado.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int posicion =
                lstDeportes.SelectedIndex;

            deportesSeleccionados.RemoveAt(
                posicion);

            lstDeportes.Items.RemoveAt(
                posicion);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo =
                new OpenFileDialog();

            dialogo.Filter =
                "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialogo.ShowDialog() ==
                DialogResult.OK)
            {
                using (Image imagen =
                       Image.FromFile(dialogo.FileName))
                {
                    picFoto.Image =
                        new Bitmap(imagen);
                }

                picFoto.SizeMode =
                    PictureBoxSizeMode.Zoom;
            }
        }
        private byte[] ImagenABytes(
            Image imagen)
        {
            if (imagen == null)
            {
                return null;
            }

            using (MemoryStream ms =
                   new MemoryStream())
            {
                imagen.Save(
                    ms,
                    System.Drawing.Imaging
                        .ImageFormat.Png);

                return ms.ToArray();
            }
        }
        private bool ValidarCampos()
        {
            if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese los nombres.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombres.Focus();

                return false;
            }


            if (txtApellidos.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese los apellidos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtApellidos.Focus();

                return false;
            }


            // TELÉFONO
            string telefono =
                txtTelefono.Text.Trim();

            if (telefono.Length != 10 ||
                !telefono.All(char.IsDigit))
            {
                MessageBox.Show(
                    "El teléfono debe contener exactamente 10 dígitos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelefono.Focus();

                return false;
            }


            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese la dirección.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDireccion.Focus();

                return false;
            }


            if (txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el correo electrónico.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();

                return false;
            }


            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un rol.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }


            if (cmbRol.Text == "Entrenador" &&
                deportesSeleccionados.Count == 0)
            {
                MessageBox.Show(
                    "El entrenador debe tener al menos un deporte asignado.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }


            return true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool TieneDeportistasAsignados()
        {
            // Todavía no tenemos implementada aquí
            // la tabla de asignaciones de deportistas.
            // Cuando hagamos Gestión de Entrenadores
            // completaremos esta validación.

            return false;
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            // ==========================================
            // OBTENER NUEVO ROL
            // ==========================================
            int idRolNuevo =
                Convert.ToInt32(cmbRol.SelectedValue);

            string nombreRolNuevo =
                cmbRol.Text;


            // ==========================================
            // VALIDACIÓN:
            // ENTRENADOR → OTRO ROL
            // ==========================================
            if (nombreRolOriginal == "Entrenador" &&
                nombreRolNuevo != "Entrenador")
            {
                if (TieneDeportistasAsignados())
                {
                    MessageBox.Show(
                        "No puede cambiar el rol del entrenador porque todavía tiene deportistas asignados.\n\n" +
                        "Primero debe realizar la reasignación desde Gestión de Entrenadores.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            // FOTO A BYTES

            byte[] foto =
                ImagenABytes(picFoto.Image);
            // CONEXIÓN
            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
            {
                return;
            }


            SqlTransaction transaccion =
                conexion.oCon.BeginTransaction();


            try
            {
                // 1. ACTUALIZAR USUARIO
                string sqlUsuario = @"
            UPDATE Usuarios
            SET
                Nombres = @Nombres,
                Apellidos = @Apellidos,
                Telefono = @Telefono,
                Direccion = @Direccion,
                Correo = @Correo,
                Foto = @Foto,
                IdRol = @IdRol
            WHERE IdUsuario = @IdUsuario;
        ";


                SqlCommand cmdUsuario =
                    new SqlCommand(
                        sqlUsuario,
                        conexion.oCon,
                        transaccion);


                cmdUsuario.Parameters.AddWithValue(
                    "@Nombres",
                    txtNombres.Text.Trim());

                cmdUsuario.Parameters.AddWithValue(
                    "@Apellidos",
                    txtApellidos.Text.Trim());

                cmdUsuario.Parameters.AddWithValue(
                    "@Telefono",
                    txtTelefono.Text.Trim());

                cmdUsuario.Parameters.AddWithValue(
                    "@Direccion",
                    txtDireccion.Text.Trim());

                cmdUsuario.Parameters.AddWithValue(
                    "@Correo",
                    txtCorreo.Text.Trim());

                cmdUsuario.Parameters.AddWithValue(
                    "@IdRol",
                    idRolNuevo);

                cmdUsuario.Parameters.AddWithValue(
                    "@IdUsuario",
                    idUsuario);


                if (foto != null)
                {
                    cmdUsuario.Parameters.Add(
                        "@Foto",
                        SqlDbType.VarBinary).Value = foto;
                }
                else
                {
                    cmdUsuario.Parameters.Add(
                        "@Foto",
                        SqlDbType.VarBinary).Value = DBNull.Value;
                }


                cmdUsuario.ExecuteNonQuery();
                // 2. SI ANTES NO ERA ENTRENADOR
                //    Y AHORA SÍ

                if (nombreRolOriginal != "Entrenador" &&
                    nombreRolNuevo == "Entrenador")
                {
                    string sqlNuevoEntrenador = @"
                INSERT INTO Entrenadores
                (
                    IdUsuario,
                    EstadoEntrenador
                )
                VALUES
                (
                    @IdUsuario,
                    'Activo'
                );

                SELECT SCOPE_IDENTITY();
            ";


                    SqlCommand cmdNuevoEntrenador =
                        new SqlCommand(
                            sqlNuevoEntrenador,
                            conexion.oCon,
                            transaccion);


                    cmdNuevoEntrenador.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);


                    int idEntrenador =
                        Convert.ToInt32(
                            cmdNuevoEntrenador.ExecuteScalar());


                    foreach (int idDeporte
                             in deportesSeleccionados)
                    {
                        string sqlDeporte = @"
                    INSERT INTO EntrenadorDeporte
                    (
                        IdEntrenador,
                        IdDeporte,
                        Activo
                    )
                    VALUES
                    (
                        @IdEntrenador,
                        @IdDeporte,
                        1
                    );
                ";


                        SqlCommand cmdDeporte =
                            new SqlCommand(
                                sqlDeporte,
                                conexion.oCon,
                                transaccion);


                        cmdDeporte.Parameters.AddWithValue(
                            "@IdEntrenador",
                            idEntrenador);

                        cmdDeporte.Parameters.AddWithValue(
                            "@IdDeporte",
                            idDeporte);


                        cmdDeporte.ExecuteNonQuery();
                    }
                }

                // 3. SI YA ERA ENTRENADOR
                //    Y SIGUE SIENDO ENTRENADOR
                else if (nombreRolOriginal == "Entrenador" &&
                         nombreRolNuevo == "Entrenador")
                {
                    int idEntrenador = 0;


                    string sqlBuscarEntrenador = @"
                SELECT IdEntrenador
                FROM Entrenadores
                WHERE IdUsuario = @IdUsuario;
            ";


                    SqlCommand cmdBuscar =
                        new SqlCommand(
                            sqlBuscarEntrenador,
                            conexion.oCon,
                            transaccion);


                    cmdBuscar.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);


                    object resultado =
                        cmdBuscar.ExecuteScalar();


                    if (resultado != null)
                    {
                        idEntrenador =
                            Convert.ToInt32(resultado);
                    }
                    // Desactivar deportes actuales

                    string sqlDesactivar = @"
                UPDATE EntrenadorDeporte
                SET
                    Activo = 0,
                    FechaFin = CAST(GETDATE() AS DATE)
                WHERE
                    IdEntrenador = @IdEntrenador
                    AND Activo = 1;
            ";


                    SqlCommand cmdDesactivar =
                        new SqlCommand(
                            sqlDesactivar,
                            conexion.oCon,
                            transaccion);


                    cmdDesactivar.Parameters.AddWithValue(
                        "@IdEntrenador",
                        idEntrenador);


                    cmdDesactivar.ExecuteNonQuery();

                    // Insertar nuevamente los seleccionados
                    foreach (int idDeporte
                             in deportesSeleccionados)
                    {
                        string sqlInsertarDeporte = @"
                    INSERT INTO EntrenadorDeporte
                    (
                        IdEntrenador,
                        IdDeporte,
                        FechaInicio,
                        FechaFin,
                        Activo
                    )
                    VALUES
                    (
                        @IdEntrenador,
                        @IdDeporte,
                        CAST(GETDATE() AS DATE),
                        NULL,
                        1
                    );
                ";


                        SqlCommand cmdInsertar =
                            new SqlCommand(
                                sqlInsertarDeporte,
                                conexion.oCon,
                                transaccion);


                        cmdInsertar.Parameters.AddWithValue(
                            "@IdEntrenador",
                            idEntrenador);

                        cmdInsertar.Parameters.AddWithValue(
                            "@IdDeporte",
                            idDeporte);


                        cmdInsertar.ExecuteNonQuery();
                    }
                }
                // 4. SI ERA ENTRENADOR Y DEJA DE SERLO

                else if (nombreRolOriginal == "Entrenador" &&
                         nombreRolNuevo != "Entrenador")
                {
                    string sqlInhabilitar = @"
                UPDATE Entrenadores
                SET EstadoEntrenador = 'Inhabilitado'
                WHERE IdUsuario = @IdUsuario;
            ";


                    SqlCommand cmdInhabilitar =
                        new SqlCommand(
                            sqlInhabilitar,
                            conexion.oCon,
                            transaccion);


                    cmdInhabilitar.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);


                    cmdInhabilitar.ExecuteNonQuery();


                    string sqlCerrarDeportes = @"
                UPDATE ED
                SET
                    ED.Activo = 0,
                    ED.FechaFin =
                        CAST(GETDATE() AS DATE)
                FROM EntrenadorDeporte ED
                INNER JOIN Entrenadores E
                    ON ED.IdEntrenador =
                       E.IdEntrenador
                WHERE
                    E.IdUsuario = @IdUsuario
                    AND ED.Activo = 1;
            ";


                    SqlCommand cmdCerrar =
                        new SqlCommand(
                            sqlCerrarDeportes,
                            conexion.oCon,
                            transaccion);


                    cmdCerrar.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);


                    cmdCerrar.ExecuteNonQuery();
                }

                transaccion.Commit();     


                MessageBox.Show(
                    "Los datos del usuario fueron actualizados correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                this.Close();
            }
            catch (SqlException ex)
            {
                transaccion.Rollback();


                if (ex.Number == 2627 ||
                    ex.Number == 2601)
                {
                    MessageBox.Show(
                        "El correo electrónico ya está registrado por otro usuario.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Error al actualizar el usuario:\n\n" +
                        ex.Message,
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                transaccion.Rollback();


                MessageBox.Show(
                    "Error al actualizar el usuario:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
    }
}
