using MediatR;

namespace Application.Features.Disasters.Commands.Create;

//Alacağım bilgi

public class CreateDisasterCommand:IRequest<CreatedDisasterResponse> // IRequest<TResponse>
{
    public string Name { get; set; }
    
    
    public class CreateDisasterCommandHandler : IRequestHandler<CreateDisasterCommand, CreatedDisasterResponse>
    {
        public Task<CreatedDisasterResponse>? Handle(CreateDisasterCommand request, CancellationToken cancellationToken)
        {
            CreatedDisasterResponse createdDisasterResponse = new CreatedDisasterResponse();
            createdDisasterResponse.Name = request.Name;
            createdDisasterResponse.Id = new Guid();
            return Task.FromResult(createdDisasterResponse);
            
        }
    }
}
