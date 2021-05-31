using Glomil.BLL.Abstract;
using System;

namespace Glomil.BLL.Concrete
{
    public class CalculationsBLL : ICalculationBLL
    {
        public string Addition(double numberOne, double numberTwo)
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
