using Infrastructure.DataAccess;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactDbContext dbContext) : base(dbContext)
        {
        }
    }
}