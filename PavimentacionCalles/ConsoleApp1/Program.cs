using System;
using ObrasPublicas;


//los tipos de daño son tipos medios
// tipo alimento son los metros afectados
//cantidad de alimento es los metros totales de la calle
//cantidad de calles es cantidad de animales
//calles.obras = animales.Zoo

namespace ObrasPublicas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("programa para el arreglo de vias publicas");
            int cantidadCalles = 0;
            bool datoCorrecto = false;

            while (datoCorrecto == false)
            {
                try
                {
                    Console.Write("\ningrese la cantidad de calles para el proceso de reparacion ");
                    cantidadCalles = int.Parse(Console.ReadLine()!);

                    if (cantidadCalles > 0)
                        datoCorrecto = true;
                    else
                        Console.WriteLine("La cantidad debe ser un numero entero positivo. Intenta nuevamente");
                }
                catch (FormatException elError)
                {
                    Console.WriteLine("La cantidad debe ser un numero entero positivo. Intenta nuevamente");
                    Console.WriteLine(elError.Message);
                }
            }

            string[] losDaños = { "hundimientos", "ondulaciones", "agrietamientos" };
            //int[] metroscalle = { 400 };

            Random aleatorio = new Random();

            calleObjeto[] callesObras = new calleObjeto[cantidadCalles];

            for (int i = 0; i < callesObras.Length; i++)
            {
                callesObras[i] = new calleObjeto();

                callesObras[i].MetrosCalle = aleatorio.Next(100, 501);
                callesObras[i].MetrosAfectados = aleatorio.Next(20, 61);
                callesObras[i].TipoDano = losDaños[aleatorio.Next(losDaños.Length)];

            }

            VisualizaInformacionCalles(callesObras);
            


            
            Console.WriteLine("\n Los totales de metros afectados por tipo de calle son");
            float[] totalesCalleDaño = ObtieneCantidadCallePavimentadaPorDeterioro(callesObras, losDaños);
            int[] totalAfectacionesPorDeterioro = TotalizaAfectacionesPorDeterioro(callesObras, losDaños);
            float[] longitudesPromedio = ObtieneLongitudPromedioTramosPorDeterioro(callesObras, losDaños);
            for (int i = 0; i < losDaños.Length; i++)
            {
                Console.WriteLine($"\nDaño: {losDaños[i]}:\n" +
                    $"Total Calles afectadas: {totalAfectacionesPorDeterioro[i]} . " +
                    $"Total metros afectados: {totalesCalleDaño[i].ToString(".00")} mts. " +
                    $"longitud promedio de los tramos afectados {longitudesPromedio[i].ToString("0.00")}\n");
            }





        }

        static void VisualizaInformacionCalles(calleObjeto[] callesObras)
        {

            Console.WriteLine("\nlas calles son:");

            int contador = 1;
            foreach (calleObjeto unCalleObjeto in callesObras)
            {
                Console.WriteLine($"\nCalle No. {contador}, \n" +
                    $"de longitud {unCalleObjeto.MetrosCalle} y con un daño de tipo {unCalleObjeto.TipoDano} \n" +
                    $"tuvo un daño del {unCalleObjeto.MetrosAfectados} %");
                contador++;

            }
        }


        static float[] ObtieneCantidadCallePavimentadaPorDeterioro(calleObjeto[] lasCalles, string[] losDaños)
        {
            //los totalesPorDaño son como los totales por Medio

            float[] totalesPorDaño = new float[losDaños.Length];

            for (int i = 0; i < losDaños.Length; i++)
            {
                int totalMetrosAfectados = 0; // Reiniciar el contador en cada iteración del primer bucle

                for (int j = 0; j < lasCalles.Length; j++)
                {
                    if (lasCalles[j].TipoDano == losDaños[i])
                        totalMetrosAfectados += (int)(lasCalles[j].MetrosCalle * (lasCalles[j].MetrosAfectados / 100.0));
                }

                totalesPorDaño[i] = totalMetrosAfectados;
            }

            return totalesPorDaño;
        }

        static float[] ObtieneLongitudPromedioTramosPorDeterioro(calleObjeto[] lasCalles, string[] losDeterioros)
        {
            float[] longitudesPromedio = new float[losDeterioros.Length];
            int[] totalAfectaciones = TotalizaAfectacionesPorDeterioro(lasCalles, losDeterioros);
            float[] TotalPavimentoPorDeterioro = ObtieneCantidadCallePavimentadaPorDeterioro(lasCalles, losDeterioros);

            for (int i = 0; i < losDeterioros.Length; i++)
                longitudesPromedio[i] = TotalPavimentoPorDeterioro[i] / (totalAfectaciones[i] * 1.0f);

            return longitudesPromedio;
        }


        static int[] TotalizaAfectacionesPorDeterioro(calleObjeto[] lasCalles, string[] losDeterioros)
        {
            int[] totalAfectaciones = new int[losDeterioros.Length];

            for (int i = 0; i < lasCalles.Length; i++)
                for (int j = 0; j < losDeterioros.Length; j++)
                    if (lasCalles[i].TipoDano == losDeterioros[j])
                        totalAfectaciones[j]++;

            return totalAfectaciones;

        }
    }
}
