using Dynamics.MessagingService.Abtractions.Services;
using Dynamics.MessagingService.Abtractions.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Dynamics.MessagingService.Core.Services;

public class ContactsService: IContactsService {
    private readonly IUserContextService _userContextService;
    private readonly ILogger<ContactsService> _logger;
    private readonly IDbContext _dbContext;

    public ContactsService(
        IUserContextService userContextService,
        ILogger<ContactsService> logger,
        IDbContext dbContext
    ){
        _userContextService = userContextService;
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Contact>> GetContacts(GetContactsCommand command){
        var userId = await _userContextService.GetCurrentUserId();

        IQueryable<Contact> contacts = _dbContext.Contacts
            .Where(c => c.OwnerId == userId && command.LastEvaluatedKey.CompareTo(c.Id) > 0)
            .OrderBy(m => m.Id)
            .Take(command.PageSize);

        return await contacts.ToListAsync();
    }

    public async Task<Contact> GetContactById(GetContactByIdCommand command){
        var userId = await _userContextService.GetCurrentUserId();

        var contact = await _dbContext.Contacts.FindAsync(command.Id);
        return contact.OwnerId == userId ? contact : null;
    }

    public async Task<string> CreateContact(CreateContactCommand command){
        var userId = await _userContextService.GetCurrentUserId();

        var contact = new Contact()
        {
            OwnerId = userId,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Phone = command.Phone
        };

        _dbContext.Contacts.Add(contact);
        await _dbContext.SaveChangesAsync();

        return contact.Id;
    }

    public async Task<string> UpdateContact(UpdateContactCommand command){
        var userId = await _userContextService.GetCurrentUserId();

        var contact = await _dbContext.Contacts.FindAsync(command.Id);

        if (contact == null)
        {
            return null;
        }
        else{
            contact.FirstName = command.FirstName;
            contact.LastName = command.LastName;
            contact.Phone = command.Phone;

            await _dbContext.SaveChangesAsync();

            return contact.Id;
        }
    }

    public async Task<string> DeleteContact(DeleteContactByIdCommand command){
        var userId = await _userContextService.GetCurrentUserId();

        var contact = await _dbContext.Contacts.Where(c => c.Id == command.Id).FirstOrDefaultAsync();
        if (contact == null) return null;

        _dbContext.Contacts.Remove(contact);
        await _dbContext.SaveChangesAsync();
        return contact.Id;
    }
}