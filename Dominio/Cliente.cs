using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDveterinaria.Dominio
{
    internal class Cliente
    {
         public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public int Sexo { get; set; } 

        public Cliente(int IdCliente, string nombre,  int sexo)
        {            
            this.IdCliente = IdCliente;
            this.Nombre = nombre;
            this.Sexo = 1;
        }

        public Cliente (int id,string nombre)
        {
            this.IdCliente = id;
            this.Nombre = nombre;
        }
        public Cliente()
        {           
            this.Nombre="";
            this.IdCliente=0;
            this.Sexo=1;           
        }
        public override string ToString()
        {
            return  Nombre ;
        }
    }
}
