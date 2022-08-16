using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using UnityEngine;

namespace FirClient
{
	public class RollingFileAppender :  Logger.ILogAppender
	{
#if UNITY_EDITOR
        string logRootPath = Application.dataPath + "/../Log";
#elif UNITY_STANDALONE_WIN
		string logRootPath = Application.dataPath + "/../Log";
#elif UNITY_STANDALONE_OSX
		string logRootPath = Application.dataPath + "/Log";
#else
		string logRootPath = Application.persistentDataPath + "/Log";
#endif

        // 时间格式化
        protected const string TIME_FORMATER = "yyyy-MM-dd hh:mm:ss,fff";
		
		/// <summary>
		/// 文件最大值 10M
		/// </summary>
		private int maxFileSize = 10 * 1024 * 1024;

		// 文件Writer
		private StreamWriter streamWriter;

		// 文件流
		private FileStream fileStream;

		// 文件路径
		private string filePath;

		// 写日志队列
		private List<Logger.LogData> writeList;

		// 等待队列
		private List<Logger.LogData> waitList;

		// 锁
		private object lockObj;

		// 是否停止的标志
		private bool stopFlag;
        private bool NeedUpdate;

        // 文件编码
        private Encoding encoding = Encoding.UTF8;

        // 程序启动是否要清空除了game.log以外的log文件
        private bool cleanFiles = false;

        // 线程是否开启标志
        private bool threadStartFlag = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RollingFileAppender()
        {
            this.NeedUpdate = false;
            this.Init();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="encoding">Encoding.</param>
        public RollingFileAppender(Encoding encoding, bool cleanFiles)
        {
            this.encoding = encoding;
            this.cleanFiles = cleanFiles;
            this.NeedUpdate = false;
            this.Init();
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        public void Init()
        {
            this.filePath = Path.Combine(logRootPath, "game.log");

            if (File.Exists(filePath))
            {
                if (this.cleanFiles == true)
                {
                    //如果有除了game.log以外的log文件，直接清理内容
                    string[] fileList = Directory.GetFiles(logRootPath);
                    for (int i = 0; i <= fileList.Length - 1; i++)
                    {
                        if ((fileList[i].Contains("game.log") == false) && (fileList[i].Contains(".log") == true))
                        {
       						FileStream _fileStream = new FileStream(fileList[i], FileMode.Create);
                            StreamWriter _streamWriter = new StreamWriter(_fileStream, this.encoding);
                            _fileStream.Close();
                            _streamWriter.Close();
                        }
                    }
                }
                this.fileStream = new FileStream(filePath, FileMode.Create);
                this.streamWriter = new StreamWriter(this.fileStream, this.encoding);
                this.streamWriter.AutoFlush = true;

                this.writeList = new List<Logger.LogData>();
                this.waitList = new List<Logger.LogData>();
                this.lockObj = new object();
                this.stopFlag = false;
            }
            else
            {
                if (!Directory.Exists(logRootPath))
                {
                    Directory.CreateDirectory(logRootPath);
                }
                this.fileStream = new FileStream(filePath, FileMode.Create);
                this.streamWriter = new StreamWriter(this.fileStream, this.encoding);
                this.streamWriter.AutoFlush = true;
            }

            this.writeList = new List<Logger.LogData>();
            this.waitList = new List<Logger.LogData>();
            this.lockObj = new object();
            this.stopFlag = false;

            // 开始执行
            StartFlushThread();
            
        }

		/// <summary>
		/// 记录日志
		/// </summary>
		/// <param name="log">Log.</param>
		/// <param name="logData">Log data.</param>
        public void Log (Logger.LogData logData)
		{
			lock (lockObj) {
				waitList.Add (logData);
				Monitor.PulseAll (lockObj);
			}

            if (!threadStartFlag) {
                // 开始执行
                StartFlushThread();
            }
		}

        /// <summary>
        /// 初始化执行任务
        /// </summary>
        public void Initialize()
        {
            return;
        }

        /// <summary>
        /// 关闭执行
        /// </summary>
        public void Destroy ()
		{
			this.stopFlag = true;
			if (null != this.fileStream) {
				this.fileStream.Close ();
			}
		}

		/// <summary>
		/// 开始运行
		/// </summary>
		public void Run ()
		{
			while (!stopFlag) {
				lock (lockObj) {
					if (waitList.Count == 0) {
						Monitor.Wait (lockObj);			
					}
					this.writeList.AddRange (this.waitList);
					this.waitList.Clear ();
				}
                int count = writeList.Count;
                for (int i = 0; i < count; i++) {
                    Logger.LogData data = writeList [i];
					// 写日志
					this.streamWriter.WriteLine (String.Format ("{0}#{1}#{2}", System.DateTime.Now.ToString (TIME_FORMATER), data.Tag, data.Log));
					
					// 写堆栈
					if (null != data.Track) {
						this.streamWriter.WriteLine (data.Track);
					}
					
					// 判断是否触发策略
//					HandleTriggerEvent ();
				}
                this.streamWriter.Flush();
                writeList.Clear ();
			}
			
		}

		/// <summary>
		/// 处理Trigger事件
		/// </summary>
		private void HandleTriggerEvent() {
			if (this.fileStream.Length >= maxFileSize) {
				// 文件超过大小，重头开始写
				this.streamWriter.Close ();
				this.fileStream.Close ();
				
				// 重新开始写
				this.fileStream = new FileStream (this.filePath, FileMode.Create);
				this.streamWriter = new StreamWriter (this.fileStream);
				this.streamWriter.AutoFlush = true;
			}
		}


        /// <summary>
        /// 启动刷新线程
        /// </summary>
        private void StartFlushThread()
        {
            if (threadStartFlag)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(RunThreadTask);
            threadStartFlag = true;
        }

        /// <summary>
        /// 线程任务
        /// </summary>
        /// <param name="obj"></param>
        private void RunThreadTask(object obj)
        {
            Run();
        }

	}
}

