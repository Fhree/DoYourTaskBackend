﻿using DYT.businessLogic.Status.Models;
using DYT.businessLogic.TypeTask.Models;

namespace DYT.businessLogic.Tasks.Models
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeTaskDTO Type { get; set; }
        public StatusDTO Status { get; set; }

    }
}
