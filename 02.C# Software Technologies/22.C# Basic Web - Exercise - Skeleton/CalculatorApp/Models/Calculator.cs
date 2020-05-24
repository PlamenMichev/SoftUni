﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    public class Calculator
    {
        public Calculator()
        {
            this.Result = 0;
        }

        public decimal LeftOperand { get; set; }

        public decimal RightOperand { get; set; }

        public string Operator { get; set; }

        public decimal Result { get; set; }

        public void calculate(string sign)
        {
            switch (sign)
            {
                case "+":
                {
                    this.Result = this.LeftOperand + this.RightOperand;
                    break;
                }          
                case "-":
                {
                    this.Result = this.LeftOperand - this.RightOperand;
                    break;
                }
                case "*":
                {
                    this.Result = this.RightOperand * this.LeftOperand;
                    break;
                }
                case "/":
                {
                    if(this.RightOperand != 0)
                    this.Result = this.LeftOperand / this.RightOperand;
                    break;
                }
            }
        }
    }
}
