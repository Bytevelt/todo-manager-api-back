using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoManager.Data;
using TodoManager.Models.Domain;
using TodoManager.Models.DTO;
using TodoManager.Repositories.Interface;

namespace TodoManager.Controllers
{
    // https://localhost:xxxx/api/tasks
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly INewTaskRepository newTaskRepository;
        public TasksController(INewTaskRepository taskRepository) 
        {
            this.newTaskRepository = taskRepository;
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

            await newTaskRepository.CreateAsync(task);


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
