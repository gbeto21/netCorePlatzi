namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int AñoCreación { get; set; }

        public string País { get; set; }

        public string Ciudad { get; set; }

        #region Constructors

        public Escuela(string nombre, int año) => (Nombre, AñoCreación) = (nombre,año);

        #endregion

    }

}