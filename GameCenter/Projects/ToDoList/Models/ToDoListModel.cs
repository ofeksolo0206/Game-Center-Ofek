using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Projects.ToDoList.Models
{
    internal class ToDoListModel
    {
        public ObservableCollection<ToDoTask> Tasks { get; set; }
        public ToDoListModel()
        {
            Tasks = new ObservableCollection<ToDoTask>();
        }

        public void AddNewTask(ToDoTask task)
        {
            Tasks.Add(task);
        }

        public void ToggleTaskIsCompleted(int taskId)
        {
            ToDoTask task = Tasks.FirstOrDefault(task => task.Id == taskId);
            if (task != null)
            {
                task.IsComplete = !task.IsComplete;
            }
            else throw new Exception("the task with this id didn't found");
        }

        public void UpdateTask(int taskId, string newDescription)
        {
            ToDoTask taskToEdit = Tasks.FirstOrDefault(task => task.Id == taskId);
            if (taskToEdit != null)
            {
                taskToEdit.Description = newDescription;
            }
            else throw new Exception("the task with this id didn't found");
        }

        //properties
        //List of tasks - ObservableCollection

        //methods
        //Constructor
        //Update Task
        //ToggleTaskIsComplete
        //AddNewTask



    }
}
