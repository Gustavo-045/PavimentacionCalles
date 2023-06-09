using ObrasPublicas;



namespace PruebasUnitarias1
{
    [TestClass]
    public class PruebasCalles
    {
        [TestMethod]
        public void ValidarQuelongitudPromedioHundimientosEs30()
        {
            string[] dañosPrueba = { "hundimientos", "agrietamientos", "ondulaciones" };

            calleObjeto[] metrosAfectadosPrueba =
            {
                new calleObjeto() {MetrosCalle=100, MetrosAfectados=30, TipoDano ="hundimientos"},
            };

            float[] longitudPromedioHundimiento = Program.ObtieneLongitudPromedioTramosPorDeterioro(metrosAfectadosPrueba, dañosPrueba);
            int totalEsperado = 30;
            float totalObtenido = longitudPromedioHundimiento[0];

            Assert.AreEqual(totalEsperado, totalObtenido);


        }

        [TestMethod]
        public void ValidarQueTotalAfectacionesPorHundimientosEs6()
        {
            string[] dañosPrueba = { "hundimientos", "agrietamientos", "ondulaciones" };

            calleObjeto[] calles =
            {
                new calleObjeto() {TipoDano = "hundimientos"},
                new calleObjeto() {TipoDano = "hundimientos"},
                new calleObjeto() {TipoDano = "hundimientos"},
                new calleObjeto() {TipoDano = "hundimientos"},
                new calleObjeto() {TipoDano = "hundimientos"},
                new calleObjeto() {TipoDano = "hundimientos"},

            };
            int[] totalAfectacionesHundimiento = Program.TotalizaAfectacionesPorDeterioro(calles, dañosPrueba);
            int cantidadEsperada = 6;
            int cantidadObtenida = totalAfectacionesHundimiento[0];

            Assert.AreEqual(cantidadEsperada, cantidadObtenida);

        }
    }
}