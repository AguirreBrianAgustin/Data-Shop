using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Pegis
    {
        private int id_pegi;
        private String descripcion;

        public Pegis()
        { }
        public int getid_pegi()
        {
            return id_pegi;
        }
        public void setid_pegi(int idpegi)
        {
            id_pegi = idpegi;
        }
        public String getnombre()
        {
            return descripcion;
        }
        public void setNombre(String Nombre)
        {
            descripcion = Nombre;
        }
    }
}
