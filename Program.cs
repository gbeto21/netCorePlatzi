using CoreEscuela.Util;
using CoreEscuela.Entidades;
using static System.Console;
using System;
using CoreEscuela.App;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionEvento;
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA.");

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evaluaciones = reporteador.GetListaEvaluaciones();
            var asignaturas = reporteador.GetListaAsignaturas();
        }

        private static void AccionEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo");
            Printer.WriteTitle("Salio");

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
