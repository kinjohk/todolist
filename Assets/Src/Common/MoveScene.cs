using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    private int SampleValue;
    public void MoveNextScene(string SceneName)
    {
        SceneManager.sceneLoaded += LoadScene;
        SceneManager.LoadScene(SceneName);
    }

    private void LoadScene(Scene Next, LoadSceneMode Mode)
    {
        // シーン遷移時に呼ばれる
        //移動先に初期設定オブジェクトを持ち、その要素に値をセットする
        var InitSettingObject = GameObject.FindWithTag("InitSettingObject").GetComponent<InitTaskSetting>();
        InitSettingObject.TaskId = SampleValue;

        // イベントから削除
        SceneManager.sceneLoaded -= LoadScene;
    }

}