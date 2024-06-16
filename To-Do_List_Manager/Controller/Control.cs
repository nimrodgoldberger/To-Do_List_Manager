using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List_Manager.Model;
using To_Do_List_Manager.View;

namespace To_Do_List_Manager.Controller
{
    internal class Control
    {
        //private ViewController m_ViewController;
        private ModelManager m_ModelManager;

        public void Run()
        {
            //m_ViewController = new ViewController();
            m_ModelManager = new ModelManager();

            string input;

            do
            {
                Console.WriteLine(ViewController.MainMenu);

                input = Console.ReadLine();

                if(Int32.TryParse(input, out int choice))
                {
                    invokeMainMenuAction(choice);
                }

            } while(input.ToLower() != "quit");

            Console.WriteLine("\n\nGoodbye, thanks for using the app! :)\n");
        }

        private void showTasks()
        {
            List<string> allTasks = m_ModelManager.ShowTasks();

            if(allTasks.Count == 0)
            {
                Console.WriteLine("No tasks to show!");
            }
            else
            {
                foreach(string task in allTasks)
                {
                    Console.WriteLine($"Task: {task}");
                }
            }
        }

        private void createTask()
        {
            Console.WriteLine(ViewController.CreateTaskMsg);

            string name = Console.ReadLine();
            while(name == null)
            {
                Console.WriteLine("Please re-enter the name, it can't be empty");
                // todo check if the name exists and if it does then aqdvice to edit the task, and give the task id too.
                name = Console.ReadLine();
            }

            string description = Console.ReadLine();
            while(description == null)
            {
                Console.WriteLine("Please re-enter the description, it can't be empty");
                //todo add option to have empty description
                description = Console.ReadLine();
            }

            string dueDateString = Console.ReadLine();
            DateTime dueDateTime = DateTime.Now;
            while(!DateTime.TryParseExact(dueDateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateTime) || dueDateTime < DateTime.Now)
            {
                Console.WriteLine("Please re-enter the date. Has to be a future date and in a valid format: dd-MM-yyyy ");
                dueDateString = Console.ReadLine();
            }

            int newTaskID = m_ModelManager.CreateTask(name, description, dueDateTime, out string o_taskName);
            Console.WriteLine($"Task {o_taskName}, created successfully with task id={newTaskID}");
        }

        private void printSpecificTask()
        {
            Console.WriteLine(ViewController.SeeOneTaskMsg);

            string taskSearchKeyString = Console.ReadLine();

            while(taskSearchKeyString == null)
            {
                taskSearchKeyString = Console.ReadLine();
            }

            string taskString;
            try
            {
                if(Int32.TryParse(taskSearchKeyString, out int value))
                {
                    taskString = m_ModelManager.GetTaskString(value);
                }
                else
                {
                    taskString = m_ModelManager.GetTaskString(taskSearchKeyString);
                }
            }
            catch(TaskNotFoundException ex)
            {
                taskString = ViewController.TaskNotExisting;
            }

            Console.WriteLine($"The task is: \n" +
                $"{taskString}");
        }

        private void loadTasksFromJson()
        {
            Console.WriteLine(ViewController.LoadTasksFromFileMsg);
            string filePath = Console.ReadLine();

            if(!m_ModelManager.LoadTasksFromFile(filePath))
            {
                Console.WriteLine("File not found or you have existing tasks.");
            }
        }

        private void saveTasksToJson()
        {
            Console.WriteLine(ViewController.SaveTasksToFileMsg);

            string filePath = Console.ReadLine();

            m_ModelManager.SaveTasksToFile(filePath);
        }

        private void invokeMainMenuAction(int choice)
        {
            switch(choice)
            {
                case 1:
                    {
                        showTasks();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("This option is not ready yet"); //todo Edit existing task
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("This option is not ready yet"); // todo Delet existing task
                        break;
                    }
                case 4:
                    {
                        createTask();
                        break;
                    }
                case 5:
                    {
                        printSpecificTask();
                        break;
                    }
                case 6:
                    {
                        loadTasksFromJson();
                        break;
                    }
                case 7:
                    {
                        saveTasksToJson();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("There is no such option!");
                        break;
                    }
            }
        }
    }
}
