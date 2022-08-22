using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Dynamics.MessagingService.Abtractions.Models;
using Dynamics.MessagingService.Abtractions.Services;
using Bogus;
using Bogus.DataSets;
using Be.Vlaanderen.Basisregisters.Generators.Guid;


namespace Dynamics.MessagingService.Persistence.EntityFramework;

public class SeededDbContext_TESTING : DbContext, IDbContext
{
    public SeededDbContext_TESTING(DbContextOptions<SeededDbContext_TESTING> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        var namespaceKey = Guid.NewGuid();

        var testingUser = new User()
        {
            Id = "1",
            FirstName = "George",
            LastName = "Washington",
            Phone = "5554443333",
            PhoneVerified = true
        };

        var fakeUsers = new Faker<User>()
            .RuleFor(u => u.Id, fake => Deterministic.Create(namespaceKey, Guid.NewGuid().ToString(), 3).ToString())
            .RuleFor(u => u.FirstName, fake => fake.Name.FirstName())
            .RuleFor(u => u.LastName, fake => fake.Name.LastName())
            .RuleFor(u => u.Phone, fake => fake.Phone.PhoneNumber())
            .RuleFor(u => u.PhoneVerified, fake => fake.Random.Bool(0.9f))
            .GenerateBetween(10, 10);

        fakeUsers.Add(testingUser);

        modelBuilder.Entity<User>().HasData(testingUser);

        modelBuilder.Entity<Message>().HasData(new Message()
        {
            Id = "0",
            OwnerId = "1",
            SequenceId = 0,
            To = "1231231234",
            From = "3213214321",
            Content = "Some Random Message"
        });

        base.OnModelCreating(modelBuilder);
    }
    
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Contact> Contacts { get; set; }
}