using SQLite4Unity3d;
using System;

namespace DBTable{
    // タスクテーブル
    public class DataTask
    {
        // タスクのID
        [PrimaryKey, AutoIncrement]
        public int TaskId { get; set; }

        // タスクの作成日時
        public DateTime TaskCreateDate { get; set; }
        // タスクの更新日時
        public DateTime TaskUpdateDate { get; set; }
        // タスクの完了日時
        public DateTime TaskCompleteDate { get; set; }
        // タスクの削除日時
        public DateTime TaskDeleteDate { get; set; }

        // タスクの共通ID
        public int TaskCommonId { get; set; }

        // タスクの名前
        public string TaskName { get; set; }
        // タスクの内容
        public string TaskContent { get; set; }
        // タスクの期日
        public int TaskDeadline { get; set; }
        // タスクの工数
        public int TaskWorkload { get; set; }
        // タスクの工数単位
        public string TaskWorkloadUnit { get; set; }
        // タスクのステータス
        public TaskStatus TaskStatus { get; set; }
        // タスクの優先度
        public TaskPriority TaskPriority { get; set; }
        //タスクの色
        public TaskColor TaskColor { get; set; }
    }

    public enum TaskStatus{
        // 未完了
        NotCompleted,
        // 完了
        Completed,
        // 削除
        Deleted,
    }   

    public enum TaskPriority{
        // 低
        Low,
        // 中
        Medium,
        // 高
        High,
    }

    public enum TaskColor{
        // 赤
        Red,
        // 緑
        Green,
        // 青
        Blue,
    }
}