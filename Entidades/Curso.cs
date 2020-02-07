using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso : ObjetoEscuelaBase
    {
        #region Propiedades

        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }
        #endregion

        #region Constructores

        public Curso() { }

        #endregion
    }
}