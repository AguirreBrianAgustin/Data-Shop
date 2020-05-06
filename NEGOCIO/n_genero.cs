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
    public class n_genero
    {
        public DataTable getTabla()
        {
            DatosGeneros dao = new DatosGeneros();
            return dao.getTablaMarcas();
        }

        public Generos get(int id)
        {
            DatosGeneros dao = new DatosGeneros();
            //Validar si existe esa categoria
            return dao.getMarca(id);
        }
        public void AgregarGenero(String ID, String NOMBRE)
        {
            DatosGeneros dao = new DatosGeneros();
            dao.AgregarGenero(ID, NOMBRE);

        }
        public int obtenercantidadregistrogenero()
        {
            DatosGeneros reg = new DatosGeneros();
            int resu = reg.obtenercantidadregistrogenero();
            return resu;
        }

        public void eliminarGenero(string id)
        {
            DatosGeneros reg = new DatosGeneros();
            reg.eliminarGenero(id);
        }

        public void actualizarGenero(string todo)
        {
            DatosGeneros reg = new DatosGeneros();
            reg.actualizarGenero(todo);

        }
    }
}
