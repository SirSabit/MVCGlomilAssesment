using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.BLL.Abstract
{
    public interface ICalculationBLL
    {
        public string Addition(double numberOne, double numberTwo);
        public string Subtraction(double numberOne, double numberTwo);
        public string Multiplication(double numberOne, double numberTwo);
        public string Division(double numberOne, double numberTwo);
    }
}
