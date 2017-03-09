using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using log4net.Config;

namespace BloombergReader.Core.Logging
{
    /// <summary>
    /// Singleton wrapper on log4net used for logging. 
    /// </summary>
    public class Logger
    {
        private static readonly ILog Log;

        private Logger() { }

        static Logger()
        {
            XmlConfigurator.Configure();
            Log = LogManager.GetLogger(typeof(Logger));
        }

        /// <summary>
        /// Instance of the class which can be accessed
        /// </summary>
        public static ILog Instance
        {
            get { return Log; }
        }
    }
}
