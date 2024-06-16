using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List_Manager.Model
{
    internal class TaskNotFoundException : Exception
    {

        public TaskNotFoundException(string msg) : base(msg)
        {

        }
    }
}
