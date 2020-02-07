using System;
using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DrawLine(int pTamaño = 10)
        {
            WriteLine("".PadLeft(pTamaño, '='));
        }

        public static void WriteTitle(string titulo)
        {
            var tamaño = titulo.Length + 4;
            DrawLine(tamaño);
            WriteLine($"| {titulo} |");
            DrawLine(tamaño);
        }
    }
}