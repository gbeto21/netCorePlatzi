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
            var evaluacionesAsignatura = reporteador.GetListaEvaluacionesAsignatura();
            var promedios = reporteador.GetPromedioAlumnoAsignatura();
            foreach (var promedio in promedios)
            {
                foreach (var alumno in promedio.Value)
                {
                    var alumnoPromedio = alumno as AlumnoPromedio;
                }
            }

            Printer.WriteTitle("Captura de una Evaluacion por consola");
            var evaluacion = new Evaluación();
            string nombre, notaString;
            float nota;

            WriteLine("Ingrese el nombre de la evaluacion.");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
                Printer.WriteTitle("El valor del nombre no puede ser vacio");
            else
                evaluacion.Nombre = nombre.ToLower();

            WriteLine("El nombre de la evaluacion se ha ingresado correctamente.");

            WriteLine("Ingrese la nota de la evaluacion.");
            Printer.PresioneEnter();
            notaString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(notaString))
                Printer.WriteTitle("El valor de la nota no puede ser vacio");
            else
            {
                try
                {
                    evaluacion.Nota = float.Parse(notaString);
                    WriteLine("La nota de la evaluacion se ha ingresado correctamente.");
                    if (evaluacion.Nota < 0 || evaluacion.Nota > 5)
                        throw new ArgumentOutOfRangeException("La nota debe de estar entre 0 y 5.");
                }
                catch (ArgumentOutOfRangeException excepcion)
                {
                    WriteLine(excepcion.Message);
                }
                catch (System.Exception)
                {
                    Printer.WriteTitle("El valor de la nota no es un numero valido");
                }
                finally
                {
                    Printer.WriteTitle("FINALY");

                }
            }
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
