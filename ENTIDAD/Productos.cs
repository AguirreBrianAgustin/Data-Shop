
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ENTIDAD
{
    public class Productos
    {

        private int id_producto;
        private string nombre;
        private int id_marca;
        private int id_genero;
        private int stock;
        private int pegi;
        private string portada;
        private string descripcion;
        private float precio_unidad;

        public Productos()
        { }

        public int getid_producto()
        {
            return id_producto;
        }
        public void setid_producto(int id_Producto)
        {
            id_producto = id_Producto;
        }

        public int getnombre_producto()
        {
            return id_producto;
        }
        public void setnombre_producto(string Nombre)
        {
            nombre = Nombre;
        }

        public int getidmarca_producto()
        {
            return id_marca;
        }
        public void setidmarca_producto(int ID)
        {
            id_marca = ID;
        }

        public int getigenero_producto()
        {
            return id_genero;
        }
        public void setidgenero_producto(int ID)
        {
            id_genero = ID;
        }

        public int getstock_producto()
        {
            return stock;
        }
        public void setstock_producto(int Stock)
        {
            stock = Stock;
        }

        public int getpegi_producto()
        {
            return pegi;
        }
        public void setpegi_producto(int Pegi)
        {
            pegi = Pegi;
        }

        public string getportada_producto()
        {
            return portada;
        }
        public void setportada_producto(string Portada)
        {
            portada = Portada;
        }

        public string getdescripcion_producto()
        {
            return descripcion;
        }
        public void setdescripcion_producto(string Desc)
        {
            descripcion = Desc;
        }

        public float getprecio_unidad_producto()
        {
            return precio_unidad;
        }
        public void setprecio_unidad_producto(float Precio)
        {
            precio_unidad = Precio;
        }

        //public int getid_proveedor()
        //{
        //    return id_proveedor;
        //}
        //public void setid_proveedor(int id_Proveedor)
        //{
        //    id_proveedor = id_Proveedor;

        //}


    }
}
