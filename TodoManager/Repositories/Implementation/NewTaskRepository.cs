using TodoManager.Data;
using TodoManager.Models.Domain;
using TodoManager.Repositories.Interface;

namespace TodoManager.Repositories.Implementation
{
    public class NewTaskRepository : INewTaskRepository
    {
        private readonly ApplicationDbContext dbContext;
        public NewTaskRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<NewTask> CreateAsync(NewTask task)
        {
            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            return task;
        }
    }
}
