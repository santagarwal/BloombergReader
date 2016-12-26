using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloombergReader.Core.Logging
{
    /// <summary>
    /// Singleton wrapper on log4net used for logging. 
    /// </summary>
    public class Logger
    {
        private static readonly log4net.ILog Log;

        private Logger() { }

        static Logger()
        {
            XmlConfigurator.Configure();
            Log = log4net.LogManager.GetLogger(typeof(Logger));
        }

        /// <summary>
        /// Instance of the class which can be accessed
        /// </summary>
        public static log4net.ILog Instance
        {
            get { return Log; }
        }
    }
}
