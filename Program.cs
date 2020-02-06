using System;

namespace CoreEscuela
{
    class Escuela
    {
        public string nombre;

        public string direccion;

        public int añoFundacion;

        public string ceo;
        public void Timbrar()
        {
            //Todo
            Console.Beep(10000, 3000);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var miEscuela = new Escuela();
            miEscuela.nombre = "Platzi Academy";
            miEscuela.direccion = "Carrera 9 calle 72";
            miEscuela.añoFundacion = 2012;
            Console.WriteLine("TIMBRE");
            miEscuela.Timbrar();
            //Console.WriteLine("Hello World!");
        }
    }
}
