using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using DBTable;
using DataBaseService;

public class DataManager : MonoBehaviour
{
    private DBService _DBService;

    List<DataTask> TaskData = new List<DataTask>(){
        new DataTask{
            TaskName = "タスク1",
            TaskContent = "タスク1の内容",
            TaskCreateDate = DateTime.Now,
            TaskUpdateDate = DateTime.Now,
            TaskCompleteDate = DateTime.Now,
            TaskDeleteDate = DateTime.Now,
        },
        new DataTask{
            TaskName = "タスク2",
            TaskContent = "タスク2の内容",
            TaskCreateDate = DateTime.Now,
            TaskUpdateDate = DateTime.Now,
            TaskCompleteDate = DateTime.Now,
            TaskDeleteDate = DateTime.Now,
        }
    };


    private void Awake(){
        _DBService = new DataBaseService.DBService();
        _DBService.InitDatabase("TaskData.db");
        _DBService.CreateTables();
    }



    public void InsertTaskData()
    {
        foreach(DataTask Task in TaskData)
        {
            _DBService.InsertTask(Task);
        }
    }

    private void Start(){
        //InsertTaskData();
        _DBService.OnDestroy();
    }

}
