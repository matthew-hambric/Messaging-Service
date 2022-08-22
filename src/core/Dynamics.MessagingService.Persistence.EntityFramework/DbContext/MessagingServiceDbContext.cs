using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Dynamics.MessagingService.Abtractions.Models;
using Dynamics.MessagingService.Abtractions.Services;

namespace Dynamics.MessagingService.Persistence.EntityFramework;

public class MessagingServiceDbContext : DbContext, IDbContext
{
    public MessagingServiceDbContext(DbContextOptions<MessagingServiceDbContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Contact> Contacts { get; set; }
}


