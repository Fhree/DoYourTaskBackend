using DYT.businessLogic.TypeTask.Models;
using DYT.repository;

namespace DYT.businessLogic.TypeTask.Queries
{
    public interface IGetTypeTaskQueryHandler 
    {
        public TypeTaskDTO GetTypeTask(int id);
    }
    public class GetTypeTaskQueryHandler : IGetTypeTaskQueryHandler
    {
        private readonly IGenericRepository<infrastructure.Models.TypeTask> _repository;

        public GetTypeTaskQueryHandler(IGenericRepository<infrastructure.Models.TypeTask> repository)
        {
            _repository = repository;
        }

        public TypeTaskDTO GetTypeTask(int id)
        {
            var repoResult = _repository.Get(id);

            return new TypeTaskDTO 
            {
                Id = repoResult.Id,
                Name = repoResult.Name,
            };
        }
    }
}
