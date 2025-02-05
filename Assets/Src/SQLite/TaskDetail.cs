using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DataManagers;
using DBTable;

public class TaskDetail : MonoBehaviour
{
    public InitTaskSetting InitTaskSetting;
    // Start is called before the first frame update
    void Start()
    {
        int TaskId = 0;
        TaskId = InitTaskSetting.TaskId;

        GameObject _GameObject = new GameObject("DataManager");
        DataManager DataManager = _GameObject.AddComponent<DataManager>();
        DataTask task = DataManager.GetTask(TaskId);

        GameObject.Find("TaskName").GetComponent<InputField>().text = task.TaskName;
        GameObject.Find("TaskContent").GetComponent<InputField>().text = task.TaskContent;
    }


}
