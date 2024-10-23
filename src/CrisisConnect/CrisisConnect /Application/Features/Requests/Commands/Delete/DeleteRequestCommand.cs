    using Application.Services.Repositories;
    using AutoMapper;
    using Domain.Entities;
    using MediatR;

    namespace Application.Features.Requests.Commands.Delete;

    public class DeleteRequestCommand : IRequest<DeletedRequestResponse>
    {
    public Guid Id { get; set; }

    public class UpdateRequestCommandHandler : IRequestHandler<DeleteRequestCommand, DeletedRequestResponse>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public UpdateRequestCommandHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<DeletedRequestResponse> Handle(DeleteRequestCommand request,
            CancellationToken cancellationToken)
        {
            Request? requestEntity = await _requestRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);

            await _requestRepository.UpdateAsync(requestEntity);

            DeletedRequestResponse response = _mapper.Map<DeletedRequestResponse>(request);
            return response;
        }
    }
    }