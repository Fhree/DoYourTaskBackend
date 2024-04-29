using DYT.businessLogic.Status.Queries;
using DYT.businessLogic.Tasks.Models;
using DYT.businessLogic.TypeTask.Queries;
using DYT.repository;

namespace DYT.businessLogic.Tasks.Queries
{
    public interface IGetTaskQueryHandler 
    {
        public TaskDTO GetTask(int id);
    }
    public class GetTaskQueryHandler : IGetTaskQueryHandler
    {
        private readonly IGenericRepository<infrastructure.Models.Task> _repository;
        private readonly IGetStatusQueryHandler _getStatusQueryHandler;
        private readonly IGetTypeTaskQueryHandler _getTypeTaskQueryHandler;

        public GetTaskQueryHandler(IGenericRepository<infrastructure.Models.Task> repository,
            IGetStatusQueryHandler getStatusQueryHandler,
            IGetTypeTaskQueryHandler getTypeTaskQueryHandler) 
        { 
            _repository = repository; 
            _getStatusQueryHandler = getStatusQueryHandler;
            _getTypeTaskQueryHandler = getTypeTaskQueryHandler;
        }

        public TaskDTO GetTask(int id)
        {
            var repoResult = _repository.Get(id, i => i.Status, i => i.Type);
            
            if (repoResult == null)
                return null;

            var task = new TaskDTO 
            {
                Description = repoResult.Description,
                Id = repoResult.Id,
                Name = repoResult.Name,
                Status = _getStatusQueryHandler.GetStatus(repoResult.StatusId),
                Type = _getTypeTaskQueryHandler.GetTypeTask(repoResult.TypeId)
            };

            return task;
        }
    }
}
