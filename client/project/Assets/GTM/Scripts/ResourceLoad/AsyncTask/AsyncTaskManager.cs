﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gtm
{
    public class AsyncTaskManager : BaseAsyncTaskManager
    {
        /// <summary>
        /// 任务列表
        /// </summary>
        List<AsyncTask> m_TaskList = new List<AsyncTask>(ConstDefine.LIST_CONST_100);

        /// <summary>
        /// 临时任务列表
        /// </summary>
        List<AsyncTask> m_TempTaskList = new List<AsyncTask>(ConstDefine.LIST_CONST_16);


        public override void AddTask(AsyncTask asynctask)
        {
            m_TaskList.Add(asynctask);
        }

        public override void DoClose()
        {
            
        }

        public override void DoInit()
        {
            
        }

        public override void DoUpdate()
        {
            m_TempTaskList.Clear();

            for(int i = 0; i < m_TaskList.Count; i++)
            {
                var task = m_TaskList[i];
                if (task == null)
                    continue;

                task.Update();

                if (task.isEnd)
                {
                    m_TempTaskList.Add(task);
                }
            }

            for(int i = 0; i < m_TempTaskList.Count; i++)
            {
                var task = m_TempTaskList[i];
                if (task == null)
                    continue;

                m_TaskList.Remove(task);
            }

            m_TempTaskList.Clear();
        }
    }
}
