using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFT.Data;
using ProjectFT.Interfaces;
using ProjectFT.Models;


namespace ProjectFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {

        private ITaskRepository taskRepository;
        public TaskItemsController(ITaskRepository taskRepository) 
        {
            this.taskRepository= taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var taskItems = await taskRepository.GetAllTasks();
            if(taskItems == null) 
            {
                return NotFound();
            }

            return Ok(taskItems);
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            var taskItem = await taskRepository.GetTaskById(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return Ok(taskItem);    
             
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskItem taskItem)
        {
            var isAdded = await taskRepository.AddTask(taskItem);
            if (isAdded )
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest("Problem has occured");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] TaskItem taskItem)
        {
            var isUpdated = await taskRepository.UpdateTask(id, taskItem);
            if (isUpdated)
            {
                return Ok("Record has been updated");
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete (int id)
        {
            var isDeleted = await taskRepository.DeleteTask(id);
            if (isDeleted)
            {
                return Ok("Record has been deleted");
            }
            return BadRequest();
        }
    }
}
