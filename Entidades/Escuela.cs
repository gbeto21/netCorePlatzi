using System.Collections.Generic;
using System;
namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int AñoCreación { get; set; }

        public string País { get; set; }

        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }

        #region Constructors

        public Escuela(string nombre, int año) => (Nombre, AñoCreación) = (nombre, año);

        public Escuela(string nombre, int año, TiposEscuela tipoEscuela, string pais = "", string ciudad = "")
        {
            (Nombre, AñoCreación) = (nombre, año);
            (TipoEscuela, País, Ciudad) = (tipoEscuela, pais, ciudad);
        }

        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} \nPaís: {País},{System.Environment.NewLine}Ciudad: {Ciudad}";
        }
        #endregion

    }

}