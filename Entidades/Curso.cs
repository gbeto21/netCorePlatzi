using System;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        #region Propiedades

        public string UniqueId { get; private set; }

        public string Nombre { get; set; }

        public TiposJornada Jornada { get; set; }
        #endregion

        #region Constructores

        public Curso() => UniqueId = Guid.NewGuid().ToString();

        #endregion
    }
}