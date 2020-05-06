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
    public class n_cliente
    {
        public DataTable getTabla()
        {
            DatosClientes dao = new DatosClientes();
            return dao.getTablaMarcas();
        }

        public Clientes get(int id)
        {
            DatosClientes dao = new DatosClientes();
            //Validar si existe esa categoria
            return dao.getCliente(id);
        }

        public void getagregar_cliente(string id, string dni, string nombre, string direccion, string telefono)
        {
            DatosClientes reg = new DatosClientes();
            reg.AgregarCliente( id,  dni, nombre,  direccion,  telefono);
        }

        public string obtenerclienteid(string id)
        {
            DatosClientes reg = new DatosClientes();
            string resu= reg.obeterclienteid(id);
            return resu;
        }

        public void eliminarcliente(string id)
        {
            DatosClientes reg = new DatosClientes();
            reg.eliminarcliente(id);
        }

        public void actualizarCliente(string todo)
        {
            DatosClientes reg = new DatosClientes();
            reg.actualizarCliente(todo);

        }

        public int obtenerregistrocliente() {
            DatosClientes reg = new DatosClientes();
            int resu;
            resu=reg.obtenerregistrocliente();
            return resu;
        }


    }
}
