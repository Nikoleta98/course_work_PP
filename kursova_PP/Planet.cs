using System;
using System.Collections.Generic;
using System.Text;

namespace kursova_PP
{
    public class Planet
    {
        public static List<String> planetTypes = new List<String>();

        private string namePlanet;
        private string typePlanet;
        public bool isHabitable { get; set; }
        public List<Moon> Moons;

        static Planet()
        {
            planetTypes.Add("terrestrial");
            planetTypes.Add("giant planet");
            planetTypes.Add("ice giant,");
            planetTypes.Add("mesoplanet");
            planetTypes.Add(" mini-neptune");
            planetTypes.Add("planetar");
            planetTypes.Add("super-earth");
            planetTypes.Add(" super-jupiter");
            planetTypes.Add("sub-earth");
        }

        public string NamePlanet
        {
            set { this.namePlanet = value; }
            get { return namePlanet; }
        }

        public string TypePlanet
        {
            set
            {
                if (planetTypes.Contains(value)) this.typePlanet = value;
                else
                {
                    Console.WriteLine("Cannot set galaxy to " + value);
                }
            }
            get { return typePlanet; }
        }
        public Planet(string name, string type, bool ishabitable)
        {
            NamePlanet = name;
            TypePlanet = type;
            isHabitable = ishabitable;
            this.Moons = new List<Moon>();
        }
    }
}
