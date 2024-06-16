using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace To_Do_List_Manager.View
{
    internal static class ViewController
    {
        public static readonly string MainMenu = $"Please choose one of the following options: \n" +
            $"1. See existing tasks.\n" +
            $"2. Edit an existing task.\n" +
            $"3. Delete an existing task.\n" +
            $"4. Create a new task.\n" +
            $"5. See one task by:\n" +
            $"6. Load tasks from file.\n" +
            $"7. Save tasks to file.\n" +
            $"quit. Close the program\n";

        public static readonly string SeeTasksMenu = $"In which order do you want to see the tasks?\n" +
            $"1. By creation time (oldest first).\n" +
            $"2. By creation time (newest first).\n" +
            $"3. By due time (most urgent first).\n" +
            $"4. By due time (least urgent first).\n" +
            $"5. Show Un-Completed tasks\n" +
            $"6. Show Completed tasks\n" +
            $"7. Show late tasks (tasks that should've been finished already).\n";
        public static readonly string CreateTaskMsg = $"Please enter the following (each one in a different line):\n" +
            $"Task name\n" +
            $"Description\n" +
            $"Due Date dd-MM-yyyy\n";
        public static readonly string SeeOneTaskMsg = $"Please enter the key you want to use to identify the task: (integer for id, name of task for seach by name)";
        public static readonly string TaskNotExisting = "There is no such task!";
        public static readonly string LoadTasksFromFileMsg = "Please enter the path of the file you wish to load the Tasks from or press 'ENTER' to use the default path:";
        public static readonly string SaveTasksToFileMsg = "Please enter the path of the file you wish to save the Tasks to or press 'ENTER' to use the default path:";
        public static readonly string EraseTaskMsg = $"{SeeOneTaskMsg} to Erase";
        public static readonly string EditTaskMsg = $"{SeeOneTaskMsg} to Edit";
        public static readonly string EditTaskMenu = $"Please choose which field of the Task you wish to update:\n" +
            $"1. Task name\n" +
            $"2. Task Description\n" +
            $"3. Due Date\n" +
            $"4. Status\n";
        public static readonly string EditTaskNameMsg = "Please enter the new name for the task:";
        public static readonly string EditTaskDescriptionMsg = "Please enter the new description for the task:";
        public static readonly string EditTaskDueDateMsg = "Please enter the new due date in this format: dd-MM-yyyy";
        public static readonly string EditTaskStatusMsg = "Please enter the new Status for the Task:\n" +
            "0. To Do\n" +
            "1. Completed\n";

    }
}
