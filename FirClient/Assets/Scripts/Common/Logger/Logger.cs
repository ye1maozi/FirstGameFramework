using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace FirClient
{
    /// <summary>
    /// 日志类
    /// </summary>
    public partial class Logger
    {
        // Log instance
        private static Logger instance;
        // logAppender
        private static ILogAppender logAppender;

        // 错误日志回调函数
        protected Action<string> errorLogCallFunc;


        /// <summary>
        /// 获取实例
        /// </summary>
        /// <value>The instance.</value>
        public static Logger Instance {
            get {
                if (null == instance) {
                    instance = new Logger ();
                }
                return instance;
            }
        }

		/// <summary>
		/// 日志是否打印到控制台
		/// </summary>
		/// <value><c>true</c> if log console; otherwise, <c>false</c>.</value>
		public bool LogConsole {
			get;
			set;
		}

        /// <summary>
        /// 构造函数
        /// </summary>
        private Logger()
        {
            LogConsole = LogConfig.LogConsole;


            // 由于WINTAIL不支持UTF-8，所以需要指定编码
            // 目前的规则是windows模拟器用unicode，editor用ascii,其他都是utf-8
            if (LogConfig.USE_WINTAIL == true)
            {
#if UNITY_EDITOR
                logAppender = new RollingFileAppender(Encoding.Default, true);
#elif UNITY_STANDALONE_WIN
                logAppender = new RollingFileAppender(Encoding.Unicode,true);
#else
                logAppender = new RollingFileAppender(Encoding.UTF8, false);
#endif
            }
            else
            {
                logAppender = new RollingFileAppender(Encoding.UTF8, false);
            }

            // 注册系统异常捕获器
            UnityEngine.Application.logMessageReceived += UnityLogCallback;
        }

        /// <summary>
        /// 捕获全局异常
        /// </summary>
        /// <param name="condition">Condition.</param>
        /// <param name="stackTrack">Stack track.</param>
        /// <param name="logType">Log type.</param>
        private void UnityLogCallback (string condition, string stackTrack, UnityEngine.LogType logType)
        {
            if (logType == UnityEngine.LogType.Exception || logType == UnityEngine.LogType.Assert) {
                LogData data = GetLogData ("ERROR", TextUtil.Format("uncatch error, msg:{0}, type:{1}", condition, logType.ToString()), stackTrack);
                logAppender.Log (data);

                if (LogConsole) {
                    UnityEngine.Debug.Log (data.ToString ());
                }

                callErrorLogInterceptor(data);
            }
        }

		/// <summary>
		/// 设置错误日志回调函数
		/// </summary>
		/// <param name="errorLogInterceptor">Error log interceptor.</param>
        public void SetErrorLogCallFunc(Action<string> errorLogInterceptor)
		{
			this.errorLogCallFunc = errorLogInterceptor;
		}

        /// <summary>
        /// debug Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Debug (object log)
        {
            LogData data = GetLogData ("DEBUG", log);
            logAppender.Log (data);
        }

        /// <summary>
        /// debug Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Debug(string log)
        {
            LogData data = GetLogData("DEBUG", log);
            logAppender.Log(data);
        }

        /// <summary>
        /// info Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Info (object log)
        {
            LogData data = GetLogData ("INFO", log);
            logAppender.Log (data);

            if (LogConsole) {
                UnityEngine.Debug.Log (data.ToString ());
            }
        }

        /// <summary>
        /// info Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Info(string log)
        {
            LogData data = GetLogData("INFO", log);
            logAppender.Log(data);

            if (LogConsole)
            {
                UnityEngine.Debug.Log(data.ToString());
            }
        }

        /// <summary>
        /// warn Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Warn(object log)
        {
            LogData data = GetLogData("WARN", log);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(data.ToString());
#else
			if (LogConsole) {
			    UnityEngine.Debug.LogWarning (data.ToString ());
			}
#endif
        }

        /// <summary>
        /// warn Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Warn(string log)
        {
            LogData data = GetLogData("WARN", log);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(data.ToString());
#else
			if (LogConsole) {
			    UnityEngine.Debug.LogWarning (data.ToString ());
			}
#endif
        }

        /// <summary>
        /// warn Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Warn(object log, string track)
        {
            LogData data = GetLogData("WARN", log, track);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(data.ToString());
#else
			if (LogConsole) {
			    UnityEngine.Debug.LogWarning (data.ToString ());
			}
#endif
        }

        /// <summary>
        /// warn Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Warn(string log, string track)
        {
            LogData data = GetLogData("WARN", log, track);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(data.ToString());
#else
			if (LogConsole) {
			    UnityEngine.Debug.LogWarning (data.ToString ());
			}
#endif
        }

        /// <summary>
        /// warn Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Warn(string log, Exception e)
        {
            LogData data = GetLogData("WARN", log, e);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(data.ToString());
#else
			if (LogConsole) {
			UnityEngine.Debug.LogWarning (data.ToString ());
			}
#endif
        }

        /// <summary>
        /// warn Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Warn(object log, Exception e)
        {
            LogData data = GetLogData("WARN", log, e);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(data.ToString());
#else
			if (LogConsole) {
			UnityEngine.Debug.LogWarning (data.ToString ());
			}
#endif
        }

        /// <summary>
        /// error Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Error(object log)
        {
            LogData data = GetLogData("ERROR", log);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// error Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Error(string log)
        {
            LogData data = GetLogData("ERROR", log);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// error Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Error (object log, string track)
        {
            LogData data = GetLogData ("ERROR", log, track);
            logAppender.Log (data);

			#if UNITY_EDITOR
			UnityEngine.Debug.LogError (data.ToString ());
            #else
			UnityEngine.Debug.LogError (data.ToString ());
			#endif

			// 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// error Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Error(string log, string track)
        {
            LogData data = GetLogData("ERROR", log, track);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// error Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Error(object log, Exception e)
        {
            LogData data = GetLogData("ERROR", log, e);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// error Log
        /// </summary>
        /// <param name="log">Log.</param>
        public void Error(string log, Exception e)
        {
            LogData data = GetLogData("ERROR", log, e);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// Fatal the specified log.
        /// </summary>
        /// <param name="log">Log.</param>
        public void Fatal(object log)
        {
            LogData data = GetLogData("FATAL", log);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// Fatal the specified log.
        /// </summary>
        /// <param name="log">Log.</param>
        public void Fatal(string log)
        {
            LogData data = GetLogData("FATAL", log);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }


        /// <summary>
        /// Fatal the specified log and track.
        /// </summary>
        /// <param name="log">Log.</param>
        /// <param name="track">Track.</param>
        public void Fatal(object log, string track)
        {
            LogData data = GetLogData("FATAL", log, track);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// Fatal the specified log and track.
        /// </summary>
        /// <param name="log">Log.</param>
        /// <param name="track">Track.</param>
        public void Fatal(string log, string track)
        {
            LogData data = GetLogData("FATAL", log, track);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// Fatal the specified log and e.
        /// </summary>
        /// <param name="log">Log.</param>
        /// <param name="e">E.</param>
        public void Fatal(object log, Exception e)
        {
            LogData data = GetLogData("FATAL", log, e);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// Fatal the specified log and e.
        /// </summary>
        /// <param name="log">Log.</param>
        /// <param name="e">E.</param>
        public void Fatal(string log, Exception e)
        {
            LogData data = GetLogData("FATAL", log, e);
            logAppender.Log(data);

#if UNITY_EDITOR
            UnityEngine.Debug.LogError(data.ToString());
#else
			UnityEngine.Debug.LogError (data.ToString ());
#endif

            // 回调错误日志拦截
            callErrorLogInterceptor(data);
        }

        /// <summary>
        /// Gets the log data.
        /// </summary>
        /// <returns>The log data.</returns>
        /// <param name="levelStr">Level string.</param>
        /// <param name="log">Log.</param>
        private LogData GetLogData (string levelStr, object log)
        {

            LogData data = new LogData ();
            data.Log = log.ToString ();
            data.Tag = levelStr;

            return data;
        }

        /// <summary>
        /// Gets the log data.
        /// </summary>
        /// <returns>The log data.</returns>
        /// <param name="levelStr">Level string.</param>
        /// <param name="log">Log.</param>
        private LogData GetLogData(string levelStr, string log)
        {

            LogData data = new LogData();
            data.Log = log.ToString();
            data.Tag = levelStr;

            return data;
        }

        /// <summary>
        /// Gets the log data.
        /// </summary>
        /// <returns>The log data.</returns>
        /// <param name="levelStr">Level string.</param>
        /// <param name="log">Log.</param>
        /// <param name="track">Track.</param>
        private LogData GetLogData (string levelStr, object log, string track)
        {
            LogData data = new LogData ();
            data.Log = log.ToString ();
            data.Tag = levelStr;
            data.Track = track;

            return data;

        }

        /// <summary>
        /// Gets the log data.
        /// </summary>
        /// <returns>The log data.</returns>
        /// <param name="levelStr">Level string.</param>
        /// <param name="log">Log.</param>
        /// <param name="track">Track.</param>
        private LogData GetLogData(string levelStr, string log, string track)
        {
            LogData data = new LogData();
            data.Log = log.ToString();
            data.Tag = levelStr;
            data.Track = track;

            return data;

        }

        /// <summary>
        /// Gets the log data.
        /// </summary>
        /// <returns>The log data.</returns>
        /// <param name="levelStr">Level string.</param>
        /// <param name="log">Log.</param>
        /// <param name="e">E.</param>
        private LogData GetLogData (string levelStr, object log, Exception e)
        {
            LogData data = new LogData ();
            data.Log = log.ToString ();
            data.Tag = levelStr;
            data.Track = GetExceptionTrack (e);

            return data;

        }

        /// <summary>
        /// Gets the log data.
        /// </summary>
        /// <returns>The log data.</returns>
        /// <param name="levelStr">Level string.</param>
        /// <param name="log">Log.</param>
        /// <param name="e">E.</param>
        private LogData GetLogData(string levelStr, string log, Exception e)
        {
            LogData data = new LogData();
            data.Log = log.ToString();
            data.Tag = levelStr;
            data.Track = GetExceptionTrack(e);

            return data;

        }

        /// <summary>
        /// 获取异常堆栈
        /// </summary>
        /// <returns>The exception track.</returns>
        /// <param name="e">E.</param>
        private string GetExceptionTrack (Exception e)
        {
            //StringBuilder builder = new StringBuilder (120);
            //builder.Append (e.Message).Append ("\n");
            //StackFrame [] frames = new StackTrace ().GetFrames ();
            //for (int i = 0; i < frames.Length; i++) {
            //    StackFrame stack = frames [i];
            //    builder.AppendFormat ("{0} {1} {2} {3}\n", 
            //                          stack.GetFileName (), 
            //                          stack.GetFileLineNumber (), 
            //                          stack.GetFileColumnNumber (), 
            //                          stack.GetMethod ().ToString ());
            //}
            //if (!string.IsNullOrEmpty (e.StackTrace)) {
            //    builder.Append (e.StackTrace);
            //}
            return ExtractAllStackTrace (e);
            //
            //			StackTrace stackTrace = e.StackTrace;
            //			StackFrame[] stackFrames = stackTrace.GetFrames ();
            //			foreach (StackFrame frame in stackFrames) {
            //				builder.Append ("\t at ")
            //					.Append (frame.GetFileName())
            //					.Append (".")
            //					.Append(frame.GetMethod())
            //					.Append(":")
            //					.Append(frame.GetFileLineNumber())
            //					.Append("\n");
            //			}
            //			return builder.ToString ();
        }

        /// <summary>
        /// 提取异常及其内部异常堆栈跟踪
        /// </summary>
        /// <param name="exception">提取的例外</param>
        /// <param name="lastStackTrace">最后提取的堆栈跟踪（对于递归）， String.Empty or null</param>
        /// <param name="exCount">提取的堆栈数（对于递归）</param>
        /// <returns>Syste.String</returns>
        public string ExtractAllStackTrace (Exception exception, string lastStackTrace = null, int exCount = 1)
        {
            var ex = exception;
            const string entryFormat = "#{0}: {1}\n{2}";
            // 修复最后一个堆栈跟踪参数
            lastStackTrace = lastStackTrace ?? "";
            // 添加异常的堆栈跟踪
            lastStackTrace += string.Format (entryFormat, exCount, ex.Message, ex.StackTrace);
            if (exception.Data.Count > 0) {
                lastStackTrace += "\n    Data: ";
                foreach (KeyValuePair<string, string> item in exception.Data) {
                    lastStackTrace += string.Format ("\n\t{0}: {1}", item.Key, item.Value);
                }
            }

            // 递归添加内部异常
            if ((ex = ex.InnerException) != null) {
                return ExtractAllStackTrace (ex, string.Format ("{0}\n\n", lastStackTrace), ++exCount);
            }

            return lastStackTrace;
        }

        /// <summary>
        /// 执行errorLog拦截器
        /// </summary>
        /// <param name="data">Data.</param>
        protected void callErrorLogInterceptor(LogData data)
        {
            if (null != errorLogCallFunc) {
                    MainThreadSynchronizationContext.Instance.RunOnMainThread(() => {
                        errorLogCallFunc(data.ToString());
                    });
            }
        }

        

    }
}

