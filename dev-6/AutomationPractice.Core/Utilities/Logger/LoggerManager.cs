using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace AutomationPracticeTests.Utilities.Logger
{
    public static class LoggerManager
    {
        static LoggerManager()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var logRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            XmlConfigurator.Configure(logRepository, log4netConfig["log4net"]);
        }

        public static Logger GetLogger(Type type)
        {
            return new Logger(type);
        }
    }
}
