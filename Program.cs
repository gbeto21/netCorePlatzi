using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad: "Bogota", pais: "Colombia");

            escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101" },
                new Curso() { Nombre = "201" },
                new Curso { Nombre = "301" }
            };

            escuela.Cursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });

            var cursos = new List<Curso>(){
                new Curso() { Nombre = "401" },
                new Curso() { Nombre = "501" },
                new Curso { Nombre = "502" }
            };

            cursos.Clear();

            escuela.Cursos.AddRange(cursos);

            WriteLine(escuela);
            WriteLine(new String('*', 30));
            ImprimirCursos(escuela.Cursos.ToArray());

        }

        private static void ImprimirCursos(Curso[] cursos)
        {
            if (cursos == null)
                return;

            foreach (var curso in cursos)
            {
                WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
            }
        }
    }
}
