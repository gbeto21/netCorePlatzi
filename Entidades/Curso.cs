using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso : ObjetoEscuelaBase, ILugar
    {
        #region Propiedades

        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }
        #endregion

        public string Dirección { get; set; }

        #region Constructores

        public Curso() { }


        #endregion

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento");
            Console.WriteLine($"Curso {Nombre} limpio");
        }
    }
}