using log4net;
using System;

namespace AutomationPracticeTests.Utilities.Logger
{
    public class Logger
    {
        private ILog Log { get; set; }

        internal Logger(Type type)
        {
            Log = LogManager.GetLogger(type);
        }

        public void Info(string message)
        {
            Log.Info(message);
        }

        public void Debug(string message)
        {
            Log.Info(message);
        }

        public void Error(string message)
        {
            Log.Info(message);
        }
    }
}
