using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.Logging;
using NUnit.Framework;

namespace GwApiNETTest.Logging
{

    public class GwLogManagerTest
    {
        [Test]
        public void TestLogger()
        {
            
            foreach (var loggerName in Constants.LoggerNames)
            {

                GwLogManager.TestLogger(loggerName, "All Enabled");
                GwLogManager.SetLogLevel(loggerName, false);
                GwLogManager.TestLogger(loggerName, "All Disabled");

                GwLogManager.LogLevel level = GwLogManager.LogLevel.Debug;
                GwLogManager.SetLogLevel(loggerName, true, level);
                GwLogManager.TestLogger(loggerName, string.Format("{0} Enabled", level));
                GwLogManager.SetLogLevel(loggerName, false, level);
                level = GwLogManager.LogLevel.Error;
                GwLogManager.SetLogLevel(loggerName, true, level);
                GwLogManager.TestLogger(loggerName, string.Format("{0} Enabled", level));
                GwLogManager.SetLogLevel(loggerName, false, level);
                level = GwLogManager.LogLevel.Fatal;
                GwLogManager.SetLogLevel(loggerName, true, level);
                GwLogManager.TestLogger(loggerName, string.Format("{0} Enabled", level));
                GwLogManager.SetLogLevel(loggerName, false, level);
                level = GwLogManager.LogLevel.Info;
                GwLogManager.SetLogLevel(loggerName, true, level);
                GwLogManager.TestLogger(loggerName, string.Format("{0} Enabled", level));
                GwLogManager.SetLogLevel(loggerName, false, level);
                level = GwLogManager.LogLevel.Warn;
                GwLogManager.SetLogLevel(loggerName, true, level);
                GwLogManager.TestLogger(loggerName, string.Format("{0} Enabled", level));
                GwLogManager.SetLogLevel(loggerName, false, level);
            }
        }
    }
}
