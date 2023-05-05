namespace ObrasPublicas
{
    public class calleObjeto
    {
        // Atributos
        private string tipoDano;
        private int metrosCalle;
        private int metrosAfectados;

        //Constructor
        public calleObjeto()
        {
            metrosCalle = 0;
            tipoDano = string.Empty;
            metrosAfectados = 0;
        }

        //Las propiedades
        public string TipoDano
        {
            get { return tipoDano; }
            set { tipoDano = value; }
        }

        public int MetrosCalle
        {
            get { return metrosCalle; }
            set { metrosCalle = value; }
        }

        public int MetrosAfectados
        {
            get { return metrosAfectados; }
            set { metrosAfectados = value; }
        }
    }
}