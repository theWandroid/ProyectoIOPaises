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
            countryList[numCountries] = theCountry;
            numCountries++;
        }

        public void ListCountries(Country[] theCountryList)
        {
            int i = 0;
            while (i < theCountryList.Length && theCountryList[i] != null)
            {{}
                string[] textLines = new string[] { "Pais => "+ CultureInfo.InvariantCulture.TextInfo.ToTitleCase(theCountryList[i].name) +"   Capital:" + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(theCountryList[i].capital)+ "    Población: " + theCountryList[i].population+ "    Superficie => " + theCountryList[i].surface };

                //Para poder poner separadores de miles y millones a un int podemos recurrir a la forma n.ToString(#,##0.00) o (#.##0,00)
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
            string countryPopulation = Console.ReadLine();
            Program.WriteCharByChar(textLines[3]);
            string countrySurface = Console.ReadLine();
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

        public void EraseCountry()
        {
            Program.WriteCharByChar("¿Introduce el nombre del país que deseas borrar?");
            Country countryToErase = SearchCountry(false);
            int i = 0,
                j = 0;
            bool found = false;
            if(countryToErase != null)
            {
                while(i < countryList.Length && countryList[i] != null && !found)
                {
                    if (countryToErase.name == countryList[i].name)
                    {
                        i = j;
                        if (i < countryList.Length - 1)
                        {
                            countryList[i] = countryList[i + i];
                        }
                        else { countryList[i] = null; }

                        while (j < countryList.Length)
                        {
                            if(j< countryList.Length - 1)
                            {
                                countryList[j] = countryList[j + 1];
                                                            
                            }else { countryList[j] = null; }
                                                        j++;
                        }
                        found = true;
                    }
                    i++;
                }

            }
            ListCountries(countryList);
        }

        public Country SearchCountry(bool normalSearch)
        {
            string[] textLines = new string[] {
                                                "Que país desea buscar?",
                                                "Introduzca el nombre del país que desea buscar"};
            Country searchedCountry = null;
            if(normalSearch) Program.WriteCharByChar(textLines);
            string countryName = Console.ReadLine();
            bool found = false;
            int i = 0;
            while(i< countryList.Length && found == false && countryList[i] != null)
            {
                if (countryList[i].name.ToLower() == countryName.ToLower())
                {
                    found = true;
                    Program.WriteCharByChar("El país esta en la lista.");
                    searchedCountry = countryList[i];
                }
                i++;
            }

            if (!found)
            {
                Program.WriteCharByChar("El país no esta en la lista");
                searchedCountry = null;
            }

            return searchedCountry;
        }


        public void OrderByPopulation()
        {
            int i = 0,
                j = 0;
            Country[] orderedByPopulationCountryList = new Country [countryList.Length];





            orderedByPopulationCountryList[i] = countryList[i];
            while( i < countryList.Length && countryList[i] != null)
            {
                orderedByPopulationCountryList[0] = countryList[0];
                if (countryList[i] != null && orderedByPopulationCountryList[i] != null)
                {
                   if (Convert.ToSingle(countryList[i].population) > Convert.ToSingle(orderedByPopulationCountryList[i].population))
                    { 
                        orderedByPopulationCountryList[i + 1] = orderedByPopulationCountryList[i];
                    }
                    orderedByPopulationCountryList[i] = countryList[i];

                }
                Console.WriteLine(i);
                i++;
                
            }
            ListCountries(orderedByPopulationCountryList);
        }

        public void AddCities()
        {
                Program.WriteCharByChar("¿A que país quiere añadir las ciudades?");

           Country countryToAddCities = SearchCountry(false);
            if(countryToAddCities != null)
            {
                int i = 0;
                countryToAddCities.hasCities = true;
                string[] phrases = new string[] {   "Recuerde que como máximo puede añadir 5 ciudades, las demás que se añadan no se tendrán en cuenta",
                                                    "¿Que ciudades desea añadir?, separelas por /" };
                Program.WriteCharByChar(phrases);

                string citiesToAddString = Console.ReadLine();

                string[] citiesToAddArray = citiesToAddString.Split('/');
                if(citiesToAddArray.Length < countryToAddCities.cities.Length)
                {
                    while (i < citiesToAddArray.Length)
                    {
                        countryToAddCities.cities[i] = citiesToAddArray[i].ToLower();
                        i++;
                    }
                }
                else
                {
                    while(i < countryToAddCities.cities.Length){
                    countryToAddCities.cities[i] = citiesToAddArray[i];
                    i++;
                    }
                }
               
                int citiesNum = 0;
                i = 0;
                while(i < countryToAddCities.cities.Length && countryToAddCities.cities[i] != null)
                {
                    if(countryToAddCities.cities[i] != null)
                    {
                        citiesNum++;
                    }
                    i++;
                }

                Program.WriteCharByChar("El país " + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryToAddCities.name)+ "tiene " +citiesNum+ " ciudades:");
                i = 0;
                while(i < citiesNum)
                {
                     Program.WriteCharByChar(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryToAddCities.cities[i]));
                     i++;
                }

            }
            SaveDataOnFile("Countries.txt", countryToAddCities);


        }

        public void SaveDataOnFile(string fileName, Country theCountry)
        {
            StreamWriter file = new StreamWriter(fileName, true);
            int i = 0,
                j = 0;
            while(i < countryList.Length && countryList[i] != null)
            {
                if (countryList[i].hasCities)
                {
                    string citiesFullString = "";
                    j = 0;
                    while(j < countryList[i].cities.Length && countryList[i].cities[j] != null)
                    {
                        if (j < countryList[i].cities[j].Length - 1)
                        {
                            citiesFullString += countryList[i].cities[j] + "*";
                        }
                        else
                        {
                            citiesFullString += countryList[i].cities[j];
                        }
                        j++;
                    }
                    file.WriteLine(theCountry.name + "/" + theCountry.capital + "/" + theCountry.population + "/" + theCountry.surface+ "/" +citiesFullString);

                }
                else
                {
                    file.WriteLine(theCountry.name + "/" + theCountry.capital + "/" + theCountry.population + "/" + theCountry.surface);

                }
                i++;
            }
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
                InsertCountry(new Country(words[0], words[1], words[2], words[3]));
                s = file.ReadLine();

            }
            file.Close();

        }
    }
}
