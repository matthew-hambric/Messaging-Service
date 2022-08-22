using System.Threading.Tasks;
using System.Collections.Generic;
using Dynamics.MessagingService.Abtractions.Models;

namespace Dynamics.MessagingService.Abtractions.Services;

public interface IContactsService {

    public Task<IEnumerable<Contact>> GetContacts(GetContactsCommand command);

    public Task<Contact> GetContactById(GetContactByIdCommand command);

    public Task<string> CreateContact(CreateContactCommand command);

    public Task<string> UpdateContact(UpdateContactCommand command);

    public Task<string> DeleteContact(DeleteContactByIdCommand command);
}