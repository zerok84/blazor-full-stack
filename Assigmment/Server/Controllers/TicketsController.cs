using Assigmment.Server.Database;
using Assigmment.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigmment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DataContext _context;
        public TicketsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetTickets()
        {
            var tickets = await _context.TicketSet.ToListAsync();
            return Ok(tickets);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<Ticket>> CreateTicket([FromBody] Ticket ticket)
        {
            await _context.TicketSet.AddAsync(ticket);
            _context.SaveChanges();

            return Ok("Created");
        }
    }
}
