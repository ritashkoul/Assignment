using Assignment.Exceptions;
using Assignment.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace Assignment.Extractor
{
    public class FileDataExtractor : IExtractor
    {
        public int[] Extract()
        {
            string filePath = $@"{AppContext.BaseDirectory}InputFile\Numbers.txt";
            if(!File.Exists(filePath))
            {
                throw new CustomException("Exception : Numbers.txt file not found");
            }

            string input = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(input))
            {
                string[] stringNumbers = input.Split(',').Select(x => x.Trim()).ToArray();
                if (stringNumbers.All(x => x.All(char.IsDigit)))
                {
                    int[] numbers = stringNumbers.Select(int.Parse).ToArray();
                    return numbers;
                }
                else
                {
                    var valuesOtherThanDigits = stringNumbers.Where(x => x.Any(y => !char.IsDigit(y)));
                    throw new CustomException($"Exception : {string.Join(",", valuesOtherThanDigits)} is/are not number(s)");
                }
            } 

            return Array.Empty<int>();
        }
    }
}