using DYT.businessLogic.Status.Models;
using DYT.businessLogic.Tasks.Models;
using DYT.businessLogic.TypeTask.Models;
using DYT.infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DYT.businessLogic.Tasks.Queries
{
    public interface IGetAllTasksQueryHandler 
    {
        public List<TaskDTO> GetAllTasks();
    }

    public class GetAllTasksQueryHandler : IGetAllTasksQueryHandler
    {
        private DoYourTaskDBContext _dbContext;

        public GetAllTasksQueryHandler(DoYourTaskDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TaskDTO> GetAllTasks() 
        {
            List<TaskDTO> taskDTOs = new List<TaskDTO>();

            List<infrastructure.Models.Task> tasks = new List<infrastructure.Models.Task>();

            tasks = _dbContext.Tasks.Include(task => task.Status).Include(task => task.Type).ToList();

            tasks.ForEach(task =>
            {
                taskDTOs.Add(new TaskDTO
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Status = new StatusDTO
                    {
                        Id = task.Status.Id,
                        Name = task.Status.Name
                    },
                    Type = new TypeTaskDTO
                    {
                        Id = task.Type.Id,
                        Name = task.Type.Name
                    }
                });

            });
            return taskDTOs;
        }
    }
}
