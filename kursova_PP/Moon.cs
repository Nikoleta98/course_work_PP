using System;
using System.Collections.Generic;
using System.Text;

namespace kursova_PP
{
    public class Moon
    {
        
        private string nameMoon;

        public string NameMoon
        {
            set { this.nameMoon = value; }
            get { return nameMoon; }
        }

        public Moon(string moonname)
        {
            this.nameMoon = moonname;
        }
    }
}
