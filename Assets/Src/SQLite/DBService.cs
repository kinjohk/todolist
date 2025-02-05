using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.IO;
using System.Linq;

using DBTable;

namespace DataBaseService{
    public class DBService
    {
        private SQLiteConnection _connection;
        private string _databasePath;

        public void InitDatabase(string databaseName)
        {
            // データベースファイルのパスを設定
            #if UNITY_EDITOR
                _databasePath = Path.Combine(Application.dataPath, "StreamingAssets", databaseName);
            #else
                _databasePath = Path.Combine(Application.persistentDataPath, databaseName);
            #endif

            // データベース接続を作成
            try{
                _connection = new SQLiteConnection(_databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            }catch(System.Exception e){
                Debug.LogError($"データベースの初期化に失敗しました: {e.Message}");
            }

            //Debug.Log($"データベースが正常に初期化されました: {_databasePath}");

        }

        public void CreateTables()
        {
            try{
                _connection.CreateTable<DBTable.DataTask>();
            }catch(System.Exception e){
                Debug.LogError($"テーブルの作成に失敗しました: {e.Message}");
            }
        }

        public void UpdInsTask(DataTask task){
            if (task.TaskId == 0){
                InsertTask(task);
            }else{
                UpdateTask(task);
            }
        }

        private void InsertTask(DataTask task){
            try{
                _connection.Insert(task);
            }catch(System.Exception e){
                Debug.LogError($"データの挿入に失敗しました: {e.Message}");
            }
        }

        private void UpdateTask(DataTask task){
            try{
                _connection.Update(task);
            }catch(System.Exception e){
                Debug.LogError($"データの挿入に失敗しました: {e.Message}");
            }
        }

        public void DeleteTask(int TaskId){
            try{
                _connection.Delete<DataTask>(TaskId);
            }catch(System.Exception e){
                Debug.LogError($"データの削除に失敗しました: {e.Message}");
            }
        }

        public DataTask GetTask(int TaskId){
            try{
                return _connection.Table<DataTask>().Where(t => t.TaskId == TaskId).FirstOrDefault();
            }catch(System.Exception e){
                Debug.LogError($"データの取得に失敗しました: {e.Message}");
            }
            return null;
        }


        public List<DataTask> GetAllTasks(){
            try{
                return _connection.Table<DataTask>().ToList();
            }catch(System.Exception e){
                Debug.LogError($"データの取得に失敗しました: {e.Message}");
            }
            return null;
        }


        public void OnDestroy()

        {
            // データベース接続を閉じる
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
            //Debug.Log($"データベースの接続を閉じました。");
        }


        // データベース接続を取得するためのプロパティ
        public SQLiteConnection Connection
        {
            get { return _connection; }
        }

    }
}