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
    public class n_proveedor
    {
        public DataTable getTabla()
        {
            DatosProveedores dao = new DatosProveedores();
            return dao.getTablaProveedores();
        }

        public Proveedores get(int id)
        {
            DatosProveedores dao = new DatosProveedores();
            //Validar si existe esa categoria
            return dao.getProveedor(id);
        }

        public void AgregarProveedor(string id, string id_producto, string nombre , string direccion, string telefono, string localidad)
        {

            DatosProveedores reg = new DatosProveedores();
            reg.AgregarProveedor(id, id_producto, nombre, direccion, telefono, localidad);
        }

        public void eliminarproveedor(string id)
        {
            DatosProveedores reg = new DatosProveedores();
            reg.eliminarproveedor(id);
        }
        
        public void ActualizarProveedor(string todo)
        {
            DatosProveedores reg = new DatosProveedores();
            reg.ActualizarProveedor(todo);
        }

        public int obtenerregistroproveedor() {
            DatosProveedores reg = new DatosProveedores();
            int resu = reg.obtenerregistroproveedor();
            return resu;
        }
    }
}
