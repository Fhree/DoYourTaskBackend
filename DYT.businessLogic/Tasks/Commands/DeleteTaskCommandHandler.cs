using DYT.repository;
using MediatR;

namespace DYT.businessLogic.Tasks.Commands
{
    public record DeleteTaskCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IGenericRepository<infrastructure.Models.Task> _repository;

        public DeleteTaskCommandHandler(IGenericRepository<infrastructure.Models.Task> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
        }
    }
}
