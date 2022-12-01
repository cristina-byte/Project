﻿using Task = Domain.Entities.TeamEntities.Task;

namespace Application.Abstraction
{
    public interface ITaskRepository
    {
        public void Create(Task task);
        public void Update(int id, Task task);
        public Task Delete(int id);
        public IEnumerable<Task> GetAll();
    }
}
