﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Web;

namespace ProyectoIOPaises
{
    public class World
    {
        public int numCountries = 0;
        public Country[] countryList = new Country[100];
        public bool awake = true;
      
        public void InsertCountry(Country theCountry, bool newCountry)
        {
            int i = 0;
            if (awake)
            {
                countryList[numCountries] = theCountry;
                   numCountries++ ;
            }
                   
            while (i < countryList.Length && !newCountry) 
            {
                //Console.WriteLine(countryList[i].name);
                //Console.WriteLine(theCountry.name);
                if (countryList[i] != null)
                {
                    if (theCountry.name == countryList[i].name && numCountries != 0)
                    {
                        countryList[i] = theCountry;
                    }
                }

                i++;
            }

            if (newCountry)
            {
                countryList[numCountries] = theCountry;
                numCountries++;
            }

        }

        public void ListCountries(Country[] theCountryList, bool showCities)
        {
            int i = 0;
            string textLines;
            while (i < theCountryList.Length && theCountryList[i] != null)
            {
                int j = 0;

                if (theCountryList[i].hasCities && showCities)
                {
                    string citiesFullString = "";  
                    if (theCountryList[i] != null)

                    {

                            while (j < theCountryList[i].cities.Length)
                            {
                                if (theCountryList[i].cities[j] != null)
                                {

                                    if (j < countryList[i].cities[j].Length - 1 && j != 0)
                                    {
                                        citiesFullString += "\n\t" + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(theCountryList[i].cities[j]);
                                    }
                                    else
                                    {
                                        citiesFullString += "\t" + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(theCountryList[i].cities[j]);
                                    }


                                }
                                j++;
                        }
                    }
                     textLines =  "Pais => " + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(theCountryList[i].name) + "   Capital:" + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(theCountryList[i].capital) + "    Población: " + theCountryList[i].population + "    Superficie => " + theCountryList[i].surface+"\n Ciudades:\n " +citiesFullString ;
                }
                else
                {

                    textLines = "Pais => " + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(theCountryList[i].name) + "   Capital:" + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(theCountryList[i].capital) + "    Población: " + theCountryList[i].population + "    Superficie => " + theCountryList[i].surface ;
                    //Console.WriteLine(numCountries);

                }
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
                Program.WriteCharByChar(textLines[1]);
                string countryCapital = Console.ReadLine();
                Program.WriteCharByChar(textLines[2]);
                string countryPopulation = Console.ReadLine();
                Program.WriteCharByChar(textLines[3]);
                string countrySurface = Console.ReadLine();
                InsertCountry(new Country(countryName, countryCapital, countryPopulation, countrySurface), true);
                SaveDataOnFile("Countries.txt");

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
                        j = i;
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
            SaveDataOnFile("Countries.txt");

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
                    Program.WriteCharByChar("Pais => " + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryList[i].name) + "   Capital:" + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryList[i].capital) + "    Población: " + countryList[i].population + "    Superficie => " + countryList[i].surface);

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
                j = 0,
                k = 0,
                counter = 0;
            bool found = false;
            Country[] orderedByPopulationCountryList = new Country [countryList.Length];
            Country[] helpingList = new Country[countryList.Length];

            while (i < countryList.Length)
            {
                helpingList[i] = countryList[i];
                if (countryList[i] != null)
                {
                    counter++;
                }
                i++;
            }

            i = 0;

            Country greater = helpingList[i];

            Console.WriteLine("El contador de paises es " + counter);
            while(k < counter)
            {
                i = 0;
                while(i < helpingList.Length)
                {
                    if (helpingList[i] != null)
                    {
                        greater = helpingList[i];
                    }
                    i++;
                }
                i = 0;
                while (i < helpingList.Length)
                {
                    if (helpingList[i] != null)
                    {
                        if (Convert.ToSingle(helpingList[i].population) > Convert.ToSingle(greater.population))
                        {
                            greater = helpingList[i];

                        }

                    }
                    i++;
                }
                i = 0;
                while( i < helpingList.Length)
                {
                    if (helpingList[i] != null)
                    {
                        if (helpingList[i] == greater)
                        {
                            helpingList[i] = null;
                        }
                    }
                    i++;
                }
                orderedByPopulationCountryList[j] = greater;

                j++;
                k++;

            }
           ListCountries(orderedByPopulationCountryList, false);
        }

        public void AddCities()
        {
                Program.WriteCharByChar("¿A que país quiere añadir las ciudades?");
            string citiesToAddString = "";
           Country countryToAddCities = SearchCountry(false);
            if(countryToAddCities != null)
            {
                int i = 0;
                countryToAddCities.hasCities = true;
                string[] phrases = new string[] {   "Recuerde que como máximo puede añadir 5 ciudades, las demás que se añadan no se tendrán en cuenta",
                                                    "¿Que ciudades desea añadir?, separelas por /" };
                Program.WriteCharByChar(phrases);

                citiesToAddString = Console.ReadLine().Trim();

                string[] citiesToAddArray = citiesToAddString.Split('/');
                bool isAlreadyInTheList = false;
                int k = 0,
                    j = 0,
                    pos = 0;
                
                if(countryToAddCities.citiesCounter < 5)
                {
                    if (countryToAddCities.hasCities)
                    {
                        while (j < citiesToAddArray.Length)
                        {
                            k = 0;
                            while (k < countryToAddCities.cities.Length && countryToAddCities.cities[k] != "")
                            {
                                if (citiesToAddArray[j].Trim() == countryToAddCities.cities[k])
                                {
                                Console.WriteLine("Ya esta en la lista");
                                break;
                                }
                                k++;
                            }
                            j++;
                        }
                    }
                    
                    while (i < citiesToAddArray.Length)
                    {
                        if(countryToAddCities.citiesCounter < 5)
                        {
                            countryToAddCities.cities[countryToAddCities.citiesCounter] = citiesToAddArray[i].ToLower().Trim();
                        countryToAddCities.citiesCounter++;
                        }
                        i++;
                    }
                }
                else
                {
                    Program.WriteCharByChar("Un país puede tener 5 ciudades como máximo");
                }
               
             
                Program.WriteCharByChar("El país " + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryToAddCities.name)+ " tiene " +countryToAddCities.citiesCounter+ " ciudades:");
                i = 0;
                while(i < countryToAddCities.citiesCounter)
                {
                     Program.WriteCharByChar(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryToAddCities.cities[i]));
                     i++;
                }
                
            }

            //InsertCountry(new Country(countryToAddCities.name, countryToAddCities.capital, countryToAddCities.population, countryToAddCities.surface, true, citiesToAddString));
            SaveDataOnFile("Countries.txt");


        }

        public void EraseCities()
        {
            Program.WriteCharByChar("¿A que país quiere eliminar las ciudades?");
            string citiesToEraseString = "";
            Country countryToEraseCities = SearchCountry(false);
            if (countryToEraseCities != null)
            {
                int i = 0;
                countryToEraseCities.hasCities = true;
                Program.WriteCharByChar("¿Que ciudades desea borrar?, separelas por /");

                citiesToEraseString = Console.ReadLine().Trim();

                string[] citiesToEraseArray = citiesToEraseString.Split('/');
                bool isAlreadyInTheList = false;
                int k = 0,
                    j = 0,
                    pos = 0;

                if (countryToEraseCities.citiesCounter < 5)
                {
                    if (countryToEraseCities.hasCities)
                    {
                        while (j < citiesToEraseArray.Length)
                        {
                            k = 0;
                            while (k < countryToEraseCities.cities.Length && countryToEraseCities.cities[k] != "")
                            {
                                if (citiesToEraseArray[j] == countryToEraseCities.cities[k])
                                {
                                    Console.WriteLine("Esta en la lista");
                                    break;
                                }
                                k++;
                            }
                            j++;
                        }
                    }


                    i = 0;
                    j = 0;
                    while (i < citiesToEraseArray.Length)
                    {
                        if (countryToEraseCities.citiesCounter < 5)
                        {
                            countryToEraseCities.cities[countryToEraseCities.citiesCounter] = citiesToEraseArray[i].ToLower();
                            countryToEraseCities.citiesCounter++;
                        }
                        i++;
                    }
                }
                else
                {
                    Program.WriteCharByChar("Un país puede tener 5 ciudades como máximo");
                }


                Program.WriteCharByChar("El país " + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryToEraseCities.name) + " tiene " + countryToEraseCities.citiesCounter + " ciudades:");
                i = 0;
                while (i < countryToEraseCities.citiesCounter)
                {
                    Program.WriteCharByChar(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryToEraseCities.cities[i]));
                    i++;
                }

            }

            //InsertCountry(new Country(countryToAddCities.name, countryToAddCities.capital, countryToAddCities.population, countryToAddCities.surface, true, citiesToAddString));
            SaveDataOnFile("Countries.txt");
        }

        public void SearchCity()
        {
            int i = 0;
            Program.WriteCharByChar("Que ciudad quieres busar?");
            string searchedCity = Console.ReadLine().Trim();
            bool found = false;

            while(i < countryList.Length && countryList[i] != null)
            {
               
                if(countryList[i] != null)
                {
                    if (countryList[i].hasCities)
                    {
                        int j = 0;
                        while (j < countryList[i].citiesCounter)
                        {
                            if (countryList[i].cities[j] != null)
                            {
                                if (countryList[i].cities[j] == searchedCity)
                                {
                                    found = true;
                                    Program.WriteCharByChar("La ciudad " + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(countryList[i].name) + " tiene la ciudad " + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(searchedCity));
                                }
                               
                            }
                            j++;
                        }
                        
                    }
                }
              
                i++;
            }

            if (!found)
            {
                Program.WriteCharByChar("No hay ninguna ciudad con ese nombre");
            }
        }

        public void SaveDataOnFile(string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
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
                        if (j < countryList[i].cities[j].Length - 1 && j != 0)
                        {
                            citiesFullString +="*" +countryList[i].cities[j];
                        }
                        else
                        {
                            citiesFullString += countryList[i].cities[j];
                        }
                        j++;
                    }
                    file.WriteLine(countryList[i].name + "/" + countryList[i].capital + "/" + countryList[i].population + "/" + countryList[i].surface + "/" +citiesFullString);

                }
                else
                {
                    file.WriteLine(countryList[i].name + "/" + countryList[i].capital + "/" + countryList[i].population + "/" + countryList[i].surface+ "/");

                }
                i++;
            }
            file.Close();
        }



        public void ReadDataFromFile(string fileName)
        {
            StreamReader file = new StreamReader(fileName, Encoding.UTF8);
            string s = file.ReadLine();

            while (s != null)
            {
                Console.WriteLine(s);
                string[] words = s.Split('/');
                bool countryHasCities = false;
                int i = 0;
                while (i < words.Length)
                {
                         if (words[4] != "")
                        {
                            countryHasCities = true;
                        }
                       
                    i++;
                }

                if (countryHasCities)
                {
                    InsertCountry(new Country(words[0], words[1], words[2], words[3], true, words[4]), false);

                }
                else
                {
                    InsertCountry(new Country(words[0], words[1], words[2], words[3]), false);

                }



                s = file.ReadLine();

            }
            file.Close();

        }
    }
}
