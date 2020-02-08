using CoreEscuela.Util;
using CoreEscuela.Entidades;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Cursos escuela.");
            ImprimirCursos(engine.Escuela.Cursos.ToArray());

            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "gbeto21");
            diccionario.Add(23, "lorem ipsum");

            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key} Valor: {keyValPair.Value} ");
            }

            diccionario[0] = "Pekermal";
            Printer.WriteTitle("Acceso a Diccionario");
            WriteLine(diccionario[0]);

            Printer.WriteTitle(" SEGUNDO DICCIONARIO ");
            var segundo = new Dictionary<string, string>();
            segundo["Luna"] = "Cuerpo que guira alredor de la tierra";
            WriteLine(segundo["Luna"]);
            

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
