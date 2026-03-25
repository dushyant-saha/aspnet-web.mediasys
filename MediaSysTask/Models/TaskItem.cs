using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaSysTask.Models
{
    public class TaskItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Username { get; set; } // owner

        public string Title { get; set; }
        public string Description { get; set; }

        public string Status { get; set; } // Pending / Completed
        public string Priority { get; set; } // Low / Medium / High

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}