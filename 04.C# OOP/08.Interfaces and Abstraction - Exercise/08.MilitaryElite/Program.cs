using _08.MilitaryElite.Enums;
using _08.MilitaryElite.Soldiers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Soldier> soldiers = new HashSet<Soldier>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] soldierTokens = input
                    .Split();

                string typeOfSoldier = soldierTokens[0];
                int id = int.Parse(soldierTokens[1]);
                string firstName = soldierTokens[2];
                string lastName = soldierTokens[3];
                decimal salary = decimal.Parse(soldierTokens[4]);
                try
                {
                    if (typeOfSoldier == "Private")
                    {
                        var privateSoldier = new Private(id, firstName, lastName, salary);
                        soldiers.Add(privateSoldier);
                    }
                    else if (typeOfSoldier == "LieutenantGeneral")
                    {
                        List<int> privatesIds = soldierTokens.Skip(5).Select(int.Parse).ToList();

                        var lieutenant = new LieutanantGeneral(id, firstName, lastName, salary);

                        foreach (var currentId in privatesIds)
                        {
                            Private currentPrivate = (Private)soldiers.FirstOrDefault(x => x.Id == currentId);

                            lieutenant.Privates.Add(currentPrivate);
                        }

                        soldiers.Add(lieutenant);
                    }
                    else if (typeOfSoldier == "Engineer")
                    {
                        string corps = soldierTokens[5];
                        var engineer = new Engineer(id, firstName, lastName, salary, corps);

                        List<string> repairs = soldierTokens.Skip(6).ToList();

                        for (int i = 0; i < repairs.Count; i += 2)
                        {

                            string partName = repairs[i];
                            int hours = int.Parse(repairs[i + 1]);

                            Repair repair = new Repair(partName, hours);
                            engineer.Repairs.Add(repair);


                        }

                        soldiers.Add(engineer);
                    }
                    else if (typeOfSoldier == "Commando")
                    {
                        string corps = soldierTokens[5];
                        var commando = new Commando(id, firstName, lastName, salary, corps);

                        List<string> missions = soldierTokens.Skip(6).ToList();

                        for (int i = 0; i < missions.Count; i += 2)
                        {
                            try
                            {
                                string codeName = missions[i];
                                string state = missions[i + 1];

                                Mission mission = new Mission(codeName, state);
                                commando.Missions.Add(mission);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            
                        }

                        soldiers.Add(commando);
                    }
                    else if (typeOfSoldier == "Spy")
                    {
                        int code = Convert.ToInt32(salary);
                        var spy = new Spy(id, firstName, lastName, code);
                        soldiers.Add(spy);
                    }

                    input = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    if (ex.Message == "invalid corps")
                    {
                        input = Console.ReadLine();
                    }
                }

            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
