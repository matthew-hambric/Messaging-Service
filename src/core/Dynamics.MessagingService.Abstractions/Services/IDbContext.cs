using Dynamics.MessagingService.Abtractions.Models;
using Microsoft.EntityFrameworkCore;

namespace Dynamics.MessagingService.Abtractions.Services;

public interface IDbContext {
    public DbSet<Message> Messages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}