using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        public Doctor(string name)
        {
            this.patients = new List<Patient>();
            this.Name = name;
        }

        public Doctor()
        {

        }

        private List<Patient> patients { get; set; }

        public string Name { get; set; }

        public void AddPatient(Patient patient)
        {
            this.patients.Add(patient);
        }

        public List<string> GetPatientsNames()
        {
            var result = new List<string>();
            foreach (var patient in patients)
            {
                result.Add(patient.Name);
            }

            return result;
        }
    }
}
