using Microsoft.EntityFrameworkCore;
using ProjectFT.Data;
using ProjectFT.Interfaces;
using ProjectFT.Models;

namespace ProjectFT.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private ApiDbContext dbContext;
        public TaskRepository(ApiDbContext dbContext)


        {
            this.dbContext = dbContext;
        }
        public async Task<bool> AddTask(TaskItem item)
        {
            try
            {
                await dbContext.TaskItems.AddAsync(item);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch 
            {

                return false;
            }
            
        }

        public async Task <bool>DeleteTask(int id)
        {
            try
            {
                var existingTaskItem = await dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id==id);
                if (existingTaskItem!=null)
                {
                    dbContext.TaskItems.Remove(existingTaskItem);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                return false;   
            }
            catch 
            {

                return false;
            }
            
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await dbContext.TaskItems.ToListAsync();
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            return await dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> UpdateTask(int id, TaskItem item)
        {
            try
            {
                var existingTaskItem = await dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
                if (existingTaskItem!=null)
                {
                    existingTaskItem.Title = item.Title;
                    existingTaskItem.Description = item.Description;
                    await dbContext.SaveChangesAsync();
                    return  false;
                }
                else {return false;}    
            }
            catch 
            {

                return false;
            }
            
        }
    }
}
