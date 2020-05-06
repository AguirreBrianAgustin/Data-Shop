using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Generos
    {
        private int id_genero;
        private String descripcion;

        public Generos()
        { }
        public int getid_genero()
        {
            return id_genero;
        }
        public void setid_genero(int idgenero)
        {
            id_genero = idgenero;
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
