using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIOPaises
{
    public class Country
    {
        public string name = "España";
        public string capital = "Madrid";
        public string population = "47.615.034";
        public string surface = "505.944";
        public bool hasCities = false;
        public string[] cities = new string[5];
        public int citiesCounter = 0;

        /// <summary>
        /// Contruye un pais
        /// </summary>
        /// <param name="name">Nombre del pais</param>
        /// <param name="capital">Capital del pais</param>
        public Country(string theName, string theCapital, string thePopulation, string theSurface)
        {
            this.name = theName;
            this.capital = theCapital;
            this.population = thePopulation;
            this.surface = theSurface;
        }

        public Country(string theName, string theCapital, string thePopulation, string theSurface, bool theBoolCities, string theCities)
        {
            this.name = theName;
            this.capital = theCapital;
            this.population = thePopulation;
            this.surface = theSurface;
            this.hasCities = theBoolCities;
            int i = 0,
            j = 0; 
            string[] citiesArray = theCities.Split('*');

            while(i < citiesArray.Length && citiesCounter < 5)
            {
                if (citiesArray[i] != "")
                {
                    cities[i] = citiesArray[i];
                    citiesCounter++;
                }
                i++;
            }
            
      
        }

        public void SetCountryData(string theName, string theCapital)
        {
            name = theName;
            capital = theCapital;
        }


    }


}
