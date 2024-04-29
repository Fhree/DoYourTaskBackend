using DYT.repository;
using DYT.businessLogic.Status.Models;

namespace DYT.businessLogic.Status.Queries
{
    public interface IGetStatusQueryHandler 
    {
        public StatusDTO GetStatus(int id);
    }

    public class GetStatusQueryHandler : IGetStatusQueryHandler
    {
        private readonly IGenericRepository<infrastructure.Models.Status> _repository;

        public GetStatusQueryHandler(IGenericRepository<infrastructure.Models.Status> repository)
        {
            _repository = repository;
        }

        public StatusDTO GetStatus(int id)
        {
            var repoResult = _repository.Get(id);

            return new StatusDTO
            {
                Id = repoResult.Id,
                Name = repoResult.Name,
            };
        }


    }
}
