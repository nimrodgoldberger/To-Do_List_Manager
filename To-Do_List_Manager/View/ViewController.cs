using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List_Manager.View
{
    internal class ViewController
    {
        public readonly string MainMenu = $"Please choose one of the fopllowing options: \n" +
            $"1. See existing tasks.\n" +
            $"2. Edit an existing task.\n" +
            $"3. Delete an existing task.\n" +
            $"4. Create a new task.\n" +
            $"5. See one task by:\n" +
            $"quit. Close the program";

        public readonly string SeeTasksMenu = $"In which order do you want to see the tasks?\n" +
            $"1. By creation time (oldest first).\n" +
            $"2. By creation time (newest first).\n" +
            $"3. By due time (most urgent first).\n" +
            $"4. By due time (least urgent first).\n" +
            $"5. Show Completed tasks" +
            $"6. Show late tasks (tasks that should've been finished already).\n";
        public readonly string CreateTaskMsg = $"Please enter the following (each one in a different line):\n" +
            $"Task name\n" +
            $"Description\n" +
            $"Due Date dd-MM-yyyy";
        public readonly string SeeOneTaskMenu = $"Please enter the key you want to use to get the task (integer for id, name of task for seach by name):";
        public readonly string TaskNotExisting = "There is no such task!";
    }
}
