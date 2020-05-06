using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Proveedores
    {
        private int id_proveedor;
        private string nombre;
        private string direccion;
        private int telefono;
        private string localidad;

        public Proveedores()
        { }

        public int getid_proveedor()
        {
            return id_proveedor;
        }

        public void setid_proveedor(int id_Proveedor)
        {
            id_proveedor = id_Proveedor;

        }

        public string getnombe_proveedor()
        {
            return nombre;
        }
        public void setnombre_proveedor(string Nombre)
        {
            nombre = Nombre;
        }

        public string getdireccion_proveedor()
        {
            return direccion;
        }

        public void setdireccion_proveedor(string Direccion)
        {
            direccion = Direccion;
        }
        public int gettelefono_proveedor()
        {
            return telefono;
        }
        public void settelefono_proveedor(int Telefono)
        {
            telefono = Telefono;
        }

        public void setlocalidad_proveedor(string Localidad)
        {
            localidad = Localidad;
        }

        public string getlocalidad_proveedor()
        {
            return localidad;
        }
    }
}
