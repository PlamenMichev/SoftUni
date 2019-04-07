using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private List<IAnimal> procedureHistory;

        public Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public List<IAnimal> ProcedureHistory
        {
            get => this.procedureHistory;
            private set
            {
                this.procedureHistory = value;
            }
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
            this.procedureHistory.Add(animal);
        }

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);

            foreach (var animal in this.ProcedureHistory)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
