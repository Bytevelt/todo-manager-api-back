using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoManager.Data;
using TodoManager.Models.Domain;
using TodoManager.Models.DTO;

namespace TodoManager.Controllers
{
    // https://localhost:xxxx/api/tasks
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public TasksController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        //
        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskRequestDto request)
        {
            // Map DTO to Domain Model
            var task = new NewTask
            {
                priority = request.priority,
                description = request.description,
                dueDate = request.dueDate,
                createdTime = DateTime.Now,
                label = request.label,
                isVisible = request.isVisible
            };

            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            // Domain model to DTO
            var response = new TaskDto
            {
                id = task.id,
                priority = request.priority,
                description = request.description,
                dueDate = request.dueDate,
                createdTime = DateTime.Now,
                label = request.label,
                isVisible = request.isVisible
            };

            return Ok(response);
        }
    }
}
