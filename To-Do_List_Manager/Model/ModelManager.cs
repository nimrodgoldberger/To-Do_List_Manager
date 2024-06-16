using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace To_Do_List_Manager.Model
{
    internal class ModelManager
    {
        private int m_LastTaskID = 0;
        private Dictionary<int, Task> m_KeyValuePairsOfTasks = new Dictionary<int, Task>();

        public int CreateTask(string taskName, string description, DateTime dueTime, out string o_taskName)
        {
            m_LastTaskID++;
            DateTime currentDateTime = DateTime.Now;

            m_KeyValuePairsOfTasks.Add(m_LastTaskID, new Task(m_LastTaskID, currentDateTime, dueTime, false, taskName, description));

            o_taskName = taskName;

            return m_LastTaskID;
        }

        public Task GetTask(int id)
        {
            Task task;

            if (m_KeyValuePairsOfTasks.TryGetValue(id, out task))
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

            foreach(KeyValuePair<int, Task> kvp in m_KeyValuePairsOfTasks)
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

            List<Task> tasks = m_KeyValuePairsOfTasks.Values.ToList();

            foreach(Task task in tasks)
            {
                tasksStrings.Add(task.ToString());
            }

            return tasksStrings;
        }

        protected Dictionary<int, Task> GetTasks()
        {
            return m_KeyValuePairsOfTasks;
        }


        public void SaveTasksToFile(string filePath="")
        {
            if (string.IsNullOrEmpty(filePath))
            {
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                filePath = Path.Combine(projectDirectory, "tasks.json");
            }
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new DateTimeConverter() }
            };

            string jsonString = JsonSerializer.Serialize(m_KeyValuePairsOfTasks, options);
            File.WriteAllText(filePath, jsonString);
        }

        public bool LoadTasksFromFile(string filePath="")
        {
            if (m_KeyValuePairsOfTasks.Count > 0)
            {
                return false;
            }


            if(string.IsNullOrEmpty(filePath))
            {
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                filePath = Path.Combine(projectDirectory, "tasks.json");
            }

            if(File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);

                var options = new JsonSerializerOptions
                {
                    Converters = { new DateTimeConverter() }
                };

                m_KeyValuePairsOfTasks = JsonSerializer.Deserialize<Dictionary<int, Task>>(jsonString, options);
                m_LastTaskID = m_KeyValuePairsOfTasks.Count;
                return true;
            }
            else
            {
                return false;
            }
        }

        public ModelManager()
        {
            LoadTasksFromFile();
        }

    }
}
