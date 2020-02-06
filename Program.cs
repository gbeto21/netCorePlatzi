using System;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012);
            escuela.Ciudad = "Bogota";
            escuela.País = "Colombia";
            Console.WriteLine(escuela.Nombre);
        }
    }
}
