using Infrastructure.Enums;

namespace Infrastructure.Entities
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ContactCategory Category { get; set; }
        public string Subcategory { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
