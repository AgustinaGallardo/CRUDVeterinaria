using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDveterinaria.Dominio
{
    internal class Cliente
    {
          int CodCliente { get; set; }
          string Nombre { get; set; }
          string Sexo { get; set; }
          int Dni { get; set; }      
          string Apellido { get; set; }



        public Cliente(int codCliente, string nombre, string apellido, string sexo, int dni)
        {
            this.Apellido = apellido;
            this.CodCliente = codCliente;
            this.Nombre = nombre;
            this.Sexo = sexo;
            this.Dni = dni;
        }
        public Cliente()
        {
            this.Apellido="";
            this.Nombre="";
            this.CodCliente=0;
            this.Sexo="";
            this.Dni=0;
        }
        public override string ToString()
        {
            return "Cliente:" + Apellido + "," + Nombre + " -Dni: " + Dni;
        }
    }
}
