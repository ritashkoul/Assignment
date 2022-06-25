using Assignment.Interfaces;
using System.Linq;

namespace Assignment.Calculation
{
    public class SumCalculator : ICalculator
    {
        public int Calculate(int[] numbers)
        {
            return numbers.Sum();
        }
    }
}
