using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib.Models
{
    public class HistoryItem
    {
        public string Expression { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string FormattedEntry => $"{Expression} = {Result}";
    }
}