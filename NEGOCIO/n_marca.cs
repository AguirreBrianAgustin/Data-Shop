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
    public class n_marca
    {
        public DataTable getTabla()
        {
            DatosMarcas dao = new DatosMarcas();
            return dao.getTablaMarcas();
        }

        public Marcas get(int id)
        {
            DatosMarcas dao = new DatosMarcas();
            //Validar si existe esa categoria
            return dao.getMarca(id);
        }


        //public bool eliminarCategoria(int id)
        //{
        //    //Validar id existente 
        //    DaoCategoria dao = new DaoCategoria();
        //    Categoria cat = new Categoria();
        //    cat.setIdCategoria(id);
        //    int op = dao.eliminarCategoria(cat);
        //    if (op == 1)
        //        return true;
        //    else
        //        return false;
        //}
        public void AgregarMarca(String ID, String NOMBRE)
        {
            DatosMarcas REG = new DatosMarcas();
            REG.AgregarMarca(ID,NOMBRE);
            
        }
        public int obtenercatidadregistro() {
            DatosMarcas reg = new DatosMarcas();
            int resu;
            resu=reg.obtenercatidadregistro();
            return resu;
        }
        public void eliminarMarca(string id)
        {
            DatosMarcas reg = new DatosMarcas();
            reg.eliminarMarca(id);
        }

        public void actualizarMarca(string todo)
        {
            DatosMarcas reg = new DatosMarcas();
            reg.actualizarMarca(todo);

        }
    }
   
}
