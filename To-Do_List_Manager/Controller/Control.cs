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
        private ViewController m_ViewController;
        private ModelManager m_ModelManager;

        public void Run()
        {
            m_ViewController = new ViewController();
            m_ModelManager = new ModelManager();

            do
            {
                Console.WriteLine(m_ViewController.MainMenu);

                string input = Console.ReadLine();
                
                if(input == "quit")
                {
                    break; //  print goodbye and: return;
                }

                if(Int32.TryParse(input, out int choice))
                {
                    switch(choice)
                    {
                        case 1:
                            {
                                List<string> allTasks = m_ModelManager.ShowTasks();
                                foreach(string task in allTasks)
                                {
                                    Console.WriteLine($"Task: {task}");
                                }
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
                                Console.WriteLine(m_ViewController.CreateTaskMsg);

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
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine(m_ViewController.SeeOneTaskMenu);
                                
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
                                    taskString = m_ViewController.TaskNotExisting;
                                }

                                Console.WriteLine($"The task is: \n" +
                                    $"{taskString}");

                                break;
                            }
                        default:
                            {
                                Console.WriteLine("There is no such option!");
                                break;
                            }
                    }
                }

            } while(true);
        }
    }
}
