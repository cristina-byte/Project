using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.MeetingQueries
{
    public class GetMeetingsHandler : IRequestHandler<GetMeetingsQuery, IEnumerable<Meeting>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMeetingsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Meeting>> Handle(GetMeetingsQuery request, CancellationToken cancellationToken)
        {
            var meetings = await _unitOfWork.MeetingRepository.GetAllAsync(request.UserId);
            return meetings;
        }
    }
}
