using Infrastructure.Enums;

namespace Application.Models
{
    public class ContactSmallDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ContactCategory Category { get; set; }
        public string Subcategory { get; set; }
        public string Phone { get; set; }
    }
}