using ObrasPublicas;



namespace PruebasUnitarias1
{
    [TestClass]
    public class PruebasCalles
    {
        [TestMethod]
        public void ValidarQuelongitudPromedioHundimientosEs20()
        {
            string[] da�osPrueba = { "hundimientos", "agrietamientos", "ondulaciones" };

            calleObjeto[] metrosAfectadosPrueba =
            {
                new calleObjeto() {MetrosCalle=100, MetrosAfectados=20, TipoDano ="hundimientos"},
                new calleObjeto() {MetrosCalle=100, MetrosAfectados=20, TipoDano ="hundimientos"},
            };

            float[] longitudPromedioHundimiento = Program.ObtieneLongitudPromedioTramosPorDeterioro(metrosAfectadosPrueba, da�osPrueba);
            int totalEsperado = 20;
            float totalObtenido = longitudPromedioHundimiento[0];

            Assert.AreEqual(totalEsperado, totalObtenido);


        }

        [TestMethod]
        public void ValidarQueTotalAfectacionesPorHundimientosEs5()
        {
            string[] da�osPrueba = { "hundimientos", "agrietamientos", "ondulaciones" };

            calleObjeto[] calles =
            {
                new calleObjeto() {TipoDano = "hundimientos"},
                new calleObjeto() {TipoDano = "hundimientos"},
                new calleObjeto() {TipoDano = "hundimientos"},
                new calleObjeto() {TipoDano = "hundimientos"},
                new calleObjeto() {TipoDano = "hundimientos"},

            };
            int[] totalAfectacionesHundimiento = Program.TotalizaAfectacionesPorDeterioro(calles, da�osPrueba);
            int cantidadEsperada = 5;
            int cantidadObtenida = totalAfectacionesHundimiento[0];

            Assert.AreEqual(cantidadEsperada, cantidadObtenida);

        }
    }
}