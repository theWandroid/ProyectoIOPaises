using System;
using System.Collections.Generic;
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
        public string[] cities = new string[5];

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

        public void SetCountryData(string theName, string theCapital)
        {
            name = theName;
            capital = theCapital;
        }


    }


}
