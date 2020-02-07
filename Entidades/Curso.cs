using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        #region Propiedades

        public string UniqueId { get; private set; }

        public string Nombre { get; set; }

        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }
        #endregion

        #region Constructores

        public Curso() => UniqueId = Guid.NewGuid().ToString();

        #endregion
    }
}