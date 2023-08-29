using Application.Models;
using Infrastructure.Entities;

namespace Application.Services
{
    public interface IContactService
    {
        Task<Contact> AddNewContact(AddNewContactDto newContact);

        Task<bool> DeleteContatct(int id);

        Task<IEnumerable<ContactSmallDto>> GetAllContacts();

        Task<Contact> GetContactById(int id);

        Task<Contact> UpdateContact(Contact contact);
    }
}