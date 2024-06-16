//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace To_Do_List_Manager.Model
//{
//    internal class Task
//    {
//        protected int m_TaskID;
//        protected DateTime m_CreationTime;
//        protected DateTime m_DueTime;

//        public bool IsCompleted { get; set; }

//        public string TaskName { get; set; }

//        public string Description { get; set; }

//        public string CreationTime
//        {
//            get
//            {
//                return m_CreationTime.ToShortDateString();
//            }
//        }

//        public string DueTime
//        {
//            get
//            {
//                return m_DueTime.ToShortDateString();
//            }
//        }

//        public string TaskID
//        {
//            get
//            {
//                return m_TaskID.ToString();
//            }
//        }

//        public override string ToString()
//        {
//            return $"Task name: {TaskName}\n" +
//                    $"Description: {Description}\n" +
//                    $"Task ID: {TaskID}\n" +
//                    $"Task Status: {GetStatus()}\n" +
//                    $"Creation Date: {CreationTime}\n" +
//                    $"Due Date: {DueTime}\n";
//        }

//        public string GetStatus()
//        {
//            string status = "To Do";
//            if(IsCompleted)
//            {
//                status = "Completed";
//            }
//            else if (m_DueTime <= DateTime.Now)
//            {
//                status = "Due date Passed!";
//            }

//            return status;
//        }

//        public Task(int taskID, DateTime creationTime, DateTime dueTime, bool isCompleted, string taskName, string description)
//        {
//            m_TaskID = taskID;
//            m_CreationTime = creationTime;
//            m_DueTime = dueTime;
//            IsCompleted = isCompleted;
//            TaskName = taskName;
//            Description = description;
//        }
//    }
//}




using System;
using System.Text.Json.Serialization;

namespace To_Do_List_Manager.Model
{
    internal class Task
    {
        [JsonInclude]
        public int TaskID { get; private set; }

        [JsonInclude]
        public DateTime CreationTime { get; private set; }

        [JsonInclude]
        public DateTime DueTime { get; private set; }

        public bool IsCompleted { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public string CreationTimeString => CreationTime.ToShortDateString();

        [JsonIgnore]
        public string DueTimeString => DueTime.ToShortDateString();

        [JsonIgnore]
        public string TaskIDString => TaskID.ToString();

        public override string ToString()
        {
            return $"Task name: {TaskName}\n" +
                   $"Description: {Description}\n" +
                   $"Task ID: {TaskIDString}\n" +
                   $"Task Status: {GetStatus()}\n" +
                   $"Creation Date: {CreationTimeString}\n" +
                   $"Due Date: {DueTimeString}\n";
        }

        public string GetStatus()
        {
            string status = "To Do";
            if(IsCompleted)
            {
                status = "Completed";
            }
            else if(DueTime <= DateTime.Now)
            {
                status = "Due date Passed!";
            }

            return status;
        }

        [JsonConstructor]
        public Task(int taskID, DateTime creationTime, DateTime dueTime, bool isCompleted, string taskName, string description)
        {
            TaskID = taskID;
            CreationTime = creationTime;
            DueTime = dueTime;
            IsCompleted = isCompleted;
            TaskName = taskName;
            Description = description;
        }

        // Parameterless constructor needed for deserialization
        public Task() { }
    }
}
