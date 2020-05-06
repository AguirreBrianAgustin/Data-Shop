using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DATOS;
using System.Data;



namespace NEGOCIO
{
    public class n_producto
    {
        public DataTable getTabla()
        {
            DatosProductos dao = new DatosProductos();
            return dao.getTablaProductos();
        }
        public DataTable getTablalike(string con)
        {
            DatosProductos dao = new DatosProductos();
            return dao.getTablaProductoslike(con);
        }

        public DataTable getTablaInner()
        {
            DatosProductos dao = new DatosProductos();
            return dao.getTablaProductosInner();
        }

        public Productos get(int id)
        {
            DatosProductos dao = new DatosProductos();
            //Validar si existe esa categoria
            return dao.getProducto(id);
        }

        public string obtenerproductoid(string id)
        {
            DatosProductos reg = new DatosProductos();
            string resu = reg.obtenerproductoid(id);
            return resu;
        }

        


        public void eliminarProducto(string id )
        {
            DatosProductos dao = new DatosProductos();
            dao.eliminarProducto(id);
        }



        public void actualizarProducto(string todo)
        {
            DatosProductos reg = new DatosProductos();
            reg.actualizarProducto(todo);

        }

        public void actualizarProducto2(string todo)
        {
            DatosProductos reg = new DatosProductos();
            reg.actualizarProducto2(todo);

        }

        public void AgregarProducto(string id_producto, string nombre, string id_marca, string id_genero, string id_pegi, string stock, string portada, string Descripcion, string precio_de_unidad)
        {

            DatosProductos reg = new DatosProductos();
            reg.AgregarProducto(id_producto, nombre, id_marca, id_genero, id_pegi, stock, portada, Descripcion, precio_de_unidad);
        }
        public int obtenercantidadderegistros()
        {
            DatosProductos reg = new DatosProductos();
            int resu = reg.obtenercantidadderegistros();
            return resu;

        }
        public int obtenerStock(int sto) {
            DatosProductos reg = new DatosProductos();
            int resu = reg.obtenerStock(sto);
            return resu;

        }
        public void actualizarStock(int id, int sto) {
            DatosProductos reg = new DatosProductos();
            reg.actualizarStock( id,  sto);
        }

        public void cargarVenta(string dni,string telefono, string precio)
        {
            DatosProductos reg = new DatosProductos();
            reg.cargarVenta(dni,telefono,precio);
        }
        
    public int cargarDetalleVentas(int id , int sto)
        {
            DatosProductos reg = new DatosProductos();
           return reg.cargarDetalleVentas(id, sto);
        }
        

            public void cargarDETALLECOMPLETO(int id, int sto, int idventa)
        {
            DatosProductos reg = new DatosProductos();
           reg.cargarDETALLECOMPLETO(id, sto, idventa);
        }
    }
}
