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
    public class n_pegi
    {
        public DataTable getTabla()
        {
            DatosPegis dao = new DatosPegis();
            return dao.getTablaPegis();
        }

        public Pegis get(int id)
        {
            DatosPegis dao = new DatosPegis();
            //Validar si existe esa categoria
            return dao.getPegi(id);
        }
    }
}
