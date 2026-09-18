using System;
using System.Collections.Generic;
using System.IO;
using CalculatorLib.Services.Interfaces;

namespace CalculatorLib.Services
{
    public class FileHistoryService : IHistoryService
    {
        private static readonly string _filePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Calculator_history.log"
        );

        public void SaveResult(string expression, string result)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentNullException(nameof(expression), "Выражение не может быть пустым.");
            }
            if (string.IsNullOrWhiteSpace(result))
            {
                throw new ArgumentNullException(nameof(result), "Результат не может быть пустым.");
            }

            File.AppendAllText(_filePath, $"{expression} = {result}{Environment.NewLine}");
        }

        public List<string> LoadHistory()
        {
            if (!File.Exists(_filePath)) return new List<string>();
            return new List<string>(File.ReadAllLines(_filePath));
        }

        public void ClearHistory()
        {
            if (File.Exists(_filePath)) File.Delete(_filePath);
        }
    }
}