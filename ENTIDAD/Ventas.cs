using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Ventas
    {
        private int id_venta;
        private int id_cliente;
        private int dni_cliente;
        private int telefono;
        private string fecha;
        private int id_Detalle_venta;
        private int total;

        public Ventas()
        { }
        ///****
        public int getid_venta()
        {
            return id_venta;
        }

        public void setid_venta(int id_Venta)
        {
            id_venta = id_Venta;

        }
        ///****
        public int getid_cliente()
        {
            return id_cliente;
        }

        public void setid_cliente(int id_Cliente)
        {
            id_cliente = id_Cliente;

        }
        ///****
        public int getdni_cliente()
        {
            return dni_cliente;
        }

        public void setdni_cliente(int dni_Cliente)
        {
            dni_cliente = dni_Cliente;

        }
        ///****
        public int gettelefono()
        {
            return telefono;
        }

        public void settelefono(int Telefono)
        {
            telefono = Telefono;

        }
        ///****
        public string getfecha()
        {
            return fecha;
        }

        public void setfecha(string Fecha)
        {
            fecha = Fecha;

        }
        ///****
        public int getid_Detalle_venta()
        {
            return id_Detalle_venta;
        }

        public void setid_Detalle_venta(int Id_Detalle_venta)
        {
            id_Detalle_venta = Id_Detalle_venta;

        }
        ///****
        public float gettotal()
        {
            return total;
        }

        public void settotal(int Total)
        {
            total = Total;

        }


    }
}
