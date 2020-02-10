using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using System.Linq;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        private Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> diccionario;

        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> pDiccionario)
        {
            if (pDiccionario == null)
                throw new ArgumentNullException(nameof(pDiccionario));

            diccionario = pDiccionario;
        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {
            if (diccionario.TryGetValue(LlaveDiccionario.Evaluación, out IEnumerable<ObjetoEscuelaBase> lista))
                return lista.Cast<Evaluación>();

            return new List<Evaluación>();
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluación> evaluaciones)
        {
            evaluaciones = GetListaEvaluaciones();

            return (from evaluacion in evaluaciones
                        // where evaluacion.Nota >= 3.0f
                    select evaluacion.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluación>> GetListaEvaluacionesAsignatura()
        {
            var evaluaciones = new Dictionary<string, IEnumerable<Evaluación>>();
            var asignaturas = GetListaAsignaturas(out var evaluacións);

            foreach (var asignatura in asignaturas)
            {
                var evaluacionesAsignatura = from eva in evaluacións
                                             where eva.Asignatura.Nombre == asignatura
                                             select eva;

                evaluaciones.Add(asignatura, evaluacionesAsignatura);
            }

            return evaluaciones;
        }

        public Dictionary<string, IEnumerable<Object>> GetPromedioAlumnoAsignatura()
        {
            var respuesta = new Dictionary<string, IEnumerable<object>>();
            var evaluaciones = GetListaEvaluacionesAsignatura();

            foreach (var asignatura in evaluaciones)
            {
                var promedios = from eva in asignatura.Value
                                group eva by eva.Alumno
                            into grupo
                                select new AlumnoPromedio
                                {
                                    Alumno = grupo.Key,
                                    Promedio = grupo.Average(evalu => evalu.Nota)
                                };
                respuesta.Add(asignatura.Key, promedios);
            }

            return respuesta;
        }
    }
}