using Assignment.Exceptions;
using Assignment.Interfaces;
using Serilog;
using System;
using System.Linq;

namespace Assignment
{
    public class Executor
    {
        private readonly IExtractor _extractor;
        private readonly ICalculator _calculator;
        private readonly IPersister _persister;
        private readonly ILogger _logger;

        public Executor(IExtractor extractor,
                        ICalculator calculator,
                        IPersister persister,
                        ILogger logger)
        {
            _extractor = extractor;
            _calculator = calculator;
            _persister = persister;
            _logger = logger;
        }

        public void Execute()
        {
            try
            {
                int[] data = _extractor.Extract();
                if (data.Any())
                {
                    int sum = _calculator.Calculate(data);
                    _persister.SaveData(sum);
                }
            }
            catch (CustomException ce)
            {
                _logger.Error($"{ce.Message}");
            }
            catch (Exception e)
            {
                _logger.Error($"Exception : {e.Message}");
            }
        }
    }
}
