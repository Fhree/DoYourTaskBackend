using DYT.repository;
using MediatR;

namespace DYT.businessLogic.Tasks.Commands
{
    public record UpdateTaskCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
    }

    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IGenericRepository<infrastructure.Models.Task> _repository;

        public UpdateTaskCommandHandler(IGenericRepository<infrastructure.Models.Task> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = new infrastructure.Models.Task()
            {
                Description = request.Description,
                Id = request.Id,
                Name = request.Name,
                StatusId = request.StatusId,
                TypeId = request.TypeId
            };

            _repository.Update(entity);
        }
    }
}
