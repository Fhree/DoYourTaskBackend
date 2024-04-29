using DYT.businessLogic.Status.Models;
using DYT.repository;
using MediatR;

namespace DYT.businessLogic.Status.Queries
{
    public record GetAllStatusQuery : IRequest<List<StatusDTO>> 
    {
        public List<StatusDTO> status { get; set; }
    }
    public class GetAllStatusQueryHandler : IRequestHandler<GetAllStatusQuery ,List<StatusDTO>>
    {
        private readonly IGenericRepository<infrastructure.Models.Status> _repository;

        public GetAllStatusQueryHandler(IGenericRepository<infrastructure.Models.Status> repository)
        {
            _repository = repository;
        }

        public async Task<List<StatusDTO>> Handle(GetAllStatusQuery request, CancellationToken cancellationToken)
        {
            var result = new List<StatusDTO>();
            _repository.GetAll().ToList().ForEach(status => 
            {
                result.Add(new StatusDTO 
                {
                    Id = status.Id,
                    Name = status.Name 
                });
            });
            return result;
        }
    }
}
