using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib.Services.Interfaces
{
    public interface IHistoryService
    {
        void SaveResult(string expression, string result);
        List<string> LoadHistory();
        void ClearHistory();
    }
}
