using System;
using System.Text;

namespace FirClient
{
    public partial class Logger
    {
        /// <summary>
        /// Log的具体内容
        /// </summary>
        public class LogConfig
        {
            /// <summary>
            /// 日志等级，为不同输出配置用
            /// </summary>
            public const int DEBUG = 0;
            public const int INFO = 1;
            public const int WARNING = 2;
            public const int ERROR = 3;
            public const int FATAL = 4;

            // 默认日志级别
            public const int DEFAULT_LOG_LEVEL = INFO;
            // 是否输出日志到Unity控制台
            public static bool LogConsole = true;
            // 是否启用Wintail模式
            public const bool USE_WINTAIL = false;



        }
    }
}

