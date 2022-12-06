using la_mia_pizzeria_static.Data;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbMessageRepository : IDbMessageRepository
    {
        private PizzeriaDbContext db;

        public DbMessageRepository(PizzeriaDbContext _db)
        {
            db = _db;
        }

        public void Create(Message message)
        {

            db.Messages.Add(message);
            db.SaveChanges();

        }
    }
}
