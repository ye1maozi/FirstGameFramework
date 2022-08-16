using System;

namespace FirClient
{
    public partial class Logger {
        /// <summary>
        /// 日志Appender
        /// </summary>
        public interface ILogAppender
        {
            /// <summary>
            /// 记录日志
            /// </summary>
            /// <param name="log">Log.</param>
            void Log(LogData logData);
        }
    }
	
}

