using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace kursova_PP
{
    public class Lists
    {
        private List<Galaxy> Galaxies;

        public Lists()
        {
            this.Galaxies = new List<Galaxy>();
        }

        private bool IsAgeCorrect(string age)
        {
            Regex rx = new Regex(@"\d*\.\d{1,2}[BM]");

            if (rx.IsMatch(age))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void AddGalaxy(string setGalaxyName, string setGalaxyType, string setGalaxyAge)
        {
            if (!IsAgeCorrect(setGalaxyAge) || !Galaxy.galaxyTypes.Contains(setGalaxyType)||setGalaxyName=="")
            {
                Console.WriteLine("Cannot create a galaxy, wrong data...");
                return;
            }

            Galaxy newGalaxy = new Galaxy();
            newGalaxy.NameGalaxy = setGalaxyName;
            newGalaxy.TypeGalaxy =setGalaxyType;

            newGalaxy.AgeMagnitude = setGalaxyAge[setGalaxyAge.Length - 1].ToString()[0];
            newGalaxy.AgeGalaxy = float.Parse(setGalaxyAge.Substring(0, setGalaxyAge.Length - 1));

            this.Galaxies.Add(newGalaxy); 

        }
        public void AddStar(string setGalaxyName, string setStarName, string setTemp, string setMass, string setLumin, string setSize)
        {
            float mass = float.Parse(float.Parse(setMass).ToString("0.00"));//Правим низа на float след това го правим на форматиран низ, за да дадем точност до 2 знака и след това пак парсваме на float
            float size = float.Parse(float.Parse(setSize).ToString("0.00"));
            int temp =int.Parse(setTemp);
            float light = float.Parse(float.Parse(setLumin).ToString("0.00"));
            Star newStar = new Star(setStarName, mass, size, temp, light);
            foreach (Galaxy g in Galaxies)
            {
                if (g.NameGalaxy == setGalaxyName)
                {
                    g.Stars.Add(newStar);
                }
            }
        }

        public void AddPlanet(string setStarName, string setName, string setType, string sethabbit)
        {
            bool isHabbitable = sethabbit == "yes";

            Planet newPlanet = new Planet(setName, setType, isHabbitable);

            foreach (Galaxy g in Galaxies)
            {
                foreach(Star s in g.Stars)

                if (s.NameStar == setStarName)
                {
                    s.Planets.Add(newPlanet);
                }
            }
        }

        public void AddMoon(string setPlanetName, string setName)
        {
            Moon newMoon = new Moon(setName);


            foreach (Galaxy g in Galaxies)
            {
                foreach (Star s in g.Stars)

                    foreach(Planet p in s.Planets)
                    {
                        if (p.NamePlanet == setPlanetName)
                        {
                            p.Moons.Add(newMoon);
                        }

                    }
            }
        }

        public void ListGalaxies()
        {
            Console.WriteLine("--- List of all researched galaxies ---");
            foreach (Galaxy g in Galaxies)
            {
                Console.WriteLine(g.NameGalaxy);
            }
            Console.WriteLine("--- End of galaxies list ---");
        }

        public void ListStars()
        {
            Console.WriteLine("--- List of all researched stars ---");
            foreach(Galaxy g in Galaxies)
            {
                foreach (Star s in g.Stars)
                {
                    Console.WriteLine(s.NameStar);
                }
                Console.WriteLine("--- End of stars list ---");
            }

        }

        public void ListPlanets()
        {
            Console.WriteLine("--- List of all researched planets ---");
            foreach(Galaxy g in Galaxies)
            {
                foreach(Star s in g.Stars)
                {
                    foreach (Planet p in s.Planets)
                    {
                        Console.WriteLine(p.NamePlanet);
                    }
                    Console.WriteLine("--- End of planets list ---");
                }

            }
           
        }

        public void ListMoons()
        {
            foreach (Galaxy g in Galaxies)
            {
                foreach (Star s in g.Stars)
                {
                    foreach (Planet p in s.Planets)
                    {
                        Console.WriteLine("--- List of all researched moons ---");
                        foreach (Moon m in p.Moons)
                        {
                            Console.WriteLine(m.NameMoon);
                        }
                        Console.WriteLine("--- End of moons list ---");
                    }
                }
            }
        }

        public string[] SplitTemplate(string input)
        {
            StringBuilder template = new StringBuilder();
            var a = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    a.Add(template.ToString());
                    template.Clear();
                    continue;
                }
                if (input[i] == '[')
                {
                    i++;
                    while (input[i] != ']')
                    {
                        template.Append(input[i]);
                        i++;
                    }
                    a.Add(template.ToString());
                    template.Clear();
                    i++;
                    continue;
                }
                template.Append(input[i]);
            }
            a.Add(template.ToString());

            return a.ToArray();
        }

        public void GetStats()
        {
            int numGalaxies = 0;
            int numStars = 0;
            int numPlanets = 0;
            int numMoon = 0;

            foreach (Galaxy g in Galaxies)
            {
                numGalaxies++;
                foreach (Star s in g.Stars)
                {
                    numStars++;
                    foreach (Planet p in s.Planets)
                    {
                        numPlanets++;
                        foreach (Moon m in p.Moons)
                        {
                            numMoon++;
                        }
                    }
                }
            }

            Console.WriteLine("--- Stats ---");
            Console.WriteLine($"Galaxies: {numGalaxies}");
            Console.WriteLine($"Stars: {numStars}");
            Console.WriteLine($"Planets: {numPlanets}");
            Console.WriteLine($"Moons: {numMoon}");
            Console.WriteLine("--- End of Stats ---");
        }

        public void Print(string GalaxyName)
        {
            Console.WriteLine($"--- Data for {GalaxyName} galaxy ---");
            Galaxy galaxy = Galaxies.FirstOrDefault(g => g.NameGalaxy == GalaxyName);
            Console.WriteLine($"Type:{galaxy.TypeGalaxy}");
            Console.WriteLine($"Age:{galaxy.AgeGalaxy}{galaxy.AgeMagnitude}");
            Console.WriteLine("Stars:");
            foreach (Star s in galaxy.Stars)
            {
                Console.WriteLine($"    -  Name:{s.NameStar}");
                Console.WriteLine($"       Class:{s.ClassStar} ({s.Mass},{s.Size},{s.Temperature},{s.Light:f2})");

                Console.WriteLine($"       Planets:");
                foreach (Planet p in s.Planets)
                {
                    Console.WriteLine($"         ■   Name:{p.NamePlanet}");
                    Console.WriteLine($"             Type:{p.TypePlanet}");
                    var isHabbitable = p.isHabitable ? "yes" : "no";
                    Console.WriteLine($"             Support life:{isHabbitable}");

                    Console.WriteLine($"             Moons:");
                    foreach (Moon m in p.Moons)
                    {
                        Console.WriteLine($"                    ■    {m.NameMoon}");
                    }

                }
                Console.WriteLine($"--- End of data for {GalaxyName} galaxy ---");
            }
        }
    }
}
