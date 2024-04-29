using DYT.businessLogic.TypeTask.Models;
using DYT.repository;
using MediatR;

namespace DYT.businessLogic.TypeTask.Queries
{
    public record GetAllTypeTaskQuery : IRequest<List<TypeTaskDTO>> 
    {
        public List<TypeTaskDTO> TypesTask { get; set; }
    }

    public class GetAllTypeTaskQueryHandler : IRequestHandler<GetAllTypeTaskQuery, List<TypeTaskDTO>>
    {
        private readonly IGenericRepository<infrastructure.Models.TypeTask> _repository;

        public GetAllTypeTaskQueryHandler(IGenericRepository<infrastructure.Models.TypeTask> repository)
        {
            _repository = repository;
        }

        public async Task<List<TypeTaskDTO>> Handle(GetAllTypeTaskQuery request, CancellationToken cancellationToken)
        {
            var result = new List<TypeTaskDTO>();
            _repository.GetAll().ToList().ForEach(typeTask => 
            {
                result.Add(new TypeTaskDTO 
                {
                    Id = typeTask.Id,
                    Name = typeTask.Name
                });
            });
            return result;
        }
    }
}
