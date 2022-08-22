using System.Net.Http.Json;

namespace Assigmment.Client.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _http;

        public TicketService(HttpClient http)
        {
            this._http = http;
        }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public List<Ticket> DisplayTickets { get; set; } = new List<Ticket>();
        
        public List<WorkItem> WorkItems { get; set; } = new List<WorkItem>();

        public string filter { get; set; }  = "";

        public async Task GetTickets()
        {
            var results = await _http.GetFromJsonAsync<List<Ticket>>("api/tickets");
            if (results != null)
            {
                Tickets = results;
                DisplayTickets = results;
            }
        }

        public Task GetWorkItems()
        {
            throw new NotImplementedException();
        }

        public void SetFilter(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                filter = search;
                DisplayTickets = Tickets.Where(t => t.Id.ToString() == search || t.Title.Contains(search)).ToList<Ticket>();
            } else
            {
                filter = "";
                DisplayTickets = Tickets;
            }
        }

    }
}
