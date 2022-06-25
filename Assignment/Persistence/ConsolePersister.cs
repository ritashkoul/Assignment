using Assignment.Interfaces;
using Serilog;
using System;

namespace Assignment.Persistence
{
    public class ConsolePersister : IPersister
    {
        private readonly ILogger _logger;

        public ConsolePersister(ILogger logger)
        {
            _logger = logger;
        }

        public void SaveData(int data)
        {
            _logger.Information($"Sum : {data}");
        }
    }
}
