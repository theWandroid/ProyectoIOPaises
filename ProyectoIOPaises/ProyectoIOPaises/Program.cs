using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIOPaises
{
    internal class Program
    {
        static World theWorld = new World();

        static void Main(string[] args)
        {
            /*
            Country countryOne = new Country("España", "Madrid");
            //countryOne.SetCountryData("España", "Madrid");
            Country countryTwo = new Country("Portugal", "Lisboa");
            //countryTwo.SetCountryData("Portugal", "Lisboa");

            
            theWorld.InsertCountry(countryOne);
            theWorld.InsertCountry(countryTwo);

            theWorld.ListCountries();
            theWorld.SaveDataOnFile("Countries.txt");
            

            // Lee el arvhivo Countries.txt y muestra lo que hay en el
            //theWorld.ListCountries();

            */

            int option = 0;
            theWorld.ReadDataFromFile("Countries.txt");
           
            while(option != 6)
            {
                option = 0;
                option = ShowMenu(option);
                MakeAction(option);
                WriteCharByChar("Aprete cualquier texla para continuar");
                Console.ReadKey();
            }
            Console.ReadKey();
        }

        static int ShowMenu(int theOption)
        {
            while(theOption != 1 && theOption != 2 && theOption != 3 && theOption != 4 && theOption != 5 && theOption != 6 && theOption != 7)
            {
                Console.Clear();
                string[] textLines = new string[] { "Menu:",
                                                    "1- Añadir país", 
                                                    "2 - Buscar país.", 
                                                    "3 - Listar paises.",
                                                    "4 - Ordenar por población",
                                                    "5 - Añadir ciudades",
                                                    "6 - Borrar país",
                                                    "7 - Finalizar",
                                                    "Intruduzca la opción:"};
                WriteCharByChar(textLines);

            string optionString = Console.ReadLine();

            if(!Int32.TryParse(optionString, out theOption)) theOption = 0;
            if (theOption < 1 || theOption > 7) {
                    textLines = new string[] {  "La opción debe estar comprendida entre 1 y 6" ,
                                                "Pulse cualquier tecla"};
                    WriteCharByChar(textLines);
                    Console.ReadKey();
                }
            }

            return theOption;
        }

        static void MakeAction(int theOption)
        {
            switch (theOption)
            {
                case 1:
                    WriteCharByChar("Ha elegido añadir país");
                    theWorld.AddCountry();
                    break;
                case 2:
                    WriteCharByChar("Ha elegido buscar país.");
                    theWorld.SearchCountry(true);
                    break;
                case 3:
                    WriteCharByChar("Ha elegido listar países");
                    theWorld.ListCountries(theWorld.countryList);
                    break;
                case 4:
                    WriteCharByChar("Ha elegido ordenar por población");
                    theWorld.OrderByPopulation();
                    break;
                case 5:
                    WriteCharByChar("Ha elegido añadir ciudades");
                    theWorld.AddCities();
                    break;
                case 6:
                    WriteCharByChar("Ha elegido borrar país");
                    theWorld.EraseCountry();
                    break;
                case 7:
                    string[] textLines = new string[] {
                                                        "Ha elegido finalizar el programa.",
                                                        "Pulse cualquier tecla para finalizar el programa."};
                    WriteCharByChar(textLines);
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    WriteCharByChar("Posibilidad no contemplada");
                    break;
            }
        }


    
        /// <summary>
        /// Para que el texto aparezca paulatinamente
        /// </summary>
        /// <param name="theTextLines"></param>
        static public void WriteCharByChar(string [] theTextLines)
        {
            int i = 0;
            while (i < theTextLines.Length)
            {
                char[] charInTextLine = theTextLines[i].ToCharArray();
                int j = 0;

                while (j < charInTextLine.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(charInTextLine[j]);
                    if (j == charInTextLine.Length - 1) Console.Write('\n');
                    System.Threading.Thread.Sleep(2);
                    j++;
                }
                System.Threading.Thread.Sleep(10);
                i++;
            }
        }

        static public void WriteCharByChar(string textLine)
        {
           
                char[] charInTextLine = textLine.ToCharArray();
                int j = 0;
                while (j < charInTextLine.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(charInTextLine[j]);
                    if (j == charInTextLine.Length - 1) Console.Write('\n');
                    System.Threading.Thread.Sleep(2);
                    j++;
                }
        }
    }
}
