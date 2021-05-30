using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.BLL.Concrete
{
   public class CalculationsBLL
    {
        public string Addition(double numberOne,double numberTwo)
        {
            double result = numberOne + numberTwo;
            return Convert.ToString(result);
        }
        public string Subtraction(double numberOne, double numberTwo)
        {
            double result = numberOne - numberTwo;
            return Convert.ToString(result);
        }
        public string Multiplication(double numberOne, double numberTwo)
        {
            double result = numberOne * numberTwo;
            return Convert.ToString(result);
        }
        public string Division(double numberOne, double numberTwo)
        {
            if (numberTwo != 0) 
            {
            double result = numberOne / numberTwo;
                return Convert.ToString(result);
            }
            else
            {
               return "Hata";
            }
        }
    }
}
