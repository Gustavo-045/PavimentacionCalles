namespace ObrasPublicas
{
    public class calleObjeto
    {
        // Atributos
        private string tipoDano;
        private float metrosCalle;
        private float metrosAfectados;

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

        public float MetrosCalle
        {
            get { return metrosCalle; }
            set { metrosCalle = value; }
        }

        public float MetrosAfectados
        {
            get { return metrosAfectados; }
            set { metrosAfectados = value; }
        }
    }
}