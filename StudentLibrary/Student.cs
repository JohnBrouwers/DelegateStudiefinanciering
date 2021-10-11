using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    public class Student
    {
        public string Naam { get; set; }

        public Bankrekening Bankrekening { get; set; }

        public Student(string naam)
        {
            this.Naam = naam;
            this.Bankrekening = new Bankrekening();
        }

    }
}
