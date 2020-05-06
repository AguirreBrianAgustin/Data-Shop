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
    public class DatosClientes
    {
        AccesoDatos ds = new AccesoDatos();
        public Clientes getCliente(int id)
        {
            Clientes cat = new Clientes();
            DataTable tabla = ds.ObtenerTabla("Clientes", "Select * from CLIENTES where id_cliente=" + id);
            cat.setid_cliente(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            cat.setnombre(tabla.Rows[0][1].ToString());
            cat.setdireccion(tabla.Rows[0][2].ToString());
            cat.settelefono(Convert.ToInt32(tabla.Rows[0][3].ToString()));
            return cat;
        }

        public DataTable getTablaMarcas()
        {
            //List<Categoria> lista = new List<Categoria>();
            DataTable tabla = ds.ObtenerTabla("Clientes", "select (id_cliente)as ID_Cliente,(dni)as DNI,Nombre,Direccion,Telefono from CLIENTES");
            return tabla;
        }

        public void AgregarCliente(string id, string dni, string nombre, string direccion, string telefono)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.agregarClientes(id, dni, nombre, direccion, telefono);
        }

        public string obeterclienteid(string id)
        {
            AccesoDatos reg = new AccesoDatos();
           string resu= reg.obtenerclienteid(id);
            return resu;
        }

        public void eliminarcliente(string id)
        {
            AccesoDatos reg = new AccesoDatos();

            reg.eliminarcliente(id);
        }

        public void actualizarCliente(string todo)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.actualizarCliente(todo);
        }

        public int obtenerregistrocliente()
        {
            AccesoDatos reg = new AccesoDatos();
            int resu = reg.obtenerregistrocliente();
            return resu;

        }

    }
}
