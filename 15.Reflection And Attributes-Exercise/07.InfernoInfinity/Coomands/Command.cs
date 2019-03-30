using _07.InfernoInfinity.Contracts;
using _07.InfernoInfinity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Coomands
{
    public abstract class Command
    {
        public abstract void Execute(List<Weapon> weapons, string[] args);
    }
}
