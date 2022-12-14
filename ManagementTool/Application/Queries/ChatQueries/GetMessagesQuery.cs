using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ChatQueries
{
    public class GetMessagesQuery:IRequest<IEnumerable<Message>>
    {
        public int ChatId { get; set; }
    }
}
