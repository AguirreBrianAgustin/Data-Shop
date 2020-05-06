using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Marcas
    {
        private int id_marca;
        private String nombre;

        public Marcas()
        { }
        public int getid_marca()
        {
            return id_marca;
        }
        public void setid_marca(int idmarca)
        {
            id_marca = idmarca;
        }
        public String getnombre()
        {
            return nombre;
        }
        public void setNombre(String Nombre)
        {
            nombre = Nombre;
        }

    }
}
