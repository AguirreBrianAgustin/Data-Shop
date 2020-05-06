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
    public class login
    {
        public string obtenerpermiso(string user, string contra) {
            Datoslogin reg = new Datoslogin();
            string resu;
            resu = reg.obetenerpermiso(user, contra);
            return resu;
        }
        public void cargarlogin(string consulta)
        {
            Datoslogin reg = new Datoslogin();
            reg.cargarlogin(consulta);
        }
        
        
        
    }
}
