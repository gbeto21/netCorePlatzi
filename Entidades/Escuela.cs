using System.Collections.Generic;
using System;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {

        public int AñoCreación { get; set; }

        public string País { get; set; }

        public string Ciudad { get; set; }

        public string Dirección { get; set; }

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

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando escuela");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Printer.WriteTitle($"Escuela {Nombre} limpio");
        }
        #endregion

    }

}