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
        public Int64 population = 47615034;
        public int surface = 505944;

        /// <summary>
        /// Contruye un pais
        /// </summary>
        /// <param name="name">Nombre del pais</param>
        /// <param name="capital">Capital del pais</param>
        public Country(string theName, string theCapital, Int64 thePopulation, int theSurface)
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
