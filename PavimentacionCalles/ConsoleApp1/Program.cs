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
            int[] totalesCalleDaño = ObtieneCantidadCallePavimentadaPorDeterioro(callesObras, losDaños);

            for (int i = 0; i < losDaños.Length; i++)
                Console.WriteLine($"Daño: {losDaños[i]}, " +
                    $"Total Metros Afectados: {totalesCalleDaño[i]}");

            








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

        
        static int[] ObtieneCantidadCallePavimentadaPorDeterioro(calleObjeto[] lasCalles, string[] losDaños)
        {
            //los totalesPorDaño son como los totales por Medio
            
            int[] totalesPorDaño = new int[lasCalles.Length];

            int totalMetrosAfectados = 0;

            for (int i = 0; i < losDaños.Length; i++)
            {
                for (int j = 0; j < lasCalles.Length; j++)
                {
                    if (lasCalles[j].TipoDano == losDaños[i])
                        totalMetrosAfectados += (int)(lasCalles[j].MetrosCalle * (lasCalles[j].MetrosAfectados / 100.0));
                }
                totalesPorDaño[i] = totalMetrosAfectados;
            }

            return totalesPorDaño;
            
        }

       /* static float[] ObtieneLongitudPromedioTramosPorDeterioro(calleObjeto[] lasCalles, string[] losPromedios)
        {
            //los totalesPorDaño son como los totales por Medio

            float[] totalesPorDaño = new float[lasCalles.Length];

            int totalMetrosAfectados = 0;

            for (int i = 0; i < losPromedios.Length; i++)
            {
                for (int j = 0; j < lasCalles.Length; j++)
                {
                    if (lasCalles[j].TipoDano == losPromedios[i])
                        totalMetrosAfectados += (int)(lasCalles[j].MetrosCalle * (lasCalles[j].MetrosAfectados / 100.0));
                }
                for (int k = 0; k < losPromedios.Length; i++)
                {
                    if (totalesPorDaño[k] > 0)
                    {
                        int promedio = totalMetrosAfectados[i] / totalesPorDaño[i];
                    }

            return totalesPorDaño;

        }*/
    }
}
