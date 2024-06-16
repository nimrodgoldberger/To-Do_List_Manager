using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List_Manager.Model
{
    internal class ModelManager
    {
        private int m_LastTaskID = 0;
        private Dictionary<int, Task> m_KeyValuePairs = new Dictionary<int, Task>();

        public int CreateTask(string taskName, string description, DateTime dueTime, out string o_taskName)
        {
            m_LastTaskID++;
            DateTime currentDateTime = DateTime.Now;

            m_KeyValuePairs.Add(m_LastTaskID, new Task(m_LastTaskID, currentDateTime, dueTime, false, taskName, description));

            o_taskName = taskName;

            return m_LastTaskID;
        }

        public Task GetTask(int id)
        {
            Task task;

            if (m_KeyValuePairs.TryGetValue(id, out task))
            {
                return task;
            }
            else
            {
                throw new TaskNotFoundException("There is no task with that id!");
            }
        }

        public string GetTaskString(int id)
        {
            return GetTask(id).ToString();
        }

        public string GetTaskString(string taskName)
        {
            string taskAsString = "There is no task with that id!";

            foreach(KeyValuePair<int, Task> kvp in m_KeyValuePairs)
            {
                if(kvp.Value.TaskName == taskName)
                {
                    return taskAsString = kvp.Value.ToString();
                }
            }

            throw new TaskNotFoundException(taskAsString);
        }


        public List<string> ShowTasks()
        {
            List<string> tasksStrings = new List<string>();

            List<Task> tasks = m_KeyValuePairs.Values.ToList();

            foreach(Task task in tasks)
            {
                tasksStrings.Add(task.ToString());
            }

            return tasksStrings;
        }

        public bool CheckIfTaskExists(string taskName)
        {
            bool exists = false;
            m_KeyValuePairs
        }
    }
}
