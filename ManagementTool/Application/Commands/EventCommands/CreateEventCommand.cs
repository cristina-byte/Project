using Domain.Entities;
using MediatR;

namespace Application.Commands.EventCommands
{
    public class CreateEventCommand : IRequest<Event>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
