using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigmment.Shared
{
    public class WorkItem
    {
        public int Id { get; set; }

        public string ItemType { get; set; }

        public string UnitPrice { get; set; }

        public int Quantity { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public Ticket Ticket { get; set; }

        public int TicketId { get; set; }
    }
}
