using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    public class DatosProveedores
    {
        AccesoDatos ds = new AccesoDatos();
        public Proveedores getProveedor(int id)
        {
            Proveedores cat = new Proveedores();
            DataTable tabla = ds.ObtenerTabla("Proveedores", "Select * from PROVEEDORES where id_proveedor=" + id);
            cat.setid_proveedor(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            cat.setnombre_proveedor(tabla.Rows[0][1].ToString());
            cat.setdireccion_proveedor(tabla.Rows[0][2].ToString());
            cat.settelefono_proveedor(Convert.ToInt32(tabla.Rows[0][3].ToString()));
            cat.setlocalidad_proveedor(tabla.Rows[0][4].ToString());

            return cat;
        }

        public DataTable getTablaProveedores()
        {
            //List<Categoria> lista = new List<Categoria>();
            DataTable tabla = ds.ObtenerTabla("Proveedores", "SELECT (id_proveedor)as ID_Proveedor,(id_producto)as ID_Producto,Nombre,Dirección,Telefono,Localidad FROM PROVEEDORES");
            return tabla;
        }

        public void AgregarProveedor(string id, string id_producto, string nombre, string direccion, string telefono, string localidad)
        {
            AccesoDatos reg = new AccesoDatos();
            //DatosProveedores reg = new DatosProveedores();
            reg.AgregarProveedor(id, id_producto, nombre, direccion, telefono, localidad);
        }

        public void eliminarproveedor(string id)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.eliminarproveedor(id);
        }

        public void ActualizarProveedor(string todo)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.ActualizarProveedor(todo);
        }
        public int obtenerregistroproveedor() {
            AccesoDatos reg = new AccesoDatos();
            int resu = reg.obtenerregistroproveedor();
            return resu;
        }
    }
}
