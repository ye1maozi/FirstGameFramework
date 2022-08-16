using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace FirClient
{
    /// <summary>
    /// 主线程执行器
    /// </summary>
    
    public class MainThreadSynchronizationContext : MonoBehaviour
    {
        private static MainThreadSynchronizationContext mInstnace;
        /// <summary>
        /// 单例
        /// </summary>
        public static MainThreadSynchronizationContext Instance {
            get{
                return mInstnace;
            }
        }
        void Awake(){
            mInstnace = this;
        }
        // 主线程需要执行的Action
        private readonly List<Action> m_Actions = new List<Action>();

        // 用于交换使用的Action
        private readonly List<Action> m_SwapActions = new List<Action>();

        /// <summary>
        /// 获取游戏框架模块优先级。
        /// </summary>
        /// <remarks>优先级较高的模块会优先轮询，并且关闭操作会后进行。</remarks>
        internal int Priority
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Update执行
        /// </summary>
         void Update()
        {
            if (m_Actions.Count <= 0)
            {
                return;
            }

            // 执行需要在主线程运行的Action
            lock (m_Actions)
            {
                m_SwapActions.AddRange(m_Actions);
                m_Actions.Clear();
            }

            if (m_SwapActions.Count > 0)
            {
                foreach (Action action in m_SwapActions)
                {
                    try
                    {
                        action();
                    }
                    catch (Exception e)
                    {
                        Log.ErrorFormat("multi thread update error", e);
                    }
                }
            }
            m_SwapActions.Clear();
        }

        /// <summary>
        /// 在主线程执行
        /// </summary>
        /// <param name="action">Action.</param>
        public void RunOnMainThread(Action action)
        {
            lock (m_Actions)
            {
                m_Actions.Add(action);
            }
        }

        /// <summary>
        /// 销毁时候执行
        /// </summary>
        void Destroy()
        {
            m_Actions.Clear();
            m_SwapActions.Clear();
        }
    }
}
