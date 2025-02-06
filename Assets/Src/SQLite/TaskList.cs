using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

using DataManagers;
using DBTable;

public class TaskList : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentPanel;
    public string SceneName;
    public InitTaskSetting InitTaskSetting;

    // Start is called before the first frame update
    void Start()
    {
        CreateUIElements();
    }

    // リストのデータに基づいてUI要素を生成するメソッド
    private void CreateUIElements()
    {
        GameObject _GameObject = new GameObject("DataManager");
        DataManager DataManager = _GameObject.AddComponent<DataManager>();
        List<DataTask> taskList = DataManager.GetAllTasks();

        foreach (var task in taskList)
        {
            // ボタンをPrefabから複製
            GameObject newButton = Instantiate(buttonPrefab, contentPanel);
            
            // ボタンのテキストを設定
            Text buttonText = newButton.GetComponentInChildren<Text>();
            buttonText.text = string.Concat(task.TaskId, " : ", task.TaskName);

            // ボタンにクリックイベントを追加
            Button button = newButton.GetComponent<Button>();
            button.onClick.AddListener(() => OnButtonClick(task));
        }
    }

    // ボタンがクリックされた時の処理
    private void OnButtonClick(DataTask task)
    {
        InitTaskSetting.TaskId = task.TaskId;

        SceneManager.sceneLoaded += LoadScene;
        SceneManager.LoadScene(SceneName);
    }

    private void LoadScene(Scene Next, LoadSceneMode Mode)
    {
        // イベントから削除
        SceneManager.sceneLoaded -= LoadScene;
    }

}


