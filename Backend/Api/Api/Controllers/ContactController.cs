using Api.Validators;
using Application.Models;
using Application.Services;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route(Route)]
    public class ContactController : Controller
    {
        public const string Route = "contact";
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("get-contact-list")]
        public async Task<IActionResult> ContactList()
        {
            return Ok(await _contactService.GetAllContacts());
        }

        [HttpPost("add-new-contact")]
        public async Task<IActionResult> AddNewContact([FromBody] AddNewContactDto contact)
        {
            ValidationResult validationResult = new AddNewContactValidation().Validate(contact);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(await _contactService.AddNewContact(contact));
        }

        [HttpPut("update-contact")]
        public async Task<IActionResult> UpdateContact([FromBody] Contact contact)
        {
            ValidationResult validationResult = new UpdateContactValidation().Validate(contact);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (await _contactService.GetContactById(contact.Id) is not null)
            {
                return BadRequest("Contact with this ID does not exist");
            }

            return Ok(await _contactService.UpdateContact(contact));
        }

        [HttpDelete("delete-contact/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (await _contactService.GetContactById(id) is not null)
            {
                return BadRequest("Contact with this ID does not exist");
            }

            return Ok(await _contactService.DeleteContatct(id));
        }
    }
}
