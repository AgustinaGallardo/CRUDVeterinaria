using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDveterinaria.Dominio
{
     class Atencion
    {
       public string Descripcion { get; set; }
       public double Importe { get; set; }
        public DateTime Fecha { get; set; }

        public Atencion(string descripcion,double importe, DateTime fecha)
        {
            this.Fecha=fecha;            
            this.Importe=importe;
            this.Descripcion = descripcion;
        }
        public Atencion()
        {             
            Importe=0;
            Fecha=DateTime.Now;
            Descripcion="";
        }
        public override string ToString()
        {
            return  "Costo:" + Importe + " $ ";
        }
    }
}
