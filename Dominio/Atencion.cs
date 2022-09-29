using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDveterinaria.Dominio
{
    internal class Atencion
    {
       private double Importe { get { return Importe; } set { Importe = value; } }
        public DateTime Fecha { get { return Fecha; } set { Fecha = value; } }
       


        public Atencion( double importe, DateTime fecha)
        {
            this.Fecha=fecha;
            
            this.Importe=importe;

        }
        public Atencion()
        {
            this.Importe=0;
            this.Fecha=DateTime.Today;
        }
        public override string ToString()
        {
            return  "Costo:" + Importe + " $ ";
        }
    }
}
