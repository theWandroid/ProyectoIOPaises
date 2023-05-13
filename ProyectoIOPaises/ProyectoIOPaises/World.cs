using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            Console.WriteLine(countryList[numCountries].name);
            Console.WriteLine(numCountries);
            numCountries++;
        }

        public void ListCountries()
        {
            int i = 0;
            Console.WriteLine(numCountries);
            //Console.WriteLine("Hay {0} paises en la lista", countryList[i].name);
            while (i < countryList.Length && countryList[i] != null)
            {
                Console.WriteLine("El pais es {0} y su capital es {1}.", countryList[i].name, countryList[i].capital);
                i++;
            }
        }


        public void SaveDataOnFile(string fileName)
        {
            StreamWriter file = new StreamWriter(fileName, true);
            Console.WriteLine("Escribe un pais que quieras introducir seguido de su capital separado por /.");
            string s = Console.ReadLine();
            file.WriteLine(s);
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
                InsertCountry(new Country(words[0], words[1]));
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
