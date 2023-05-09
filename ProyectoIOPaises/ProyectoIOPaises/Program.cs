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
            Country countryOne = new Country("España", "Madrid");
            //countryOne.SetCountryData("España", "Madrid");
            Country countryTwo = new Country("Portugal", "Lisboa");
            //countryTwo.SetCountryData("Portugal", "Lisboa");

            World theWorld = new World();
            /*
            theWorld.InsertCountry(countryOne);
            theWorld.InsertCountry(countryTwo);

            theWorld.ListCountries();
            theWorld.SaveDataOnFile("Countries.txt");
            */
            theWorld.ReadDataFromFile("Countries.txt");
            theWorld.ListCountries();


            Console.ReadKey();
        }
    }
}
