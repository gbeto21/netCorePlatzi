using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using System.Linq;
using CoreEscuela.Util;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academay", 2012, TiposEscuela.Primaria,
            ciudad: "Bogotá", pais: "Colombia"
            );

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> pDiccionario, bool pImprimirEvaluacion = false)
        {
            foreach (var elemento in pDiccionario)
            {
                Printer.WriteTitle(elemento.Key.ToString());
                foreach (var valor in elemento.Value)
                {

                    switch (elemento.Key)
                    {
                        case LlaveDiccionario.Evaluación:
                            if (pImprimirEvaluacion)
                                Console.WriteLine(valor);
                            break;

                        case LlaveDiccionario.Escuela:
                            Console.WriteLine($"Escuela: {valor}.");
                            break;

                        case LlaveDiccionario.Alumno:
                            Console.WriteLine($"Alumno: {valor.Nombre}");
                            break;

                        case LlaveDiccionario.Curso:
                            Console.WriteLine($"Curso: {valor.Nombre}, Alumnos {(valor as Curso).Alumnos.Count}");
                            break;

                        default:
                            Console.WriteLine(valor);
                            break;
                    }

                }
            }
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
        out int conteoEvaluaciones,
        out int conteoCursos,
        out int conteoAsignaturas,
        out int conteoAlumnos,
        bool traerEvaluaciones = true,
        bool traerAlumnos = true,
        bool traerAsignaturas = true,
        bool traerCursos = true
        )
        {
            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = 0;

            var lista = new List<ObjetoEscuelaBase>();
            lista.Add(Escuela);

            if (traerCursos)
                lista.AddRange(Escuela.Cursos);

            conteoCursos = Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;

                if (traerAsignaturas)
                    lista.AddRange(curso.Asignaturas);

                if (traerAlumnos)
                    lista.AddRange(curso.Alumnos);

                if (traerEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        lista.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }
            return lista.AsReadOnly();
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                bool traerEvaluaciones = true,
                bool traerAlumnos = true,
                bool traerAsignaturas = true,
                bool traerCursos = true
                )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos);

            var evaluaciones = new List<Evaluación>();
            var asignaturas = new List<Asignatura>();
            var alumnos = new List<Alumno>();

            foreach (var curso in Escuela.Cursos)
            {
                asignaturas.AddRange(curso.Asignaturas);
                alumnos.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                    evaluaciones.AddRange(alumno.Evaluaciones);

            }

            diccionario.Add(LlaveDiccionario.Evaluación, evaluaciones);
            diccionario.Add(LlaveDiccionario.Asignatura, asignaturas);
            diccionario.Add(LlaveDiccionario.Alumno, alumnos);

            return diccionario;
        }

        #region Metodos de carga de datos

        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluación
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = MathF.Round((float)(5 * rnd.NextDouble()), 2),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas"} ,
                            new Asignatura{Nombre="Educación Física"},
                            new Asignatura{Nombre="Castellano"},
                            new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                        new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana },
                        new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
            };

            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }

        #endregion

    }
}