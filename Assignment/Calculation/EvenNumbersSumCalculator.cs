using Assignment.Interfaces;
using System.Linq;

namespace Assignment.Calculation
{
    public class EvenNumbersSumCalculator : ICalculator
    {
        public int Calculate(int[] numbers)
        {
            return numbers.Where(x => x % 2 == 0).Sum();
        }
    }
}
