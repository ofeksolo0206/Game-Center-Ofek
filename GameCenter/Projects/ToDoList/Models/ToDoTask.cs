using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Projects.ToDoList
{
    internal class ToDoTask
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete;
        public DateTime CreatedDateTime;

        public ToDoTask(string id, string description)
        {
            Id = id;
            Description = description;
            IsComplete = true;
            CreatedDateTime = DateTime.Now;
        }
    }
}