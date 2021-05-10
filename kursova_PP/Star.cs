using System;
using System.Collections.Generic;
using System.Text;

namespace kursova_PP
{
    public class Star
    {
        public static List<char> starTypes = new List<char>();

        private string nameStar;
        private float mass;
        private float size;
        private float light;
        private int temperature;
        private char classStar;
        public List<Planet> Planets;


        static Star()
        {
            starTypes.Add('O');
            starTypes.Add('B');
            starTypes.Add('A');
            starTypes.Add('F');
            starTypes.Add('G');
            starTypes.Add('K');
            starTypes.Add('M');
        }
        public string NameStar
        {
            set { this.nameStar = value; }
            get { return nameStar; }
        }

        public float Mass
        {
            set
            {
                if (value.ToString().Split('.').Length > 1)
                {
                    if (value.ToString().Split('.')[1].Length <= 2)
                        this.mass = value;
                }
                else
                {
                    this.mass = value;
                }
            }
            get { return mass; }
        }

        public float Size
        {
            set
            {
                if (value.ToString().Split('.').Length > 1)
                {
                    if (value.ToString().Split('.')[1].Length <= 2)
                        this.size = value;
                }
                else
                {
                    this.size = value;
                }
            }
            get { return size; }
        }

        public float Light
        {
            set
            {
                if (value.ToString().Split('.').Length > 1)
                {
                    if (value.ToString().Split('.')[1].Length <= 2)
                        this.light = value;
                }
                else
                {
                    this.light = value;
                }
            }
            get { return light; }
        }

        public int Temperature
        {
            set { this.temperature = value; }
            get { return temperature; }
        }

        public char ClassStar
        {
            get { return this.classStar; }
            set
            {
                if (starTypes.Contains(char.ToUpper(value))) this.classStar = char.ToUpper(value);
                else
                {
                    Console.WriteLine("Cannot set star to type " + char.ToUpper(value));
                }
            }
        }

        public Star(string name, float mass, float size, int temperature, float light)
        {
            NameStar = name;
            Mass = mass;
            Size = size;
            Temperature = temperature;
            Light = light;

            if (Temperature >= 30000 &&
                Light >= 30000 &&
                Mass >= 16 &&
                Size >= 6.6)
            {
                ClassStar = 'O';
            }
            else if (Temperature >= 10000 &&
                Light >= 25 &&
                Mass >= 2.1 &&
                Size >= 1.8)
            {
                ClassStar = 'B';
            }
            else if (Temperature >= 7500 &&
                Light >= 5 &&
                Mass >= 1.4 &&
                Size >= 1.4)
            {
                ClassStar = 'A';
            }
            else if (Temperature >= 6000 &&
                Light >= 1.5 &&
                Mass >= 1.04 &&
                Size >= 1.15)
            {
                ClassStar = 'F';
            }
            else if (Temperature >= 5200 &&
                Light >= 0.6 &&
                Mass >= 0.8 &&
                Size >= 0.96)
            {
                ClassStar = 'G';
            }
            else if (Temperature >= 3700 &&
                Light > 0.08 &&
                Mass >= 0.45 &&
                Size > 0.7)
            {
                ClassStar = 'K';
            }
            else if (Temperature >= 2400 &&
                Light <= 0.08 &&
                Mass >= 0.08 &&
                Size <= 0.7)
            {
                ClassStar = 'M';
            }
            this.Planets = new List<Planet>();
        }

    }
}
