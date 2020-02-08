using CoreEscuela.Util;
using CoreEscuela.Entidades;
using static System.Console;

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
            Printer.DrawLine(20);

            Printer.WriteTitle("Pruebas de Polimorfismo");
            var alumnoTest = new Alumno { Nombre = "Clare UnderWood" };
            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno ID: {alumnoTest.UniqueId}");
            WriteLine($"Alumno Type: {alumnoTest.GetType()}");

            Printer.WriteTitle("Objeto escuela");
            WriteLine($"Objeto Escuela: {ob.Nombre}");
            WriteLine($"Objeto Escuela ID: {ob.UniqueId}");
            WriteLine($"Objeto Escuela Type: {ob.GetType()}");

            var evaluacion = new Evaluación { Nombre = "Math", Nota = 4.4f };
            Printer.WriteTitle("Evaluacion");
            WriteLine($"Evaluacion: {evaluacion.Nombre}");
            WriteLine($"Evaluacion ID: {evaluacion.UniqueId}");
            WriteLine($"Evaluacion Nota: {evaluacion.Nota}");
            WriteLine($"Evaluacion Type: {evaluacion.GetType()}");

            // ob = evaluacion;
            if (ob is Alumno)
            {
                Alumno alumnoCast = (Alumno)(ob);
            }

            Alumno alumnoCast2 = ob as Alumno;
            if (alumnoCast2 != null)
            {

            }

            var objetos = engine.GetObjetosEscuela();

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
