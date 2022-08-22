namespace Assigmment.Server.Database
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket {
                    Id = 1,
                    Title = "Ticket 1",
                    Description = "Description 1",
                    Created = DateTime.Now,
                    CreatedBy = "anonymouse",
                    Status = "TODO"
                },
                new Ticket {
                    Id = 2,
                    Title = "Ticket 2",
                    Description = "Description 2",
                    Created = DateTime.Now,
                    CreatedBy = "anonymouse",
                    Status = "WORKDONE"
                }
            );
            
            modelBuilder.Entity<WorkItem>().HasData(
                new WorkItem
                {
                    Id = 1,
                    ItemType = "LABOR",
                    UnitPrice = "USD",
                    Quantity = 0,
                    Created = new DateTime(),
                    CreatedBy = "anonymous",
                    TicketId = 1
                },
                new WorkItem
                {
                    Id = 2,
                    ItemType = "PART",
                    UnitPrice = "USD",
                    Quantity = 10,
                    Created = new DateTime(),
                    CreatedBy = "anonymous",
                    TicketId = 2
                }
            );
        }

        public DbSet<Ticket> TicketSet { get; set; }

        public DbSet<WorkItem> WorkItems { get; set; }
    }
}
