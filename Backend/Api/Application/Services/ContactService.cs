using Application.Common;
using Application.Models;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Contact> AddNewContact(AddNewContactDto newContact)
        {
            var contact = _mapper.Map<Contact>(newContact);
            contact.Password = StringToSHA.ConvertToSHA(contact.Password);

            var result =  await _contactRepository.Add(contact);
            await _contactRepository.SaveChanges();
            
            return result;
        }

        public async Task<IEnumerable<ContactSmallDto>> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAll();
            return _mapper.Map<IEnumerable<ContactSmallDto>>(contacts);
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _contactRepository.GetById(id);
        }

        public Task<Contact> UpdateContact(Contact contact)
        {
            contact.Password = StringToSHA.ConvertToSHA(contact.Password);
            var editedContact = _contactRepository.Update(contact);

            _contactRepository.SaveChanges();
            return Task.FromResult(editedContact);
        }

        public async Task<bool> DeleteContatct(int id)
        {
            var contact = await _contactRepository.GetById(id);
            _contactRepository.Delete(contact);
            await _contactRepository.SaveChanges();
            return true;
        }
    }
}
