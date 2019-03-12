using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Patient
    {
        public Patient(string name, Doctor doctor)
        {
            this.Name = name;
            this.Doctor = doctor;
        }

        public Patient()
        {

        }

        public string Name { get; private set; }

        public Doctor Doctor { get; private set; }

        public int Room { get; set; }
    }
}
