using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib.Services.Interfaces
{
    public interface ICalculationService
    {
        string Calculate(string expression);
    }
}
