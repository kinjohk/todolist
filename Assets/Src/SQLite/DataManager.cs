using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

using DBTable;
using DataBaseService;

namespace DataManagers{
    public class DataManager : MonoBehaviour
    {
        private DBService _DBService;
        private string _DBName = "TaskData.db";
        public InitTaskSetting InitTaskSetting;

        private void Awake(){
            _DBService = new DataBaseService.DBService();
            _DBService.InitDatabase(_DBName);
            _DBService.CreateTables();
        }

        public DataTask GetTask(int TaskId){
            _DBService.InitDatabase(_DBName);
            DataTask task = _DBService.GetTask(TaskId);
            _DBService.OnDestroy();
            return task;
        }

        public List<DataTask> GetAllTasks(){
            _DBService.InitDatabase(_DBName);
            List<DataTask> tasks = _DBService.GetAllTasks();
            _DBService.OnDestroy();

            return tasks;
        }

        public void UpdInsTaskData()
        {
            DataTask DataTask = new DataTask();
            DataTask = GetTaskDataFromInputField();
            _DBService.InitDatabase(_DBName);
            _DBService.UpdInsTask(DataTask);
            _DBService.OnDestroy();
        }

        private DataTask GetTaskDataFromInputField(){
            int _TaskId = InitTaskSetting.TaskId;
            string _TaskName = GameObject.Find("TaskName").GetComponent<InputField>().text;
            string _TaskContent = GameObject.Find("TaskContent").GetComponent<InputField>().text;

            DataTask task = new DataTask();
            task.TaskId = _TaskId;
            task.TaskName = _TaskName;
            task.TaskContent = _TaskContent;
            task.TaskCreateDate = DateTime.Now;
            task.TaskUpdateDate = DateTime.Now;
            task.TaskCompleteDate = DateTime.Now;
            task.TaskDeleteDate = DateTime.Now;

            return task;
        }
        
        public void DeleteTaskData()
        {
            int _TaskId = InitTaskSetting.TaskId;
            _DBService.InitDatabase(_DBName);
            _DBService.DeleteTask(_TaskId);
            _DBService.OnDestroy();


        }


        private void Start(){
            _DBService.OnDestroy();
        }

    }
}