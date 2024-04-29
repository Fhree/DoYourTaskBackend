using DYT.repository;
using MediatR;

namespace DYT.businessLogic.Tasks.Commands
{
    public record CreateTaskCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand>
    {
        private readonly IGenericRepository<infrastructure.Models.Task> _repository;

        public CreateTaskCommandHandler(IGenericRepository<infrastructure.Models.Task> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(new infrastructure.Models.Task
            {
                Description = request.Description,
                Name = request.Name,
                StatusId = request.StatusId,
                TypeId = request.TypeId
            });
        }
    }
}
