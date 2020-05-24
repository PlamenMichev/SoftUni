using _03.WildFarm.Models.Animal_Hierarchy;
using _03.WildFarm.Models.Animal_Hierarchy.Birds;
using _03.WildFarm.Models.Animal_Hierarchy.Mammals;
using _03.WildFarm.Models.Animal_Hierarchy.Mammals.Felines;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal Create(string[] animalArgs)
        {
            string type = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            switch (type)
            {
                case nameof(Owl):
                    {
                        double wingSize = double.Parse(animalArgs[3]);
                        return new Owl(name, weight, wingSize);
                    }
                case nameof(Hen):
                    {
                        double wingSize = double.Parse(animalArgs[3]);
                        return new Hen(name, weight, wingSize);
                    }
                case nameof(Mouse):
                    {
                        string livingRegion = animalArgs[3];
                        return new Mouse(name, weight, livingRegion);
                    }
                case nameof(Dog):
                    {
                        string livingRegion = animalArgs[3];
                        return new Dog(name, weight, livingRegion);
                    }
                case nameof(Cat):
                    {
                        string livingRegion = animalArgs[3];
                        string breed = animalArgs[4];
                        return new Cat(name, weight, livingRegion, breed);
                    }

                case nameof(Tiger):
                    {
                        string livingRegion = animalArgs[3];
                        string breed = animalArgs[4];
                        return new Tiger(name, weight, livingRegion, breed);
                    }

                default:
                    return null;
            }
        }
    }
}
