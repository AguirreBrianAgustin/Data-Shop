using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using DATOS;

namespace DATOS
{
    public class Datoslogin
    {
        public string obetenerpermiso(string user, string contra)
        {
            AccesoDatos reg = new AccesoDatos();
           string resu;
            resu = reg.obetenerpermiso(user, contra);
            return resu;
        }
        public void cargarlogin(string consulta)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.cargarlogin(consulta);
        }
    }
}
