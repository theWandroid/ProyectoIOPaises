using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIOPaises
{
    internal class Program
    {
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
            //theWorld.ReadDataFromFile("Countries.txt");
            //theWorld.ListCountries();

            */

            int option = 0;
            World theWorld = new World();
            option = ShowMenu(option);
            Console.ReadKey();
        }

        static int ShowMenu(int theOption)
        {
            while(theOption != 1 && theOption != 2 && theOption != 3 && theOption != 4)
            {
                Console.Clear();
                string[] textLines = new string[] { "Menu:",
                                                    "1- Añadir país", 
                                                    "2 - Buscar país.", 
                                                    "3 - Listar paises.", 
                                                    "4 - Finalizar",
                                                    "Intruduzca la opción:"};
                WriteCharByChar(textLines);

            string optionString = Console.ReadLine();

            if(!Int32.TryParse(optionString, out theOption)) theOption = 0;
            if (theOption < 1 || theOption > 4) {
                    textLines = new string[] {  "La opción debe estar comprendida entre 1 y 4" ,
                                                "Pulse cualquier tecla"};
                    WriteCharByChar(textLines);
                    Console.ReadKey();
                }
            }

            return theOption;
        }


    
        /// <summary>
        /// Para que el texto aparezca paulatinamente
        /// </summary>
        /// <param name="theTextLines"></param>
        static void WriteCharByChar(string [] theTextLines)
        {
            int i = 0;
            while (i < theTextLines.Length)
            {
                char[] charInTextLine = theTextLines[i].ToCharArray();
                int j = 0;
                while (j < charInTextLine.Length)
                {
                    Console.Write(charInTextLine[j]);
                    if (j == charInTextLine.Length - 1) Console.Write('\n');
                    System.Threading.Thread.Sleep(15);
                    j++;
                }
                i++;
            }
        }
    }
}
