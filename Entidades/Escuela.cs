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

        public TiposEscuela TipoEscuela { get; set; }

        #region Constructors

        public Escuela(string nombre, int año) => (Nombre, AñoCreación) = (nombre, año);

        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \nPaís: {País}, Ciudad: {Ciudad}";
        }
        #endregion

    }

}