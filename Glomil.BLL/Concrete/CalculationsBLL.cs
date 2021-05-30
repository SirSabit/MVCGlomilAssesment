using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.BLL.Concrete
{
   public class CalculationsBLL
    {
        public double Addition(double numberOne,double numberTwo)
        {
            double result = numberOne + numberTwo;
            return result;
        }
        public double Subtraction(double numberOne, double numberTwo)
        {
            double result = numberOne - numberTwo;
            return result;
        }
        public double Multiplication(double numberOne, double numberTwo)
        {
            double result = numberOne * numberTwo;
            return result;
        }
        public double Division(double numberOne, double numberTwo)
        {
            if (numberTwo != 0) 
            {
            double result = numberOne / numberTwo;
            return result;
            }
            else
            {
                try
                {
                    double result = numberOne / numberTwo;
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
