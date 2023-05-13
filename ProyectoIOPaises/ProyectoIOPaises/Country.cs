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

        /// <summary>
        /// Contruye un pais
        /// </summary>
        /// <param name="name">Nombre del pais</param>
        /// <param name="capital">Capital del pais</param>
        public Country(string name, string capital)
        {
            this.name = name;
            this.capital = capital;
        }

        public void SetCountryData(string theName, string theCapital)
        {
            name = theName;
            capital = theCapital;
        }


    }


}
