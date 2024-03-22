using System.ComponentModel;
using TodoManager.Models.Domain;

namespace TodoManager.Repositories.Interface
{
    public interface INewTaskRepository
    {
        Task<NewTask> CreateAsync(NewTask task);
    }
}
