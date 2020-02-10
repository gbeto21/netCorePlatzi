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

        public IEnumerable<Escuela> GetListaEvaluaciones()
        {
            // var lista = diccionario.GetValueOrDefault(LlaveDiccionario.Escuela);
            IEnumerable<Escuela> escuela = null;
            if (diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
                escuela = lista.Cast<Escuela>();

            return escuela;
        }
    }
}