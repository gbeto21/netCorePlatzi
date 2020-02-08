using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;

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
            return null;
            // diccionario[LlaveDiccionario.Evaluación]
        }
    }
}