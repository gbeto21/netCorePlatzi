using System;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad: "Bogota", pais: "Colombia");

            var cursos = new Curso[3];
            cursos[0] = new Curso()
            {
                Nombre = "101"
            };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };

            cursos[1] = curso2;

            cursos[2] = new Curso
            {
                Nombre = "301"
            };

            Console.WriteLine(escuela);
            Console.WriteLine(new String('*', 30));
            ImprimirCursos(cursos);
        }

        private static void ImprimirCursos(Curso[] cursos)
        {
            foreach (var curso in cursos)
            {
                System.Console.WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
            }
        }
    }
}
