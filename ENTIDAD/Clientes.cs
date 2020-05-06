using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Clientes
    {
        private int id_cliente;
        private string nombre;
        private String direccion;
        private int telefono;

        public Clientes()
        { }
        public int getid_cliente()
        {
            return id_cliente;
        }
        public void setid_cliente(int idcliente)
        {
            id_cliente = idcliente;
        }
        public String getnombre()
        {
            return direccion;
        }
        public void setdireccion(String Direccion)
        {
            direccion = Direccion;
        }
        public string getnombre_cliente()
        {
            return nombre;
        }
        public void setnombre(string Nombre)
        {
            nombre = Nombre;
        }
        public int gettelefono_cliente()
        {
            return telefono;
        }
        public void settelefono (int Telefono)
        {
            telefono = Telefono;
        }
    }
}
