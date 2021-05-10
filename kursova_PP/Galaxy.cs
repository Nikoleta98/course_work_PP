using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace kursova_PP
{
    public class Galaxy
    {
        public static List<String> galaxyTypes = new List<String>();

        private string nameGalaxy;
        private String typeGalaxy;
        private float ageGalaxy;
        private char ageMagnitude;
        public List<Star> Stars { get; set; }

        static Galaxy()
        {
            galaxyTypes.Add("elliptical");
            galaxyTypes.Add("lenticular");
            galaxyTypes.Add("spiral");
            galaxyTypes.Add("irregular");
        }

        public Galaxy()
        {
            Stars = new List<Star>();
        }
        public string NameGalaxy
        {
            set { nameGalaxy = value; }
            get { return nameGalaxy; }
        }

        public String TypeGalaxy
        {
            get { return this.typeGalaxy; }
            set { if(galaxyTypes.Contains(value))this.typeGalaxy = value;
                else
                {
                    Console.WriteLine("Cannot set galaxy to " + value);
                }
            }
        }

        public float AgeGalaxy
        {
            set {
                if (value.ToString().Split('.').Length > 1)
                {
                    if (value.ToString().Split('.')[1].Length <= 2)
                        ageGalaxy = value;
                }
                else
                {
                    ageGalaxy = value;
                }
            }
            
            get { return ageGalaxy; }
        }
        public char AgeMagnitude
        {
            get { return this.ageMagnitude; }
            set { if(value=='M'||value=='B')this.ageMagnitude = value; }
        }
    }
}
