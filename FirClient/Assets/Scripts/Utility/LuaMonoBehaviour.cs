using LuaInterface;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace FirClient.Utility
{
     public class LuaMonoBehaviour : MonoBehaviour
	{
        private string displayName;
        public string DisplayName {
            get {
                return displayName;
            }
        }
		// Lua Behaviour字典
		private Dictionary <string, LuaFunction> luaBehaviourFuncDic = new Dictionary<string, LuaFunction>();

/// <summary>
        /// 调用Lua函数
        /// </summary>
        /// <param name="func">Lua函数.</param>
        private void LuaCall(string funcName)
        {
            LuaFunction func = null;
            luaBehaviourFuncDic.TryGetValue(funcName, out func);
            if (null != func && func.GetLuaState() != null)
            {
                func.Call();
            }
        }
        /// <summary>
        /// 初始化LuaBehaviour
        /// </summary>
        /// <param name="funcNameArr">函数名称数组.</param>
        /// <param name="funcArr">函数数组.</param>
        /// <param name="displayName">显示名称.</param>
		public void InitLuaBehaviour (string [] funcNameArr,LuaFunction[] funcArr, string displayName)
		{
			for (int i = 0; i < funcArr.Length; i++) {
				luaBehaviourFuncDic.Add (funcNameArr [i], funcArr [i]);
			}
			this.displayName = displayName;
		}

		/// <summary>
		/// Awake
		/// </summary>
		void Awake ()
		{

            LuaCall("Awake");
		}

        /// <summary>
        /// OnEnable
        /// </summary>
		void OnEnable()
		{
            LuaCall("OnEnable");
        }

        /// <summary>
        /// Start
        /// </summary>
        void Start()
        {

            LuaCall("Start");
        }

        /// <summary>
        /// OnDisable
        /// </summary>
		void OnDisable()
		{
            LuaCall("OnDisable");

        }

		/// <summary>
		/// Managers the fixed update.
		/// </summary>
		void FiexedUpdate()
		{
			LuaCall("FixedUpdate");
		}

		/// <summary>
		/// Managers the update.
		/// </summary>
		void Update()
		{
			LuaCall("Update");
		}

		/// <summary>
		/// Managers the late update.
		/// </summary>
		void LateUpdate ()
		{
			LuaCall("LateUpdate");
		}

        /// <summary>
        /// OnDestroy
        /// </summary>
         void OnDestroy()
        {
            LuaCall("OnDestroy");

            // 销毁LuaFunction
            foreach(KeyValuePair<string, LuaFunction> pair in luaBehaviourFuncDic)
            {
                try
                {
                    pair.Value?.Dispose();
                }
                catch (Exception e)
                {
                    Log.ErrorFormat("destroy lua fun error, name:{0}", e, pair.Key);
                }
                
            }
            luaBehaviourFuncDic.Clear();
        }

       
    }
}