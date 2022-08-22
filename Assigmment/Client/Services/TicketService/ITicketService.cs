namespace Assigmment.Client.Services.TicketService
{
    public interface ITicketService
    {
        List<Ticket> Tickets { get; set; }

        List<Ticket> DisplayTickets { get; set; }

        List<WorkItem> WorkItems { get; set; }

        string filter { get; set; }

        Task GetTickets();

        Task GetWorkItems();

        void SetFilter(string search);

    }
}
