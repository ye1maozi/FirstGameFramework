using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FirClient
{
    /// <summary>
    /// 字符相关的实用函数。
    /// </summary>
    public static class TextUtil
    {
        [ThreadStatic]
        private static StringBuilder s_CachedStringBuilder = null;

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="arg0">字符串参数 0。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, object arg0)
        {
            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, arg0);
            return s_CachedStringBuilder.ToString();
        }

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="arg0">字符串参数 0。</param>
        /// <param name="arg1">字符串参数 1。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, object arg0, object arg1)
        {
            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, arg0, arg1);
            return s_CachedStringBuilder.ToString();
        }

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="arg0">字符串参数 0。</param>
        /// <param name="arg1">字符串参数 1。</param>
        /// <param name="arg2">字符串参数 2。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, object arg0, object arg1, object arg2)
        {
            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, arg0, arg1, arg2);
            return s_CachedStringBuilder.ToString();
        }

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="args">字符串参数。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, params object[] args)
        {
            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, args);
            return s_CachedStringBuilder.ToString();
        }

        /// <summary>
        /// 将文本按行切分。
        /// </summary>
        /// <param name="text">要切分的文本。</param>
        /// <returns>按行切分后的文本。</returns>
        public static string[] SplitToLines(string text)
        {
            List<string> texts = new List<string>();
            int position = 0;
            string rowText = null;
            while ((rowText = ReadLine(text, ref position)) != null)
            {
                texts.Add(rowText);
            }

            return texts.ToArray();
        }

        /// <summary>
        /// 根据类型和名称获取完整名称。
        /// </summary>
        /// <typeparam name="T">类型。</typeparam>
        /// <param name="name">名称。</param>
        /// <returns>完整名称。</returns>
        public static string GetFullName<T>()
        {
            return GetFullName(typeof(T), null);
        }

        /// <summary>
        /// 根据类型和名称获取完整名称。
        /// </summary>
        /// <typeparam name="T">类型。</typeparam>
        /// <param name="name">名称。</param>
        /// <returns>完整名称。</returns>
        public static string GetFullName<T>(string name)
        {
            return GetFullName(typeof(T), name);
        }

        /// <summary>
        /// 根据类型和名称获取完整名称。
        /// </summary>
        /// <param name="type">类型。</param>
        /// <param name="name">名称。</param>
        /// <returns>完整名称。</returns>
        public static string GetFullName(Type type, string name)
        {
            if (type == null)
            {
                // throw new GameException("Type is invalid.");
                return string.Empty;
            }

            string typeName = type.FullName;
            return string.IsNullOrEmpty(name) ? typeName : string.Format("{0}.{1}", typeName, name);
        }

        /// <summary>
        /// 获取用于编辑器显示的名称。
        /// </summary>
        /// <param name="fieldName">字段名称。</param>
        /// <returns>编辑器显示名称。</returns>
        public static string FieldNameForDisplay(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return string.Empty;
            }

            string str = Regex.Replace(fieldName, @"^m_", string.Empty);
            str = Regex.Replace(str, @"((?<=[a-z])[A-Z]|[A-Z](?=[a-z]))", @" $1").TrimStart();
            return str;
        }

        /// <summary>
        /// 读取一行文本。
        /// </summary>
        /// <param name="text">要读取的文本。</param>
        /// <param name="position">开始的位置。</param>
        /// <returns>一行文本。</returns>
        private static string ReadLine(string text, ref int position)
        {
            if (text == null)
            {
                return null;
            }

            int length = text.Length;
            int offset = position;
            while (offset < length)
            {
                char ch = text[offset];
                switch (ch)
                {
                    case '\r':
                    case '\n':
                        string str = text.Substring(position, offset - position);
                        position = offset + 1;
                        if (((ch == '\r') && (position < length)) && (text[position] == '\n'))
                        {
                            position++;
                        }

                        return str;
                    default:
                        offset++;
                        break;
                }
            }

            if (offset > position)
            {
                string str = text.Substring(position, offset - position);
                position = offset;
                return str;
            }

            return null;
        }

        /// <summary>
        /// 对CachedStringBuilder初始化情况进行检查
        /// </summary>
        private static void CheckCachedStringBuilder()
        {
            if (s_CachedStringBuilder == null)
            {
                s_CachedStringBuilder = new StringBuilder(1024);
            }
        }
    }
}
