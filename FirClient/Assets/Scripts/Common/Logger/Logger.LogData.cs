using System;
using System.Text;

namespace FirClient
{
    public partial class Logger
    {
        /// <summary>
        /// Log的具体内容
        /// </summary>
        public class LogData
        {
            /// <summary>
            /// Log具体内容
            /// </summary>
            /// <value>The log.</value>
            public string Log { get; set; }

            /// <summary>
            /// Log标记
            /// </summary>
            /// <value>The tag.</value>
            public string Tag { get; set; }

            /// <summary>
            /// Log堆栈信息
            /// </summary>
            /// <value>The track.</value>
            public string Track { get; set; }

            /// <summary>
            /// ToString
            /// </summary>
            /// <returns>A <see cref="System.String"/> that represents the current <see cref="ReignFramework.LogData"/>.</returns>
            public string ToString()
            {
                StringBuilder builder = new StringBuilder(Log);
                // 写堆栈
                if (null != Track)
                {
                    builder.Append("\n").Append(Track);
                }
                return builder.ToString();
            }
        }
    }
}

