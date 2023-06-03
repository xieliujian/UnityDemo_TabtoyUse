
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace gtm
{
    public enum LogCategory
    {
        GameLogic,
        GameEngine,
        Plugin_Xlua,
    }

    public class LogSystem : Manager
    {
        protected string[] LOG_CATEGORY_NAME_ARRAY = {
            "GameLogic",
            "GameEngine",
            "Plugin_Xlua"
        };

        /// <summary>
        /// .
        /// </summary>
        bool m_EnableSave = false;

        /// <summary>
        /// .
        /// </summary>
        string m_LogFileDir = "";

        /// <summary>
        /// .
        /// </summary>
        StreamWriter m_LogFileWriter = null;

        public LogSystem()
        {
            s_Instance = this;
        }

        protected static LogSystem s_Instance = null;

        public static LogSystem instance
        {
            get { return s_Instance; }
        }

        public override void DoInit()
        {
            
        }

        public override void DoUpdate()
        {
           
        }

        public override void DoClose()
        {
            
        }

        [Conditional("DEBUG")]
        public void Log(LogCategory category, string message)
        {
            Log(category, LogType.Log, message);
        }

        [Conditional("DEBUG")]
        public void LogWarning(LogCategory category, string message)
        {
            Log(category, LogType.Warning, message);
        }

        [Conditional("DEBUG")]
        public void LogError(LogCategory category, string message)
        {
            Log(category, LogType.Error, message);
        }

        protected void Log(LogCategory category, LogType type, string message)
        {
            DateTime now = DateTime.Now;
            //string msg = "[" + now.ToString("yyyy-MM-dd hh:mm:ss") + "]";
            string msg = "[" + LOG_CATEGORY_NAME_ARRAY[(int)category] + "]" + message;

            if (type == LogType.Log)
            {
                UnityEngine.Debug.Log(msg);
            }
            else if (type == LogType.Warning)
            {
                UnityEngine.Debug.LogWarning(msg);
            }
            else if (type == LogType.Error)
            {
                UnityEngine.Debug.LogError(msg);
            }

            LogToFile(msg);
        }

        public void EnableSave(string logFileDir = null)
        {
            m_EnableSave = true;
            m_LogFileDir = logFileDir;

            if (string.IsNullOrEmpty(m_LogFileDir))
            {
                m_LogFileDir = AppPlatform.dataPath + "/log/";
            }
        }
        
        string GenLogFileName()
        {
            DateTime now = DateTime.Now;
            string filename = now.GetDateTimeFormats('s')[0].ToString();//2005-11-05T14:06:25
            filename = filename.Replace("-", "_");
            filename = filename.Replace(":", "_");
            filename = filename.Replace(" ", "");
            filename = filename.Replace("T", "_");
            filename += ".log";

            return filename;
        }

        void LogToFile(string message)
        {
            if (!m_EnableSave)
                return;

            if (m_LogFileWriter == null)
            {
                if (string.IsNullOrEmpty(m_LogFileDir))
                    return;

                if (!Directory.Exists(m_LogFileDir))
                {
                    Directory.CreateDirectory(m_LogFileDir);
                }

                string fullpath = string.Format("{0}/{1}", m_LogFileDir, GenLogFileName());
                try
                {
                    m_LogFileWriter = System.IO.File.CreateText(fullpath);
                    m_LogFileWriter.AutoFlush = true;
                }
                catch (Exception e)
                {
                    m_EnableSave = false;
                    Log(LogCategory.GameEngine, LogType.Error, e.Message);
                    return;
                }
            }

            if (m_LogFileWriter != null)
            {
                try
                {
                    m_LogFileWriter.WriteLine(message);

                    StackTrace st = new StackTrace(true);
                    m_LogFileWriter.WriteLine(st.ToString());
                    m_LogFileWriter.WriteLine("\n");
                }
                catch (Exception e)
                {
                    m_EnableSave = false;
                    Log(LogCategory.GameEngine, LogType.Error, e.Message);
                    return;
                }
            }
        }
    }

    public class LogHelper
    {
        private static System.Text.StringBuilder m_stringBuilder = new System.Text.StringBuilder();

        public static void Log(params string[] args)
        {
            Log(LogCategory.GameLogic, args);
        }

        public static void Log(LogCategory category, params string[] args)
        {
            m_stringBuilder.Length = 0;

            for (int i = 0; i < args.Length; i++)
            {
                m_stringBuilder.Append(args[i]);

                if (i + 1 < args.Length)
                {
                    m_stringBuilder.Append(" ");
                }
            }

            if (LogSystem.instance != null)
            {
                LogSystem.instance.Log(category, m_stringBuilder.ToString());
            }
        }
    }
}
