using System;
using static FirClient.Logger;
namespace FirClient
{
    /// <summary>
    /// Log日志类
    /// </summary>
    public static class Log
    {
        // Logger
        private static Logger s_Logger = null;

        /// <summary>
        /// 设置日志级别
        /// </summary>
        /// <value>The log level.</value>
        public static int LogLevel
        {
            get;
            set;
        } = LogConfig.DEFAULT_LOG_LEVEL;

        /// <summary>
        /// 设置具体Logger
        /// </summary>
        /// <param name="logger">具体Log记录者.</param>
        public static void SetLogger(Logger logger)
        {
            Log.s_Logger = logger;
        }

        /// <summary>
        /// 记录debug日志
        /// </summary>
        /// <param name="log">Log.</param>
        public static void Debug(string log)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.DEBUG)
            {
                return;
            }

            s_Logger.Debug(log);
        }

        /// <summary>
        /// 记录debug日志
        /// </summary>
        /// <param name="log">Log.</param>
        public static void Debug(object log)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.DEBUG)
            {
                return;
            }

            s_Logger.Debug(log);
        }

        /// <summary>
        /// 记录debug日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        public static void DebugFormat(string fmt, object arg0)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.DEBUG)
            {
                return;
            }

            s_Logger.Debug(TextUtil.Format(fmt, arg0));
        }

        /// <summary>
        /// 记录debug日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        /// <param name="arg1">具体参数 1.</param>
        public static void DebugFormat(string fmt, object arg0, object arg1)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.DEBUG)
            {
                return;
            }

            s_Logger.Debug(TextUtil.Format(fmt, arg0, arg1));
        }

        /// <summary>
        /// 记录debug日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        /// <param name="arg1">具体参数 1.</param>
        /// <param name="arg2">具体参数 2.</param>
        public static void DebugFormat(string fmt, object arg0, object arg1, object arg2)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.DEBUG)
            {
                return;
            }

            s_Logger.Debug(TextUtil.Format(fmt, arg0, arg1, arg2));
        }

        /// <summary>
        /// 记录debug日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="args">具体参数.</param>
        public static void DebugFormat(string fmt, params object[] args)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.DEBUG)
            {
                return;
            }

            s_Logger.Debug(TextUtil.Format(fmt, args));
        }

        /// <summary>
        /// 记录info日志
        /// </summary>
        /// <param name="log">Log.</param>
        public static void Info(object log)
        {
            if (LogLevel > LogConfig.INFO)
            {
                return;
            }

            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Info(log);
        }

        /// <summary>
        /// 记录info日志
        /// </summary>
        /// <param name="log">Log.</param>
        public static void Info(string log)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.INFO)
            {
                return;
            }

            s_Logger.Info(log);
        }

        /// <summary>
        /// 记录info日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        public static void InfoFormat(string fmt, object arg0)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.INFO)
            {
                return;
            }

            s_Logger.Info(TextUtil.Format(fmt, arg0));
        }

        /// <summary>
        /// 记录info日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        /// <param name="arg1">具体参数 1.</param>
        public static void InfoFormat(string fmt, object arg0, object arg1)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.INFO)
            {
                return;
            }

            s_Logger.Info(TextUtil.Format(fmt, arg0, arg1));
        }

        /// <summary>
        /// 记录info日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        /// <param name="arg1">具体参数 1.</param>
        /// <param name="arg2">具体参数 2.</param>
        public static void InfoFormat(string fmt, object arg0, object arg1, object arg2)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.INFO)
            {
                return;
            }

            s_Logger.Info(TextUtil.Format(fmt, arg0, arg1, arg2));
        }

        /// <summary>
        /// 记录info日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="args">具体参数.</param>
        public static void InfoFormat(string fmt, params object[] args)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.INFO)
            {
                return;
            }

            s_Logger.Info(TextUtil.Format(fmt, args));
        }

        /// <summary>
        /// 记录warn日志
        /// </summary>
        /// <param name="log">Log.</param>
        public static void Warn(object log)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(log);
        }

        /// <summary>
        /// 记录warn日志
        /// </summary>
        /// <param name="log">Log.</param>
        public static void Warn(string log)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(log);
        }

        /// <summary>
        /// 记录warn日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        public static void WarnFormat(string fmt, string arg0)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(TextUtil.Format(fmt, arg0));
        }

        /// <summary>
        /// 记录warn日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        /// <param name="arg1">具体参数 1.</param>
        public static void WarnFormat(string fmt, string arg0, string arg1)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(TextUtil.Format(fmt, arg0, arg1));
        }

        /// <summary>
        /// 记录warn日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        /// <param name="arg1">具体参数 1.</param>
        /// <param name="arg2">具体参数 2.</param>
        public static void WarnFormat(string fmt, string arg0, string arg1, string arg2)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(TextUtil.Format(fmt, arg0, arg1, arg2));
        }

        /// <summary>
        /// 记录warn日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="args">具体参数.</param>
        public static void WarnFormat(string fmt, params object[] args)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(TextUtil.Format(fmt, args));
        }

        /// <summary>
        /// 记录带异常的warn日志
        /// </summary>
        /// <param name="log">指定消息.</param>
        /// <param name="e">发生的异常.</param>
        public static void Warn(object log, Exception e)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(log, e);
        }

        /// <summary>
        /// 记录带异常的warn日志
        /// </summary>
        /// <param name="log">指定消息.</param>
        /// <param name="e">发生的异常.</param>
        public static void Warn(string log, Exception e)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(log, e);
        }

        /// <summary>
        /// 记录带异常的warn日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="arg0">具体消息参数 0.</param>
        public static void WarnFormat(string fmt, Exception e, object arg0)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(TextUtil.Format(fmt, arg0), e);
        }

        /// <summary>
        /// 记录带异常的warn日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="arg0">具体消息参数 0.</param>
        /// <param name="arg1">具体消息参数 1.</param>
        public static void WarnFormat(string fmt, Exception e, object arg0, object arg1)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(TextUtil.Format(fmt, arg0, arg1), e);
        }

        /// <summary>
        /// 记录带异常的warn日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="arg0">具体消息参数 0.</param>
        /// <param name="arg1">具体消息参数 1.</param>
        /// <param name="arg2">具体消息参数 2.</param>
        public static void WarnFormat(string fmt, Exception e, object arg0, object arg1, object arg2)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(TextUtil.Format(fmt, arg0, arg1, arg2), e);
        }

        /// <summary>
        /// 记录带异常的warn日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="args">具体消息参数.</param>
        public static void WarnFormat(string fmt, Exception e, params object[] args)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.WARNING)
            {
                return;
            }

            s_Logger.Warn(TextUtil.Format(fmt, args), e);
        }

        /// <summary>
        /// 记录error日志
        /// </summary>
        /// <param name="log">Log.</param>
        public static void Error(object log)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(log);
        }

        /// <summary>
        /// 记录error日志
        /// </summary>
        /// <param name="log">Log.</param>
        public static void Error(string log)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(log);
        }

        /// <summary>
        /// 记录error日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        public static void ErrorFormat(string fmt, object arg0)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(TextUtil.Format(fmt, arg0));
        }

        /// <summary>
        /// 记录error日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        /// <param name="arg1">具体参数 1.</param>
        public static void ErrorFormat(string fmt, object arg0, object arg1)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(TextUtil.Format(fmt, arg0, arg1));
        }

        /// <summary>
        /// 记录error日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        /// <param name="arg1">具体参数 1.</param>
        /// <param name="arg2">具体参数 2.</param>
        public static void ErrorFormat(string fmt, object arg0, object arg1, object arg2)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(TextUtil.Format(fmt, arg0, arg1, arg2));
        }

        /// <summary>
        /// 记录error日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="args">具体参数.</param>
        public static void ErrorFormat(string fmt, params object[] args)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(TextUtil.Format(fmt, args));

        }

        /// <summary>
        /// 记录带异常的error日志
        /// </summary>
        /// <param name="log">指定消息.</param>
        /// <param name="e">发生的异常.</param>
        public static void Error(object log, Exception e)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(log, e);
        }

        /// <summary>
        /// 记录带异常的error日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="arg0">具体消息参数 0.</param>
        public static void ErrorFormat(string fmt, Exception e, object arg0)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(TextUtil.Format(fmt, arg0), e);
        }

        /// <summary>
        /// 记录带异常的error日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="arg0">具体消息参数 0.</param>
        /// <param name="arg1">具体消息参数 1.</param>
        public static void ErrorFormat(string fmt, Exception e, object arg0, object arg1)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(TextUtil.Format(fmt, arg0, arg1), e);
        }

        /// <summary>
        /// 记录带异常的error日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="arg0">具体消息参数 0.</param>
        /// <param name="arg1">具体消息参数 1.</param>
        /// <param name="arg2">具体消息参数 2.</param>
        public static void ErrorFormat(string fmt, Exception e, object arg0, object arg1, object arg2)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(TextUtil.Format(fmt, arg0, arg1, arg2), e);
        }

        /// <summary>
        /// 记录带异常的error日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="args">具体消息参数.</param>
        public static void ErrorFormat(string fmt, Exception e, params object[] args)
        {
            if (null == s_Logger)
            {
                return;
            }

            if (LogLevel > LogConfig.ERROR)
            {
                return;
            }

            s_Logger.Error(TextUtil.Format(fmt, args), e);
        }

        /// <summary>
        /// 记录fatal日志
        /// </summary>
        /// <param name="log">Log.</param>
        public static void Fatal(object log)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(log);
        }

        /// <summary>
        /// 记录fatal日志
        /// </summary>
        /// <param name="log">Log.</param>
        public static void Fatal(string log)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(log);
        }

        /// <summary>
        /// 记录fatal日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        public static void FatalFormat(string fmt, object arg0)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(TextUtil.Format(fmt, arg0));
        }

        /// <summary>
        /// 记录fatal日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        /// <param name="arg1">具体参数 1.</param>
        public static void FatalFormat(string fmt, object arg0, object arg1)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(TextUtil.Format(fmt, arg0, arg1));
        }

        /// <summary>
        /// 记录fatal日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="arg0">具体参数 0.</param>
        /// <param name="arg1">具体参数 1.</param>
        /// <param name="arg2">具体参数 2.</param>
        public static void FatalFormat(string fmt, object arg0, object arg1, object arg2)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(TextUtil.Format(fmt, arg0, arg1, arg2));
        }

        /// <summary>
        /// 记录fatal日志，带格式化信息
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="args">具体参数.</param>
        public static void FatalFormat(string fmt, params object[] args)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(TextUtil.Format(fmt, args));
        }

        /// <summary>
        /// 记录带异常的fatal日志
        /// </summary>
        /// <param name="log">指定消息.</param>
        /// <param name="e">发生的异常.</param>
        public static void Fatal(object log, Exception e)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(log, e);
        }

        /// <summary>
        /// 记录带异常的fatal日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="arg0">具体消息参数 0.</param>
        public static void FatalFormat(string fmt, Exception e, object arg0)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(TextUtil.Format(fmt, arg0), e);
        }

        /// <summary>
        /// 记录带异常的fatal日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="arg0">具体消息参数 0.</param>
        /// <param name="arg1">具体消息参数 1.</param>
        public static void FatalFormat(string fmt, Exception e, object arg0, object arg1)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(TextUtil.Format(fmt, arg0, arg1), e);
        }

        /// <summary>
        /// 记录带异常的fatal日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="arg0">具体消息参数 0.</param>
        /// <param name="arg1">具体消息参数 1.</param>
        /// <param name="arg2">具体消息参数 2.</param>
        public static void FatalFormat(string fmt, Exception e, object arg0, object arg1, object arg2)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(TextUtil.Format(fmt, arg0, arg1, arg2), e);
        }

        /// <summary>
        /// 记录带异常的fatal日志，消息部分支持格式化
        /// </summary>
        /// <param name="fmt">格式化字符串.</param>
        /// <param name="e">发生的异常.</param>
        /// <param name="args">具体消息参数.</param>
        public static void FatalFormat(string fmt, Exception e, params object[] args)
        {
            if (null == s_Logger)
            {
                return;
            }

            s_Logger.Fatal(TextUtil.Format(fmt, args), e);
        }

        /// <summary>
		/// 设置错误日志回调函数
		/// </summary>
		/// <param name="errorLogInterceptor">Error log interceptor.</param>
        public static void SetErrorLogCallFunc(Action<string> errorLogInterceptor)
		{
            if (null == s_Logger)
            {
                return;
            }
			s_Logger.SetErrorLogCallFunc(errorLogInterceptor);
		}

        /// <summary>
        /// 设置是否打印日志到控制台
        /// </summary>
        public static void SetLogConsole(bool logConsole)
        {
            if (null == s_Logger)
            {
                return;
            }
			s_Logger.LogConsole = logConsole;
        }

        public static void White(object message)
        {
            Info("<color=white>" + message + "</color>");
        }

        public static void Gray(object message)
        {
            Info("<color=gray>" + message + "</color>");
        }

        public static void Green(object message)
        {
            Info("<color=green>" + message + "</color>");
        }

        public static void Purple(object message)
        {
            Info("<color=#9400D3>" + message + "</color>");
        }

        public static void Yellow(object message)
        {
            Info("<color=yellow>" + message + "</color>");
        }

        public static void Red(object message)
        {
            Info("<color=red>" + message + "</color>");
        }

        public static void Blue(object message)
        {
            Info("<color=blue>" + message + "</color>");
        }

        public static void Magenta(object message)
        {
            Info("<color=magenta>" + message + "</color>");
        }

        public static void Cyan(object message)
        {
            Info("<color=cyan>" + message + "</color>");
        }

    }
}
