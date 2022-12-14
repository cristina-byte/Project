using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TeamEntities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public Team Team { get; set; }

        public ToDo( string name)
        {
            Name = name;
            Tasks=new List<Task>();
        }
    }
}
