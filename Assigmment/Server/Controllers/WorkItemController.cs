using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigmment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        public static List<Ticket> tickets = new List<Ticket>
        {
            new Ticket {
                Id = 1, 
                Title = "Ticket 1", 
                Description = "", 
                Created = new DateTime(), 
                CreatedBy = "anonymouse", 
                Status = "TODO"
            }
        };

        public static List<WorkItem> workItems = new List<WorkItem>
        {
            new WorkItem {
                Id = 1,
                ItemType = "LABOR",
                UnitPrice = "USD",
                Quantity = 0,
                Created = new DateTime(),
                CreatedBy = "anonymous",
                Ticket = tickets[0]
            },
            new WorkItem { 
                Id = 2, 
                ItemType = "PART",
                UnitPrice = "USD",
                Quantity = 10, 
                Created = new DateTime(),
                CreatedBy = "anonymous",
                Ticket = tickets[0]
            },
        };

        [HttpGet]
        public async Task<ActionResult<List<WorkItem>>> GetWorkItems()
        {
            return Ok(workItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<WorkItem>>> GetWorkItem(int id)
        {
            var workItem = workItems.FirstOrDefault(w => w.Id == id);

            if (workItem == null)
            {
                return NotFound("It does not exist");
            }
            return Ok(workItem);
        }
    }
}
