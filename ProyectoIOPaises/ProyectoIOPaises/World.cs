using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace ProyectoIOPaises
{
    public class World
    {
        public int numCountries = 0;
        public Country[] countryList = new Country[100];
        
      
        public void InsertCountry(Country theCountry)
        {
            //Console.WriteLine("El pais se llama {0}", theCountry.name);
            countryList[numCountries] = theCountry;
            //Console.WriteLine(countryList[numCountries].name);
            //Console.WriteLine(numCountries);
            numCountries++;
        }

        public void ListCountries()
        {
            int i = 0;
            Console.WriteLine(numCountries);
            //Console.WriteLine("Hay {0} paises en la lista", countryList[i].name);
            while (i < countryList.Length && countryList[i] != null)
            {{}
                string[] textLines = new string[] { "Pais: "+ CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryList[i].name) +". Capital:" + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryList[i].capital)+ ". Población: " + countryList[i].population+ ". Superficie: " + countryList[i].surface };
                Program.WriteCharByChar(textLines);
                i++;
            }
        }

        public void AddCountry() 
        {
            string[] textLines = new string[] {"Introduzca el nombre del país que quiera introducir:",
                                               "Introduzca la capital del país que ha introducido anteriormente",
                                                "Introduce la población del país",
                                                "Introduce la superficie del país"};
            Program.WriteCharByChar(textLines[0]);
            string countryName = Console.ReadLine();
            Program.WriteCharByChar(textLines[1]);
            string countryCapital = Console.ReadLine();
            Program.WriteCharByChar(textLines[2]);
            Int64 countryPopulation = Convert.ToInt64(Console.ReadLine());
            Program.WriteCharByChar(textLines[3]);
            int countrySurface = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            bool found = false;
            //Para saber si el nombre del país ya esta en la lista
            while (i < countryList.Length && !found && countryList[i] != null)
            {
                if (countryList[i] != null)
                {
                    if (countryList[i].name.ToLower() == countryName.ToLower())
                    {
                    Program.WriteCharByChar("El nombre del país ya esta introducido");
                    found = true;
                    }
                }
               
                i++;
            }
            if (!found)
            {
                Program.WriteCharByChar("Se va ha introducir el páís");
                InsertCountry(new Country(countryName, countryCapital, countryPopulation, countrySurface));
                SaveDataOnFile("Countries.txt", new Country(countryName, countryCapital, countryPopulation, countrySurface));

            }

        }

        public void SearchCountry()
        {
            string[] textLines = new string[] {
                                                "Que país desea buscar?",
                                                "Introduzca el nombre del país que desea buscar"};
            Program.WriteCharByChar(textLines);
            string countryName = Console.ReadLine();
            bool found = false;
            int i = 0;
            while(i< countryList.Length && found == false)
            {
                if (countryList[i].name.ToLower() == countryName.ToLower())
                {
                    found = true;
                    Program.WriteCharByChar("El país esta en la lista.");
                }
                i++;
            }

            if (!found) Program.WriteCharByChar("El país no esta en la lista");
        }


        public void SaveDataOnFile(string fileName, Country theCountry)
        {
            StreamWriter file = new StreamWriter(fileName, true);
            //string[] textLines = new string[] { "Escribe un pais que quieras introducir seguido de su capital separado por /." };
            //Program.WriteCharByChar(textLines);
            //string s = Console.ReadLine();
            //file.WriteLine(s);
            file.WriteLine(theCountry.name + "/" + theCountry.capital+ "/" +theCountry.population+"/"+theCountry.surface);
            file.Close();
        }

        public void ReadDataFromFile(string fileName)
        {
            StreamReader file = new StreamReader(fileName, Encoding.Default);
            string s = file.ReadLine();

            while (s != null)
            {
                Console.WriteLine(s);
                string[] words = s.Split('/');
                InsertCountry(new Country(words[0], words[1], Convert.ToInt64(words[2]), Convert.ToInt32(words[3])));
                /*
                int i = 0;
                while( i < words.Length)
                {
                    Console.WriteLine(words[i]);
                    i++;
                }
                */
                s = file.ReadLine();

            }
            file.Close();

        }
    }
}
