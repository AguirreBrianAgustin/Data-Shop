using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    class AccesoDatos
    {
        string resu1="";
        string resu2="";
        string resu3="";
        string resu4;
        string resup1="";

        String rutaBDDataShop =
     //"Data Source=DESKTOP-ES3ODSC;Initial Catalog=DataShop;Integrated Security=True";
     // "Data Source=DESKTOP-C247IGF\\QLEXPRESS;Initial Catalog=DataShop;Integrated Security=True";
      //"Data Source=localhost\\sqlexpress;Initial Catalog=DataShop;Integrated Security=True";
      "Data Source=localhost\\sqlexpress;Initial Catalog=DataShop;Integrated Security=True";//"Data Source=localhost\\sqlexpress;Initial Catalog=DataShop;Integrated Security=True";"Data Source=localhost\\sqlexpress;Initial Catalog=DataShop;Integrated Security=True";
     //"Data Source=localhost\\sqlexpress;Initial Catalog=DataShop;Integrated Security=True";
        DataSet ds = new DataSet();
        public AccesoDatos()
        {
            // TODO: Agregar aquí la lógica del constructor
        }

        private SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            //       try
            //     {
            cn.Open();
            return cn;
            //   }
            // catch (Exception ex)
            //{
            //  return null;
            //}
        }


        private SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            // string rutaNeptunoSQL = "Data Source=localhost\\sqlexpress;Initial Catalog=DataShop;Integrated Security=True";

            SqlConnection Conexion = ObtenerConexion();
            // SqlConnection ConexionDATASHOP = ObtenerConexion(rutaNeptunoSQL);
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public DataTable ObtenerTablafecha(String NombreTabla, String Sql)
        {
            // string rutaNeptunoSQL = "Data Source=localhost\\sqlexpress;Initial Catalog=DataShop;Integrated Security=True";

            SqlConnection Conexion = ObtenerConexion();
            // SqlConnection ConexionDATASHOP = ObtenerConexion(rutaNeptunoSQL);
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }
    


             public string obtenerRecaudacionDia(String NombreTabla, String Sql)
        {
            SqlConnection cnNeptuno = new SqlConnection();
            cnNeptuno.ConnectionString = rutaBDDataShop;

            SqlCommand comando = new SqlCommand();
            string s = "2019-01-18";
            //string consultaSQL = "select * from Categorías where IdCategoría = " + comboBox1.Text;
            // string consultaSQL = "select * from ventas where fecha = '" + s + "'";

            comando.Connection = cnNeptuno;
            comando.CommandText = Sql;
            cnNeptuno.Open();
            string resu = "";
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read() == true)
            {

                resu = (dr["total"].ToString());


            }
           
            cnNeptuno.Close();
          
            return resu;
        }

        public string obtenerRecaudacionMes(String NombreTabla, String Sql)
        {
            SqlConnection cnNeptuno = new SqlConnection();
            cnNeptuno.ConnectionString = rutaBDDataShop;

            SqlCommand comando = new SqlCommand();
            comando.Connection = cnNeptuno;
            comando.CommandText = Sql;
            cnNeptuno.Open();
            string resu = "";
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read() == true)
            {

                resu = (dr["Totalvendido_mes"].ToString());


            }

            cnNeptuno.Close();

            return resu;
        }

        public string obtenerRecaudacionAnio(String NombreTabla, String Sql)
        {
            SqlConnection cnNeptuno = new SqlConnection();
            cnNeptuno.ConnectionString = rutaBDDataShop;

            SqlCommand comando = new SqlCommand();
            comando.Connection = cnNeptuno;
            comando.CommandText = Sql;
            cnNeptuno.Open();
            string resu = "";
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read() == true)
            {

                resu = (dr["Totalvendido_anio"].ToString());


            }

            cnNeptuno.Close();

            return resu;
        }

        public string obtenerRecaudacionRangoMes(String NombreTabla, String Sql)
        {
            SqlConnection cnNeptuno = new SqlConnection();
            cnNeptuno.ConnectionString = rutaBDDataShop;

            SqlCommand comando = new SqlCommand();
            comando.Connection = cnNeptuno;
            comando.CommandText = Sql;
            cnNeptuno.Open();
            string resu = "";
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read() == true)
            {

                resu = (dr["Totalvendido_rangoMes"].ToString());


            }

            cnNeptuno.Close();

            return resu;
        }


        public DataTable ObtenerTablaDETALLE(String NombreTabla, String Sql)
        {
            // string rutaNeptunoSQL = "Data Source=localhost\\sqlexpress;Initial Catalog=DataShop;Integrated Security=True";

            SqlConnection Conexion = ObtenerConexion();
            // SqlConnection ConexionDATASHOP = ObtenerConexion(rutaNeptunoSQL);
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public void elimproduc()
        {
            DataSet dsEliminar;
            {
                dsEliminar = new DataSet();
                dsEliminar = ds.GetChanges(DataRowState.Deleted);
                if (EliminarProductosEnBD("PRODUCTOS", dsEliminar) != true)
                {
                    return;
                }

            }
        }

        public bool EliminarProductosEnBD(String NombreTabla, DataSet ds)
        {
            int FilasEliminadas = 0;
            foreach (DataRow fila in ds.Tables[NombreTabla].Rows)
            {
                SqlCommand Comando = new SqlCommand();
                fila.RejectChanges();
                AccesoDatos ad = new AccesoDatos();
                ArmarParametrosProductosEliminar(ref Comando, fila);
                FilasEliminadas = ad.EjecutarProcedimientoAlmacenado(Comando, "SP_Eliminar_Producto");
            }
            if (FilasEliminadas >= 1)
                return true;
            else
                return false;
        }

        private void ArmarParametrosProductosEliminar(ref SqlCommand Comando, DataRow fila)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            SqlParametros.Value = fila["IdProducto"];
        }



        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        //*********************************************************************
        public void agregarClientes(string id, string dni, string nombre, string direccion, string telefono)
        {
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "INSERT INTO CLIENTES (id_cliente, dni, Nombre, Direccion, Telefono) " +
          "values(" + id + ", " + dni + ", '" + nombre + "','" + direccion + "','" + telefono + "')";


            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.ExecuteNonQuery();
        }

        //*************************************
        public void agregarMarcas(String ID, String NOMBRE)
        {
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "INSERT INTO MARCAS (id_marca,nombre) " +
          "values(" + ID + ", '" + NOMBRE + "')";


            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.ExecuteNonQuery();
        }

        ///******************************************************

        public void agregarGeneros(String ID, String NOMBRE)
        {
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "INSERT INTO GENEROS (id_genero,descripcion) " +
          "values(" + ID + ", '" + NOMBRE + "')";


            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.ExecuteNonQuery();
        }

        public void AgregarProveedor(string id,string id_producto, string nombre, string direccion, string telefono, string localidad)
        {
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "INSERT INTO PROVEEDORES (id_proveedor,id_producto,Nombre,Dirección,Telefono,Localidad) " +
          "values(" + id + ", '" + id_producto + "', '" + nombre + "', '" + direccion + "', '" + telefono + "', '" + telefono + "')";


            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.ExecuteNonQuery();

        }
        public void cargarlogin(string consulta)
        {
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();
            
            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.ExecuteNonQuery();
        }
        public string obtenerclienteid(string id)
        {


            // System.Data.SqlClient.SqlConnection cnNeptuno = new System.Data.SqlClient.SqlConnection();
            //SqlConnection cnNeptuno = new SqlConnection(rutaNeptunoSQL);
            SqlConnection cnNeptuno = new SqlConnection();
            cnNeptuno.ConnectionString = rutaBDDataShop;

            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Nombre,Direccion,Telefono FROM CLIENTES where dni =" + id;
            comando.Connection = cnNeptuno;

            cnNeptuno.Open();

            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read() == true)
            {

                resu1 = (dr["Nombre"].ToString());

                resu2 = (dr["Direccion"].ToString());

                resu3 = (dr["Telefono"].ToString());
                resu4 = resu1 + "," + resu2 + "," + resu3;

            }
            cnNeptuno.Close();
            return resu4;
        }

        public int obtenerStock(int sto) {

            SqlConnection cnNeptuno = new SqlConnection();
            cnNeptuno.ConnectionString = rutaBDDataShop;
            string resu = "";
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT stock FROM PRODUCTOS WHERE id_producto =" + sto;
            comando.Connection = cnNeptuno;

            cnNeptuno.Open();

            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read() == true)
            {

                resu = (dr["stock"].ToString());

               

            }
            cnNeptuno.Close();
            int resu1= Convert.ToInt16(resu);
            return resu1;
        }

        public void eliminarproveedor(string id)
        {
            SqlConnection Conexion = ObtenerConexion();

            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_PROveedor", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(id);

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_Eliminar_Proveedor";
            Comando.ExecuteNonQuery();

        }

        public void eliminarcliente(string id)
        {
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_cliente", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(id);

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_Eliminar_Cliente";
            Comando.ExecuteNonQuery();

        }

        public void eliminarProducto(string id)
        {

            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_producto", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(id);

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_Eliminar_Producto";
            Comando.ExecuteNonQuery();
        }
        ///***************************************
        //agreado jose 2/02/2019
        public void eliminarDetalle(string id)
        {

            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_producto", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(id);

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_Eliminar_Detalle_de_Venta";
            Comando.ExecuteNonQuery();
        }

        //agreado jose 2/02/2019
        ///***************************************


        ///***************************************
        //agreado jose 8/11
        public string obtenerproductoid(string id)
        {


            // System.Data.SqlClient.SqlConnection cnNeptuno = new System.Data.SqlClient.SqlConnection();
            //SqlConnection cnNeptuno = new SqlConnection(rutaNeptunoSQL);
            SqlConnection cnNeptuno = new SqlConnection();
            cnNeptuno.ConnectionString = rutaBDDataShop;

            SqlCommand comando2 = new SqlCommand();
            comando2.CommandText = "Select nombre,precio_de_unidad FROM PRODUCTOS where id_producto =" + id;
            comando2.Connection = cnNeptuno;

            cnNeptuno.Open();

            SqlDataReader dr = comando2.ExecuteReader();
            while (dr.Read() == true)
            {
                
                   resup1 = (dr["nombre"].ToString() + "," + dr["precio_de_unidad"].ToString());
            }
            cnNeptuno.Close();
            return resup1;
        }

        public void actualizarCliente(string todo)
        {
            string r1, r2, r3, r4, r5;
            String[] separado;
            separado = todo.Split(',');
            r1 = separado[0]; r2 = separado[1]; r3 = separado[2]; r4 = separado[3]; r5 = separado[4];
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_cliente", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r1);

            SqlParametros = Comando.Parameters.Add("@dni", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r2);

            SqlParametros = Comando.Parameters.Add("@Nombre", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r3);

            SqlParametros = Comando.Parameters.Add("@Direccion", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r4);

            SqlParametros = Comando.Parameters.Add("@Telefono", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r5);

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_actualizar_clientes";
            Comando.ExecuteNonQuery();

        }
        //***********************************************************************

        public void ActualizarProveedor(string todo)
        {
            string r1, r2, r3, r4, r5, r6;
            String[] separado;
            separado = todo.Split(',');
            r1 = separado[0]; r2 = separado[1]; r3 = separado[2]; r4 = separado[3]; r5 = separado[4]; r6 = separado[5];
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_proveedor", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r1);

            SqlParametros = Comando.Parameters.Add("@id_producto", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r2);

            SqlParametros = Comando.Parameters.Add("@Nombre", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r3);

            SqlParametros = Comando.Parameters.Add("@Direccion", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r4);

            SqlParametros = Comando.Parameters.Add("@Telefono", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r5);

            SqlParametros = Comando.Parameters.Add("@Localidad", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r6);

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_Actualizar_Proveedores";
            Comando.ExecuteNonQuery();

        }
        //***************************************************************
        public void actualizarProducto(string todo)
        {
            string r1, r2, r3, r4, r5, r6, r7, r8, r9;
            String[] separado;
            separado = todo.Split(',');
            r1 = separado[0]; r2 = separado[1]; r3 = separado[2]; r4 = separado[3]; r5 = separado[4]; r6 = separado[5]; r7 = separado[6]; r8 = separado[7]; r9 = separado[8];
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_producto", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r1);

            SqlParametros = Comando.Parameters.Add("@nombre", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r2);

            SqlParametros = Comando.Parameters.Add("@id_marca", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r3);

            SqlParametros = Comando.Parameters.Add("@id_genero", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r4);

            SqlParametros = Comando.Parameters.Add("@stock", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r5);

            SqlParametros = Comando.Parameters.Add("@pegi", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r6);

            SqlParametros = Comando.Parameters.Add("@portada", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r7);

            SqlParametros = Comando.Parameters.Add("@descripcion", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r8);

            SqlParametros = Comando.Parameters.Add("@preciounidad", SqlDbType.Float);
            SqlParametros.Value = Convert.ToDouble(r9);

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "sp_actualizar_Producto";
            Comando.ExecuteNonQuery();
        }


        ///******************************************
        public void actualizarProducto2(string todo)
        {
            string r1, r2, r3, r4, r5, r6, r7, r8;
            String[] separado;
            separado = todo.Split(',');
            r1 = separado[0]; r2 = separado[1]; r3 = separado[2]; r4 = separado[3]; r5 = separado[4]; r6 = separado[5]; r7 = separado[6]; r8 = separado[7];
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_producto", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r1);

            SqlParametros = Comando.Parameters.Add("@nombre", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r2);

            SqlParametros = Comando.Parameters.Add("@id_marca", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r3);

            SqlParametros = Comando.Parameters.Add("@id_genero", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r4);

            SqlParametros = Comando.Parameters.Add("@pegi", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r5);

            SqlParametros = Comando.Parameters.Add("@stock", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r6);

            SqlParametros = Comando.Parameters.Add("@descripcion", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r7);

            SqlParametros = Comando.Parameters.Add("@preciounidad", SqlDbType.Float);
            SqlParametros.Value = Convert.ToDouble(r8);

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "sp_actualizar_Producto_sin_portada";
            Comando.ExecuteNonQuery();
        }
        ///


        public void AgregaProducto(string id_producto, string nombre, string id_marca, string id_genero, string id_pegi, string stock, string portada, string Descripcion, string precio_de_unidad)
        {
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "INSERT INTO PRODUCTOS (id_producto,nombre,id_marca,id_genero,id_pegi,stock,portada,Descripcion,precio_de_unidad) " +
            "values(" + id_producto  + ", '"   + nombre      + "', '" + id_marca + "', '" + id_genero + "', '" + id_pegi  + "', '" + stock    + "', '" + portada + "', '" + Descripcion + "', '" + precio_de_unidad + "')";

            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.ExecuteNonQuery();

        }




        public string obetenerpermiso(string user, string contra)
        {
           // AccesoDatos reg = new AccesoDatos();
            string resu="";
            //resu = reg.obetenerpermiso(user, contra);

            // System.Data.SqlClient.SqlConnection cnNeptuno = new System.Data.SqlClient.SqlConnection();
            //SqlConnection cnNeptuno = new SqlConnection(rutaNeptunoSQL);
            SqlConnection cnNeptuno = new SqlConnection();
            cnNeptuno.ConnectionString = rutaBDDataShop;
            string consul = "and contraseña_usuario=";
           // SELECT permiso from USUARIOS where nombre_usuario = 'juan' and contraseña_usuario = '1234'
            SqlCommand comando2 = new SqlCommand(); 
            comando2.CommandText = "SELECT permiso from USUARIOS where nombre_usuario = " + " '" + user + "' " + consul + " '" + contra + "' ";//and contraseña_usuario = '" + '" + contra + "';
            comando2.Connection = cnNeptuno; 

            cnNeptuno.Open();

            SqlDataReader dr = comando2.ExecuteReader();
            while (dr.Read() == true)
            {

                resu = (dr["permiso"].ToString());
            }
            cnNeptuno.Close();
            return resu;
            //return resu;
        }

        public int obtenerregistrocliente()
        {
            int resu;
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "SELECT COUNT(id_cliente)FROM CLIENTES";


            SqlCommand comando = new SqlCommand(consulta, cn);
            resu = (int)comando.ExecuteScalar();
            
            return resu;
        }

        public int obtenercatidadregistro() {

            int resu;
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "SELECT COUNT(id_marca)FROM MARCAS";


            SqlCommand comando = new SqlCommand(consulta, cn);
            resu = (int)comando.ExecuteScalar();

            return resu;
        }
        public int obtenercantidadderegistros() {

            int resu;
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "SELECT COUNT(id_producto)FROM PRODUCTOS";


            SqlCommand comando = new SqlCommand(consulta, cn);
            resu = (int)comando.ExecuteScalar();

            return resu;

        }
        public int obtenerregistroproveedor() {

            int resu;
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "SELECT COUNT(id_proveedor) from PROVEEDORES";


            SqlCommand comando = new SqlCommand(consulta, cn);
            resu = (int)comando.ExecuteScalar();

            return resu;

        }
        public int obtenercantidadregistrogenero()
        {
            int resu;
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "SELECT COUNT(id_genero) from GENEROS";


            SqlCommand comando = new SqlCommand(consulta, cn);
            resu = (int)comando.ExecuteScalar();

            return resu;

        }
        public void eliminarMarca(string id)
        {
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_Marcas", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(id);

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_Eliminar_Marcas";
            Comando.ExecuteNonQuery();

        }

        public void actualizarMarca(string todo)
        {
            string r1, r2;
            String[] separado;
            separado = todo.Split(',');
            r1 = separado[0]; r2 = separado[1];
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_marca", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r1);

            SqlParametros = Comando.Parameters.Add("@nombre", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r2);



            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_actualizar_marcas";
            Comando.ExecuteNonQuery();

        }

        public void eliminarGenero(string id)
        {
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_generos", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(id);

            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_Eliminar_Generos";
            Comando.ExecuteNonQuery();

        }

        public void actualizarGenero(string todo)
        {
            string r1, r2;
            String[] separado;
            separado = todo.Split(',');
            r1 = separado[0]; r2 = separado[1];
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_genero", SqlDbType.Int);
            SqlParametros.Value = Convert.ToInt32(r1);

            SqlParametros = Comando.Parameters.Add("@nombre", SqlDbType.Text);
            SqlParametros.Value = Convert.ToString(r2);



            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_actualizar_generos";
            Comando.ExecuteNonQuery();

        }

        public void InsertarVentas(string id_venta, string id_cliente, string dni_cliente, string telefono, string fecha, string id_Detalle_Venta, string total)
        {
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "INSERT INTO VENTAS (id_venta,id_cliente,dni_cliente,telefono,fecha,id_Detalle_Venta,total) " +
          "values(" + id_venta + ", '" + id_cliente + "', '" + dni_cliente + "', '" + telefono + "', '" + fecha + "', '" + id_Detalle_Venta + "','" + total + "')";


            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.ExecuteNonQuery();

        }

        public int obtenercantidadderegistrosVenta()
        {

            int resu;
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "SELECT COUNT(id_venta)FROM VENTAS";


            SqlCommand comando = new SqlCommand(consulta, cn);
            resu = (int)comando.ExecuteScalar();

            return resu;

        }

        public void actualizarStock(int id, int sto)
        {
         
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@idProducto", SqlDbType.Int);
            SqlParametros.Value =id;

            SqlParametros = Comando.Parameters.Add("@cant_ven", SqlDbType.Int);
            SqlParametros.Value = sto;



            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "SP_Venta_Producto";
            Comando.ExecuteNonQuery();
        }

        public void cargarVenta(string dni, string telefono, string precio)
        {
            SqlConnection cnNeptuno = new SqlConnection();
            cnNeptuno.ConnectionString = rutaBDDataShop;
            string resu = "";
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select id_cliente from CLIENTES where dni =" + dni;
            comando.Connection = cnNeptuno;

            cnNeptuno.Open();

            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read() == true)
            {

                resu = (dr["id_cliente"].ToString());



            }
            cnNeptuno.Close();
            int id = Convert.ToInt16(resu);
          



            int d = Convert.ToInt32(dni), t = Convert.ToInt32(telefono);

            float p = Convert.ToSingle(precio);
            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_cliente", SqlDbType.Int);
            SqlParametros.Value = id;

            SqlParametros = Comando.Parameters.Add("@dni_cliente", SqlDbType.Int);
            SqlParametros.Value = d;

            SqlParametros = Comando.Parameters.Add("@telefono", SqlDbType.Int);
            SqlParametros.Value = t;

            SqlParametros = Comando.Parameters.Add("@total", SqlDbType.Float);
            SqlParametros.Value = p;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "venta_Insertar";
            Comando.ExecuteNonQuery();
        }



        public int cargarDetalleVentas(int id, int sto)
        {
          

            int resu;
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            cn.Open();

            String consulta = "select count(id_venta) from ventas";


            SqlCommand comando = new SqlCommand(consulta, cn);
            resu = (int)comando.ExecuteScalar();

            return resu;

            
        }
        public void cargarDETALLECOMPLETO(int id, int sto, int idventa)
        {
            

  
         


            SqlConnection cnNeptuno = new SqlConnection();
            cnNeptuno.ConnectionString = rutaBDDataShop;
            string resu = "";
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select precio_de_unidad from PRODUCTOS where id_producto =" + id;
            comando.Connection = cnNeptuno;

            cnNeptuno.Open();

            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read() == true)
            {

                resu = (dr["precio_de_unidad"].ToString());



            }
            cnNeptuno.Close();
            int precio = Convert.ToInt16(resu);

            ////////////////////////////////////AccesoDatos reg = new AccesoDatos();

            SqlConnection Conexion = ObtenerConexion();


            SqlCommand Comando = new SqlCommand();

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@id_venta", SqlDbType.Int);
            SqlParametros.Value = idventa;

            SqlParametros = Comando.Parameters.Add("@id_producto", SqlDbType.Int);
            SqlParametros.Value = id;

            SqlParametros = Comando.Parameters.Add("@cantidad", SqlDbType.Int);
            SqlParametros.Value = sto;

            SqlParametros = Comando.Parameters.Add("@precio", SqlDbType.Float);
            SqlParametros.Value = precio;
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "DetalleDeVenta_Insertar";
            Comando.ExecuteNonQuery();

        }

    }


}