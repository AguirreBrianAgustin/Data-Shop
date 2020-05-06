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
    public class DatosProductos
    {
        AccesoDatos ds = new AccesoDatos();
        public Productos getProducto(int id)
        {
            Productos prod = new Productos();
            DataTable tabla = ds.ObtenerTabla("Productos", "Select * from PRODUCTOS where id_producto=" + id);
            prod.setid_producto(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            prod.setnombre_producto(tabla.Rows[0][1].ToString());
            prod.setidmarca_producto(Convert.ToInt32(tabla.Rows[0][2].ToString()));
            prod.setidgenero_producto(Convert.ToInt32(tabla.Rows[0][3].ToString()));
            prod.setstock_producto(Convert.ToInt32(tabla.Rows[0][4].ToString()));
            prod.setpegi_producto(Convert.ToInt32(tabla.Rows[0][5].ToString()));
            prod.setportada_producto(tabla.Rows[0][6].ToString());
            prod.setdescripcion_producto(tabla.Rows[0][7].ToString());
            prod.setprecio_unidad_producto(Convert.ToInt32(tabla.Rows[0][8].ToString()));

            return prod;
        }

        public DataTable getTablaProductos()
        {
            //List<Categoria> lista = new List<Categoria>();
            DataTable tabla = ds.ObtenerTabla("Productos", "select (id_producto)as ID_Producto,(nombre)as Nombre,(id_marca)as ID_Marca,(id_genero)as ID_Genero,(id_pegi)as ID_Pegi,(stock)as Stock,Descripcion,(precio_de_unidad)as Precio_X_Unidad from PRODUCTOS");
            return tabla;
        }
        public DataTable getTablaProductoslike(string con)
        {
            //List<Categoria> lista = new List<Categoria>();
            DataTable tabla = ds.ObtenerTabla("Productos", "select (id_producto)as ID_Producto,(nombre)as Nombre from PRODUCTOS where NOMBRE like  " +
                       " '" + con + "%'" );
            return tabla;
        }




        public DataTable getTablaProductosInner()
        {
            
            DataTable tabla = ds.ObtenerTabla("Productos", "select (productos.id_producto)as ID_Producto,(productos.nombre)as Nombre,(productos.id_marca)as ID_Marca,(productos.id_genero)as ID_Genero,(productos.id_pegi)as ID_Pegi,(productos.stock)as Stock,productos.Descripcion,(productos.precio_de_unidad)as Precio_X_Unidad from PRODUCTOS INNER JOIN MARCAS ON PRODUCTOS.id_marca = MARCAS.id_marca INNER JOIN GENEROS on PRODUCTOS.id_genero = GENEROS.id_genero INNER JOIN PEGI on PRODUCTOS.id_pegi = PEGI.id_pegi;");
            return tabla;
        }

        public void eliminarProducto(string id)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.eliminarProducto(id);
        }

        public string obtenerproductoid(string id)
        {
            AccesoDatos reg = new AccesoDatos();
            string resu = reg.obtenerproductoid(id);
            return resu;
        }

        public void actualizarProducto(string todo)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.actualizarProducto(todo);
        }

        public void actualizarProducto2(string todo)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.actualizarProducto2(todo);
        }

        public void AgregarProducto(string id_producto, string nombre, string id_marca, string id_genero, string id_pegi, string stock, string portada, string Descripcion, string precio_de_unidad)
        {
            AccesoDatos reg = new AccesoDatos();
            //DatosProveedores reg = new DatosProveedores();
            reg.AgregaProducto(id_producto, nombre, id_marca, id_genero, id_pegi, stock, portada, Descripcion, precio_de_unidad);
        }


        public int obtenercantidadderegistros() {
            AccesoDatos reg = new AccesoDatos();
            int resu = reg.obtenercantidadderegistros();
            return resu;
        }
        public int obtenerStock(int sto) {
            AccesoDatos reg = new AccesoDatos();
            int resu = reg.obtenerStock(sto);
            return resu;
        }

        public void actualizarStock(int id, int sto)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.actualizarStock(id, sto);
        }
        public void cargarVenta(string dni, string telefono, string precio)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.cargarVenta(dni, telefono, precio);
        }
        public int cargarDetalleVentas(int id, int sto)
        {
            AccesoDatos reg = new AccesoDatos();
           return reg.cargarDetalleVentas(id, sto);
        }

        public void cargarDETALLECOMPLETO(int id, int sto, int idventa)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.cargarDETALLECOMPLETO(id, sto, idventa);
        }
    }


}
